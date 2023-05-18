namespace Crematorium.Domain.Entities
{
    public class Order : Base
    {
        public User Customer { get; set; } = null!;
        //public Date? RegistrationDate { get; set; }

        public StateOrder State { get; set; } = StateOrder.Decorated;

        public Date DateOfStart { get; set; } = null!;

        public Corpose CorposeId { get; set; } = null!;

        public RitualUrn RitualUrnId { get; set; } = null!;

        public Hall HallId { get; set; } = null!;
    }

    public enum StateOrder
    {
        Decorated,  //оформленный
        Approved,   //подтвержденный
        Closed,     //закрытый
        Cancelled   //отмененный
    }
}
