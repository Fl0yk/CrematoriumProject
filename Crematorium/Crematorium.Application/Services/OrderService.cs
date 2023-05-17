using Crematorium.Application.Abstractions;
using Crematorium.Domain.Abstractions;
using Crematorium.Domain.Entities;

namespace Crematorium.Application.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        public OrderService(IUnitOfWork unitOfWork) 
        {
            _repository = unitOfWork.OrderRepository;
        }

        public Task CancelOrder(int Id)
        {
            var order = _repository.GetByIdAsync(Id).Result;
            CancelOrder(ref order);

            return Task.CompletedTask;
        }

        public Task CancelOrder(ref Order? order)
        {
            if (order is null || order.State == StateOrder.Closed)
                return Task.CompletedTask;

            order.State = StateOrder.Cancelled;

            return Task.CompletedTask;
        }

        public Task NextState(int Id)
        {
            var order = _repository.GetByIdAsync(Id).Result;
            if (order is null)
                return Task.CompletedTask;

            switch(order.State)
            {
                case StateOrder.Decorated:
                    order.State = StateOrder.Approved;
                    break;

                case StateOrder.Approved:
                    order.State = StateOrder.Closed;
                    break;
            }

            return Task.CompletedTask;
        }

        public Task NextState(ref Order? order)
        {
            if (order is null)
                return Task.CompletedTask;

            switch (order.State)
            {
                case StateOrder.Decorated:
                    order.State = StateOrder.Approved;
                    break;

                case StateOrder.Approved:
                    order.State = StateOrder.Closed;
                    break;
            }

            return Task.CompletedTask;
        }
    }
}
