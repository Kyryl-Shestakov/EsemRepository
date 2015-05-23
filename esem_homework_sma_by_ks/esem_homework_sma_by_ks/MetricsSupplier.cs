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
    class MetricsSupplier
    {
        private static string defaultMetricsPath = "metrics";
        private static string defaulMetricsNamesPath = "metrics_names.txt";
        private static string defaultProjectNamesPath = "projects_names.txt";
        private static int defaultTableWidth = 8;
        private static int defaultTableHeight = 30;
        private static int directMetricsCount = 5;
        private static int indirectMetricsCount = 3;

        private string metricsPath;
        private string metricsNamesPath;
        private string projectNamesPath;

        static MetricsSupplier()
        {
            if (File.Exists(defaultMetricsPath)) 
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

            double[][] metricsJaggedArray = new double[defaultTableWidth][];

            for (int k = 0; k < metricsJaggedArray.Length; ++k)
            {
                metricsJaggedArray[k] = new double[defaultTableHeight];
            }

            for (int i = 0; i < defaultTableWidth; ++i)
            {

                for (int j = 0; j < defaultTableHeight; ++j)
                {
                    metricsJaggedArray[i][j] = metricsArray[i,j];
                }
            }

            IFormatter bf = new BinaryFormatter();

            using (Stream fs = File.Create(defaultMetricsPath)) 
            {
                bf.Serialize(fs, metricsJaggedArray);
            }
        }

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
