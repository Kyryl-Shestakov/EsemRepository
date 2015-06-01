using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esem_homework_sma_by_ks
{
    public class MetricsPair
    {
        public string Name { get; private set; }
        public Metric DirectMetric { get; private set; }
        public Metric IndirectMetric { get; private set; }
        public double CorrelationCoefficient { get; private set; }

        public double FirstLinearCoefficient { get; private set; }
        public double SecondLinearCoefficient { get; private set; }

        public double FirstPolynomialCoefficient { get; private set; }
        public double SecondPolynomialCoefficient { get; private set; }
        public double ThirdPolynomialCoefficient { get; private set; }

        public double FirstLogarithmicCoefficient { get; private set; }
        public double SecondLogarithmicCoefficient { get; private set; }

        public double[] LinearValues;
        public double[] PolynomialValues;
        public double[] LogarithmicValues;

        public double LinearSSE;
        public double PolynomialSSE;
        public double LogarithmicSSE;

        public MetricsPair(string name, Metric first, Metric second)
        {
            this.Name = name;
            this.DirectMetric = first;
            this.IndirectMetric = second;

            CalculateCorrelationCoefficient();
        }

        private void CalculateCorrelationCoefficient()
        {
            if (DirectMetric.NormalDistributionFlag && IndirectMetric.NormalDistributionFlag)
            {
                CorrelationCoefficient = CalculatePirsonsCorrelationCoefficient();
            }
            else
            {
                CorrelationCoefficient = CalculateSpirmensCorrelationCoefficient();
            }
        }

        private double CalculateSpirmensCorrelationCoefficient()
        {
            double sum = 0.0;

            for (int i = 0; i < DirectMetric.Values.Length; ++i)
            {
                sum += Math.Pow(DirectMetric.Ranks[i] - IndirectMetric.Ranks[i], 2.0);
            }

            return 1.0 - (6.0 / (DirectMetric.Values.Length * (Math.Pow(DirectMetric.Values.Length, 2.0) - 1.0))) * sum;
        }

        private double CalculatePirsonsCorrelationCoefficient()
        {
            double sum = 0.0;

            for (int i = 0; i < DirectMetric.Values.Length; ++i)
            {
                sum += DirectMetric.Values[i] * IndirectMetric.Values[i];
            }

            return ((sum / DirectMetric.Values.Length) - DirectMetric.SampleMean * IndirectMetric.SampleMean) / (DirectMetric.StandardDeviation * IndirectMetric.StandardDeviation);
        }

        public void setLinearCoefficients(double flc, double slc)
        {
            this.FirstLinearCoefficient = flc;
            this.SecondLinearCoefficient = slc;
            CalculateLinearValues();
            CalculateLinearSSE();
        }

        public void setLogarithmicCoefficients(double flc, double slc)
        {
            this.FirstLogarithmicCoefficient = flc;
            this.SecondLogarithmicCoefficient = slc;
            CalculateLogarithmicValues();
            CalculateLogarithmicSSE();
        }

        public void setPolynomialCoefficients(double  fpc, double spc, double tpc)
        {
            this.FirstPolynomialCoefficient = fpc;
            this.SecondPolynomialCoefficient = spc;
            this.ThirdPolynomialCoefficient = tpc;
            CalculatePolynomialValues();
            CalculatePolynomialSSE();
        }

        private void CalculateLinearValues()
        {
            for (int i = 0; i < IndirectMetric.Values.Length; ++i)
            {
                LinearValues[i] = this.FirstLinearCoefficient * DirectMetric.Values[i] + this.SecondLinearCoefficient;
            }
        }

        private void CalculatePolynomialValues()
        {
            for (int i = 0; i < IndirectMetric.Values.Length; ++i)
            {
                PolynomialValues[i] = (this.FirstPolynomialCoefficient * DirectMetric.Values[i] * DirectMetric.Values[i]) + (this.SecondPolynomialCoefficient * DirectMetric.Values[i]) + this.ThirdPolynomialCoefficient;
            }
        }

        private void CalculateLogarithmicValues()
        {
            for (int i = 0; i < IndirectMetric.Values.Length; ++i)
            {
                LogarithmicValues[i] = this.FirstLogarithmicCoefficient * Math.Log(DirectMetric.Values[i]) + this.SecondLogarithmicCoefficient;
            }
        }

        private void CalculateLinearSSE()
        {
            double sum = 0.0;

            for (int i = 0; i < IndirectMetric.Values.Length; ++i)
            {
                sum += Math.Pow(LinearValues[i] - IndirectMetric.Values[i], 2.0);
            }

            LinearSSE = sum;
        }

        private void CalculateLogarithmicSSE()
        {
            double sum = 0.0;

            for (int i = 0; i < IndirectMetric.Values.Length; ++i)
            {
                sum += Math.Pow(LogarithmicValues[i] - IndirectMetric.Values[i], 2.0);
            }

            LogarithmicSSE = sum;
        }

        private void CalculatePolynomialSSE()
        {
            double sum = 0.0;

            for (int i = 0; i < IndirectMetric.Values.Length; ++i)
            {
                sum += Math.Pow(PolynomialValues[i] - IndirectMetric.Values[i], 2.0);
            }

            PolynomialSSE = sum;
        }
    }
}
