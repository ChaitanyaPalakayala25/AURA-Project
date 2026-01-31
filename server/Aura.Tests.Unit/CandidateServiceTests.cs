using Aura.Core.DTOs;
using Aura.Core.Entities;
using Aura.Core.Interfaces;
using Aura.Core.Services;
using Moq;
using Xunit;

namespace Aura.Tests.Unit;

public class CandidateServiceTests
{
    private readonly Mock<ICandidateRepository> _candidateRepoMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<INotificationService> _notificationMock;
    private readonly Mock<IDocumentService> _documentMock;
    private readonly CandidateService _candidateService;

    public CandidateServiceTests()
    {
        _candidateRepoMock = new Mock<ICandidateRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _notificationMock = new Mock<INotificationService>();
        _documentMock = new Mock<IDocumentService>();
        
        _unitOfWorkMock.Setup(u => u.Candidates).Returns(_candidateRepoMock.Object);
        
        _candidateService = new CandidateService(
            _unitOfWorkMock.Object, 
            _notificationMock.Object
        );
    }

    [Fact]
    public async Task UpdateCandidate_ShouldFail_WhenITSignsOffBeforeHR()
    {
        // Arrange
        var candidateId = 1;
        var existingCandidate = new CandidateData 
        { 
            Id = candidateId, 
            RecruiterTimestamp = DateTime.UtcNow,
            ManagerTimestamp = DateTime.UtcNow,
            HrTimestamp = null // HR NOT DONE
        };

        var dto = new CandidateDTO 
        { 
            ItTimestamp = DateTime.UtcNow // IT TRYING TO SIGN OFF
        };

        _candidateRepoMock.Setup(r => r.GetByIdAsync(candidateId)).ReturnsAsync(existingCandidate);

        // Act
        var result = await _candidateService.UpdateCandidateAsync(candidateId, dto);

        // Assert
        Assert.False(result); // Should fail validation
        _unitOfWorkMock.Verify(u => u.CompleteAsync(), Times.Never);
    }

    [Fact]
    public async Task UpdateCandidate_ShouldSucceed_WhenSequentialStepsFollowed()
    {
        // Arrange
        var candidateId = 1;
        var existingCandidate = new CandidateData 
        { 
            Id = candidateId, 
            RecruiterTimestamp = DateTime.UtcNow,
            ManagerTimestamp = DateTime.UtcNow,
            HrTimestamp = DateTime.UtcNow // HR DONE
        };

        var dto = new CandidateDTO 
        { 
            ItTimestamp = DateTime.UtcNow // IT NOW ALLOWED
        };

        _candidateRepoMock.Setup(r => r.GetByIdAsync(candidateId)).ReturnsAsync(existingCandidate);
        _unitOfWorkMock.Setup(u => u.CompleteAsync()).ReturnsAsync(1);

        // Act
        var result = await _candidateService.UpdateCandidateAsync(candidateId, dto);

        // Assert
        Assert.True(result);
        _unitOfWorkMock.Verify(u => u.CompleteAsync(), Times.Once);
    }
}
