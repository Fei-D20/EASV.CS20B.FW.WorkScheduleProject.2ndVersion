using Moq;
using Xunit;

namespace CS20.FW.WorkSchedule.Domain.Test.IRepositoryTest
{
    public class IWorkRecordRepositoryTest
    {
        private readonly Mock<IWorkRecordRepository> _mockWorkRepository;

        public IWorkRecordRepositoryTest()
        {
            _mockWorkRepository = new Mock<IWorkRecordRepository>();

        }

        [Fact]
        public void IWorkRecordRepository_IsAvailable()
        {
            Assert.NotNull(_mockWorkRepository);
        }
    }

    public interface IWorkRecordRepository
    {
    }
}