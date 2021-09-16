using Autofac.Extras.Moq;
using AutoMapper;
using ExamTimeChallenge.Training.BusinessObjects;
using ExamTimeChallenge.Training.Repositories;
using ExamTimeChallenge.Training.Services;
using ExamTimeChallenge.Training.UnitOfWorks;
using Moq;
using NUnit.Framework;
using Shouldly;
using System;
using EO = ExamTimeChallenge.Training.Entities;

namespace ExamTimeChallenge.Training.Tests
{
    public class CourseServiceTests
    {
        private AutoMock _mock;
        private Mock<IMapper>  _mapperMock;
        private ICourseService _courseService;
        private Mock<ITrainingUnitOfWork>  _trainingUnitOfWork;
        private Mock<ICourseRepository> _courseRepositoryMock;

        [OneTimeSetUp]
        public void ClassSetup()
        {
            _mock = AutoMock.GetLoose();
        }

        [OneTimeTearDown]
        public void ClassCleanup()
        {
            _mock?.Dispose();
        }

        [SetUp]
        public void TestSetup()
        {
            _mapperMock = _mock.Mock<IMapper>();
            _courseService = _mock.Create<CourseService>();
            //_courseRepositoryMock = _mock.Mock<ICourseRepository>();
            //_trainingUnitOfWork = _mock.Mock<ITrainingUnitOfWork>();
        }

        [TearDown]
        public void TestCleanup()
        {
            _mapperMock.Reset();
            //_courseRepositoryMock.Reset();
            //_trainingUnitOfWork.Reset();
        }

        [Test]
        public void UpdateCourse_CourseDoseNotExit_ThrowsException()
        {
            //Arrange

            Course course = null;
            //var id = 5;

            //var courseEntity = new EO.Course()
            //{
            //    Title = "Asp.Net",
            //    Fees = 30000,
            //    Id = 5
            //};


            //_trainingUnitOfWork.Setup(x => x.Courses).Returns(_courseRepositoryMock.Object);
            //_courseRepositoryMock.Setup(x => x.GetById(id)).Returns(courseEntity);


            //Act & Assert
            Should.Throw<InvalidOperationException>(
                () => _courseService.UpdateCourse(course)
            );
        }
    }
}