using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Mini_Assignment.Models;
using Mini_Assignment.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Mini_Assignment_Tests
{
    public class EnrollmentTest
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentTest()
        {

            var context = GetDbContext();
            _enrollmentService = new EnrollmentService(context);


        }
        [Fact]
        public async void Add_Enrollment_Test()
        {
           
           var enrollment = new Enrollment()
            {
            
               StudentId =2,
               SubjectId = 1
               

            };

            var savedEnrollment = await _enrollmentService.AssignSubject(enrollment);

            //check the savedEnrollment Id
            savedEnrollment.Id.Should().Be(1);

            //check the savedEnrollment Student Id
            savedEnrollment.StudentId.Should().Be(2,"Because Student ID is 2");

            //check the savedEnrollment Subject Id
            savedEnrollment.SubjectId.Should().Be(1,"Because Subject id is 1");

        }



        [Fact]
        public async void Get_All_Enrollments_Test()
        {
            

            var EnrollmentList = await _enrollmentService.GetEnrollmentList();

            //Check whether Enrollment List is Empty
           // EnrollmentList.Should().BeEmpty();

            Enrollment enrollment1 = new Enrollment()
            {
                
                StudentId = 1,
                SubjectId = 1


            };

            Enrollment enrollment2 = new Enrollment()
            {
              
                StudentId = 2,
                SubjectId = 2


            };

            await _enrollmentService.AssignSubject(enrollment1);
            await _enrollmentService.AssignSubject(enrollment2);


            EnrollmentList = await _enrollmentService.GetEnrollmentList();



            //check whether enrollment list is not empty
            EnrollmentList.Should().NotBeEmpty("Because this should be consist of 2 enrollment  objects");

            //checkig the count of the enrollment list
            //EnrollmentList.Should().HaveCount(2);

            //check whether enrollment1  object is in the list
            EnrollmentList.Should().Contain(EnrollmentList, enrollment1);

            //check whether enrollment2 object is in the list
            EnrollmentList.Should().Contain(EnrollmentList, enrollment2);

        }
        private StudentDetailContext GetDbContext()
        {
            DbContextOptions<StudentDetailContext> options;
            var builder = new DbContextOptionsBuilder<StudentDetailContext>();
            builder.UseInMemoryDatabase(databaseName: "database_name");
            options = builder.Options;
            StudentDetailContext studentDetailContext = new StudentDetailContext(options);
            return studentDetailContext;

        }
    }
}
