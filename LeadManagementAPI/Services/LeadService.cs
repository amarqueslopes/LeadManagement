using LeadManagementAPI.Models;
using LeadManagementAPI.Repositories.Interfaces;
using LeadManagementAPI.Services.Interfaces;

namespace LeadManagementAPI.Services
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
            if (lead.Price > 500) lead.Price *= 0.9m; // Aplica 10% de desconto

            // Simula envio de e-mail
            System.IO.File.WriteAllText("email.txt", $"Email enviado para vendas@test.com: Lead {lead.Id} aceito.");

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
