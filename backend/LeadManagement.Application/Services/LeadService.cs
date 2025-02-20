using LeadManagement.Domain.Models;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Application.Interfaces;

namespace LeadManagement.Application.Services
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;

        public LeadService(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<IEnumerable<Lead>> GetInvitedLeadsAsync()
        {
            return await _leadRepository.GetInvitedLeadsAsync();
        }

        public async Task AcceptLeadAsync(int id)
        {
            var lead = await _leadRepository.GetLeadByIdAsync(id);
            if (lead == null) throw new KeyNotFoundException("Lead not found");

            lead.Status = "Accepted";
            if (lead.Price > 500) lead.Price *= 0.9m;

            System.IO.File.WriteAllText("email.txt", $"E-mail sent to vendas@test.com: Lead {lead.Id} accepted.");

            await _leadRepository.UpdateLeadAsync(lead);
        }

        public async Task DeclineLeadAsync(int id)
        {
            var lead = await _leadRepository.GetLeadByIdAsync(id);
            if (lead == null) throw new KeyNotFoundException("Lead not found");

            lead.Status = "Declined";
            await _leadRepository.UpdateLeadAsync(lead);
        }
    }
}
