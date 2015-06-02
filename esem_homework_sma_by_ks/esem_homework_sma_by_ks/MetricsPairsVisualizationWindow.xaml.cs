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
            this.BestLineFitResultLabel.Content = "";
            ((LineSeries)MetricPairChart.Series[1]).ItemsSource = null;
            ((LineSeries)MetricPairChart.Series[2]).ItemsSource = null;
            ((LineSeries)MetricPairChart.Series[3]).ItemsSource = null;

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

        private void LinearPlottingButton_Click(object sender, RoutedEventArgs e)
        {
            double flc;

            if (!double.TryParse(this.FirstLinearCoefficientTextBox.Text, out flc))
            {
                MessageBox.Show("First linear coefficient is incorrect");
                return;
            }

            double slc;

            if (!double.TryParse(this.SecondLinearCoefficientTextBox.Text, out slc))
            {
                MessageBox.Show("Second linear coefficient is incorrect");
                return;
            }

            mpc.MetricsPairs[this.MetricsPairsListBox.SelectedIndex].setLinearCoefficients(flc, slc);

            ((LineSeries)MetricPairChart.Series[1]).ItemsSource = LoadLinearMetricPairData(MetricsPairsListBox.SelectedIndex);
        }

        private void LogarithmicPlottingButton_Click(object sender, RoutedEventArgs e)
        {
            double flc;

            if (!double.TryParse(this.FirstLogarithmicCoefficientTextBox.Text, out flc))
            {
                MessageBox.Show("First logarithmic coefficient is incorrect");
                return;
            }

            double slc;

            if (!double.TryParse(this.SecondLogarithmicCoefficientTextBox.Text, out slc))
            {
                MessageBox.Show("Second logarithmic coefficient is incorrect");
                return;
            }

            mpc.MetricsPairs[this.MetricsPairsListBox.SelectedIndex].setLogarithmicCoefficients(flc, slc);

            ((LineSeries)MetricPairChart.Series[2]).ItemsSource = LoadLogarithmicMetricPairData(MetricsPairsListBox.SelectedIndex);
        }

        private void PolynomialPlottingButton_Click(object sender, RoutedEventArgs e)
        {
            double fpc;

            if (!double.TryParse(this.FirstPolynomialCoefficientTextBox.Text, out fpc))
            {
                MessageBox.Show("First polynomial coefficient is incorrect");
                return;
            }

            double spc;

            if (!double.TryParse(this.SecondPolynomialCoefficientTextBox.Text, out spc))
            {
                MessageBox.Show("Second polynomial coefficient is incorrect");
                return;
            }

            double tpc;

            if (!double.TryParse(this.ThirdPolynomialCoefficientTextBox.Text, out tpc))
            {
                MessageBox.Show("Third polynomial coefficient is incorrect");
                return;
            }

            mpc.MetricsPairs[this.MetricsPairsListBox.SelectedIndex].setPolynomialCoefficients(fpc, spc, tpc);

            ((LineSeries)MetricPairChart.Series[3]).ItemsSource = LoadPolynomialMetricPairData(MetricsPairsListBox.SelectedIndex);
        }

        private List<KeyValuePair<double, double>> LoadLinearMetricPairData(int index)
        {
            List<KeyValuePair<double, double>> list = new List<KeyValuePair<double, double>>();

            for (int i = 0; i < mpc.MetricsPairs[index].DirectMetric.Values.Length; ++i)
            {
                list.Add(new KeyValuePair<double, double>(Math.Round(mpc.MetricsPairs[index].DirectMetric.Values[i], 2), Math.Round(mpc.MetricsPairs[index].LinearValues[i], 2)));
            }

            return list;
        }

        private List<KeyValuePair<double, double>> LoadLogarithmicMetricPairData(int index)
        {
            List<KeyValuePair<double, double>> list = new List<KeyValuePair<double, double>>();

            for (int i = 0; i < mpc.MetricsPairs[index].DirectMetric.Values.Length; ++i)
            {
                list.Add(new KeyValuePair<double, double>(Math.Round(mpc.MetricsPairs[index].DirectMetric.Values[i], 2), Math.Round(mpc.MetricsPairs[index].LogarithmicValues[i], 2)));
            }

            return list;
        }

        private List<KeyValuePair<double, double>> LoadPolynomialMetricPairData(int index)
        {
            List<KeyValuePair<double, double>> list = new List<KeyValuePair<double, double>>();

            for (int i = 0; i < mpc.MetricsPairs[index].DirectMetric.Values.Length; ++i)
            {
                list.Add(new KeyValuePair<double, double>(Math.Round(mpc.MetricsPairs[index].DirectMetric.Values[i], 2), Math.Round(mpc.MetricsPairs[index].PolynomialValues[i], 2)));
            }

            return list;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        private void BestLineFitDeterminationButton_Click(object sender, RoutedEventArgs e)
        {
            int i = MetricsPairsListBox.SelectedIndex;
            
            if (mpc.MetricsPairs[i].LinearValues == null)
            {
                MessageBox.Show("Linear coefficients were not set");
                return;
            }

            if (mpc.MetricsPairs[i].LogarithmicValues == null)
            {
                MessageBox.Show("Logarithmic coefficients were not set");
                return;
            }

            if (mpc.MetricsPairs[i].PolynomialValues == null)
            {
                MessageBox.Show("Polynomial coefficients were not set");
                return;
            }

            double min = mpc.MetricsPairs[i].LinearSSE;
            string bestLineFit = "Linear";

            if (mpc.MetricsPairs[i].LogarithmicSSE < min)
            {
                min = mpc.MetricsPairs[i].LogarithmicSSE;
                bestLineFit = "Logarithmic";
            }

            if (mpc.MetricsPairs[i].PolynomialSSE < min)
            {
                min = mpc.MetricsPairs[i].PolynomialSSE;
                bestLineFit = "Polynomial";
            }

            this.BestLineFitResultLabel.Content = "The best line fit for this pair is " + bestLineFit;
        } 
    }
}
