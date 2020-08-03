using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Mini_Assignment.Controllers;
using Mini_Assignment.Models;
using Mini_Assignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Mini_Assignment_Tests
{
    public class SubjectTest
    {

        private readonly ISubjectService _subjectService;
       
        public SubjectTest()
        {
            var context = GetDbContext();
            _subjectService = new SubjectService(context);
        }

        [Fact]
        public async void Add_Subject_Test()
        {
            
            var subject = new Subject()
            {
                Name = "ICT"
            };

            
            var savedSubject = await _subjectService.AddSubjectAsync(subject);

            //check the savedSubject Id
            //savedSubject.Id.Should().Be(1);

            //check the savedSubject Name
            savedSubject.Name.Should().Be("ICT","Subject name is ICT");
           

        }

     

        [Fact]
        public async void Get_All_Subjects_Test()
        {
            
            var subjectList = await _subjectService.GetSubjectListAsync();

            // Assert
            //subjectList.Should().BeEmpty(); 

            var subject1 = new Subject()
            {
              Name = "CS"
            };

           var subject2 = new Subject()
            {  
                Name = "SE"
            };


            
            await _subjectService.AddSubjectAsync(subject1);
            await _subjectService.AddSubjectAsync(subject2);

            subjectList = await _subjectService.GetSubjectListAsync();


            // Assert

            //check whether student list is not empty
            subjectList.Should().NotBeEmpty();

            //checkig the count of the student list
            //subjectList.Should().HaveCount(2);

            //check whether student object is in the list
            subjectList.Should().Contain(subjectList,subject1);

            //check whether student1 object is in the list
            subjectList.Should().Contain(subjectList,subject2);

            
            
           
        }

        [Fact]
        public async void Get_One_Subject_Test()
        {
           
            
           var subject1 = new Subject()
            {
               
                Name = "CS"

            };

           var subject2 = new Subject()
            {
               
                Name = "SE"

            };

            await _subjectService.AddSubjectAsync(subject1);
            await _subjectService.AddSubjectAsync(subject2);

            var chosenSubject1 = await _subjectService.GetOneSubjectAsync(1);
            var chosenSubject2 = await _subjectService.GetOneSubjectAsync(2);

            //check the chosenSubject1 Name property
            chosenSubject1.Name.Should().Be("CS");

            //check the chosenSubject2 Name Property
            chosenSubject2.Name.Should().Be("SE");

           



        }

        [Fact]
        public async void Update_Subject_Test()
        {
           
            var SubjectToBeUpdated = new Subject()
            {
                Name = "CS"
            };

            await _subjectService.AddSubjectAsync(SubjectToBeUpdated);

            var subject = new Subject()
            {
               Name = "Computer Science"
            };

            var modifiedSubject = await _subjectService.UpdateSubjectAsync(SubjectToBeUpdated,subject);


            //check the Subject Id
           // modifiedSubject.Id.Should().Be(1);

            //check the Subject Name
            modifiedSubject.Name.Should().Be("Computer Science");

        }

        [Fact]
        public async void Delete_Subject_Test()
        {
           
            Subject subject = new Subject()
            {
                Name = "CS"
            };

            var subjectList = await _subjectService.GetSubjectListAsync();

            //checking whether the subject list is empty
            //subjectList.Should().BeEmpty();

            var createdSubject = await _subjectService.AddSubjectAsync(subject);

            //checking whether the subject list is not empty
            subjectList.Should().NotBeEmpty();

            var deletedSubject = await _subjectService.DeleteSubjectAsync(createdSubject);

            //chcking the deleted subject Id
            //deletedSubject.Id.Should().Be(1);

            //checking the deleted subject Name
            deletedSubject.Name.Should().Be("CS");

            //checking whether the subject list is empty
            //subjectList.Should().BeEmpty();



           


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
