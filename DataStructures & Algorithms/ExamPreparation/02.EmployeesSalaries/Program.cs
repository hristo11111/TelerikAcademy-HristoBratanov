using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.EmployeesSalaries
{
    class Program
    {
        static int salaries = 0;

        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());

            string bigBossName = Console.ReadLine();
            Employee bigBoss = new Employee(bigBossName);

            Dictionary<string, Employee> employees = new Dictionary<string,Employee>();
            employees.Add(bigBossName, bigBoss);

            for (int i = 1; i < N; i++)
            {
                string name = Console.ReadLine();
                Employee employee = new Employee(name);
                employees.Add(name, employee);
            }

            for (int i = 0; i < M; i++)
            {
                string[] names = Console.ReadLine().Split(' ');
                string superiorName = names[0];

                for (int j = 1; j < names.Length; j++)
                {
                    employees[superiorName].AddSubordinate(employees[names[j]]);
                }
            }

            DFS(employees[bigBossName]);
            Console.WriteLine(salaries);
        }

        private static void DFS(Employee employee)
        {
            if (employee.Subordinates.Count == 0)
            {
                employee.Salary = 1;
            }
            

            foreach (var subordinate in employee.Subordinates)
            {
                DFS(subordinate);
                employee.Salary += subordinate.Salary;
            }
            salaries += employee.Salary;
        }
    }

    class Employee
    {
        public string Name { get; private set; }
        public int Salary { get; set; }
        public List<Employee> Subordinates { get; private set; }

        public Employee(string name)
        {
            this.Name = name;
            this.Salary = 0;
            this.Subordinates = new List<Employee>();
        }

        public void AddSubordinate(Employee employee)
        {
            this.Subordinates.Add(employee);
        }
    }
}
