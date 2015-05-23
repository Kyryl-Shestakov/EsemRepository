using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esem_homework_sma_by_ks
{
    class MetricPair
    {
        public string name { get; private set; }
        public double[] directMetric { get; private set; }
        public double[] indirectMetric { get; private set; }
        public double[] linearCoefficients;
        public double[] polynomialCoefficients;
        public double[] logarithmicCoefficients;
        public double[] linearValues;
        public double[] polynomialValues;
        public double[] logarithmicValues;
        public double linearSSE { get; private set; }
        public double polynomialSSE { get; private set; }
        public double logarithmicSSE { get; private set; }
        public MetricPair(string name, double[] directMetric, double[] indirectMetric)
        {
            this.name = name;
            this.directMetric = directMetric;
            this.indirectMetric = indirectMetric;

            this.linearValues = new double[indirectMetric.Length];
            this.polynomialValues = new double[indirectMetric.Length];
            this.logarithmicValues = new double[indirectMetric.Length];
        }

        public void setLinearCoefficients(double[] linearCoefficients) 
        {
            this.linearCoefficients = linearCoefficients;
            CalculateLinearValues();
            CalculateLinearSSE();
        }

        public void setLogarithmicCoefficients(double[] logarithmicCoefficients) 
        {
            this.logarithmicCoefficients = logarithmicCoefficients;
            CalculateLogarithmicValues();
            CalculateLogarithmicSSE();
        }

        public void setPolynomialCoefficients(double[] polynomialCoefficients) 
        {
            this.polynomialCoefficients = polynomialCoefficients;
            CalculatePolynomialValues();
            CalculatePolynomialSSE();
        }

        private void CalculateLinearValues()
        {
            for (int i = 0; i < indirectMetric.Length; ++i)
            {
                linearValues[i] = linearCoefficients[0] * directMetric[i] + linearCoefficients[1];
            }
        }

        private void CalculatePolynomialValues()
        {
            for (int i = 0; i < indirectMetric.Length; ++i)
            {
                polynomialValues[i] = (polynomialCoefficients[0] * directMetric[i] * directMetric[i]) + (polynomialCoefficients[1] * directMetric[i]) + polynomialCoefficients[2];
            }
        }

        private void CalculateLogarithmicValues()
        {
            for (int i = 0; i < indirectMetric.Length; ++i)
            {
                linearValues[i] = logarithmicCoefficients[0] * Math.Log(directMetric[i]) + logarithmicCoefficients[1];
            }
        }

        private void CalculateLinearSSE()
        {
            double sum = 0.0;

            for (int i = 0; i < indirectMetric.Length; ++i)
            {
                sum += Math.Pow(linearValues[i] - indirectMetric[i], 2.0);
            }

            linearSSE = sum;
        }

        private void CalculateLogarithmicSSE()
        {
            double sum = 0.0;

            for (int i = 0; i < indirectMetric.Length; ++i)
            {
                sum += Math.Pow(logarithmicValues[i] - indirectMetric[i], 2.0);
            }

            logarithmicSSE = sum;
        }

        private void CalculatePolynomialSSE()
        {
            double sum = 0.0;

            for (int i = 0; i < indirectMetric.Length; ++i)
            {
                sum += Math.Pow(polynomialValues[i] - indirectMetric[i], 2.0);
            }

            logarithmicSSE = sum;
        }

        public string GetBestLineFit()
        {
            string result = "";

            if (linearSSE < polynomialSSE && linearSSE < logarithmicSSE)
            {
                result = "Linear";
            }

            if (polynomialSSE < linearSSE && polynomialSSE < logarithmicSSE)
            {
                result = "Polynomial";
            }

            if (logarithmicSSE < linearSSE && logarithmicSSE < polynomialSSE)
            {
                result = "Logarithmic";
            }

            return result;
        }
    }
}
