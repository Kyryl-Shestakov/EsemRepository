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
        public MetricsPairsContainer metricsPairsContainer { get; private set; }
        public MetricsPairsContainer dependentMetricsPairsContainer { get; private set; }

        public MetricsFacade(MetricsSupplier metricsSupplier)
        {
            this.metricsSupplier = metricsSupplier;
        }

        public MetricsContainer ObtaingMetricsContainer()
        {
            Metric[] metrics = metricsSupplier.SupplyMetrics();
            string[] projectsNames = metricsSupplier.SupplyProjectsNames();
            this.metricsContainer = new MetricsContainer(metrics, projectsNames);
            return metricsContainer;
        }

        public MetricsPairsContainer ObtainMetricsPairsContainer()
        {
            Metric[] normalMetrics = this.metricsContainer.SupplyNormalMetrics();
            string[] normalProjectsNames = this.metricsContainer.SupplyNormalProjectsNames();
            this.normalMetricsContainer = new MetricsContainer(normalMetrics, normalProjectsNames);

            MetricsPairComposer metricsPairComposer = new MetricsPairComposer(normalMetrics);
            MetricsPair[] metricsPairs = metricsPairComposer.SupplyMetricsPairs();
            this.metricsPairsContainer = new MetricsPairsContainer(metricsPairs);

            MetricsPair[] dependentMetricsPairs = this.metricsPairsContainer.SupplyDependentMetricsPairs();
            this.dependentMetricsPairsContainer = new MetricsPairsContainer(dependentMetricsPairs);

            return this.dependentMetricsPairsContainer;
        }
    }
}
