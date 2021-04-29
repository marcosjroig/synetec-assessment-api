﻿using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Domain;
using System;
using System.Collections.Generic;

namespace SynetecAssessmentApi.Persistence
{
    public class DbContextGenerator : IDisposable
    {
        public AppDbContext AppContext { get; set; }

        public DbContextGenerator()
        {
            var databaseName = "HrDb_" + DateTime.Now.ToFileTimeUtc();
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;

            AppContext = new AppDbContext(options);

            SeedData();
        }
        
        private void SeedData()
        {
            var departments = new List<Department>
            {
                new Department(1, "Finance", "The finance department for the company"),
                new Department(2, "Human Resources", "The Human Resources department for the company"),
                new Department(3, "IT", "The IT support department for the company"),
                new Department(4, "Marketing", "The Marketing department for the company")
            };

            var employees = new List<Employee>
            {
                new Employee(1, "John Smith", "Accountant (Senior)", 60000, 1),
                new Employee(2, "Janet Jones", "HR Director", 90000, 2),
                new Employee(3, "Robert Rinser", "IT Director", 95000, 3),
                new Employee(4, "Jilly Thornton", "Marketing Manager (Senior)", 55000, 4),
                new Employee(5, "Gemma Jones", "Marketing Manager (Junior)", 45000, 4),
                new Employee(6, "Peter Bateman", "IT Support Engineer", 35000, 3),
                new Employee(7, "Azimir Smirkov", "Creative Director", 62500, 4),
                new Employee(8, "Penelope Scunthorpe", "Creative Assistant", 38750, 4),
                new Employee(9, "Amil Kahn", "IT Support Engineer", 36000, 3),
                new Employee(10, "Joe Masters", "IT Support Engineer", 36500, 3),
                new Employee(11, "Paul Azgul", "HR Manager", 53000, 2),
                new Employee(12, "Jennifer Smith", "Accountant (Junior)", 48000, 1),
            };

            AppContext.Departments.AddRange(departments);
            AppContext.Employees.AddRange(employees);

            AppContext.SaveChanges();
        }

        public void Dispose()
        {
            AppContext.Dispose();
        }
    }
}
