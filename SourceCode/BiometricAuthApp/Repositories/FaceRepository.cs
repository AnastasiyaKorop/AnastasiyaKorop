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
    public class FaceRepository
    {

        public async Task<List<Face>> GetAll()
        {
            await using var context = new AppDbContext();

            return await context.Faces.AsNoTracking().ToListAsync();
        }

        public async Task<Face> Add(Face face)
        {
            await using var context = new AppDbContext();

            context.Faces.Add(face);
            await context.SaveChangesAsync();
            return face;
        }

    }
}
