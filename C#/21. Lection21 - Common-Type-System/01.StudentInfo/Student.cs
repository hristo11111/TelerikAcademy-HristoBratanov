using System;

public enum Specialties
{
    ComputerScience = 1,
    Mathematics = 2,
    Informatics = 3,
    BusinessAdministration = 4,
    ComunicationTechnologies = 5
}

public enum Universities
{
    TechnicalUniversity = 1,
    SofiaUniversity = 2,
    UNSS = 3,
    NewBulgarianUniversity = 4    
}

public enum Faculties
{
    FacultyOfEconomics = 1,
    FacultiOfMathematics = 2
}

class Student : ICloneable, IComparable<Student>
{
    public string FirstName { get; private set; }
    public string MiddleName { get; private set; }
    public string LastName { get; private set; }
    public ulong SSN { get; private set; }
    public string PermanentAddress { get; private set; }
    public ulong MobilePhone { get; private set; }
    public string EMail { get; private set; }
    public byte Course { get; set; }
    public Specialties Specialty { get; private set; }
    public Universities University { get; private set; }
    public Faculties Faculty { get; private set; }

    public Student()
    {
    }

    public Student(string firstName, string middleName, string lastName, ulong ssn, string permanentAdress = null,
        ulong mobilePhone = 0, string eMail = null, byte course = 0, Specialties specialty = 0, Universities university = 0,
        Faculties faculty = 0) : this()
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
        this.SSN = ssn;
        this.PermanentAddress = permanentAdress;
        this.MobilePhone = mobilePhone;
        this.EMail = eMail;
        this.Course = course;
        this.Specialty = specialty;
        this.University = university;
        this.Faculty = faculty;
    }

    public override bool Equals(object param)
    {
        Student student = param as Student;
        if (student == null)
        {
            return false;
        }

        if (!Object.Equals(this.FirstName, student.FirstName) || !Object.Equals(this.MiddleName, student.MiddleName) || !Object.Equals(this.LastName, student.LastName)
            || !Object.Equals(this.PermanentAddress,student.PermanentAddress) || !Object.Equals(this.EMail, student.EMail))
        {
            return false;
        }

        if (this.SSN != student.SSN || this.MobilePhone != student.MobilePhone || this.Course != student.Course || this.Specialty != student.Specialty
            || this.University != student.University || this.Faculty != student.Faculty)
        {
            return false;
        }
        return true;
    }

    public static bool operator ==(Student student1, Student student2)
    {
        return Student.Equals(student1, student2);
    }

    public static bool operator !=(Student student1, Student student2)
    {
        return !Student.Equals(student1, student2);
    }

    public override int GetHashCode()
    {
        return FirstName.GetHashCode() ^ SSN.GetHashCode();
    }

    public override string ToString()
    {
        return string.Format("Student: {0} {1} {2}\nSSN: {3}\nPermanentAddress: {4}\nMobile phone: {5}\nE-mail: {6}\nCourse: {7}\nSpecialty: {8}\nUniversity: {9}\nFaculty: {10}", 
            this.FirstName, this.MiddleName, this.LastName, this.SSN, this.PermanentAddress, this.MobilePhone, this.EMail, 
            this.Course, this.Specialty, this.University, this.Faculty);
    }

    public object Clone()
    {
        Student student = new Student();

        student.FirstName = (string)this.FirstName.Clone();
        student.MiddleName = (string)this.MiddleName.Clone();
        student.LastName = (string)this.LastName.Clone();
        student.SSN = this.SSN;
        if (IsNull(this.PermanentAddress))
        {
            this.PermanentAddress = string.Empty;
        }
        student.PermanentAddress = (string)this.PermanentAddress.Clone();
        student.MobilePhone = this.MobilePhone;
        if (IsNull(this.EMail))
        {
            this.EMail = string.Empty;
        }
        student.EMail = (string)this.EMail.Clone();
        student.Course = this.Course;
        student.Specialty = this.Specialty;
        student.University = this.University;
        student.Faculty = this.Faculty;
        return student;
    }

    public bool IsNull(object obj)
    {
        if (obj == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int CompareTo(Student student)
    {
        
        if (student.FirstName.CompareTo(this.FirstName) > 0)
        {
            return -1;
        }

        if (student.FirstName.CompareTo(this.FirstName) < 0)
        {
            return 1;
        }

        if (student.SSN > this.SSN)
        {
            return -1;
        }

        if (student.SSN < this.SSN)
        {
            return 1;
        }

        return 0;
    }
}


