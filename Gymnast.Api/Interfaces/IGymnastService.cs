
using Gymnast.Api.DTO;

namespace Gymnast.Api.Interfaces;

public interface IGymnastService
{
    Task<IEnumerable<GymnastDto>> GetGymnastsAsync();
    Task<GymnastDto> GetGymnastAsync(int gymnastId);
    Task<GymnastDto> CreateGymnastAsync(CreateGymnastDto gymnastDto);
    Task<bool> DeleteGymnastAsync(int gymnastId);
    
}