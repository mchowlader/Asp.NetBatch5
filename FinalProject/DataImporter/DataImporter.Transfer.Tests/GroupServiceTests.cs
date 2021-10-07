using Autofac.Extras.Moq;
using AutoMapper;
using DataImporter.Common.Utilities;
using DataImporter.Transfer.BusinessObjects;
using DataImporter.Transfer.Repositories;
using DataImporter.Transfer.Services;
using DataImporter.Transfer.UnitOfWorks;
using Moq;
using NUnit.Framework;
using Shouldly;
using System;

namespace DataImporter.Transfer.Tests
{
    public class GroupServiceTests
    {

        private AutoMock _mock;
        private Mock<ITransferUnitOfWork> _traingUnitOfWork;
        private Mock<IGroupRepository> _groupRepository;
        private Mock<IMapper> _mapperMock;
        private IGroupService _groupService;
        private DateTimeUtility _dateTimeUtility;


        [OneTimeSetUp]
        public void ClassSetup()
        {
            _mock = AutoMock.GetLoose();
        }

        [OneTimeTearDown]
        public void ClassCleanUp()
        {
            _mock?.Dispose();
        }
        [SetUp]
        public void Setup()
        {
            _mapperMock = _mock.Mock<IMapper>();
            _traingUnitOfWork = _mock.Mock<ITransferUnitOfWork>();
            _groupRepository = _mock.Mock<IGroupRepository>();
            _groupService = _mock.Create<GroupService>();
            _dateTimeUtility = _mock.Create<DateTimeUtility>();

        }
        [TearDown]
        public void TearDown()
        {
            _mapperMock?.Reset();
            _traingUnitOfWork?.Reset();
            _groupRepository?.Reset();
        }
        [Test]
        public void GroupCreate_GroupNameDoseNotExit_ThrowsException()
        {
            //Arrange
            Group group = null;

            //Act & Assert
            Should.Throw<InvalidOperationException>(
                () => _groupService.CreateGroup(group)
            );
        }
        [Test]
        public void GroupCreate_GroupDoseNotExit_ThrowsException()
        {
            //Arrange

            Group group = new Group()
            { 
                GroupName = null
            
            };

            //Act & Assert
            Should.Throw<InvalidOperationException>(
                () => _groupService.CreateGroup(group)
            );
        }
    }
}