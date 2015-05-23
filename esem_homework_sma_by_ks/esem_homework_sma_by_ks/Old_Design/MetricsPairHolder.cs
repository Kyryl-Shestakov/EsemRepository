using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esem_homework_sma_by_ks
{
    class MetricsPairHolder
    {
        public double[][] metricsTable { get; private set; }
        public string[] directMetricsNames { get; private set; }
        public readonly int directMetricsCount = 5;
        public string[] indirectMetricsNames { get; private set; }
        public readonly int indirectMetricsCount = 3;
        public string[] projectNames { get; private set; }
        public double[] sampleMean { get; private set; }
        public double[] standardDeviation { get; private set; }
        public double[][] ranks { get; private set; }
        public double[] correlationCoefficients { get; private set; }
        public bool[] normalDistributionFlags { get; private set; }
        public string[] metricsPairNames { get; private set; }
        public int[] metricsPairIndeces { get; private set; }

        public MetricPair[] metricPairs { get; private set; }

        public MetricsPairHolder(double[][] metricsTable, string[] directMetricsNames, string[] indirectMetricsNames, string[] projectNames, bool[] normalDistributionFlags)
        {
            this.metricsTable = metricsTable;
            this.projectNames = projectNames;
            this.directMetricsNames = directMetricsNames;
            this.indirectMetricsNames = indirectMetricsNames;
            this.normalDistributionFlags = normalDistributionFlags;

            sampleMean = new double[metricsTable[0].Length];
            standardDeviation = new double[metricsTable[0].Length];

            ranks = new double[metricsTable.Length][];

            for (int i = 0; i < metricsTable.Length; ++i)
            {
                ranks[i] = new double[metricsTable[0].Length];
            }

            correlationCoefficients = new double[directMetricsCount * indirectMetricsCount];

            Initialize();
        }

        private void Initialize()
        {
            CalculateSampleMean();
            CalculateStandardDeviation();
            CalculateRanks();
            CalculateCorrelationCoefficients();
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

        private void CalculateStandardDeviation()
        {
            double sum;

            for (int i = 0; i < metricsTable[0].Length; ++i)
            {
                sum = 0.0;

                for (int j = 0; j < metricsTable.Length; ++j)
                {
                    sum += Math.Pow(metricsTable[j][i] - sampleMean[i], 2.0);
                }

                standardDeviation[i] = Math.Sqrt(sum / (metricsTable.Length - 1));
            }
        }

        private void CalculateRanks()
        {
            for (int i = 0; i < metricsTable[0].Length; ++i)
            {
                for (int j = 0; j < metricsTable.Length; ++j)
                {
                    ranks[j][i] = CalculateRank(j, i);
                }
            }
        }

        private double CalculateRank(int rowIndex, int columnIndex)
        {
            int rank = 1;
            double value = metricsTable[rowIndex][columnIndex];

            for (int i = 0; i < metricsTable.Length; ++i)
            {
                if (metricsTable[i][columnIndex] < value)
                {
                    ++rank;
                }
            }

            return rank;
        }

        private void CalculateCorrelationCoefficients()
        {
            for (int i = 0; i < directMetricsCount; ++i)
            {
                for (int j = 0; j < indirectMetricsCount; ++j)
                {
                    if (normalDistributionFlags[i] && normalDistributionFlags[directMetricsCount + j])
                    {
                        correlationCoefficients[indirectMetricsCount * i + j] = CalculatePirsonsCorrelationCoefficient(i, directMetricsCount + j);
                    }
                    else
                    {
                        correlationCoefficients[indirectMetricsCount * i + j] = CalculateSpirmensCorrelationCoefficient(i, directMetricsCount + j);
                    }
                }
            }

            int pairCount = 0;

            for (int i = 0; i < directMetricsCount; ++i)
            {
                for (int j = 0; j < indirectMetricsCount; ++j)
                {
                    if (Math.Abs(correlationCoefficients[indirectMetricsCount * i + j]) >= 0.5)
                    {
                        ++pairCount;
                    }
                }
            }

            metricsPairNames = new string[pairCount];
            metricsPairIndeces = new int[pairCount];

            int sequentialIndex = 0;

            for (int i = 0; i < directMetricsCount; ++i)
            {
                for (int j = 0; j < indirectMetricsCount; ++j)
                {
                    if (Math.Abs(correlationCoefficients[indirectMetricsCount * i + j]) >= 0.5)
                    {
                        metricsPairNames[sequentialIndex] = directMetricsNames[i] + " vs. " + indirectMetricsNames[j];
                        metricsPairIndeces[sequentialIndex++] = indirectMetricsCount * i + j;
                    }
                }
            }

            metricPairs = new MetricPair[pairCount];

            for (int i = 0; i < metricPairs.Length; ++i)
            {
                double[] directMetrics = new double[metricsTable.Length];
                double[] indirectMetrics = new double[metricsTable.Length];
                int directMetricColumnIndex = metricsPairIndeces[i]/indirectMetricsCount;
                int indirectMetricColumnIndex = metricsPairIndeces[i] - directMetricColumnIndex*indirectMetricsCount;

                for (int j = 0; j < metricsTable.Length; ++j)
                {
                    directMetrics[j] = metricsTable[j][directMetricColumnIndex];
                    indirectMetrics[j] = metricsTable[j][indirectMetricColumnIndex];
                }

                metricPairs[i] = new MetricPair(metricsPairNames[i], directMetrics, indirectMetrics);

                //TODO: creation of MetricPair objects
            }
        }

        private double CalculateSpirmensCorrelationCoefficient(int columnIndex1, int columnIndex2)
        {
            double sum = 0.0;

            for (int i = 0; i < metricsTable.Length; ++i)
            {
                sum += Math.Pow(ranks[i][columnIndex1] - ranks[i][columnIndex2], 2.0);
            }

            return 1.0 - (6.0/(metricsTable.Length*(Math.Pow(metricsTable.Length, 2.0)-1.0)))*sum;
        }

        private double CalculatePirsonsCorrelationCoefficient(int columnIndex1, int columnIndex2)
        {
            double sum = 0.0;

            for(int i=0; i<metricsTable.Length; ++i) 
            {
                sum += metricsTable[i][columnIndex1] * metricsTable[i][columnIndex2];
            }

            return ((sum/metricsTable.Length) - sampleMean[columnIndex1]*sampleMean[columnIndex2])/(standardDeviation[columnIndex1]*standardDeviation[columnIndex2]);
        }
    }
}
