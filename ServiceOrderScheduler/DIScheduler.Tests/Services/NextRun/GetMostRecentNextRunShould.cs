using System;
using DIScheduler.template.Core.Interfaces.Repositories;
using DIScheduler.template.Core.Model;
using DIScheduler.template.Core.Model.Enums;
using DIScheduler.template.Core.Services;
using Moq;
using NUnit.Framework;

namespace DIScheduler.Tests.Services.NextRun
{
    [TestFixture]
    public class GetMostRecentNextRunShould
    {
        private NextRunService _nextRunService;
        private Mock<INextRunRepository> _mockNextRunRepo;
        private Mock<IServiceStateRepository> _mockServiceStateRepo;

        [SetUp]
        public void SetUp()
        {
            _mockNextRunRepo = new Mock<INextRunRepository>();
            _mockServiceStateRepo = new Mock<IServiceStateRepository>();
            _nextRunService = new NextRunService(_mockNextRunRepo.Object, _mockServiceStateRepo.Object);
        }

        [Test]
        public void ReturnNullGivenNoNextRunRowAndStatusIsHealthy()
        {
            //Setup
            _mockNextRunRepo.Setup(r => r.GetMostRecent()).Returns((Core.Model.NextRun)null);
            _mockServiceStateRepo.Setup(s => s.GetStatus(It.IsAny<string>())).Returns(new ServiceStatus { ID = 1, Status = ServiceStatusTypeValues.Healthy });

            //Act
            Core.Model.NextRun result = _nextRunService.GetMostRecentNextRun();

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void ReturnNullGivenNoNextRunRowAndStatusIsError()
        {
            //Setup
            _mockNextRunRepo.Setup(r => r.GetMostRecent()).Returns((Core.Model.NextRun)null);
            _mockServiceStateRepo.Setup(s => s.GetStatus(It.IsAny<string>())).Returns(new ServiceStatus { ID = 1, Status = ServiceStatusTypeValues.Error });

            //Act
            Core.Model.NextRun result = _nextRunService.GetMostRecentNextRun();

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void ReturnMostRecentRunGivenThereIsDataAndServiceIsHealthy()
        {
            //Setup
            var expectedNextRun = new Core.Model.NextRun
            {
                RunComplete = new DateTime(2018, 07, 01)
            };
            _mockNextRunRepo.Setup(r => r.GetMostRecent()).Returns(expectedNextRun);
            _mockServiceStateRepo.Setup(s => s.GetStatus(It.IsAny<string>())).Returns(new ServiceStatus { ID = 1, Status = ServiceStatusTypeValues.Healthy });

            //Act
            Core.Model.NextRun result = _nextRunService.GetMostRecentNextRun();

            //Assert
            Assert.AreEqual(expectedNextRun.RunComplete, result.RunComplete);
        }

        [Test]
        public void ReturnMostRecentRunGivenThereIsDataAndServiceIsError()
        {
            //Setup
            var expectedNextRun = new Core.Model.NextRun
            {
                RunComplete = new DateTime(2018, 07, 01)
            };
            _mockNextRunRepo.Setup(r => r.GetMostRecent()).Returns(expectedNextRun);
            _mockServiceStateRepo.Setup(s => s.GetStatus(It.IsAny<string>())).Returns(new ServiceStatus { ID = 1, Status = ServiceStatusTypeValues.Error });

            //Act
            Core.Model.NextRun result = _nextRunService.GetMostRecentNextRun();

            //Assert
            Assert.AreEqual(expectedNextRun.RunComplete, result.RunComplete);
        }
    }
}
