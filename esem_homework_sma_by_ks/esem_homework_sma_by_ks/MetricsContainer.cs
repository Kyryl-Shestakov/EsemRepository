using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esem_homework_sma_by_ks
{
    class MetricsContainer
    {
        public Metric[] Metrics { get; private set; }
        public string[] ProjectNames { get; private set; }
        public bool[] AbnormalProjectFlags { get; private set; }

        public static readonly double AccuracyThreshold = 1.96;
        public MetricsContainer(Metric[] metrics, string[] projectNames)
        {
            this.Metrics = metrics;
            this.ProjectNames = projectNames;
            this.AbnormalProjectFlags = new bool[projectNames.Length];

            DetermineAbnormalProjects();
        }

        public void DetermineAbnormalProjects()
        {
            for (int i = 0; i < Metrics.Length; ++i)
            {
                for (int j = 0; j < Metrics[i].Values.Length; ++j)
                {
                    if (Metrics[i].Values[j] > AccuracyThreshold)
                    {
                        AbnormalProjectFlags[j] = true;
                    }
                }
            }
        }

        public Metric[] SupplyNormalMetrics()
        {
            int projectCount = ProjectNames.Length;

            for (int i = 0; i < AbnormalProjectFlags.Length; ++i)
            {
                if (AbnormalProjectFlags[i])
                {
                    --projectCount;
                }
            }

            Metric[] normalMetrics = new Metric[Metrics.Length];

            for (int i = 0; i < normalMetrics.Length; ++i)
            {
                double[] values = new double[projectCount];
                int k = 0;

                for (int j = 0; j < Metrics[i].Values.Length; ++j)
                {
                    if (!AbnormalProjectFlags[j])
                    {
                        values[k++] = Metrics[i].Values[j];
                    }
                }

                normalMetrics[i] = new Metric(values, Metrics[i].Name, Metrics[i].ParticularMetricType);
            }

            return normalMetrics;
        }

        public string[] SupplyNormalProjectsNames()
        {
            int projectCount = ProjectNames.Length;

            for (int i = 0; i < AbnormalProjectFlags.Length; ++i)
            {
                if (AbnormalProjectFlags[i])
                {
                    --projectCount;
                }
            }

            string[] names = new string[projectCount];
            int k = 0;

            for (int i = 0; i < ProjectNames.Length; ++i)
            {
                if (!AbnormalProjectFlags[i])
                {
                    names[k++] = ProjectNames[i];
                }
            }

            return names;
        }
    }
}
