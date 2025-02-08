using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using BiometricAuthApp.Data;
using BiometricAuthApp.Models;
using BiometricAuthApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BiometricAuthApp.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _repository = new();
        private static byte[] _defaultPhoto;

        private byte[] GetDefaultPhoto()
        {
            if (_defaultPhoto != null) return _defaultPhoto;

            // Создаем пустое изображение 100x100 пикселей
            using (var bitmap = new Bitmap(100, 100))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                // Заполняем белым цветом
                graphics.Clear(Color.White);
                // Рисуем рамку
                using (var pen = new Pen(Color.Gray))
                {
                    graphics.DrawRectangle(pen, 0, 0, 99, 99);
                }

                // Конвертируем в массив байтов
                using (var ms = new MemoryStream())
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    _defaultPhoto = ms.ToArray();
                }
            }

            return _defaultPhoto;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _repository.GetAllAsync();
            
            // Заменяем null фотографии на фото по умолчанию
            foreach (var employee in employees)
            {
                if (employee.Photo == null || employee.Photo.Length == 0)
                {
                    employee.Photo = GetDefaultPhoto();
                }
            }

            return employees;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee.Photo == null || employee.Photo.Length == 0)
            {
                employee.Photo = GetDefaultPhoto();
            }
            return employee;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.FirstName) || string.IsNullOrWhiteSpace(employee.LastName))
            {
                throw new ArgumentException("First name and last name are required");
            }

            if (employee.Photo == null || employee.Photo.Length == 0)
            {
                employee.Photo = GetDefaultPhoto();
            }

            return await _repository.AddAsync(employee);
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            if (employee.Id <= 0)
            {
                throw new ArgumentException("Invalid employee ID");
            }

            if (employee.Photo == null || employee.Photo.Length == 0)
            {
                employee.Photo = GetDefaultPhoto();
            }

            return await _repository.UpdateAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
