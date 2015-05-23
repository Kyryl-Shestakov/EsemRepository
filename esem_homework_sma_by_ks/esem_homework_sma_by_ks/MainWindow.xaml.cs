using System;
using System.Collections.Generic;
using System.IO;
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
        private MetricsContainer mc;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadData_Button_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(metricsTextBox.Text))
            {
                if (File.Exists(metricsNamesTextBox.Text)) 
                {
                    if (File.Exists(projectsNamesTextBox.Text))
                    {
                        MetricsSupplier ms = new MetricsSupplier(metricsTextBox.Text, metricsNamesTextBox.Text, projectsNamesTextBox.Text);

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
    }
}
