using LeadManagement.Domain.Models;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Application.Interfaces;
using LeadManagement.Domain.Events;

namespace LeadManagement.Application.Services
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;

        public LeadService(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<IEnumerable<Lead>> GetLeadsByStatusAsync(string status)
        {
            return await _leadRepository.GetLeadsByStatusAsync(status);
        }

        public async Task AcceptLeadAsync(int id)
        {
            var lead = await _leadRepository.GetLeadByIdAsync(id);
            if (lead == null) throw new KeyNotFoundException("Lead not found");

            lead.Accept();

            await _leadRepository.UpdateLeadAsync(lead);
            System.IO.File.WriteAllText("email.txt", $"E-mail sent to vendas@test.com: Lead {lead.Id} accepted.");
            await _leadRepository.PublishEventAsync(new LeadAcceptedEvent(lead.Id, lead.Price));
        }

        public async Task DeclineLeadAsync(int id)
        {
            var lead = await _leadRepository.GetLeadByIdAsync(id);
            if (lead == null) throw new KeyNotFoundException("Lead not found");

            lead.Decline();
            await _leadRepository.UpdateLeadAsync(lead);
            await _leadRepository.PublishEventAsync(new LeadDeclinedEvent(lead.Id));
        }
    }
}
