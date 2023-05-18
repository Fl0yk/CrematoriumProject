using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crematorium.Application.Abstractions;
using Crematorium.Domain.Entities;
using Crematorium.UI.Fabrics;
using Crematorium.UI.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.UI.ViewModels
{
    public partial class UserOrdersVM : ObservableValidator
    {
        private IOrderService _orderService;
        private User curUser = null!;

        public UserOrdersVM(IOrderService orderService)
        {
            _orderService = orderService;
            curUser = ServicesFabric.CurrentUser!;
            Orders = new ObservableCollection<Order>(curUser.Orders);
        }

        public ObservableCollection<Order> Orders { get; set; }

        [ObservableProperty]
        private Order? selectedOrder;

        [RelayCommand]
        public void ViewOrder()
        {
            if (SelectedOrder is null)
                return;

            var orderInfo = (OrderInformationPage)ServicesFabric.GetPage(typeof(OrderInformationPage));
            orderInfo.InitializeOrder(SelectedOrder);
            orderInfo.ShowDialog();
        }

        [RelayCommand]
        public void CancelOrder()
        {
            if (SelectedOrder is null || curUser.UserRole == Role.Employee)
                return;

            _orderService.CancelOrder(ref selectedOrder);
            UpdateOrdersCollection();
        }

        public void UpdateOrdersCollection()
        {
            Orders.Clear();
            foreach (var order in curUser.Orders)
            {
                Orders.Add(order);
            }
        }
    }
}
