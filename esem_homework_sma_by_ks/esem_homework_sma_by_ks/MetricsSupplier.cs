using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace esem_homework_sma_by_ks
{
    public class MetricsSupplier
    {
        //private static string defaultMetricsPath = "metrics.dat";
        private static int defaultTableWidth = 8;
        private static int defaultTableHeight = 30;
        private static int directMetricsCount = 5;
        private static int indirectMetricsCount = 3;

        private string metricsPath;
        private string metricsNamesPath;
        private string projectNamesPath;

        public MetricsSupplier(string metricsPath, string metricsNamesPath, string projectNamesPath)
        {
            this.metricsPath = metricsPath;
            this.metricsNamesPath = metricsNamesPath;
            this.projectNamesPath = projectNamesPath;
        }

        public Metric[] SupplyMetrics()
        {
            double[][] metricsTable;

            IFormatter bf = new BinaryFormatter();

            try
            {
                using (Stream fs = File.OpenRead(this.metricsPath))
                {
                    metricsTable = (double[][]) bf.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString() + "; There are problems with data reading at " + metricsPath);
            }

            string[] directMetricsNames = new string[directMetricsCount];
            string[] indirectMetricsNames = new string[indirectMetricsCount];

            try
            {
                using (StreamReader sr = new StreamReader(File.OpenRead(metricsNamesPath)))
                {
                    for (int i = 0; i < directMetricsCount; ++i)
                    {
                        directMetricsNames[i] = sr.ReadLine();
                    }

                    for (int j = 0; j < indirectMetricsCount; ++j)
                    {
                        indirectMetricsNames[j] = sr.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString() + "\nThere are problems with data reading at " + metricsNamesPath);
            }

            Metric[] metrics = new Metric[metricsTable.Length];

            for (int i = 0; i < directMetricsCount; ++i)
            {
                metrics[i] = new Metric(metricsTable[i], directMetricsNames[i], MetricType.DIRECT);
            }

            for (int i = 0; i < indirectMetricsCount; ++i)
            {
                metrics[directMetricsCount + i] = new Metric(metricsTable[directMetricsCount + i], indirectMetricsNames[i], MetricType.INDIRECT);
            }

            return metrics;
        }

        public string[] SupplyProjectsNames()
        {
            string[] projectNames = new string[defaultTableHeight];

            try
            {
                using (StreamReader sr = new StreamReader(File.OpenRead(projectNamesPath)))
                {
                    for (int i = 0; i < projectNames.Length; ++i)
                    {
                        projectNames[i] = sr.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString() + "\nThere are problems with data reading at " + projectNamesPath);
            }

            return projectNames;
        }
    }
}
