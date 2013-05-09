using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSchool
{
    [TestClass]
    public class TestCourse
    {
        [ExpectedException(typeof(ArgumentOutOfRangeException), 
            "The number of students in course cannot be less than 1")]
        [TestMethod]
        public void TestCourseRemoveStudentIfCountLessThan1()
        {
            Course course = new Course("Maths");
            course.RemoveStudentByNumber(22);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "The number of students cannot be more than 30")]
        [TestMethod]
        public void TestCourseAddStudentIfCountMoreThan30()
        {
            Course course = new Course("Maths");
            for (int i = 0; i <= 30; i++)
            {
                course.AddStudent(new Student("ivan", 10001 + i));
            }
        }

        [TestMethod]
        public void TestCourseRemoveStudentIfCorrectRemoval()
        {
            Course course = new Course("Maths");
            course.Students.Add(new Student("Petyr", 10002));
            course.Students.Add(new Student("Nikola", 10003));
            course.RemoveStudentByNumber(10002);
            Assert.AreEqual(1, course.Students.Count, 
                "The students count does not change as expected");
        }

        [TestMethod]
        public void TestCourseRemoveStudentIfIncorrectRemoval()
        {
            Course course = new Course("Maths");
            course.Students.Add(new Student("Petyr", 10002));
            course.Students.Add(new Student("Nikola", 10003));
            course.RemoveStudentByNumber(10004);
            Assert.AreEqual(2, course.Students.Count, 
                "The students changes but not expected");
        }
    }
}
