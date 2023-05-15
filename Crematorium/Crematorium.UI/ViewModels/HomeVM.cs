using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crematorium.Application.Abstractions;
using Crematorium.Domain.Entities;
using System.Collections.ObjectModel;

namespace Crematorium.UI.ViewModels
{
    public partial class HomeVM : ObservableValidator
    {
        private IHelpersService<RitualUrn> _urnService;
        private IHelpersService<Hall> _hallService;

        public ObservableCollection<RitualUrn> RitualUrns { get; set; }

        public ObservableCollection<Hall> Halls { get; set; }

        public HomeVM(IHelpersService<RitualUrn> urnService,
                        IHelpersService<Hall> hallService)
        {
            _urnService = urnService;
            _hallService = hallService;
            RitualUrns = new ObservableCollection<RitualUrn>(_urnService.GetAllAsync().Result);
            Halls = new ObservableCollection<Hall>(_hallService.GetAllAsync().Result);
        }

        [ObservableProperty]
        private Hall selectedHall;

        [ObservableProperty]
        private Date selectedDate;

        [ObservableProperty]
        private RitualUrn selectedUrn;

        [RelayCommand]
        public void CreateOrder()
        {

        }

        [RelayCommand]
        public void RegCorpose()
        {

        }

        public void UpdateCollections()
        {
            RitualUrns.Clear();
            foreach (var urn in _urnService.GetAllAsync().Result)
            {
                RitualUrns.Add(urn);
            }

            Halls.Clear();
            foreach (var hall in _hallService.GetAllAsync().Result)
            {
                Halls.Add(hall);
            }
        }
    }
}
