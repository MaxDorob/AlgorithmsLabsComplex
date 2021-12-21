using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab3Visual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PlotModel model;

        public PlotModel Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (this.model != value)
                {
                    model = value;
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            
            //PlotView plot = new PlotView();
            //(Content as Viewbox).Child = plot;
            //model = new PlotModel();
            //plot.Model = model;
            //plot.Height = this.Height;
            //plot.Width = Width;
            model = new PlotModel();
            var l = new Legend
            {
                LegendPosition = LegendPosition.RightTop,
                LegendPlacement = LegendPlacement.Outside
            };
            model.Legends.Add(l);
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "t1" });
            plot1.Model = Model;
            //Draw(new double[] { 3,7,1});
        }
        public void Draw(double[] points)
        {

            model.Series.Clear();
            var ser = new LineSeries()
            { Title = "test" };
            int i = 1;
            ser.Points.AddRange( points.Select(x => new DataPoint(i++,x)).ToList());
            
            model.Series.Add(ser);
            model.InvalidatePlot(true);
            
        }
    }
}
