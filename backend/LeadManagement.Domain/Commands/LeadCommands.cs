using MediatR;

namespace LeadManagement.Domain.Commands
{
    public record AcceptLeadCommand : IRequest
    {
        public int LeadId { get; }

        public AcceptLeadCommand(int leadId)
        {
            LeadId = leadId;
        }
    }

    public class DeclineLeadCommand : IRequest
    {
        public int LeadId { get; }

        public DeclineLeadCommand(int leadId)
        {
            LeadId = leadId;
        }
    }
}