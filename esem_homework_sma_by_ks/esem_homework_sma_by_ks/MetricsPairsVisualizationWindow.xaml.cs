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
    /// Interaction logic for MetricsPairsVisualizationWindow.xaml
    /// </summary>
    public partial class MetricsPairsVisualizationWindow : Window
    {
        MetricsPairContainer mpc;

        public MetricsPairsVisualizationWindow(MetricsPairContainer mpc)
        {
            this.mpc = mpc;
            InitializeComponent();
            
            List<ListBoxItem> listBoxItemList = new List<ListBoxItem>();

            for (int i = 0; i < mpc.MetricsPairs.Length; ++i)
            {
                ListBoxItem lbi = new ListBoxItem();
                lbi.Content = mpc.MetricsPairs[i].Name;
                MetricsPairsListBox.Items.Add(lbi);
            }

            MetricsPairsListBox.SelectedIndex = 0;
        }

        private List<KeyValuePair<double, double>> LoadMetricPairData(int index)
        {
            List<KeyValuePair<double, double>> list = new List<KeyValuePair<double, double>>();

            for (int i = 0; i < mpc.MetricsPairs[index].DirectMetric.Values.Length; ++i)
            {
                list.Add(new KeyValuePair<double, double>(Math.Round(mpc.MetricsPairs[index].DirectMetric.Values[i], 2), Math.Round(mpc.MetricsPairs[index].IndirectMetric.Values[i], 2)));
            }

            return list;
        }

        private void MetricsPairsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = MetricsPairsListBox.SelectedIndex;
            MetricPairChart.Title = mpc.MetricsPairs[i].Name;
            ((ScatterSeries)MetricPairChart.Series[0]).ItemsSource = LoadMetricPairData(i);

            double min = mpc.MetricsPairs[i].DirectMetric.Values.Min();

            if (min < XLinearAxis.Maximum)
            {
                XLinearAxis.Minimum = min;
                XLinearAxis.Maximum = mpc.MetricsPairs[i].DirectMetric.Values.Max();
            }
            else
            {
                XLinearAxis.Maximum = mpc.MetricsPairs[i].DirectMetric.Values.Max();
                XLinearAxis.Minimum = min;
            }

            XLinearAxis.Interval = mpc.MetricsPairs[i].DirectMetric.Intervals[1] - mpc.MetricsPairs[i].DirectMetric.Intervals[0];

            min = mpc.MetricsPairs[i].IndirectMetric.Values.Min();

            if (min < YLinearAxis.Maximum)
            {
                YLinearAxis.Minimum = min;
                YLinearAxis.Maximum = mpc.MetricsPairs[i].IndirectMetric.Values.Max();
            }
            else
            {
                YLinearAxis.Maximum = mpc.MetricsPairs[i].IndirectMetric.Values.Max();
                YLinearAxis.Minimum = min;
            }

            YLinearAxis.Interval = mpc.MetricsPairs[i].IndirectMetric.Intervals[1] - mpc.MetricsPairs[i].IndirectMetric.Intervals[0];

            this.CorrelationCoefficientLabel.Content = Math.Round(mpc.MetricsPairs[i].CorrelationCoefficient, 2);
        }
    }
}
