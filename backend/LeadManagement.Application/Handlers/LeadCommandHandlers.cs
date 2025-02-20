using MediatR;
using LeadManagement.Domain.Events;
using LeadManagement.Domain.Commands;
using LeadManagement.Domain.Interfaces;

namespace LeadManagement.Application.Handlers
{
    public class AcceptLeadCommandHandler : IRequestHandler<AcceptLeadCommand>
    {
        private readonly ILeadRepository _leadRepository;

        public AcceptLeadCommandHandler(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<Unit> Handle(AcceptLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _leadRepository.GetLeadByIdAsync(request.LeadId);
            if (lead == null) throw new KeyNotFoundException("Lead not found");

            lead.Accept();
            await _leadRepository.UpdateLeadAsync(lead);
            System.IO.File.WriteAllText("email.txt", $"E-mail sent to vendas@test.com: Lead {lead.Id} accepted.");
            await _leadRepository.PublishEventAsync(new LeadAcceptedEvent(lead.Id, lead.Price));

            return Unit.Value;
        }

        Task IRequestHandler<AcceptLeadCommand>.Handle(AcceptLeadCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }

    public class DeclineLeadCommandHandler : IRequestHandler<DeclineLeadCommand>
    {
        private readonly ILeadRepository _leadRepository;

        public DeclineLeadCommandHandler(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<Unit> Handle(DeclineLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _leadRepository.GetLeadByIdAsync(request.LeadId);
            if (lead == null) throw new KeyNotFoundException("Lead not found");

            lead.Decline();
            await _leadRepository.UpdateLeadAsync(lead);
            await _leadRepository.PublishEventAsync(new LeadDeclinedEvent(lead.Id));

            return Unit.Value;
        }

        Task IRequestHandler<DeclineLeadCommand>.Handle(DeclineLeadCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}