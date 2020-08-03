using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Mini_Assignment.Controllers;
using Mini_Assignment.Models;
using Mini_Assignment.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Mini_Assignment_Tests
{
    public class StudentTest
    {
        private readonly IStudentService _studentService;
        public StudentTest()
        {
            var context = GetDbContext();
            _studentService = new StudentService(context);
        }


       [Fact]
       public async void Add_Student_Test()
        {

            var student = new Student()
            {
                UserName = "Pasindu",
                Password = "123",
                Addreess = "Colombo",
                MobileNo = "0112345678"
             
            };
            
            var createdStudent = await _studentService.CreateStudentAsync(student);

            //check the created student object's id
            //createdStudent.Id.Should().Be(1);

            //check the created student object's name
            createdStudent.UserName.Should().Be("Pasindu");

            //check the created student object's password
            createdStudent.Password.Should().Be("123");

            //check the created student object's Address
            createdStudent.Addreess.Should().Be("Colombo");

            //check the created student object's Mobils No
            createdStudent.MobileNo.Should().Be("0112345678");

        }
        [Fact]
        public async void Get_All_Students_Test()
        {
           
           var student1 = new Student()
            {
                UserName = "Pasindu",
                Password = "123",
                Addreess = "Colombo",
                MobileNo = "0112345678"

            };


            var student2 = new Student()
            {
                UserName = "Locahana",
                Password = "12311",
                Addreess = "Maharagama",
                MobileNo = "0112345690"

            };

            await _studentService.CreateStudentAsync(student1);
            await _studentService.CreateStudentAsync(student2);

           var studentList = await _studentService.GetAllStudentsAsync();


            //check whether student list is not empty
            studentList.Should().NotBeEmpty();

            //checkig the count of the student list
            //studentList.Should().HaveCount(2);

            //check whether student object is in the list
            studentList.Should().Contain(studentList, student1);

            //check whether student1 object is in the list
            studentList.Should().Contain(studentList, student2);

        }

        [Fact]
        public async void Get_One_Student_Test()
        {
           
            var student = new Student()
            {
               
                UserName = "Pasindu",
                Password = "123",
                Addreess = "Colombo",
                MobileNo = "0112345678"

            };

            Student student1 = new Student()
            {
               
                UserName = "Locahana",
                Password = "123",
                Addreess = "Colombo",
                MobileNo = "0112345678"

            };

            await _studentService.CreateStudentAsync(student);
            await _studentService.CreateStudentAsync(student1);

            var chosenStudent1 = await _studentService.GetAsync(1);
            var chosenStudent2 = await _studentService.GetAsync(2);


            //check the chosenStudent1 Name property
            //chosenStudent1.UserName.Should().Be("Pasindu");

            //check the chosenStudent2 Name Property
            //chosenStudent2.UserName.Should().Be("Locahana");

            



        }

        [Fact]
        public async void Update_Student_Test()
        {
           
             Student StudentToBeUpdated = new Student()
            {
               
                UserName = "Pasindu",
                Password = "123",
                Addreess = "Colombo",
                MobileNo = "0112345678"

            };


            await _studentService.CreateStudentAsync(StudentToBeUpdated);


            Student student = new Student()
            {
              
                UserName = "Hewa",
                Password = "1234567",
                Addreess = "Colombo 07",
                MobileNo = "0111111111"
            };

            var modifiedStudent = await _studentService.UpdateStudentAsync(StudentToBeUpdated,student);

            //check the Subject Id
           // modifiedStudent.Id.Should().Be(1);

            //check the Subject Name
            modifiedStudent.UserName.Should().Be("Pasindu");

            //check the Subject Name
            modifiedStudent.Password.Should().Be("1234567");

            //check the Subject Name
            modifiedStudent.Addreess.Should().Be("Colombo 07");

            //check the Subject Name
            modifiedStudent.MobileNo.Should().Be("0111111111");




        }

        [Fact]
        public async void Delete_Student_Test()
        {
            
            var student = new Student()
            {
               
                UserName = "Pasindu",
                Password = "123",
                Addreess = "Colombo",
                MobileNo = "0112345678"

            };

            var studentList = await _studentService.GetAllStudentsAsync();

            //checking whether the subject list is empty
            //studentList.Should().BeEmpty();


            var createdStudent = await _studentService.CreateStudentAsync(student);

            //checking whether the student list is not empty
            studentList.Should().NotBeEmpty();


            var deletedStudent = await _studentService.DeleteAsync(createdStudent);

            studentList = await _studentService.GetAllStudentsAsync();



            //chcking the deleted subject Id
            //deletedStudent.Id.Should().Be(1);

            //checking the deleted subject Name
            deletedStudent.UserName.Should().Be("Pasindu");

            //checking whether the subject list is empty
            //studentList.Should().BeEmpty();



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
