using BiometricAuthApp.Data;
using BiometricAuthApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BiometricAuthApp.Services
{
    public class AuthService
    {
        public async Task<User> Authenticate(string username, string password)
        {
            try
            {
                await using var context = new AppDbContext();

                if (context.Users.IsNullOrEmpty())
                {

                    var newUser = new User() { PasswordHash = "password123", Username = "admin1", Role = "Admin" };
                    context.Users.Add(newUser);
                    await context.SaveChangesAsync();
                    return newUser;
                }

                var list = await context.Users.AsNoTracking().ToListAsync();

                var el = list.Find(u => u.Username == username && u.PasswordHash == password);
                if( el != null )
                    return el;
                throw new UnauthorizedAccessException("Нзеверный логин или пароль");
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Ошибка авторизации: {ex.Message}");
                throw;
            }
        }
        public async Task<User> FindUserByName(string username)
        {
            try
            {
                await using var context = new AppDbContext();
                var users = await context.Users.AsNoTracking().ToListAsync();
                var user = users.Find(x => x.Username == username);

                if (user != null)
                {
                    return user;
                }

                throw new UnauthorizedAccessException("Неверный логин");
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Ошибка авторизации: {ex.Message}");
                throw;
            }
        }

        public async Task<List<User>> FindAllUser()
        {
            try
            {
                await using var context = new AppDbContext();
                var users = context.Users.ToList();

                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Ошибка авторизации: {ex.Message}");
                throw;
            }
        }

        public async Task ChangePassword(string username, string oldPassword, string newPassword, string repeatPassword)
        {
            try
            {
                if (string.IsNullOrEmpty(newPassword))
                {
                    throw new ArgumentNullException("Пароль должен быть!");
                }
                if (newPassword != repeatPassword)
                {
                    throw new ArgumentException("Пароли не совпадают");
                }

                await using var context = new AppDbContext();
                var list = await context.Users.AsNoTracking().ToListAsync();

                var el = list.Find(u => u.Username == username && u.PasswordHash == oldPassword);
                if (el == null)
                {
                    throw new ArgumentException("Нет пользователя с таким именем и паролем");
                }

                el.PasswordHash = newPassword;
                context.Update(el);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Ошибка авторизации: {ex.Message}");
                throw;
            }
        }

        internal async Task AddUser(string username, string password, string passwordRepeat)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException("Имя должно быть!");
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("Пароль должен быть!");

            if (password != passwordRepeat)
            {
                throw new ArgumentException("Пароли не совпадают");
            }
            try
            {
                await using var context = new AppDbContext();
                var users = context.Users.FirstOrDefault((a) => a.Username == username);
                if (users != null)
                {
                    throw new ArgumentException("Пользователь с таким именем уже существует!");
                }
                var newUser = new User() { PasswordHash = password, Username = username, Role = "Admin" };
                context.Users.Add(newUser);
                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Ошибка создания пользователя: {ex.Message}");
                throw;
            }
        }
    }
}