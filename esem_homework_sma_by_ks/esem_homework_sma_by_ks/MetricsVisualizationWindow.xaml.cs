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

        private void MetricListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = MetricListBox.SelectedIndex;
            MetricChart.Title = mc.Metrics[i].Name;
            ((ColumnSeries)MetricChart.Series[0]).ItemsSource = LoadMetricData(i);
            
            if (mc.Metrics[i].Intervals[0] < XLinearAxis.Maximum) 
            {
                XLinearAxis.Minimum = mc.Metrics[i].Intervals[0];
                XLinearAxis.Maximum = mc.Metrics[i].Intervals[mc.Metrics[i].Intervals.Length - 1] + (mc.Metrics[i].Intervals[1] - mc.Metrics[i].Intervals[0]);
            }
            else
            {
                XLinearAxis.Maximum = mc.Metrics[i].Intervals[mc.Metrics[i].Intervals.Length - 1] + (mc.Metrics[i].Intervals[1] - mc.Metrics[i].Intervals[0]);
                XLinearAxis.Minimum = mc.Metrics[i].Intervals[0];
            }
            
            XLinearAxis.Interval = mc.Metrics[i].Intervals[1] - mc.Metrics[i].Intervals[0];

            this.SampleMeanLabel.Content = Math.Round(mc.Metrics[i].SampleMean, 2);
            this.StandardDeviationLabel.Content = Math.Round(mc.Metrics[i].StandardDeviation, 2);
            this.VarianceLabel.Content = Math.Round(mc.Metrics[i].Variance, 2);
            this.KurtosisLabel.Content = Math.Round(mc.Metrics[i].Kurtosis, 2);
            this.SkewnessLabel.Content = Math.Round(mc.Metrics[i].Skewness, 2);
            NormalDistributionCheckBox.IsChecked = mc.Metrics[i].NormalDistributionFlag;
        }

        private void NormalDistributionCheckBox_Click(object sender, RoutedEventArgs e)
        {
            mc.Metrics[MetricListBox.SelectedIndex].NormalDistributionFlag = NormalDistributionCheckBox.IsChecked.Value;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            MetricsPairContainer mpc = ((MainWindow)this.Owner).mf.ObtainMetricsPairsContainer();
            MetricsPairsVisualizationWindow mpvw = new MetricsPairsVisualizationWindow(mpc);
            mpvw.Owner = this;
            this.Hide();
            mpvw.Show();
        }
    }
}
