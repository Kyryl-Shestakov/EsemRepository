using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace esem_homework_sma_by_ks
{
    /// <summary>
    /// Interaction logic for MetricsVisualizationWindow.xaml
    /// </summary>
    public partial class MetricsVisualizationWindow : Window
    {
        MetricsContainer mc;
        public MetricsVisualizationWindow(MetricsContainer mc)
        {
            this.mc = mc;
            InitializeComponent();
            List<ListBoxItem> listBoxItemList = new List<ListBoxItem>();

            for(int i=0; i<mc.Metrics.Length; ++i) 
            {
                ListBoxItem lbi = new ListBoxItem();
                lbi.Content = mc.Metrics[i].Name;
                lbi.Selected += (sender, e) =>
                {
                    MetricChart.Title = mc.Metrics[MetricListBox.SelectedIndex].Name;
                    XLinearAxis.Minimum = mc.Metrics[MetricListBox.SelectedIndex].Intervals[0];
                    XLinearAxis.Maximum = mc.Metrics[MetricListBox.SelectedIndex].Intervals[mc.Metrics[MetricListBox.SelectedIndex].Intervals.Length-1];
                    ((ColumnSeries)MetricChart.Series[0]).ItemsSource = LoadMetricData(MetricListBox.SelectedIndex);

                };
                
                MetricListBox.Items.Add(lbi);
            }

            MetricListBox.SelectedIndex = 0;
        }

        private List<KeyValuePair<double, double>> LoadMetricData(int index)
        {
            List<KeyValuePair<double, double>> list = new List<KeyValuePair<double, double>>();

            for (int i = 0; i < mc.Metrics[index].Percentages.Length; ++i)
            {
                list.Add(new KeyValuePair<double, double>(Math.Round(mc.Metrics[index].Intervals[i + 1], 2), Math.Round(mc.Metrics[index].Percentages[i], 2)));
            }

            return list;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
        }
    }
}
