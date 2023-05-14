﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crematorium.Application.Abstractions;
using Crematorium.Domain.Entities;
using Crematorium.UI.Fabrics;
using Crematorium.UI.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.UI.ViewModels
{
    public partial class HallServiceVM : ObservableValidator
    {
        private IHelpersService<Hall> _hallService;

        public ObservableCollection<Hall> Halls { get; set; }
        public HallServiceVM(IHelpersService<Hall> baseService)
        {
            _hallService = baseService;
            Halls = new ObservableCollection<Hall>(_hallService.GetAllAsync().Result);
        }
        [ObservableProperty]
        [MaxLength(20)]
        private string inputFindName;

        [RelayCommand]
        public void FindHalls()
        {
            Halls.Clear();
            if (inputFindName is null || inputFindName == string.Empty)
            {
                UpdateHallsCollection();
                return;
            }

            foreach (Hall hall in _hallService.FindByName(inputFindName).Result)
            {
                Halls.Add(hall);
            }
        }

        [RelayCommand]
        public void AddHall()
        {
            //var userChange = (ChangeHallPage)PagesFabric.GetPage(typeof(ChangehallPage));
            //userChange.Initializehall(-1);
            //userChange.OpBtnName.Text = "Registration";
            //userChange.ShowDialog();
            UpdateHallsCollection();
        }

        [ObservableProperty]
        private Hall selectedHall;

        [RelayCommand]
        public void UpdateHall()
        {
            if (SelectedHall is null)
                return;

            //var userChange = (ChangehallPage)PagesFabric.GetPage(typeof(ChangehallPage));
            //userChange.Initializehall(Selectedhall.Id);
            //userChange.OpBtnName.Text = "Update";
            //userChange.ShowDialog();
            UpdateHallsCollection();
        }

        [RelayCommand]
        public void DeleteHall()
        {
            if (SelectedHall is null)
                return;

            _hallService.DeleteAsync(SelectedHall.Id);
            UpdateHallsCollection();
        }

        private void UpdateHallsCollection()
        {
            Halls.Clear();
            foreach (Hall user in _hallService.GetAllAsync().Result)
            {
                Halls.Add(user);
            }
        }
    }
}
