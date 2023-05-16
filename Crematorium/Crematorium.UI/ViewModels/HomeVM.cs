using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crematorium.Application.Abstractions;
using Crematorium.Domain.Entities;
using Crematorium.UI.Fabrics;
using Crematorium.UI.Pages;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace Crematorium.UI.ViewModels
{
    //Сделать отдельные свойства и кним привязаться!
    //Делать ли страницу с полной инфой?...
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
            HallDates = new ObservableCollection<Date>();
        }

        [ObservableProperty]
        private Hall selectedHall;

        public ObservableCollection<Date> HallDates { get; set; }

        [RelayCommand]
        public void UpdateDates()
        {
            HallDates.Clear();
            if (SelectedHall is null)
                return;

            foreach (var date in SelectedHall.FreeDates) 
            {
                HallDates.Add(date);
            }
        }

        [ObservableProperty]
        private Date selectedDate;

        [ObservableProperty]
        private RitualUrn selectedUrn;

        //[ObservableProperty]
        private Corpose selectedCorpose;

        private Order order;

        [RelayCommand]
        public void CreateOrder()
        {
            if (SelectedHall is null || SelectedDate is null || SelectedUrn is null || selectedCorpose is null)
                throw new System.Exception("Чего-то не хватает");

            order = new Order() {HallId = SelectedHall, CorposeId = selectedCorpose, DateOfStart = SelectedDate, RitualUrnId = SelectedUrn };
            SelectedHall.FreeDates.Remove(SelectedDate);
            SelectedHall = null;
            SelectedDate = null;
            SelectedUrn = null;
            selectedCorpose = null;
            using (FileStream fs = new FileStream("order.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<Order>(fs, order);
            }
        }

        [RelayCommand]
        public void RegCorpose()
        {
            var userChange = (ChangeCorposePage)PagesFabric.GetPage(typeof(ChangeCorposePage));
            userChange.InitializeCorpose(ref selectedCorpose);
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
