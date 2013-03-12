using System;

class Test
{
    static void Main()
    {
        Student st = new Student("Petyr", "Petrov", "Tydjarov", 456789, "address", 123456, "eMail@mail.bg", 2, Specialties.BusinessAdministration,
            Universities.TechnicalUniversity, Faculties.FacultyOfEconomics);
        Console.WriteLine(st.FirstName);
        Console.WriteLine(st.Faculty);
        Console.WriteLine(st.MiddleName);
        Console.WriteLine(st.LastName);
        Student st2 = new Student("Petyr", "Petrov", "Tydjarov", 456789, "address", 123456, "eMail@mail.bg", 2, Specialties.BusinessAdministration,
            Universities.TechnicalUniversity, Faculties.FacultyOfEconomics);
        Console.WriteLine(st2.FirstName);
        Console.WriteLine(st2.University);
        Console.WriteLine(st2.Faculty);
        Console.WriteLine(st2.Specialty);
        Console.WriteLine(st2.SSN);
        Console.WriteLine(st.Equals(st2));
        Console.WriteLine(st.GetHashCode());

        Console.WriteLine(st == st2);
        Console.WriteLine(st != st2);
        Console.WriteLine(st);

        Student st3 = (Student)st.Clone();
        st3.Course = 4;
        st.Course = 3;
        Console.WriteLine(st3 == st);
        Console.WriteLine(st3);

        Console.WriteLine(st.CompareTo(st2)); 
    }
}
