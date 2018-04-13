using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using OxyPlot;
using OxyPlot.Series;
using ZedGraph;
using System.Runtime.InteropServices;

namespace F103_pmsm_sensored
{
    public partial class MainWindow : Form
    {
        SerialPort sp;
        int totalPacket = 0;
        int totalError = 0;

        List<DataPacketNormal> list = new List<DataPacketNormal>();
        Thread thread;
        ManualResetEvent mre = new ManualResetEvent(false);
        System.Windows.Forms.Timer autoRefreshTimer;
        DataPacketVarInfo varinfo;

        List<TextBox> tb_minYaxis = new List<TextBox>();
        List<TextBox> tb_maxYaxis = new List<TextBox>();
        List<CheckBox> chbox_autoYaxis = new List<CheckBox>();

        Dictionary<GraphViewerYT, List<int>> graphviewersYT = new Dictionary<GraphViewerYT, List<int>>();
        Dictionary<GraphViewerXY, Point> graphviewersXY = new Dictionary<GraphViewerXY, Point>();

        public MainWindow()
        {
            InitializeComponent();

            bt_scan_ports_Click(null, null);

            tb_minYaxis.Add(tb_minY1);
            tb_minYaxis.Add(tb_minY2);
            tb_minYaxis.Add(tb_minY3);
            tb_minYaxis.Add(tb_minY4);

            tb_maxYaxis.Add(tb_maxY1);
            tb_maxYaxis.Add(tb_maxY2);
            tb_maxYaxis.Add(tb_maxY3);
            tb_maxYaxis.Add(tb_maxY4);

            chbox_autoYaxis.Add(chbox_autoYaxis1);
            chbox_autoYaxis.Add(chbox_autoYaxis2);
            chbox_autoYaxis.Add(chbox_autoYaxis3);
            chbox_autoYaxis.Add(chbox_autoYaxis4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            zc1.MasterPane.PaneList.Clear();

            for (int i = 0; i < DataPacketNormal.nVar100us; i++)
            {
                zc1.MasterPane.Add(new GraphPane());
            }

            using (Graphics g = CreateGraphics())
            {
                zc1.MasterPane.SetLayout(g, PaneLayout.SingleColumn);
            }

            autoRefreshTimer = new System.Windows.Forms.Timer();
            autoRefreshTimer.Interval = (int)nud_autorefreshinterval.Value;
            autoRefreshTimer.Tick += AutoRefreshTimer_Tick;

            refreshUI();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // stop refresh
            autoRefreshTimer.Stop();

            // close serial port
            bt_close_port_Click(null, null);
        }

        private void AutoRefreshTimer_Tick(object sender, EventArgs e)
        {
            bt_refresh_Click(null, null);
        }

        private void refreshUI()
        {
            bool serialPortOpened = sp != null && sp.IsOpen;
            // those are enabled when port doesn't open
            bt_scan_ports.Enabled = !serialPortOpened;
            bt_open_port.Enabled = !serialPortOpened && comboBox_com_ports.Items.Count > 0;

            // those are enable when port open
            bt_close_port.Enabled = serialPortOpened;
            bt_sendstart.Enabled = serialPortOpened;
            bt_sendstop.Enabled = serialPortOpened;
            bt_refresh.Enabled = serialPortOpened;
            chbox_autorefresh.Enabled = serialPortOpened;
            nud_autorefreshinterval.Enabled = serialPortOpened;
        }

        private void bt_scan_ports_Click(object sender, EventArgs e)
        {
            comboBox_com_ports.Items.Clear();
            comboBox_com_ports.Items.AddRange(SerialPort.GetPortNames());
            if (comboBox_com_ports.Items.Count > 0)
                comboBox_com_ports.SelectedIndex = 0;

            refreshUI();
        }

        private void bt_connect_Click(object sender, EventArgs e)
        {
            if (sp == null)
            {
                if (comboBox_com_ports.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select COM Port");
                    return;
                }

                string comport = comboBox_com_ports.SelectedItem.ToString();
                sp = new SerialPort(comport, 1152000, Parity.None, 8);
                sp.StopBits = StopBits.One;
                sp.ReadTimeout = 100;
                sp.WriteTimeout = 100;
            }

            if (!sp.IsOpen)
            {
                sp.Open();
                bt_sendstop_Click(null, null);
                Thread.Sleep(100);
                sp.DiscardInBuffer();
                Thread.Sleep(100);
                sendCmdGetVarInfo();
                Thread.Sleep(100);
                if (thread == null)
                {
                    thread = new Thread(loop_readSerial);
                    thread.IsBackground = true;
                    thread.Name = "SerialMonitor";
                    thread.Start();
                }
            }

            // update buttons state
            refreshUI();

            // check checkbox autorefresh and start timer autorefresh if needed
            chbox_autorefresh_CheckedChanged(null, null);
        }

        private void bt_close_port_Click(object sender, EventArgs e)
        {
            if (sp != null && sp.IsOpen)
            {
                // stop data
                bt_sendstop_Click(null, null);
                Thread.Sleep(100);
                // close port
                sp.Close();
                // finish thread
                if (thread != null)
                {
                    // wait for serial monitor thread to stop
                    thread.Join();
                    thread = null;
                }
            }

            refreshUI();
        }

        private Stopwatch sw = new Stopwatch();

        private void loop_readSerial()
        {
            int bufsize = 64000;
            byte[] b = new byte[bufsize];
            byte[] brem = new byte[bufsize];
            int rem = 0;
            int nPacket = 0;
            bool shouldQuit = false;

            try
            {
                while (!shouldQuit && sp != null && sp.IsOpen)
                {
                    Thread.Sleep(20);

                    sw.Reset();
                    sw.Start();

                    // read from device's buffer                                    
                    while (sp.BytesToRead > DataPacket.headerSize)
                    {
                        // try to read so that it fill buffer+remain bytes
                        if (rem > 0)
                            Buffer.BlockCopy(brem, 0, b, 0, rem);

                        int btr = sp.BytesToRead;
                        int r = btr > (bufsize - rem) ? (bufsize - rem) : btr;
                        int readbytes = 0;

                        readbytes = sp.Read(b, rem, r);

                        // start decode
                        int start = 0;
                        int endpos = rem + readbytes;
                        nPacket = 0; //number of packet for this buffer

                        //Debug.WriteLine("Rem={0}, Read={1}, endpos={2}", rem, readbytes, endpos);

                        // read from buffer
                        while (start < endpos)
                        {
                            // header
                            ushort sig = BitConverter.ToUInt16(b, start);
                            ushort size = BitConverter.ToUInt16(b, start + 2);
                            ushort type = BitConverter.ToUInt16(b, start + 4);
                            // <-- 2byte reserved not read
                            uint timestamp = BitConverter.ToUInt32(b, start + 8);

                            // Check signature, some communication error might happened
                            // sometime size is wrong
                            // if com error happened, search for next packet
                            if (sig != 0x1234 || (type != DataPacket.TYPE_NORMAL && type != DataPacket.TYPE_VARINFO))
                            {
                                //Debug.WriteLine("Signature at {0} is  incorrect, searching for next packet", start);
                                int t = start + 1;
                                bool found = false;
                                while (t < endpos - DataPacket.headerSize)
                                {
                                    if (b[t] == 0x34 && b[t + 1] == 0x12)
                                    {
                                        found = true;
                                        break;
                                    }
                                    t++;
                                }
                                if (found)
                                {
                                    start = t;
                                    //Debug.WriteLine("Found at {0}, Discard 1 packet", start);
                                    totalError++;
                                    continue;//restart loop with start point
                                }
                                else
                                {
                                    rem = endpos - start;
                                    //Debug.WriteLine("Not found signature, wait for new data");
                                    Buffer.BlockCopy(b, start, brem, 0, rem);
                                    break;
                                    //rem = 0;// discard remaining
                                    //Debug.WriteLine("Discard remain data, still looking for sig");
                                    //break; // data not whole, try again with new data
                                }
                            }

                            // check size just for sure
                            if (type == DataPacket.TYPE_NORMAL && size != DataPacketNormal.dataPacketSize)
                                throw new Exception("Data packet normal size seems not correct");

                            // check if datapacket is whole? if not, move data to begin and wait for break to wait for data
                            if (start + size > endpos)
                            {
                                // normally some bytes remain
                                rem = endpos - start;
                                Buffer.BlockCopy(b, start, brem, 0, rem);
                                //Debug.WriteLine("\tData not whole, save {0} bytes at location {1} for later", rem, start);
                                break;
                            }
                            else if (start + size == endpos)
                            {
                                // sometime no bytes remaining, set it = 0 or else data corrupt
                                //Debug.WriteLine("\tData is whole, no remaining");
                                rem = 0;
                            }

                            //Debug.WriteLine("\tDecode: start={0},size={1},timestamp={2}", start, size, timestamp);

                            // deserializing data

                            //move to data pos                            

                            if (type == DataPacket.TYPE_NORMAL)
                            {
                                DataPacketNormal d = new DataPacketNormal(sig, size, type, timestamp, start, ref b);

                                // add datapacket to list
                                lock (list)
                                {
                                    list.Add(d);
                                    if (list.Count > 10000)
                                        list.RemoveAt(0);
                                }
                                start += DataPacketNormal.dataPacketSize;
                            }
                            else if (type == DataPacket.TYPE_VARINFO)
                            {
                                varinfo = new DataPacketVarInfo(sig, size, type, timestamp, start, ref b);
                                start += size;
                            }

                            nPacket++;
                        } // loop decode from buffer

                        totalPacket += nPacket;

                        //Debug.WriteLine("nPacket={0},remain={1}", nPacket, sp.BytesToRead);

                        // don't stay in loop reading from device's buffer too long, 
                        // get a break in a while to wait for device's buffer being filled
                        if (sw.ElapsedMilliseconds > 2 && sp.BytesToRead < 1024)
                            break;
                    } // loop read from device's buffer                   

                    sw.Stop();

                    //if (nPacket > 0)
                    //    Debug.WriteLine("Stopwatch elapsed = " + sw.ElapsedTicks + " ticks");
                }
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException || ex is IOException)
                    Debug.WriteLine(ex.Message);
                else throw ex;
            }
            Debug.WriteLine("Total packet handled = {0}, error = {1}, error rate = {2}%", totalPacket, totalError, (double)totalError / totalPacket * 100);
        }

