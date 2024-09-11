using Gymnast.Api.Data;
using Gymnast.Api.DTO;
using Gymnast.Api.Interfaces;
using Gymnast.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Gymnast.Api.Services;

public class MatchService: IMatchService
{
    private readonly AppDbContext _context;
    
    public MatchService(AppDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<MatchDto>> GetMatchesAsync()
    {
        return await _context.Matches
            .Select(m => new MatchDto()
            {
                Id = m.Id,
                Name = m.Name,
                StartTime = m.StartTime,
                EndTime = m.EndTime,
                Location = m.Location,
                
            })
            .ToListAsync();
    }

    public async Task<MatchDto> GetMatchAsync(int id)
    {
        var match = await _context.Matches
            .Where(m => m.Id == id)
            .Select(m => new MatchDto
            {
                Id = m.Id,
                Name = m.Name,
                Location = m.Location,
                StartTime = m.StartTime,
                EndTime = m.EndTime,
            })
            .FirstOrDefaultAsync();
        return match;
    }

    public async Task<MatchDto> CreateMatchAsync(CreateMatchDto createMatchDto)
    {
        var newMatch = new Match()
        {
            Name = createMatchDto.Name,
            Location = createMatchDto.Location,
            StartTime = createMatchDto.StartTime,
            EndTime = createMatchDto.StartTime + TimeSpan.FromHours(2),
        };
        
        _context.Matches.Add(newMatch);
        await _context.SaveChangesAsync();

        var matchDto = new MatchDto()
        {
            Id = newMatch.Id,
            Name = newMatch.Name,
            Location = newMatch.Location,
            StartTime = newMatch.StartTime,
            EndTime = newMatch.EndTime
        };
        return matchDto;
    }
    

}