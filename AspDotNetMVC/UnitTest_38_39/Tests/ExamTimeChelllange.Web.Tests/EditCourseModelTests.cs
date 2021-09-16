using Autofac.Extras.Moq;
using AutoMapper;
using ExamTimeChallenge.Training.BusinessObjects;
using ExamTimeChallenge.Training.Services;
using ExamTimeChallenge.Web.Areas.Admin.Models;
using Moq;
using NUnit.Framework;

namespace ExamTimeChelllange.Web.Tests
{
    public class EditCourseModelTests
    {
        private AutoMock _mock;
        private EditCourseModel _model;
        private Mock<IMapper> _mapperMock;
        private Mock<ICourseService> _courseServiceMock;

        [OneTimeSetUp]
        public void ClassSetUp()
        {
            _mock = AutoMock.GetLoose();
        }

        [OneTimeTearDown]
        public void ClassClean()
        {
            _mock?.Dispose();
        }

        [SetUp]
        public void TestSetup()
        {
            _mapperMock = _mock.Mock<IMapper>();
            _model = _mock.Create<EditCourseModel>();
            _courseServiceMock = _mock.Mock<ICourseService>();
        }

        [TearDown]
        public void TestCleanUp()
        {
            _courseServiceMock?.Reset();
            _mapperMock.Reset();

        }

        [Test]
        public void LoadModelData_CourseExits_LoadProperties()
        {
            //Arrange 
            const int id = 5;
            var course = new Course
            {
                Title = "Asp.Net",
                Fees = 30000,
                Id = 5
            };

            _courseServiceMock.Setup(x => x.GetCourseData(id)).Returns(course).Verifiable();
            _mapperMock.Setup(x => x.Map(course, It.IsAny<EditCourseModel>())).Verifiable();

            //Act
            _model.LoadModelData(id);

            //Assert
            _courseServiceMock.VerifyAll();
            _mapperMock.VerifyAll();
        }
    }
}