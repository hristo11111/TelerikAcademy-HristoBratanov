using System;
using System.Globalization;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }
        private DateTime birthDate { get; set; }

        public bool IsOlderThan(Student other)
        {
            this.birthDate = DateTime.ParseExact(this.OtherInfo.Substring(this.OtherInfo.Length - 10), 
                "dd.MM.yyyy", CultureInfo.InvariantCulture);
            DateTime firstDate = this.birthDate;

            other.birthDate = DateTime.ParseExact(other.OtherInfo.Substring(other.OtherInfo.Length - 10), 
                "dd.MM.yyyy", CultureInfo.InvariantCulture);
            DateTime secondDate = other.birthDate;

            return firstDate < secondDate;
        }
    }
}
