using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSchool
{
    [TestClass]
    public class TestCourse
    {
        [TestMethod]
        public void CourseRemoveStudentIfCountLessThan1()
        {
            Course course = new Course();
            course.RemoveStudentByNumber(10001);
            int courseCount = course.Students.Count;

            Assert.AreEqual

        }
    }
}
