using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crematorium.Application.Abstractions;
using Crematorium.UI.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Crematorium.UI.ViewModels
{
    public partial class LogAndRegVM :  INotifyPropertyChanged            //ObservableObject
    {
        private IUserService _userService;
        public LogAndRegVM(IUserService userService) 
        {
            _userService = userService;
            ValidatesInput = new RelayCommand(() => OpenProgram());
        }

        
        private string inputName = string.Empty;

        public string InputName
        {
            get => inputName;
            set
            {
                if (inputName != value)
                {
                    inputName = value;
                    OnPropertyChanged(nameof(InputName));
                }
            }
        }
        

        public string inputNumPassport = string.Empty;
        public string InputNumPassport
        {
            get => inputNumPassport;
            set
            {
                if(inputNumPassport != value)
                {
                    inputNumPassport = value;
                    OnPropertyChanged(nameof(InputNumPassport));
                }
            }
        }

        //[RelayCommand]
        //public void ValidatesInput() => OpenProgram();

        public ICommand ValidatesInput { get;  }

        public bool OpenProgram()
        {
            if(_userService.IsValided(inputName, inputNumPassport).Result)
            {
                return true;
            }
            
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