        private void sendCmdPacket(CmdPacket p)
        {
            byte[] bytes = p.toByteArray();

            sp.Write(bytes, 0, bytes.Length);
        }

        private void sendCmdGetVarInfo()
        {
            sendCmdPacket(new CmdPacket()
            {
                cmd = CmdPacket.CMD_GET_VARINFO
            });
        }

        private void bt_sendstart_Click(object sender, EventArgs e)
        {
            sendCmdPacket(new CmdPacket()
            {
                cmd = CmdPacket.CMD_START_SEND
            });
        }

        private void bt_sendstop_Click(object sender, EventArgs e)
        {
            sendCmdPacket(new CmdPacket()
            {
                cmd = CmdPacket.CMD_STOP_SEND
            });
        }

        private void bt_refresh_Click(object sender, EventArgs e)
        {
            if (list.Count == 0)
                return;

            for (int v = 0; v < DataPacketNormal.nVar100us; v++)
            {
                GraphPane gp = zc1.MasterPane[v];
                gp.CurveList.Clear();

                PointPairList ppl = new PointPairList();
                int maxc = (int)nud_numDataPoint.Value / (DataPacketNormal.data100usValuePointCount / 10);

                lock (list)
                {
                    int c = list.Count > maxc ? maxc : list.Count;
                    int x = 0;
                    for (int i = list.Count - c; i < list.Count; i++)
                    {
                        int nD = list[i].data[v].Count;
                        ppl.AddRange(
                            Enumerable.Range(0, nD)
                            .Select(k =>
                            new PointPair(
                                (double)(k + x) / 10,
                                list[i].data[v][k] * varinfo.multipliers_var100us[v]
                                )));
                        x += nD;
                    }
                }

                gp.AddCurve(varinfo.var100usNames[v], ppl, Color.Red, SymbolType.None);
            }

            refreshYaxisAuto();

            zc1.AxisChange();
            zc1.Invalidate();

            // refresh 2ms var
            lock (list)
            {
                dgv_data2ms.DataSource =
                Enumerable.Range(0, DataPacketNormal.nVar2ms)
                .Select(k => new
                {
                    Name = varinfo.var2msNames[k],
                    Value = list[list.Count - 1].data2ms[k]
                })
                .ToList();

                foreach (var gv in graphviewersYT.Keys)
                {
                    updateGraphViewerData(gv);
                }

                foreach (var gv in graphviewersXY.Keys)
                {
                    updateGraphViewerData(gv);
                }

            }

            Text = "F103C8T6 motor control, serial monitor: Received: " + totalPacket + "; Error: " + totalError;
        }

