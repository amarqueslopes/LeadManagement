using LeadManagement.Domain.Models;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Application.Services;
using Moq;

namespace LeadManagementBackend.Tests.Application;

public class LeadServiceTests
{
    private readonly Mock<ILeadRepository> _mockRepo;
    private readonly LeadService _leadService;

    public LeadServiceTests()
    {
        _mockRepo = new Mock<ILeadRepository>();
        _leadService = new LeadService(_mockRepo.Object);
    }

    [Fact]
    public async Task AcceptLeadAsync_ShouldApplyDiscount_WhenPriceIsAbove500()
    {
        // Arrange
        var lead = new Lead { Id = 1, Price = 600, Status = "Invited" };
        _mockRepo.Setup(repo => repo.GetLeadByIdAsync(1)).ReturnsAsync(lead);

        // Act
        await _leadService.AcceptLeadAsync(1);

        // Assert
        Assert.Equal(540, lead.Price); // 10% discount applied
        Assert.Equal("Accepted", lead.Status);
        _mockRepo.Verify(repo => repo.UpdateLeadAsync(lead), Times.Once);
    }

    [Fact]
    public async Task DeclineLeadAsync_ShouldUpdateStatus_ToDeclined()
    {
        // Arrange
        var lead = new Lead { Id = 1, Status = "Invited" };
        _mockRepo.Setup(repo => repo.GetLeadByIdAsync(1)).ReturnsAsync(lead);

        // Act
        await _leadService.DeclineLeadAsync(1);

        // Assert
        Assert.Equal("Declined", lead.Status);
        _mockRepo.Verify(repo => repo.UpdateLeadAsync(lead), Times.Once);
    }
}