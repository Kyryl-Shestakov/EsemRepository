using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace esem_homework_sma_by_ks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*private string metricsPath;
        private string projectNamesPath;
        private string metricsNamesPath;*/
        private static string defaultMetricPath = "metrics.dat";
        private static string defaultProjectNamesPath = "projects_names.txt";
        private static string defaultMetricNamesPath = "metrics_names.txt";
        private MetricsFacade mf;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadDataButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(metricsTextBox.Text))
            {
                if (File.Exists(metricsNamesTextBox.Text))
                {
                    if (File.Exists(projectsNamesTextBox.Text))
                    {
                        MetricsSupplier ms = new MetricsSupplier(metricsTextBox.Text, metricsNamesTextBox.Text, projectsNamesTextBox.Text);
                        mf = new MetricsFacade(ms);
                        mf.ObtaingMetricsContainer();
                        mf.ObtainMetricsPairsContainer();

                        MessageBox.Show("Metrics were loaded");
                    }
                    else
                    {
                        MessageBox.Show("Invalid path of a projects names file");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid path of a metrics names file");
                }
            }
            else
            {
                MessageBox.Show("Invalid path of a metrics file");
            }
        }

        private void metricsCreationButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("metrics.dat"))
            {
                return;
            }

            double[,] metricsArray = 
                {
                    {13504,	65742,	661,	16603,	0.38,	5.44,	0.14,	-0.78},
                    {5269,	24428,	142,	5963,	0.17,	2.69,	0.22,	-0.85},
                    {20027,	97952,	917,	21513,	0.23,	7.49,	0.33,	-0.74},
                    {33351,	106057,	379,	16326,	0.18,	36.93,	0.26,	-0.58},
                    {21573,	110255,	440,	18972,	0.21,	7.7,	0.3,	-0.82},
                    {22220,	132841,	1013,	25744,	0.31,	13.32,	0.21,	-0.57},
                    {19146,	101273,	800,	16597,	0.25,	2.93,	0.18,	-0.84},
                    {46800,	300678,	2143,	51076,	0.27,	4.57,	0.18,	-0.80},
                    {2789,	10765,	90, 	2407,	0.27,	4.12,	0.14,	-0.92},
                    {9632,	38492,	411,	8681,	0.58,	13.34,	0.38,	-0.38},
                    {14875,	92174,	192,	18601,	0.1,	3.38,	0.34,	-0.91},
                    {6761,	34435,	258,	7773,	0.12,	6.38,	0.49,	-0.80},
                    {13034,	61544,	1421,	16364,	0.25,	2.4,	0.15,	-0.80},
                    {1292,	6351,	108,	1528,	0.18,	3.39,	0.3,	-0.85},
                    {325,	1607,	25,	    367,	0.34,	2.56,	0.39,	-0.85},
                    {15057,	102109,	1558,	23048,	0.33,	4.08,	0.29,	-0.69},
                    {601,	3755,	58,	    802,	0.37,	1.54,	0.21,	-0.85},
                    {676,	3613,	42,	    745,	0.14,	2.61,	0.21,	-0.93},
                    {23133,	105434,	1252,	29825,	0.27,	4.29,	0.25,	-0.70},
                    {37047,	210595,	753,	53134,	0.34,	1.94,	0.05,	-0.90},
                    {61698,	215697,	1039,	30443,	0.4,	14.55,	0.12,	-0.82},
                    {7533,	39901,	539,	9944,	0.34,	3.9,	0.22,	-0.71},
                    {11798,	58657,	785,	8336,	0.37,	6.18,	0.37,	-0.66},
                    {2144,	16607,	71,	    2242,	0.07,	3.26,	0.33,	-0.95},
                    {2359,	10104,	129,	1829,	0.2,	4.2,	0.24,	-0.84},
                    {10045,	49897,	585,	10461,	0.33,	4.78,	0.22,	-0.70},
                    {353,	1674,	43,	    324,	0,	    3.18,	0.19,	-1.00},
                    {24067,	113249,	505,	19276,	0.27,	12.15,	0.31,	-0.79},
                    {6835,	33950,	325,	8054,	0.2,	6.17,	0.32,	-0.76},
                    {3272,	21233,	128,	4861,	0.05,	3.67,	0.45,	-0.91}
                };

            double[][] metricsJaggedArray = new double[8][];

            for (int k = 0; k < metricsJaggedArray.Length; ++k)
            {
                metricsJaggedArray[k] = new double[30];
            }

            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 30; ++j)
                {
                    metricsJaggedArray[i][j] = metricsArray[j, i];
                }
            }

            IFormatter bf = new BinaryFormatter();

            using (Stream fs = File.Create("metrics.dat"))
            {
                bf.Serialize(fs, metricsJaggedArray);
            }
        }

        private void metricsCheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(defaultMetricPath))
            {
                MessageBox.Show("Default metrics file exists", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Default metrics file does not exist", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void projectNamesCheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(defaultProjectNamesPath))
            {
                MessageBox.Show("Default project names file exists", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Default project names file does not exist", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void metricNamesCheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(defaultMetricNamesPath))
            {
                MessageBox.Show("Default metric names file exists", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Default metric names file does not exist", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void ViewDataButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: metrics visualization

            MetricsVisualizationWindow mvw = new MetricsVisualizationWindow(mf.metricsContainer);
            mvw.Owner = this;
            this.Hide();
            mvw.Show();
        }
    }
}
