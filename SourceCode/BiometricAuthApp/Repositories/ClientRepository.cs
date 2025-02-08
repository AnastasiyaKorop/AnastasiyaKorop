using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BiometricAuthApp.Models;
using BiometricAuthApp.Data;

namespace BiometricAuthApp.Repositories
{
    public class ClientRepository
    {
        private readonly AppDbContext _context = new();

        public async Task<List<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> AddAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            // Повторное чтение из базы для дешифрования
            var decryptedClient = await _context.Clients.AsNoTracking().FirstOrDefaultAsync(a => a.Id == client.Id);
            return decryptedClient;
        }

        public async Task UpdateAsync(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }
    }
}
