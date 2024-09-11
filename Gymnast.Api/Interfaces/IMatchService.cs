using Gymnast.Api.DTO;
using Gymnast.Api.Models;

namespace Gymnast.Api.Interfaces;

public interface IMatchService
{
    public Task<IEnumerable<MatchDto>> GetMatchesAsync();
    
    public Task<MatchDto> GetMatchAsync(int id);
    
    public Task<MatchDto> CreateMatchAsync(CreateMatchDto createMatchDto);
}