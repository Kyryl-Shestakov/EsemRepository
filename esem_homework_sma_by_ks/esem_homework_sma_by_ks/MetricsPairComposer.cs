using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esem_homework_sma_by_ks
{
    class MetricsPairComposer
    {
        public Metric[] DirectMetrics { get; private set; }
        public Metric[] IndirectMetrics { get; private set; }

        public MetricsPairComposer(Metric[] metrics)
        {
            int directMetricsCount = 0;
            int indirectMetricsCount = 0;

            for (int i = 0; i < metrics.Length; ++i)
            {
                if (metrics[i].IsDirect())
                {
                    ++directMetricsCount;
                }

                if (metrics[i].IsIndirect())
                {
                    ++indirectMetricsCount;
                }
            }

            DirectMetrics = new Metric[directMetricsCount];
            IndirectMetrics = new Metric[indirectMetricsCount];

            int k = 0, l = 0;

            for (int i = 0; i < metrics.Length; ++i)
            {
                if (metrics[i].IsDirect())
                {
                    DirectMetrics[k++] = metrics[i];
                }

                if (metrics[i].IsIndirect())
                {
                    IndirectMetrics[l++] = metrics[i];
                }
            }
        }

        public MetricsPair[] SupplyMetricsPairs()
        {
            MetricsPair[] metricsPairs = new MetricsPair[DirectMetrics.Length*IndirectMetrics.Length];

            for (int i = 0; i < DirectMetrics.Length; ++i)
            {
                for (int j = 0; j < IndirectMetrics.Length; ++j)
                {
                    metricsPairs[IndirectMetrics.Length * i + j] = new MetricsPair(DirectMetrics[i].Name + " vs. " + IndirectMetrics[j].Name, DirectMetrics[i], IndirectMetrics[j]);
                }
            }

            return metricsPairs;
        }
    }
}
