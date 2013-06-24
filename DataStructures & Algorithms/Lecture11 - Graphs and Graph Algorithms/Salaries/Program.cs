using System;
using System.Collections.Generic;

// problem "Заплати" http://bgcoder.com/Contest/Practice/103 100/100

class Program
{
    static bool[] visited = new bool[51];

    static bool[] hasEmployee = new bool[51];

    static void Main()
    {
        int C = int.Parse(Console.ReadLine());

        int[,] employeeBoard = new int[C, C];

        List<Employee> allEmployees = new List<Employee>();

        for (int i = 0; i < C; i++)
        {
            Employee employee = new Employee(new List<Employee>(), i);
            allEmployees.Add(employee);

            string line = Console.ReadLine();

            for (int letterIndex = 0; letterIndex < line.Length; letterIndex++)
            {
                if (line[letterIndex] == 'Y')
                {
                    employeeBoard[i, letterIndex] = 1;
                }
            }
        }

        bool[] hasEmployee = RefreshBoard(employeeBoard, allEmployees);

        ProcessBoard(C, employeeBoard, allEmployees);

        bool noTrues = false;

        while (!noTrues)
        {
            bool hasTrue = true;
            for (int i = 0; i < C; i++)
            {
                if (hasEmployee[i] == true)
                {
                    hasTrue = false;
                    ProcessBoard(C, employeeBoard, allEmployees);
                }
            }

            if (hasTrue)
            {
                noTrues = true;
            }
        }
        

        ulong result = CalculateSalaries(allEmployees);
        Console.WriteLine(result);
    }

    private static void ProcessBoard(int C, int[,] employeeBoard, List<Employee> allEmployees)
    {
        for (int i = 0; i < C; i++)
        {
            if (hasEmployee[i] == false && visited[i] == false)
            {
                visited[i] = true;

                if (allEmployees[i].Salary == 0)
                {
                    allEmployees[i].Salary = 1;
                }

                SetBossessSalaries(allEmployees[i]);
                DeleteEmployee(allEmployees[i], employeeBoard);
                RefreshBoard(employeeBoard, allEmployees);
            }
        }
    }

    private static bool[] RefreshBoard(int[,] employeeBoard, List<Employee> allEmployees)
    {
        for (int i = 0; i < allEmployees.Count; i++)
        {
            allEmployees[i].Bosses.Clear();
            hasEmployee[i] = false;
        }

        for (int i = 0; i < employeeBoard.GetLength(0); i++)
        {
            for (int j = 0; j < employeeBoard.GetLength(1); j++)
            {
                if (employeeBoard[i, j] == 1)
                {
                    allEmployees[j].AddBoss(allEmployees[i]);
                    hasEmployee[i] = true;
                }
            }
        }
        return hasEmployee;
    }

    private static void DeleteEmployee(Employee employee, int[,] employeeBoard)
    {
        for (int i = 0; i < employeeBoard.GetLength(0); i++)
        {
            employeeBoard[i, employee.ID] = 0;
        }
    }

    private static ulong CalculateSalaries(List<Employee> allEmployees)
    {
        ulong result = 0;
        foreach (var item in allEmployees)
        {
            result += item.Salary;
        }

        return result;
    }

    private static void SetBossessSalaries(Employee employee)
    {
        foreach (var boss in employee.Bosses)
        {
            boss.Salary += employee.Salary;
        }
    }
}

class Employee
{
    public List<Employee> Bosses { get; set; }
    public int ID { get; set; }
    public ulong Salary { get; set; }

    public Employee(List<Employee> bosses, int id)
    {
        this.Bosses = bosses;
        this.ID = id;
    }

    public void AddBoss(Employee boss)
    {
        this.Bosses.Add(boss);
    }
}