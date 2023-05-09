using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crematorium.Application.Abstractions;
using Crematorium.Application.Services;
using Crematorium.Domain.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.UI.ViewModels
{
    public partial class ChangeUrnVM : ObservableValidator
    {
        private IBaseService<RitualUrn> _urnService;

        private RitualUrn changedUrn;
        private bool _isNewUrn = false;

        private int maxId;

        public ChangeUrnVM(IBaseService<RitualUrn> userService)
        {
            _urnService = userService;
            maxId = _urnService.GetAllAsync().Result is null ? _urnService.GetAllAsync().Result.MaxBy(u => u.Id).Id : 0;
        }

        public void SetUrn(int id)
        {
            changedUrn = _urnService.GetByIdAsync(id).Result;

            if (changedUrn is null)
            {
                changedUrn = new RitualUrn();
                _isNewUrn = true;
            }
            else
            {
                _isNewUrn = false;
            }

            Name = changedUrn.Name;
            Price = changedUrn.Price;
            Image = changedUrn.Image;
        }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private decimal price = 0;

        [ObservableProperty]
        private byte[] image;

        [RelayCommand]
        public void ChangeFoto()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                byte[] data;
                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                {
                    data = new byte[fs.Length];
                    fs.Read(data, 0, data.Length);
                }
                Image = data;
                changedUrn.Image = data;
            }
        }

        [RelayCommand]
        public void AddUrn()
        {
            if(changedUrn is null)
                throw new ArgumentNullException("Urn not initialized");

            if (Name is null || Name == string.Empty ||
                Image is null)
            {
                throw new Exception("Not initialize data");
            }

            changedUrn.Name = Name;
            changedUrn.Price = Price;
            changedUrn.Image = Image;

            if(_isNewUrn)
            {
                changedUrn.Id = maxId;
                maxId++;
                _urnService.AddAsync(changedUrn);
            }
            else
            {
                _urnService.UpdateAsync(changedUrn);
            }
        }
    }
}
