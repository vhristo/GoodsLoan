using AutoMapper;
using GoodsLoan.Application.UseCases.Loans;
using GoodsLoan.Core.DTOs;
using GoodsLoan.Core.Entities;
using GoodsLoan.Core.Interfaces;
using Moq;

namespace GoodsLoan.UnitTests
{
    public class LoanServiceTests
    {
        private readonly Mock<ILoanRepository> _repoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly LoanService _service;

        public LoanServiceTests()
        {
            _repoMock = new Mock<ILoanRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new LoanService(_repoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetLoans_ShouldCallRepo()
        {
            // Arrange
            _repoMock.Setup(x => x.GetLoans()).ReturnsAsync(new List<Loan>());

            // Act
            var result = await _service.GetLoans();

            // Assert
            _repoMock.Verify(x => x.GetLoans(), Times.Once);
        }

        [Fact]
        public async Task GetLoanStatusSummary_ShouldCallRepo()
        {
            // Arrange
            _repoMock.Setup(x => x.GetLoanStatusSummary()).ReturnsAsync(new List<LoanStatusSummaryDto>());

            // Act
            var result = await _service.GetLoanStatusSummary();

            // Assert
            _repoMock.Verify(x => x.GetLoanStatusSummary(), Times.Once);
        }
    }
}
