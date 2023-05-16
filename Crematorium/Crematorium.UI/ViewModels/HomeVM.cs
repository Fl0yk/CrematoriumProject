using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crematorium.Application.Abstractions;
using Crematorium.Domain.Entities;
using Crematorium.UI.Fabrics;
using Crematorium.UI.Pages;
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

        [ObservableProperty]
        private Corpose selectedCorpose;

        private Order order;

        [RelayCommand]
        public void CreateOrder()
        {
            if (SelectedHall is null || SelectedDate is null || SelectedUrn is null || SelectedCorpose is null)
                throw new System.Exception("Чего-то не хватает");

            order = new Order() {HallId = SelectedHall, CorposeId = SelectedCorpose, RegistrationDate = SelectedDate, RitualUrnId = SelectedUrn };
            SelectedHall.FreeDates.Remove(SelectedDate);
        }

        [RelayCommand]
        public void RegCorpose()
        {
            //Передвать ref переменной труппа, который изначально null. А там получим уже зарегестрированного
            var userChange = (ChangeCorposePage)PagesFabric.GetPage(typeof(ChangeCorposePage));
            userChange.InitializeCorpose(-1);
            userChange.OpBtnName.Text = "Registration";
            userChange.ShowDialog();
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
