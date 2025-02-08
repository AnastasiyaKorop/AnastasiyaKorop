using BiometricAuthApp.Data;
using BiometricAuthApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricAuthApp.Repositories
{
    public class FilesKeyRepository
    {
        private readonly AppDbContext _context = new();

        public async Task<FilesKey> Add(byte[] key, byte[] vi)
        {
            var filesKey = new FilesKey() { Key = key, Vi = vi };
            _context.FilesKeys.Add(filesKey);
            await _context.SaveChangesAsync();

            // Повторное чтение из базы для дешифрования
            var fkDb = await _context.FilesKeys.AsNoTracking().FirstOrDefaultAsync(a => a.Id == filesKey.Id);
            return fkDb;
        }

        public async Task<FilesKey?> FindById(int id)
        {
            return await _context.FilesKeys.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
