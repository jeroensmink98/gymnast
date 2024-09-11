using Gymnast.Api.DTO;
using Gymnast.Api.Interfaces;
using Gymnast.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymnast.Api.Data;
using Gymnast.Api.DTO;

namespace Gymnast.Api.Services
{
    public class GymnastService : IGymnastService
    {
        private readonly AppDbContext _context;

        public GymnastService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GymnastDto>> GetGymnastsAsync()
        {
            return await _context.Gymnasts
                .Select(g => new GymnastDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Date = g.Date
                })
                .ToListAsync();
        }

        public async Task<GymnastDto> GetGymnastAsync(int id)
        {
            var gymnast = await _context.Gymnasts
                .Where(g => g.Id == id)
                .Select(g => new GymnastDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Date = g.Date
                })
                .FirstOrDefaultAsync();
            return gymnast;
        }

        public async Task<GymnastDto> CreateGymnastAsync(CreateGymnastDto gymnastDto)
        {
            var gymnast = new Models.Gymnast
            {
                Name = gymnastDto.Name,
                Date = DateTime.Now
            };

            _context.Gymnasts.Add(gymnast);
            await _context.SaveChangesAsync();
            
            
            var gymnastDtoResult = new GymnastDto
            {
                Id = gymnast.Id,
                Name = gymnast.Name,
                Date = gymnast.Date
            };

            return gymnastDtoResult;
        }
        
        public async Task<bool> DeleteGymnastAsync(int id)
        {
            var gymnast = await _context.Gymnasts.FindAsync(id);
            if (gymnast == null) return false;

            _context.Gymnasts.Remove(gymnast);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