        private void chbox_autorefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (chbox_autorefresh.Checked)
            {
                autoRefreshTimer.Start();
            }
            else
            {
                autoRefreshTimer.Stop();
            }
        }

        private void nud_autorefreshinterval_ValueChanged(object sender, EventArgs e)
        {
            autoRefreshTimer.Interval = (int)nud_autorefreshinterval.Value;
        }

        private void bt_apply_Yaxis_Click(object sender, EventArgs e)
        {
            refreshYaxisAuto();
            zc1.AxisChange();
            zc1.Invalidate();
        }

        private void chbox_autoYaxis_CheckedChanged(object sender, EventArgs e)
        {
            refreshYaxisAuto();
            zc1.AxisChange();
            zc1.Invalidate();
        }

        private void refreshYaxisAuto()
        {
            for (int v = 0; v < DataPacketNormal.nVar100us; v++)
            {
                GraphPane gp = zc1.MasterPane[v];

                if (!chbox_autoYaxis[v].Checked)
                {
                    gp.YAxis.Scale.MaxAuto = false;
                    gp.YAxis.Scale.MinAuto = false;
                    int min = 0, max = 0;
                    bool ss = int.TryParse(tb_minYaxis[v].Text, out min);
                    ss = ss && int.TryParse(tb_maxYaxis[v].Text, out max);
                    if (ss)
                    {
                        gp.YAxis.Scale.Min = min;
                        gp.YAxis.Scale.Max = max;
                    }
                }
                else
                {
                    gp.YAxis.Scale.MaxAuto = true;
                    gp.YAxis.Scale.MinAuto = true;
                }
            }
        }

