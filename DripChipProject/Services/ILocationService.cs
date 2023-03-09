using DripChipProject.Models;
namespace DripChipProject.Services
{
    public interface ILocationService
    {
        AnimalLocation? GetLocation(long pointId);
    }
}
