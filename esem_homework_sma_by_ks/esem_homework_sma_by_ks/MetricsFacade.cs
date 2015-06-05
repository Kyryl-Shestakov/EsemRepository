using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esem_homework_sma_by_ks
{
    public class MetricsFacade
    {
        private MetricsSupplier metricsSupplier;
        public MetricsContainer metricsContainer { get; private set; }
        public MetricsContainer normalMetricsContainer { get; private set; }
        public MetricsPairContainer metricsPairsContainer { get; private set; }
        public MetricsPairContainer dependentMetricsPairsContainer { get; private set; }

        public MetricsFacade(MetricsSupplier metricsSupplier)
        {
            this.metricsSupplier = metricsSupplier;
        }

        public MetricsContainer ObtainMetricsContainer()
        {
            Metric[] metrics = metricsSupplier.SupplyMetrics();
            string[] projectsNames = metricsSupplier.SupplyProjectsNames();
            this.metricsContainer = new MetricsContainer(metrics, projectsNames);
            return metricsContainer;
        }

        public MetricsPairContainer ObtainMetricsPairsContainer()
        {
            Metric[] normalMetrics = this.metricsContainer.SupplyNormalMetrics();
            string[] normalProjectsNames = this.metricsContainer.SupplyNormalProjectsNames();
            
            for (int i = 0; i < normalMetrics.Length; ++i)
            {
                normalMetrics[i].NormalDistributionFlag = metricsContainer.Metrics[i].NormalDistributionFlag;
            }

            this.normalMetricsContainer = new MetricsContainer(normalMetrics, normalProjectsNames);

            MetricsPairComposer metricsPairComposer = new MetricsPairComposer(normalMetrics);
            MetricsPair[] metricsPairs = metricsPairComposer.SupplyMetricsPairs();
            this.metricsPairsContainer = new MetricsPairContainer(metricsPairs);

            MetricsPair[] dependentMetricsPairs = this.metricsPairsContainer.SupplyDependentMetricsPairs();
            this.dependentMetricsPairsContainer = new MetricsPairContainer(dependentMetricsPairs);

            return this.metricsPairsContainer;
        }
    }
}
