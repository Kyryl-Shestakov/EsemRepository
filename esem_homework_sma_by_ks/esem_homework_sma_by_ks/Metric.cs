using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esem_homework_sma_by_ks
{
    public class Metric
    {
        public double[] Values { get; private set; }
        public string Name { get; private set; }
        public MetricType ParticularMetricType { get; private set; }
        public double[] Intervals { get; private set; }
        public double[] Percentages { get; private set; }
        public double SampleMean { get; private set; }
        public double Variance { get; private set; }
        public double StandardDeviation { get; private set; }
        public double Kurtosis { get; private set; }
        public double Skewness { get; private set; }
        public double[] Accuracies { get; private set; }
        public double[] Ranks { get; private set; }

        public static readonly int IntervalCount = 6;
        public bool NormalDistributionFlag { get; private set; } //determined by the user!
        
        public Metric(double[] values, string name, MetricType mt)
        {
            this.Values = values;
            this.Name = name;
            this.ParticularMetricType = mt;

            this.Intervals = new double[IntervalCount + 1]; //we add 1 to specify the minimum value at the beginning from which intervals begin
            this.Percentages = new double[IntervalCount];
            this.Accuracies = new double[values.Length];
            this.Ranks = new double[values.Length];

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
            CalculateRanks();
        }

        private void CalculateIntervals()
        {
            Intervals[0] = Min();

            double step;

            step = (Max() - Min()) / Math.Sqrt(Values.Length);

            for (int j = 1; j < Intervals.Length; ++j)
            {
                Intervals[j] = Intervals[j - 1] + step;
            }
        }

        private void CalculatePercentages()
        {
            double[] counts = new double[Intervals.Length - 1];

            for (int i = 0; i < counts.Length; ++i)
            {
                    counts[i] = CalculateCount(Intervals[i], Intervals[i+1]); //int to double conversion
            }

            for (int i = 0; i < Percentages.Length; ++i)
            {
                    Percentages[i] = (counts[i] / Values.Length) * 100.0;
            }
        }

        private int CalculateCount(double left, double right)
        {
            int count = 0;
            double entry;
            for (int i = 0; i < Values.Length; ++i)
            {
                entry = Values[i];

                if (entry >= left && entry < right)
                {
                    ++count;
                }
            }

            return count;
        }

        private double Min()
        {
            double min = Values[0];

            for (int i = 1; i < Values.Length; ++i)
            {
                if (Values[i] < min)
                {
                    min = Values[i];
                }
            }

            return min;
        }

        private double Max()
        {
            double max = Values[0];

            for (int i = 1; i < Values.Length; ++i)
            {
                if (Values[i] > max)
                {
                    max = Values[i];
                }
            }

            return max;
        }

        private void CalculateSampleMean()
        {
            double sum = 0.0;

            for (int i = 0; i < Values.Length; ++i)
            {
                sum += Values[i];
            }

            SampleMean = sum / Values.Length;
        }

        private void CalculateVariance()
        {
            double sum = 0.0;

            for (int j = 0; j < Values.Length; ++j)
            {
                sum += Math.Pow(Values[j] - SampleMean, 2.0);
            }

            Variance = sum / (Values.Length - 1);
        }

        private void CalculateStandardDeviation()
        {
            StandardDeviation = Math.Sqrt(Variance);
        }

        private void CalculateKurtosis()
        {
            double sum = 0.0;

            for (int j = 0; j < Values.Length; ++j)
            {
                sum += Math.Pow(Values[j] - SampleMean, 4.0);
            }

            Kurtosis = (((Values.Length) * (Values.Length + 1) * sum) / (Math.Pow(StandardDeviation, 4.0) * (Values.Length - 1) * (Values.Length - 2) * (Values.Length - 3))) - ((3.0 * Math.Pow(Values.Length - 1, 2.0)) / ((Values.Length - 2) * (Values.Length - 3)));
        }

        private void CalculateSkewness()
        {
            double sum = 0.0;

            for (int j = 0; j < Values.Length; ++j)
            {
                sum += Math.Pow(Values[j] - SampleMean, 3.0);
            }

            Skewness = (Values.Length * sum) / (Math.Pow(StandardDeviation, 3.0) * (Values.Length - 1) * (Values.Length - 2));
        }

        private void CalculateAccuracies()
        {
            for (int j = 0; j < Values.Length; ++j)
            {
                Accuracies[j] = Math.Abs(Values[j] - SampleMean) / StandardDeviation;
            }
        }

        private void CalculateRanks()
        {
            for (int j = 0; j < Values.Length; ++j)
            {
                Ranks[j] = CalculateRank(j);
            }
        }

        private double CalculateRank(int index)
        {
            int rank = 1;
            double value = Values[index];

            for (int i = 0; i < Values.Length; ++i)
            {
                if (Values[i] < value)
                {
                    ++rank;
                }
            }

            return rank;
        }

        public void DetermineNormalDistribution(bool normalDistributionFlag)
        {
            this.NormalDistributionFlag = normalDistributionFlag;
        }

        public bool IsDirect()
        {
            return ParticularMetricType == MetricType.DIRECT;
        }

        public bool IsIndirect()
        {
            return ParticularMetricType == MetricType.INDIRECT;
        }
    }
}