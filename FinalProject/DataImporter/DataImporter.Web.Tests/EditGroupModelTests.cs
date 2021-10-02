using Autofac.Extras.Moq;
using DataImporter.Transfer.Services;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace DataImporter.Web.Tests
{
    [ExcludeFromCodeCoverage]
    public class EditGroupModelTests
    {
        private AutoMock _mock;
        private Mock<IGroupService> _groupServiceMock;

        

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mock = AutoMock.GetLoose();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _mock?.Dispose();
        }

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void EditGroup_GroupExits_LoadPropety()
        {
            Assert.Pass();
        }
    }
}