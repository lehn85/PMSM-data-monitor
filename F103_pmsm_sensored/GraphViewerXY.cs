using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace F103_pmsm_sensored
{
    public partial class GraphViewerXY : Form
    {
        private Color[] colorList = new Color[]
        {
            Color.Blue,Color.Red,Color.Green,Color.Black,Color.Violet
        };

        public MainWindow mainWindow { get; set; }

        private static int _ID = 0;
        public int VarID { get; private set; }
        public string GraphName { get; set; }

        private double _timeRange = 200;
        public double TimeRange
        {
            get
            {
                return _timeRange;
            }
            set
            {
                _timeRange = value;
            }
        }

        private double _Xmin = -40000;
        public double Xmin
        {
            get
            {
                return _Xmin;
            }
            set
            {
                _Xmin = value;
            }
        }

        private double _Xmax = 40000;
        public double Xmax
        {
            get
            {
                return _Xmax;
            }
            set
            {
                _Xmax = value;
            }
        }

        private double _Ymin = -40000;
        public double Ymin
        {
            get
            {
                return _Ymin;
            }
            set
            {
                _Ymin = value;
            }
        }

        private double _Ymax = 40000;
        public double Ymax
        {
            get
            {
                return _Ymax;
            }
            set
            {
                _Ymax = value;
            }
        }

        private bool _swapXY = true;
        public bool SwapXY
        {
            get
            {
                return _swapXY;
            }
            set
            {
                _swapXY = value;
            }
        }

        public GraphViewerXY()
        {
            InitializeComponent();
            VarID = _ID++;
        }

        private void GraphViewer_Load(object sender, EventArgs e)
        {
            tb_TimeRange.Text = TimeRange.ToString();
            tb_Xmin.Text = Xmin.ToString();
            tb_Xmax.Text = Xmax.ToString();
            tb_Ymin.Text = Ymin.ToString();
            tb_Ymax.Text = Ymax.ToString();
            chbox_swapXY.Checked = SwapXY;            
        }

        public void setData(string nameX, string nameY, IEnumerable<double> xvalues, IEnumerable<double> yvalues)
        {
            string name = (!SwapXY) ? (nameX + "," + nameY) : (nameY + "," + nameX);

            zc1.GraphPane.CurveList.Clear();

            PointPairList ppl = (!SwapXY) ?
                new PointPairList(xvalues.ToArray(), yvalues.ToArray()) :
                new PointPairList(yvalues.ToArray(), xvalues.ToArray());

            zc1.GraphPane.Title.Text = name;
            zc1.GraphPane.AddCurve(name, ppl, Color.Red, SymbolType.None);

            double avg1 = xvalues.Average();
            double avg2 = yvalues.Average();
            string avgvalue = (!SwapXY) ? (avg1.ToString() + "," + avg2.ToString()) : (avg2.ToString() + "," + avg1.ToString());
            Text = "GraphViewerXY - " + name + " average=(" + avgvalue + ")";

            refreshDueToAxisChange();
        }

        private void refreshDueToAxisChange()
        {
            if (!chbox_autoYaxis.Checked)
            {
                if (!double.IsNaN(Xmin) && !double.IsNaN(Xmax) &&
                    !double.IsNaN(Ymin) && !double.IsNaN(Ymax))
                {
                    zc1.GraphPane.YAxis.Scale.Min = Ymin;
                    zc1.GraphPane.YAxis.Scale.Max = Ymax;
                    zc1.GraphPane.XAxis.Scale.Min = Xmin;
                    zc1.GraphPane.XAxis.Scale.Max = Xmax;
                }
            }
            else
            {
                zc1.GraphPane.XAxis.Scale.MinAuto = true;
                zc1.GraphPane.XAxis.Scale.MaxAuto = true;
                zc1.GraphPane.YAxis.Scale.MinAuto = true;
                zc1.GraphPane.YAxis.Scale.MaxAuto = true;
            }

            // overlay boundary
            zc1.GraphPane.GraphObjList.Clear();
            zc1.GraphPane.GraphObjList.Add(new LineObj(Color.Black, 0, zc1.GraphPane.YAxis.Scale.Min, 0, zc1.GraphPane.YAxis.Scale.Max));
            zc1.GraphPane.GraphObjList.Add(new EllipseObj(-32678, 32768, 65536, 65536, Color.Black, Color.Transparent));

            zc1.AxisChange();
            zc1.Invalidate();
        }

        private void chbox_autoYaxis_CheckedChanged(object sender, EventArgs e)
        {
            refreshDueToAxisChange();
        }

        private void tb_XYminmax_TextChanged(object sender, EventArgs e)
        {
            if (sender == tb_Ymin)
            {
                double min = double.NaN;
                double.TryParse(tb_Ymin.Text, out min);
                Ymin = min;
            }
            else if (sender == tb_Ymax)
            {
                double max = double.NaN;
                double.TryParse(tb_Ymax.Text, out max);
                Ymax = max;
            }
            else if (sender == tb_Xmin)
            {
                double min = double.NaN;
                double.TryParse(tb_Xmin.Text, out min);
                Xmin = min;
            }
            else if (sender == tb_Xmax)
            {
                double max = double.NaN;
                double.TryParse(tb_Xmax.Text, out max);
                Xmax = max;
            }

            refreshDueToAxisChange();
        }

        private void tb_timeRange_TextChanged(object sender, EventArgs e)
        {
            double d = 200;
            double.TryParse(tb_TimeRange.Text, out d);
            TimeRange = d;
            mainWindow.updateGraphViewerData(this);
        }

        private void chbox_swapXY_CheckedChanged(object sender, EventArgs e)
        {
            SwapXY = chbox_swapXY.Checked;
            mainWindow.updateGraphViewerData(this);
        }
    }
}
