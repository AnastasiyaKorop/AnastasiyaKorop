using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BiometricAuthApp.Data;
using BiometricAuthApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BiometricAuthApp.Repositories
{
    public class EmployeeRepository
    {
        public async Task<List<Employee>> GetAllAsync()
        {
            using var context = new AppDbContext();
            return context.Employees.ToList();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            await using var context = new AppDbContext();
            var employee = await context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found");
            }
            return employee;
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            await using var context = new AppDbContext();
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            await using var context = new AppDbContext();
            var existingEmployee = await context.Employees.FindAsync(employee.Id);
            if (existingEmployee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {employee.Id} not found");
            }

            context.Entry(existingEmployee).CurrentValues.SetValues(employee);
            await context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteAsync(int id)
        {
            await using var context = new AppDbContext();
            var employee = await context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found");
            }

            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
        }
    }
}
