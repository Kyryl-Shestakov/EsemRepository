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
    class MetricsHolder
    {
        private static string defaultDataPath = "metrics.dat";
        public double[][] metricsTable { get; private set; }
        public string[] directMetricsNames { get; private set; }
        public readonly int directMetricsCount = 5;
        public string[] indirectMetricsNames { get; private set; }
        public readonly int indirectMetricsCount = 3;
        public string[] projectNames { get; private set; }
        public readonly int intervalCount = 6;
        public double[][] intervals { get; private set; }
        public double[][] percentages { get; private set; }
        public double[] sampleMean { get; private set; }
        public double[] variance { get; private set; }
        public double[] standardDeviation { get; private set; }
        public double[] kurtosis { get; private set; }
        public double[] skewness { get; private set; }
        public double[][] accuracies { get; private set; }
        public readonly double accuracyThreshold = 1.96;
        public bool[] abnormalProjectFlags { get; private set; }
        public bool[] normalDistributionFlags { get; private set; }

        static MetricsHolder()
        {
            if (!File.Exists(defaultDataPath)) 
            {
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

                double[][] metricsJaggedArray = new double[30][];

                for (int k = 0; k < 30; ++k)
                {
                    metricsJaggedArray[k] = new double[8];
                }

                for (int i = 0; i < 30; ++i)
                {
                    for (int j = 0; j < 8; ++j)
                    {
                        metricsJaggedArray[i][j] = metricsArray[i,j];
                    }
                }

                IFormatter bf = new BinaryFormatter();

                using (Stream fs = File.Create(defaultDataPath)) 
                {
                    bf.Serialize(fs, metricsJaggedArray);
                }
            }
        }

        public MetricsHolder(string metricsPath, string projectNamesPath, string metricsNamesPath)
        {
            IFormatter bf = new BinaryFormatter();

            try
            {
                using (Stream fs = File.OpenRead(metricsPath))
                {
                    metricsTable = (double[][]) bf.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                throw new Exception("There are problems with data reading at " + metricsPath);
            }

            projectNames = new string[metricsTable.Length];

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
            

            directMetricsNames = new string[directMetricsCount];
            indirectMetricsNames = new string[indirectMetricsCount];

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

            intervals = new double[intervalCount+1][];

            for (int i = 0; i < intervals.Length; ++i)
            {
                intervals[i] = new double[metricsTable[0].Length];
            }

            percentages = new double[intervalCount][];

            for (int i = 0; i < percentages.Length; ++i)
            {
                percentages[i] = new double[metricsTable[0].Length];
            }

            sampleMean = new double[metricsTable[0].Length];
            variance = new double[metricsTable[0].Length];
            standardDeviation = new double[metricsTable[0].Length];
            kurtosis = new double[metricsTable[0].Length];
            skewness = new double[metricsTable[0].Length];

            accuracies = new double[metricsTable.Length][];

            for (int i = 0; i < accuracies.Length; ++i)
            {
                accuracies[i] = new double[metricsTable[0].Length];
            }

            abnormalProjectFlags = new bool[metricsTable.Length];
            //normalDistributionFlags = new bool[directMetricsCount + indirectMetricsCount];

            Initialize();
        }

        private void Initialize()
        {
            CalculateIntervals();
            CalculatePercentages();
            CalculateSampleMean();
            CalculateVariance();
            CalculateStandardDeviation();
            CalculateKurtosis();
            CalculateSkewness();
            CalculateAccuracies();
            DetermineAbnormalProjects();
        }

        private void CalculateIntervals()
        {
            for (int i = 0; i < metricsTable[0].Length; ++i)
            {
                intervals[0][i] = Min(i);
            }

            double step;

            for (int i = 0; i < intervals[0].Length; ++i)
            {
                step = (Max(i) - Min(i)) / Math.Sqrt(metricsTable.Length);

                for (int j = 1; j < intervals.Length; ++j)
                {
                    intervals[j][i] = intervals[j - 1][i] + step;
                }
            }
        }

        private void CalculatePercentages()
        {
            double[][] counts = new double[intervals.Length-1][];

            for (int i = 0; i < counts.Length; ++i)
            {
                counts[i] = new double[intervals[0].Length];
            }

            for (int i = 0; i < intervals[0].Length; ++i)
            {
                for (int j = 0; j < counts.Length; ++j)
                {
                    counts[j][i] = CalculateCount(i, intervals[j][i], intervals[j + 1][i]); //int to double conversion
                }
            }

            for (int i = 0; i < percentages[0].Length; ++i)
            {
                for (int j = 0; j < percentages.Length; ++j)
                {
                    percentages[j][i] = (counts[j][i] / metricsTable.Length) * 100.0;
                }
            }
        }

        private int CalculateCount(int columnIndex, double left, double right)
        {
            int count = 0;
            double entry;
            for (int i = 0; i < metricsTable.Length; ++i)
            {
                entry = metricsTable[i][columnIndex];

                if (entry >= left && entry < right)
                {
                    ++count;
                }
            }

            return count;
        }

        private double Min(int columnIndex)
        {
            double min = metricsTable[0][columnIndex];

            for (int i = 1; i < metricsTable.Length; ++i)
            {
                if (metricsTable[i][columnIndex] < min)
                {
                    min = metricsTable[i][columnIndex];
                }
            }

            return min;
        }

        private double Max(int columnIndex)
        {
            double max = metricsTable[0][columnIndex];

            for (int i = 1; i < metricsTable.Length; ++i)
            {
                if (metricsTable[i][columnIndex] > max)
                {
                    max = metricsTable[i][columnIndex];
                }
            }

            return max;
        }

        private void CalculateSampleMean()
        {
            double sum;

            for (int i = 0; i < metricsTable[0].Length; ++i)
            {
                sum = 0.0;

                for (int j = 0; j < metricsTable.Length; ++j)
                {
                    sum += metricsTable[j][i];
                }

                sampleMean[i] = sum / metricsTable.Length;
            }
        }

        private void CalculateVariance()
        {
            double sum;

            for (int i = 0; i < metricsTable[0].Length; ++i)
            {
                sum = 0.0;

                for (int j = 0; j < metricsTable.Length; ++j)
                {
                    sum += Math.Pow(metricsTable[j][i] - sampleMean[i], 2.0);
                }

                variance[i] = sum / (metricsTable.Length - 1);
            }
        }

        private void CalculateStandardDeviation()
        {
            for (int i = 0; i < standardDeviation.Length; ++i)
            {
                standardDeviation[i] = Math.Sqrt(variance[i]);
            }
        }

        private void CalculateKurtosis()
        {
            double sum;

            for (int i = 0; i < metricsTable[0].Length; ++i)
            {
                sum = 0.0;

                for (int j = 0; j < metricsTable.Length; ++j)
                {
                    sum += Math.Pow(metricsTable[j][i] - sampleMean[i], 4.0);
                }

                kurtosis[i] = (((metricsTable.Length) * (metricsTable.Length + 1) * sum) / (Math.Pow(standardDeviation[i], 4.0) * (metricsTable.Length - 1) * (metricsTable.Length - 2) * (metricsTable.Length - 3))) - ((3.0 * Math.Pow(metricsTable.Length - 1, 2.0)) / ((metricsTable.Length - 2) * (metricsTable.Length - 3)));
            }
        }

        private void CalculateSkewness()
        {
            double sum;

            for (int i = 0; i < metricsTable[0].Length; ++i)
            {
                sum = 0.0;

                for (int j = 0; j < metricsTable.Length; ++j)
                {
                    sum += Math.Pow(metricsTable[j][i] - sampleMean[i], 3.0);
                }

                skewness[i] = (metricsTable.Length*sum) / (Math.Pow(standardDeviation[i], 3.0) * (metricsTable.Length - 1) * (metricsTable.Length - 2));
            }
        }

        private void CalculateAccuracies()
        {
            for (int i = 0; i < metricsTable[0].Length; ++i)
            {
                for (int j = 0; j < metricsTable.Length; ++j)
                {
                    accuracies[j][i] = Math.Abs(metricsTable[j][i] - sampleMean[i]) / standardDeviation[i];
                }
            }
        }

        private void DetermineAbnormalProjects()
        {
            for (int i = 0; i < metricsTable.Length; ++i)
            {
                for (int j = 0; j < metricsTable[0].Length; ++j)
                {
                    if (accuracies[i][j] > accuracyThreshold)
                    {
                        abnormalProjectFlags[i] = true;
                        break;
                    }
                }
            }
        }

        public void DetermineNormalDistributions(bool[] nd)
        {
            normalDistributionFlags = nd;
        }

        public double[][] SupplyNormalMetrics()
        {
            int normalMetricsCount = this.metricsTable.Length;

            for (int i = 0; i < abnormalProjectFlags.Length; ++i)
            {
                if (abnormalProjectFlags[i])
                {
                    --normalMetricsCount;
                }
            }

            double[][] newMetricsTable = new double[normalMetricsCount][];

            for (int j = 0; j < this.metricsTable.Length; ++j)
            {
                if (!abnormalProjectFlags[j])
                {
                    newMetricsTable[j] = this.metricsTable[j];
                }
            }

            return newMetricsTable;
        }

        public string[] SupplyNormalProjectsNames()
        {
            int normalProjectsNamesCount = this.projectNames.Length;

            for (int i = 0; i < abnormalProjectFlags.Length; ++i)
            {
                if (abnormalProjectFlags[i])
                {
                    --normalProjectsNamesCount;
                }
            }

            string[] newProjectsNames = new string[normalProjectsNamesCount];

            for (int j = 0; j < this.projectNames.Length; ++j)
            {
                if (!abnormalProjectFlags[j])
                {
                    newProjectsNames[j] = this.projectNames[j];
                }
            }

            return newProjectsNames;
        }
    }
}