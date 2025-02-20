namespace LeadManagement.Domain.Events
{
    public class LeadAcceptedEvent
    {
        public int LeadId { get; }
        public decimal Price { get; }

        public LeadAcceptedEvent(int leadId, decimal price)
        {
            LeadId = leadId;
            Price = price;
        }
    }

    public class LeadDeclinedEvent
    {
        public int LeadId { get; }

        public LeadDeclinedEvent(int leadId)
        {
            LeadId = leadId;
        }
    }
}