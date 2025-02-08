using BiometricAuthApp.Services;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiometricAuthApp.Models
{
    public class Employee
    {
        [DisplayName("ID")] public int Id { get; set; }

        [DisplayName("Код сотрудника")] public string EmployeeCode { get; set; }

        [DisplayName("Код должности")] public string PositionCode { get; set; }

        [DisplayName("Фамилия")] public string LastName { get; set; }

        [DisplayName("Имя")] public string FirstName { get; set; }

        [DisplayName("Отчество")] public string MiddleName { get; set; }

        [DisplayName("Дата рождения")] public string EncryptedDateOfBirth { get; set; }

        [NotMapped]
        public DateTime? DateOfBirth
        {
            get => !string.IsNullOrEmpty(EncryptedDateOfBirth)
                ? DateTime.Parse(EncryptedDateOfBirth)
                : (DateTime?)null;
            set => EncryptedDateOfBirth = value.HasValue
                ? value.Value.ToString("yyyy-MM-dd")
                : null;
        }

        [DisplayName("Телефон")] public string Phone { get; set; }

        [DisplayName("Адрес")] public string Address { get; set; }

        [DisplayName("Фото")] public byte[] Photo { get; set; }
    }
}