using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.Domain.Entities
{
    public class Order : Entity
    {
        public User Customer { get; set; } = null!;
        public DateTime? RegistrationDate { get; init; }

        public StateOrder State { get; set; } = StateOrder.Decorated;

        public DateTime? DateOfStart { get; init; }

        public Corpose CorposeId { get; init; } = null!;

        public RitualUrn RitualUrnId { get; init; } = null!;

        public Hall HallId { get; init; } = null!;
    }

    public enum StateOrder
    {
        Decorated,  //оформленный
        Approved,   //подтвержденный
        Closed,     //закрытый
        Cancelled   //отмененный
    }
}
