using System;
using System.Diagnostics;
using System.Reactive.Linq;
using Prism.Mvvm;

namespace MVVM_CP_You.Model
{
    public class CpuManager : BindableBase
    {
        private const string CATEGORY_NAME = "Processor";
        private const string COUNTER_NAME = "% Processor Time";
        private const string INSTANCE_NAME = "_Total";
        public PerformanceCounter TotalCounter { get; } = new PerformanceCounter(CATEGORY_NAME, COUNTER_NAME, INSTANCE_NAME);

        private int _cpuPercentage = 0;

        public int CpuPercentage
        {
            get => _cpuPercentage;
            set => this.SetProperty(ref _cpuPercentage, value);
        }

        public CpuManager()
        {
            Observable
                .Interval(TimeSpan.FromMilliseconds(1000))
                .Select(_ => (int) TotalCounter.NextValue())
                .Subscribe(value => CpuPercentage = value);
        }
    }
}
