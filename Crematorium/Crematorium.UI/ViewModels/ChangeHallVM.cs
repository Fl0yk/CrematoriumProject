using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crematorium.Application.Abstractions;
using Crematorium.Application.Services;
using Crematorium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crematorium.UI.ViewModels
{
    public partial class ChangeHallVM : ObservableValidator
    {
        private IHelpersService<Hall> _hallService;
        private bool _isNewHall;

        public ChangeHallVM(IHelpersService<Hall> hallService)
        {
            _hallService = hallService;
            FreeDates = new ObservableCollection<Date>();
        }

        [ObservableProperty]
        private Hall selectedHall;

        public void SetHall(int id)
        {
            SelectedHall = _hallService.GetByIdAsync(id).Result;

            if(SelectedHall is null)
            {
                SelectedHall = new();
                _isNewHall = true;
            }
            else
            {
                _isNewHall = false;
            }
            Name = SelectedHall.Name;
            Capacity = SelectedHall.Capacity;
            Price = SelectedHall.Price;
            NewDate = "01.01.0001";
            FreeDates.Clear();
            if(SelectedHall.FreeDates is not null)
            {
                foreach(var date in SelectedHall.FreeDates)
                {
                    FreeDates.Add(date);
                }
            }
        }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private int capacity;

        [ObservableProperty]
        private decimal price;

        [ObservableProperty]
        private string newDate;

        public ObservableCollection<Date> FreeDates { get; set; }

        [RelayCommand]
        public void AddNewDate()
        {
            if (NewDate is not null && Regex.IsMatch(NewDate, @"(\d\d|\d)\.(\d\d|\d)\.\d\d\d\d"))
            {
                Date d = new Date() { Data = NewDate};
                FreeDates.Add(d);
                //SelectedHall.FreeDates.Add(d);
            }
            else
            {
                NewDate = string.Empty;
            }
        }

        [RelayCommand]
        public async void AddHall()
        {
            if (SelectedHall is null)
                throw new ArgumentNullException("User not initialized");

            if (Name == string.Empty || Name is null ||
                Price == 0  ||
                Capacity == 0)
            {
                throw new Exception("Not initialize data");
            }

            SelectedHall.Name = this.Name;
            SelectedHall.Price = this.Price;
            SelectedHall.Capacity = this.Capacity;
            SelectedHall.FreeDates = this.FreeDates.ToList();

            if (_isNewHall)
            {
                //User.Id = 0;
                await _hallService.AddAsync(SelectedHall);
            }
            else
            {
                await _hallService.UpdateAsync(SelectedHall);
            }
        }
    }
}
