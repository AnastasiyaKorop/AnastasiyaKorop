using BiometricAuthApp.Data;
using BiometricAuthApp.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricAuthApp.Repositories
{
    public class ClientEmployeeService
    {
        private readonly AppDbContext _context = new();

        public List<Employee> GetEmployees()
        {
            try
            {
                return _context.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Не удается получить данные о Работниках", ex);
            }
        }

        public List<Client> GetClients()
        {
            try
            {
                return _context.Clients.ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Не удается получить данные о Клиентах", ex);
            }
        }

        public List<ClientEmployeeConnection> GetClientsConnections()
        {
            try
            {
                return _context.ClientEmployeeConnections.ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Не удается получить данные о связи клиентов с работниками", ex);
            }
        }

        public void AddClientEmployee(Client client, Employee employee)
        {
            try
            {
                var connection = _context.ClientEmployeeConnections.FirstOrDefault(c => c.UserId == client.Id && c.EmployeeId == employee.Id);
                if (connection != null)
                {
                    throw new InvalidDataException("Не удается добавить связь клиента и работника, она уже существует!");
                }
                _context.ClientEmployeeConnections.Add(new ClientEmployeeConnection() { UserId = client.Id, EmployeeId = employee.Id });
                _context.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw new InvalidDataException("Не удается добавить связь клиента и работника", ex);
            }
        }

        public void RemoveClientEmployee(ClientEmployeeConnection connection)
        {
            try
            {
                
                _context.ClientEmployeeConnections.Remove(connection);
                _context.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw new InvalidDataException("Не удается удалить связь клиента и работника", ex);
            }
        }

    }
}
