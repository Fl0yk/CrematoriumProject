using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crematorium.Application.Abstractions;
using Crematorium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Crematorium.UI.ViewModels
{
    public partial class ChangeCorposeVM : ObservableValidator
    {
        private IHelpersService<Corpose> _corposeService;
        private bool _isNewCorpose;
        public ChangeCorposeVM(IHelpersService<Corpose> corposeService)
        {
            _corposeService = corposeService;
        }

        [ObservableProperty]
        [Required]
        private Corpose corpose;

        public void SetCorpose(int corposeId)
        {
            Corpose = _corposeService.GetByIdAsync(corposeId).Result;

            if (Corpose is null)
            {
                Corpose = new Corpose();
                _isNewCorpose = true;
            }
            else
            {
                _isNewCorpose = false;
            }
            this.Name = Corpose.Name;
            this.Surname = Corpose.SurName;
            this.NumPassport = Corpose.NumPassport;
        }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string surname;

        [ObservableProperty]
        private string numPassport;


        [RelayCommand]
        public void AddCorpose()
        {
            if (Corpose is null)
                throw new ArgumentNullException("corpose not initialized");

            if (Name == string.Empty || Name is null ||
                Surname == string.Empty || Surname is null ||
                NumPassport == string.Empty || NumPassport is null)
            {
                throw new Exception("Not initialize data");
            }

            Corpose.Name = this.Name;
            Corpose.SurName = this.Surname;
            Corpose.NumPassport = this.NumPassport;

            if (_isNewCorpose)
            {
                _corposeService.AddAsync(Corpose);
            }
            else
            {
                _corposeService.UpdateAsync(Corpose);
            }
        }
    }
}