using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esem_homework_sma_by_ks
{
    public class MetricsPairsContainer
    {
        private static double correlationThreshold = 0.5;
        public MetricsPair[] MetricsPairs { get; private set; }

        public MetricsPairsContainer(MetricsPair[] metricsPairs)
        {
            this.MetricsPairs = metricsPairs;
        }

        public MetricsPair[] SupplyDependentMetricsPairs()
        {
            int dependentMetricsPairsCount = 0;

            for (int i = 0; i < MetricsPairs.Length; ++i)
            {
                if (MetricsPairs[i].CorrelationCoefficient >= correlationThreshold)
                {
                    ++dependentMetricsPairsCount;
                }
            }

            MetricsPair[] dependentMetricsPairs = new MetricsPair[dependentMetricsPairsCount];
            int k = 0;

            for (int i = 0; i < MetricsPairs.Length; ++i)
            {
                if (MetricsPairs[i].CorrelationCoefficient >= correlationThreshold)
                {
                    dependentMetricsPairs[k++] = MetricsPairs[i];
                }
            }

            return dependentMetricsPairs;
        }
    }
}
