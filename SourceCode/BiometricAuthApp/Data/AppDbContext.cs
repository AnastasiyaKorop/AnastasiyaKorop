using System.Configuration;
using BiometricAuthApp.Models;
using BiometricAuthApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;

namespace BiometricAuthApp.Data
{
    public class AppDbContext : DbContext, IDisposable
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Face> Faces { get; set; }
        public DbSet<FilesKey> FilesKeys { get; set; }
        public DbSet<EncodeKey> EncodeKeys { get; set; }
        public DbSet<ClientEmployeeConnection> ClientEmployeeConnections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            options.UseSqlServer(connectionString);
        }

        public override int SaveChanges()
        {
            EncryptSensitiveData();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            EncryptSensitiveData();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void EncryptSensitiveData()
        {
            // Шифрование для сущности Employees
            foreach (var entry in ChangeTracker.Entries<Employee>()
                         .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (!string.IsNullOrEmpty(entry.Entity.EmployeeCode))
                {
                    entry.Entity.EmployeeCode = CustomEncryptService.GetInstance().Encrypt(entry.Entity.EmployeeCode);
                }
                if (!string.IsNullOrEmpty(entry.Entity.PositionCode))
                {
                    entry.Entity.PositionCode = CustomEncryptService.GetInstance().Encrypt(entry.Entity.PositionCode);
                }
                if (!string.IsNullOrEmpty(entry.Entity.LastName))
                {
                    entry.Entity.LastName = CustomEncryptService.GetInstance().Encrypt(entry.Entity.LastName);
                }
                if (!string.IsNullOrEmpty(entry.Entity.FirstName))
                {
                    entry.Entity.FirstName = CustomEncryptService.GetInstance().Encrypt(entry.Entity.FirstName);
                }
                if (!string.IsNullOrEmpty(entry.Entity.MiddleName))
                {
                    entry.Entity.MiddleName = CustomEncryptService.GetInstance().Encrypt(entry.Entity.MiddleName);
                }
                if (!string.IsNullOrEmpty(entry.Entity.Phone))
                {
                    entry.Entity.Phone = CustomEncryptService.GetInstance().Encrypt(entry.Entity.Phone);
                }
                if (!string.IsNullOrEmpty(entry.Entity.Address))
                {
                    entry.Entity.Address = CustomEncryptService.GetInstance().Encrypt(entry.Entity.Address);
                }

                if (entry.Entity.DateOfBirth != null)
                {
                    entry.Entity.EncryptedDateOfBirth = CustomEncryptService.GetInstance().Encrypt(entry.Entity.DateOfBirth.ToString());
                }
                if (entry.Entity.Photo != null && entry.Entity.Photo.Length > 0)
                {
                    entry.Entity.Photo = CustomEncryptService.GetInstance().Encrypt(entry.Entity.Photo);
                }
            }

            foreach (var entry in ChangeTracker.Entries<Client>()
                         .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (!string.IsNullOrEmpty(entry.Entity.LastName))
                {
                    entry.Entity.LastName = CustomEncryptService.GetInstance().Encrypt(entry.Entity.LastName);
                }
                if (!string.IsNullOrEmpty(entry.Entity.FirstName))
                {
                    entry.Entity.FirstName = CustomEncryptService.GetInstance().Encrypt(entry.Entity.FirstName);
                }
                if (!string.IsNullOrEmpty(entry.Entity.MiddleName))
                {
                    entry.Entity.MiddleName = CustomEncryptService.GetInstance().Encrypt(entry.Entity.MiddleName);
                }
                if (entry.Entity.DateOfBirth != null)
                {
                    entry.Entity.EncryptedDateOfBirth = CustomEncryptService.GetInstance().Encrypt(entry.Entity.DateOfBirth.ToString());
                }
                if (!string.IsNullOrEmpty(entry.Entity.Gender))
                {
                    entry.Entity.Gender = CustomEncryptService.GetInstance().Encrypt(entry.Entity.Gender);
                }
                if (!string.IsNullOrEmpty(entry.Entity.Address))
                {
                    entry.Entity.Address = CustomEncryptService.GetInstance().Encrypt(entry.Entity.Address);
                }
                if (!string.IsNullOrEmpty(entry.Entity.Phone))
                {
                    entry.Entity.Phone = CustomEncryptService.GetInstance().Encrypt(entry.Entity.Phone);
                }
                if (!string.IsNullOrEmpty(entry.Entity.Passport))
                {
                    entry.Entity.Passport = CustomEncryptService.GetInstance().Encrypt(entry.Entity.Passport);
                }
                if (!string.IsNullOrEmpty(entry.Entity.BU))
                {
                    entry.Entity.BU = CustomEncryptService.GetInstance().Encrypt(entry.Entity.BU);
                }
            }

            foreach (var entry in ChangeTracker.Entries<Face>()
                         .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Entity.data != null && entry.Entity.data.Length > 0)
                {
                    entry.Entity.data = CustomEncryptService.GetInstance().Encrypt(entry.Entity.data);
                }
                if (!string.IsNullOrEmpty(entry.Entity.Name))
                {
                    entry.Entity.Name = CustomEncryptService.GetInstance().Encrypt(entry.Entity.Name);
                }
            }

            foreach (var entry in ChangeTracker.Entries<User>()
                         .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (!string.IsNullOrEmpty(entry.Entity.Username))
                {
                    entry.Entity.Username = CustomEncryptService.GetInstance().Encrypt(entry.Entity.Username);
                }
                if (!string.IsNullOrEmpty(entry.Entity.PasswordHash))
                {
                    entry.Entity.PasswordHash = CustomEncryptService.GetInstance().Encrypt(entry.Entity.PasswordHash);
                }
                if (!string.IsNullOrEmpty(entry.Entity.Role))
                {
                    entry.Entity.Role = CustomEncryptService.GetInstance().Encrypt(entry.Entity.Role);
                }
            }

            foreach (var entry in ChangeTracker.Entries<FilesKey>()
                         .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Entity.Key != null && entry.Entity.Key.Length > 0)
                {
                    entry.Entity.Key = CustomEncryptService.GetInstance().Encrypt(entry.Entity.Key);
                }
                if (entry.Entity.Vi != null && entry.Entity.Vi.Length > 0)
                {
                    entry.Entity.Vi = CustomEncryptService.GetInstance().Encrypt(entry.Entity.Vi);
                }
            }
            foreach (var entry in ChangeTracker.Entries<EncodeKey>()
                         .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Entity.Key != null && entry.Entity.Key.Length > 0)
                {
                    entry.Entity.Key = CustomEncryptService.DesEncrypt(entry.Entity.Key);
                }
                if (entry.Entity.Vi != null && entry.Entity.Vi.Length > 0)
                {
                    entry.Entity.Vi = CustomEncryptService.DesEncrypt(entry.Entity.Vi);
                }
            }

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Дешифрование данных для Employees
            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeCode)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PositionCode)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);

            modelBuilder.Entity<Employee>()
                .Property(e => e.MiddleName)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Phone)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Address)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EncryptedDateOfBirth)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Photo)
                .HasConversion(
                    v => v,
                    v => v != null && v.Length > 0 ? CustomEncryptService.GetInstance().Decrypt(v) : v);


            //client
            modelBuilder.Entity<Client>()
                .Property(e => e.LastName)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);
            modelBuilder.Entity<Client>()
                .Property(e => e.FirstName)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);
            modelBuilder.Entity<Client>()
                .Property(e => e.MiddleName)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);
            modelBuilder.Entity<Client>()
                .Property(e => e.EncryptedDateOfBirth)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);
            modelBuilder.Entity<Client>()
                .Property(e => e.Gender)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);
            modelBuilder.Entity<Client>()
                .Property(e => e.Address)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);
            modelBuilder.Entity<Client>()
                .Property(e => e.Phone)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);
            modelBuilder.Entity<Client>()
                .Property(e => e.Passport)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);
            modelBuilder.Entity<Client>()
                .Property(e => e.BU)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);

            //faces
            modelBuilder.Entity<Face>()
                .Property(e => e.data)
                .HasConversion(
                    v => v,
                    v => v != null && v.Length > 0 ? CustomEncryptService.GetInstance().Decrypt(v) : v);
            modelBuilder.Entity<Face>()
                .Property(e => e.Name)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);

            //User
            
            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);
            modelBuilder.Entity<User>()
                .Property(e => e.PasswordHash)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);
            modelBuilder.Entity<User>()
                .Property(e => e.Role)
                .HasConversion(
                    v => v,
                    v => !string.IsNullOrEmpty(v) ? CustomEncryptService.GetInstance().Decrypt(v) : v);
            //FileKey
            modelBuilder.Entity<FilesKey>()
                .Property(e => e.Key)
                .HasConversion(
                    v => v,
                    v => v != null && v.Length > 0 ? CustomEncryptService.GetInstance().Decrypt(v) : v);
            modelBuilder.Entity<FilesKey>()
                .Property(e => e.Vi)
                .HasConversion(
                    v => v,
                    v => v != null && v.Length > 0 ? CustomEncryptService.GetInstance().Decrypt(v) : v);
            //EncodeKey
            modelBuilder.Entity<EncodeKey>()
                .Property(e => e.Key)
                .HasConversion(
                    v => v,
                    v => v != null && v.Length > 0 ? CustomEncryptService.DesDecrypt(v) : v);
            modelBuilder.Entity<EncodeKey>()
                .Property(e => e.Vi)
                .HasConversion(
                    v => v,
                    v => v != null && v.Length > 0 ? CustomEncryptService.DesDecrypt(v) : v);
        }
    }
}
