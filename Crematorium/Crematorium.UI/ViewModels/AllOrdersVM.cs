using CommunityToolkit.Mvvm.ComponentModel;
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
    //Сделать кнопку для перевода в следующую стадию. Если не хватает прав, то открывать окно с ошибкой
    public partial class AllOrdersVM : ObservableValidator
    {
        private IOrderService _orderService;

        public AllOrdersVM(IOrderService orderService)
        {
            //_userService = userService;
            //Users = new ObservableCollection<User>(_userService.GetAllAsync().Result);
            _orderService = orderService;
            Orders = new ObservableCollection<Order>(_orderService.GetAllAsync().Result);
        }

        public ObservableCollection<Order> Orders { get; set; }


        [RelayCommand]
        public void NextStateOrder()
        {
            
        }

        [ObservableProperty]
        private User selectedOrder;

        [RelayCommand]
        public void ViewOrder()
        {
            
        }

        [RelayCommand]
        public void CancelOrderUser()
        {
            
        }

        private void UpdateOrdersCollection()
        {
            
        }
    }
}
