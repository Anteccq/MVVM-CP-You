using MVVM_CP_You.Model;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MVVM_CP_You.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private CpuManager Model { get; } = new CpuManager();
        public ReadOnlyReactiveProperty<int> CpuPercentage { get; }

        public MainWindowViewModel()
        {
            CpuPercentage = Model
                .ObserveProperty(x => x.CpuPercentage)
                .ToReadOnlyReactiveProperty();
        }
    }
}
