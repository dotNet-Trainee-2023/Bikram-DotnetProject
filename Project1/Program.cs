
namespace Project1
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<Employee> employees = ReadEmployeeFromCsv("C:\\Users\\bikram.shrestha\\source\\repos\\employees.csv");
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine($"First Name: {employee.Salary}");
            //}

            Console.WriteLine("---LINQ Expression--");

            // Group the employees by their department.
            var employeesByDepartment = employees
                .GroupBy(e => e.Department);
            foreach (var group in employeesByDepartment)
            {
                foreach (var employee in group)
                {
                    Console.WriteLine($" Department: {group.Key} {employee.FirstName} {employee.LastName} ");
                }
            }


            //Find highest salary earning Project Manager.
            var highestSalaryProjectManager = employees
                .Where(e => e.JobTitle == "Project Manager")
                .OrderByDescending(e => e.Salary)
                .FirstOrDefault();
            Console.WriteLine($"The highest salary of Project manager is {highestSalaryProjectManager.Salary}");

            //Find the most experienced Web Developer.
            var mostExperiencedWebDeveloper= employees
                .Where(e=>e.JobTitle=="Web Developer")
                .OrderByDescending(e=>e.Years)
                .FirstOrDefault();
            Console.WriteLine($"The most experienced Web developer is with their experienceyear is{mostExperiencedWebDeveloper.FirstName} and {mostExperiencedWebDeveloper.Years} years");

            //Find the average salary of all Job Title.
            var averageSalaryOfJobTitle = employees
                .GroupBy(e => e.JobTitle);
            foreach (var jobgroup in averageSalaryOfJobTitle)
            {
                string jobTitle = jobgroup.Key;
                decimal averageSalary = jobgroup.Average(e => (decimal.Parse(e.Salary)));

                Console.WriteLine($"Job Title: {jobTitle}");
                Console.WriteLine($"Average Salary: {averageSalary}");
                Console.WriteLine();
            }


            // Find total number of male and female employees.
            var countNoOfEmployees = employees.GroupBy(e => e.Gender);
            foreach (var group in countNoOfEmployees)
            {
                var count = group.Count();
                Console.WriteLine($"Number of {group.Key} Employees: {count} ");
            }



        }

        //listing the employee in list 
        static List<Employee> ReadEmployeeFromCsv(string path)
        {
            var result = new List<Employee>();
            var lines=File.ReadAllLines(path);

            foreach (var line in lines.Skip(1))
            {
                var word = line.Split(',');
                result.Add(new Employee
                {
                    FirstName = word[0],
                    LastName = word[1],
                    Email = word[2],
                    PhoneNumber = word[3],
                    Gender = word[4],
                    Age = word[5],
                    JobTitle = word[6],
                    Years = word[7],
                    Salary = word[8],
                    Department = word[9]
                });
            }
            return result;
        }
    }
}