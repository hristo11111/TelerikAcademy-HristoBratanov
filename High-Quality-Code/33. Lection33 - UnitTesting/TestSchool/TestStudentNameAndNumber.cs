using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSchool
{
    [TestClass]
    public class TestStudentNameAndNumber
    {
        //Student's name tests
        [TestMethod]
        public void TestStudentNameIfValidInput()
        {
            Student student = new Student("Ivan", 12455);
            Assert.AreEqual("Ivan", student.Name, "The student's name is not valid");
        }

        [ExpectedException(typeof(ArgumentNullException), 
            "The student's name cannot be empty")]
        [TestMethod]
        public void TestStudentNameIfNameEmpty()
        {
            Student student = new Student("", 12455);
        }

        [ExpectedException(typeof(ArgumentNullException), 
            "The student's name cannot be null")]
        [TestMethod]
        public void TestStudentNameIfNameNull()
        {
            Student student = new Student(null, 12455);
        }

        [ExpectedException(typeof(ArgumentNullException), 
            "The student's name cannot be empty spaces")]
        [TestMethod]
        public void TestStudentNameIfNameIsEmptySpaces()
        {
            Student student = new Student("     ", 12455);
        }

        //Student's number tests
        [TestMethod]
        public void TestStudentNumberIfValidInput()
        {
            Student student = new Student("Ivan", 12455);
            Assert.AreEqual(12455, student.StudentNumber, 
                "The student's number is not valid");
        }

        [ExpectedException(typeof(ArgumentException), 
            "The student's number cannot be less than 10000")]
        [TestMethod]
        public void TestStudentNumberifNumberLessThan10000()
        {
            Student student = new Student("Ivan", 9999);
        }

        [ExpectedException(typeof(ArgumentException), 
            "The student's number cannot be more than 99999")]
        [TestMethod]
        public void TestStudentNumberifNumberMoreThan99999()
        {
            Student student = new Student("Ivan", 100000);
        }
    }
}
