using DripChipProject.Models;
using DripChipProject.Models.ResponseModels.Locations;

namespace DripChipProject.Services.ServiceInterfaces
{
    public interface ILocationService
    {
        AnimalLocation? GetLocation(long pointId);
        AnimalLocation? GetLocation(EditCreateLocation location);
        AnimalLocation AddLocation(EditCreateLocation location);
        AnimalLocation EditLocation(long pointid, EditCreateLocation location);
        void DeleteLocation(long pointId);
    }
}