        private void bt_update_varinfo_Click(object sender, EventArgs e)
        {
            sendCmdGetVarInfo();
        }

        private void dgv_data2ms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_data2ms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int v = e.RowIndex;
            createNewGraphViewerYT(varinfo.var2msNames[v], new int[] { v });
        }

        private void createNewGraphViewerYT(string name, IEnumerable<int> listVarID)
        {
            GraphViewerYT g = new GraphViewerYT();
            g.mainWindow = this;
            g.GraphName = name;
            g.FormClosed +=
                (s, ee) =>
                {
                    graphviewersYT.Remove(g);
                };
            graphviewersYT[g] = listVarID.ToList();

            updateGraphViewerData(g);

            g.Show();
        }

        public void updateGraphViewerData(GraphViewerYT g)
        {
            int range = (int)(g.TimeAxisRange / 2);//axis range
            if (range > list.Count)
                range = list.Count;

            List<int> listVarId = graphviewersYT[g];

            Dictionary<string, PointPairList> ppls = new Dictionary<string, PointPairList>();
            foreach (var v in listVarId)
            {
                PointPairList ppl = new PointPairList();
                ppl.AddRange(Enumerable.Range(0, range)
                    .Select(i => new PointPair(i * 2, list[list.Count - range + i].data2ms[v] * varinfo.multipliers_var2ms[v])));
                ppls[varinfo.var2msNames[v]] = ppl;
            }

            g.setData(ppls);
        }

        private void createNewGraphViewerXY(string name, int v1, int v2)
        {
            GraphViewerXY g = new GraphViewerXY();
            g.mainWindow = this;
            g.GraphName = name;
            g.FormClosed +=
                (s, ee) =>
                {
                    graphviewersXY.Remove(g);
                };
            graphviewersXY[g] = new Point(v1, v2);

            updateGraphViewerData(g);

            g.Show();
        }

        public void updateGraphViewerData(GraphViewerXY g)
        {
            int range = (int)(g.TimeRange / 2);//axis range
            if (range > list.Count)
                range = list.Count;

            int v1 = graphviewersXY[g].X;
            int v2 = graphviewersXY[g].Y;

            g.setData(varinfo.var2msNames[v1], varinfo.var2msNames[v2],
                Enumerable.Range(0, range)
                    .Select(i => list[list.Count - range + i].data2ms[v1] * varinfo.multipliers_var2ms[v1]),
                Enumerable.Range(0, range)
                    .Select(i => list[list.Count - range + i].data2ms[v2] * varinfo.multipliers_var2ms[v2]));
        }

        private void bt_varinfo_acquire_Click(object sender, EventArgs e)
        {
            sendCmdGetVarInfo();
        }

        private void bt_view_graph_time_Click(object sender, EventArgs e)
        {
            var srs = dgv_data2ms.SelectedRows;
            string name = "";
            List<int> listVarId = new List<int>();
            foreach (DataGridViewRow r in srs)
            {
                name = name + varinfo.var2msNames[r.Index] + ";";
                listVarId.Add(r.Index);
            }

            createNewGraphViewerYT(name, listVarId);
        }

        private void bt_view_graph_XY_Click(object sender, EventArgs e)
        {
            var srs = dgv_data2ms.SelectedRows;
            if (srs.Count != 2)
            {
                MessageBox.Show("Must select 2 variables");
                return;
            }

            string name = "";
            List<int> listVarId = new List<int>();
            foreach (DataGridViewRow r in srs)
            {
                name = name + varinfo.var2msNames[r.Index] + ";";
                listVarId.Add(r.Index);
            }

            createNewGraphViewerXY(name, listVarId[0], listVarId[1]);
        }

        private void chbox_enable_set_speed_CheckedChanged(object sender, EventArgs e)
        {
            tb_set_speed.Enabled = chbox_enable_set_speed.Checked;
            bt_set_speed.Enabled = chbox_enable_set_speed.Checked;
            if (!chbox_enable_set_speed.Checked)
            {
                sendCmdPacket(new CmdPacket()
                {
                    cmd = CmdPacket.CMD_SET_VAR_VALUE,
                    cmd2 = CmdPacket.CMD2_SET_VAR_SPEED,
                    d1 = 0,
                    d2 = 0,
                });
            }
        }

        private void bt_set_speed_Click(object sender, EventArgs e)
        {
            double v = 0;
            bool b = double.TryParse(tb_set_speed.Text, out v);
            if (!b || v < -1 || v > 1)
            {
                MessageBox.Show("Number must be real number from -1 to 1");
                return;
            }

            short vint = (short)(32768 * v);
            sendCmdPacket(new CmdPacket()
            {
                cmd = CmdPacket.CMD_SET_VAR_VALUE,
                cmd2 = CmdPacket.CMD2_SET_VAR_SPEED,
                d1 = 1,
                d2 = vint
            });
        }
    }

    /// <summary>
    /// Packet as command to uP
    /// </summary>
    [Serializable]
    public class CmdPacket
    {
        public const int CMD_START_SEND = 1;
        public const int CMD_STOP_SEND = 2;
        public const int CMD_GET_VARINFO = 3;
        public const int CMD_SET_VAR_VALUE = 4;

        public const int CMD2_SET_VAR_SPEED = 1;

        public ushort cmd;
        public ushort cmd2;
        public short d1;
        public short d2;

        public byte[] toByteArray()
        {
            byte[] b1 = BitConverter.GetBytes(cmd);
            byte[] b2 = BitConverter.GetBytes(cmd2);
            byte[] b3 = BitConverter.GetBytes(d1);
            byte[] b4 = BitConverter.GetBytes(d2);
            return new byte[] { b1[0], b1[1], b2[0], b2[1], b3[0], b3[1], b4[0], b4[1] };
        }
    }

    /// <summary>
    /// Base data packet, contains only header
    /// </summary>
    public class DataPacket
    {
        public static readonly int headerSize = 12;

        public static readonly int TYPE_NORMAL = 1;
        public static readonly int TYPE_VARINFO = 2;

        public ushort sig;
        public ushort size;
        public ushort type;
        public ushort reserved;
        public uint timestamp;
    }

    /// <summary>
    /// Data packet of working state. Includes 100us-interval data and 2ms-interval data    
    /// </summary>
    public class DataPacketNormal : DataPacket
    {
        public static readonly int dataSize = 2;

        public static readonly int data100usValuePointCount = 20;//1 packet has .. value point for each var
        public static readonly int nVar100us = 4; // number of var 100us

        public static readonly int data2msValuePointCount = 1;//1 packet has one value point for each var
        public static readonly int nVar2ms = 20; // number of var 2ms

        public static readonly int Data100usSize = nVar100us * dataSize * data100usValuePointCount;
        public static readonly int Data2msSize = nVar2ms * dataSize * data2msValuePointCount;

        public static readonly int dataPacketSize = headerSize + Data100usSize + Data2msSize;//should be equal to size

        public List<List<short>> data = new List<List<short>>();
        public List<short> data2ms = new List<short>();

        /// <summary>
        /// Constructor from raw data
        /// </summary>
        /// <param name="sig"></param>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <param name="timestamp"></param>
        /// <param name="start"></param>
        /// <param name="b"></param>
        public DataPacketNormal(ushort sig, ushort size, ushort type, uint timestamp, int start, ref byte[] b)
        {
            this.sig = sig;
            this.size = size;
            this.type = type;
            this.timestamp = timestamp;

            start += headerSize;//move to data pos

            // get 100us data
            for (int k = 0; k < nVar100us; k++)
            {
                List<short> l = new List<short>();
                // data list for this var
                for (int i = 0; i < data100usValuePointCount; i++)
                {
                    l.Add(BitConverter.ToInt16(b, start + i * dataSize));
                }
                data.Add(l);
                start += data100usValuePointCount * dataSize;
            }

            // get 2ms data
            for (int k = 0; k < nVar2ms; k++)
                data2ms.Add(BitConverter.ToInt16(b, start + k * dataSize));
        }
    }

    /// <summary>
    /// Data packet of variable information
    /// </summary>
    public class DataPacketVarInfo : DataPacket
    {
        public static readonly int varNameBufSize = 500;
        public static readonly int multipliersCount = DataPacketNormal.nVar2ms + DataPacketNormal.nVar100us;

        public List<string> var100usNames = new List<string>();
        public List<string> var2msNames = new List<string>();
        public List<double> multipliers_var100us = new List<double>();
        public List<double> multipliers_var2ms = new List<double>();

        public DataPacketVarInfo(ushort sig, ushort size, ushort type, uint timestamp, int start, ref byte[] b)
        {
            this.sig = sig;
            this.size = size;
            this.type = type;
            this.timestamp = timestamp;

            start += headerSize;//move to data pos

            string s = Encoding.ASCII.GetString(b, start, varNameBufSize);
            string[] ss = s.Split(new char[] { ',', '\0' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < DataPacketNormal.nVar100us; i++)
            {
                if (i < ss.Length)
                    var100usNames.Add(ss[i]);
                else var100usNames.Add("Data " + i);
            }
            for (int i = 0; i < DataPacketNormal.nVar2ms; i++)
            {
                int k = DataPacketNormal.nVar100us + i;
                if (k < ss.Length)
                    var2msNames.Add(ss[k]);
                else var2msNames.Add("Var " + i);
            }

            start += varNameBufSize;

            for (int i = 0; i < DataPacketNormal.nVar100us; i++)
            {
                multipliers_var100us.Add(BitConverter.ToSingle(b, start + i * 4));
            }

            start += DataPacketNormal.nVar100us * 4;

            for (int i = 0; i < DataPacketNormal.nVar2ms; i++)
            {
                multipliers_var2ms.Add(BitConverter.ToSingle(b, start + i * 4));
            }
        }
    }
}
