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
    public partial class GraphViewerYT : Form
    {
        private Color[] colorList = new Color[]
        {
            Color.Blue,Color.Red,Color.Green,Color.Black,Color.Violet
        };

        public MainWindow mainWindow { get; set; }

        private static int _ID = 0;
        public int VarID { get; private set; }
        public string GraphName { get; set; }

        private double _XaxisRange = 200;
        public double TimeAxisRange
        {
            get
            {
                return _XaxisRange;
            }
            set
            {
                _XaxisRange = value;
            }
        }

        private double _Ymin = -10000;
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

        private double _Ymax = 10000;
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

        public GraphViewerYT()
        {
            InitializeComponent();
            VarID = _ID++;
        }

        private void GraphViewer_Load(object sender, EventArgs e)
        {
            tb_XaxisRange.Text = TimeAxisRange.ToString();
            tb_Ymin.Text = Ymin.ToString();
            tb_Ymax.Text = Ymax.ToString();
        }

        public void setData(IDictionary<string, PointPairList> ppls)
        {
            Text = "GraphViewerYT - " + GraphName;
            zc1.GraphPane.Title.Text = GraphName;
            zc1.GraphPane.CurveList.Clear();

            if (ppls != null && ppls.Count() != 0)
            {
                int i = 0;
                foreach (var name in ppls.Keys)
                {
                    zc1.GraphPane.AddCurve(name, ppls[name], colorList[i], SymbolType.None);
                    i++;
                    if (i == colorList.Length)
                        i = 0;
                }
            }

            refreshDueToAxisChange();
        }

        private void refreshDueToAxisChange()
        {
            if (!chbox_autoYaxis.Checked)
            {
                double min = Ymin;
                double max = Ymax;
                if (!double.IsNaN(min) && !double.IsNaN(max))
                {
                    zc1.GraphPane.YAxis.Scale.Min = min;
                    zc1.GraphPane.YAxis.Scale.Max = max;
                }
            }
            else
            {
                zc1.GraphPane.YAxis.Scale.MinAuto = true;
                zc1.GraphPane.YAxis.Scale.MaxAuto = true;
            }

            zc1.AxisChange();
            zc1.Invalidate();
        }

        private void chbox_autoYaxis_CheckedChanged(object sender, EventArgs e)
        {
            refreshDueToAxisChange();
        }

        private void tb_Ymin_Ymax_TextChanged(object sender, EventArgs e)
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

            refreshDueToAxisChange();
        }

        private void tb_XaxisRange_TextChanged(object sender, EventArgs e)
        {
            double d = 200;
            double.TryParse(tb_XaxisRange.Text, out d);
            TimeAxisRange = d;
            mainWindow.updateGraphViewerData(this);
        }
    }
}
