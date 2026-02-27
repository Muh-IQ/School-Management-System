using Modules.School.Domain.Entities.Place;

namespace Modules.School.Infrastructure.Persistent.Seeds;

public class CountrySeed : IEntitySeed<Country>
{
    public static readonly Guid IraqId = new("11111111-1111-1111-1111-111111111111");
    public static readonly Guid UnitedStatesId = new("22222222-2222-2222-2222-222222222222");
    public static readonly Guid UnitedKingdomId = new("33333333-3333-3333-3333-333333333333");
    public static readonly Guid CanadaId = new("44444444-4444-4444-4444-444444444444");
    public static readonly Guid GermanyId = new("55555555-5555-5555-5555-555555555555");

    private static readonly Country[] _data =
    [
        new Country { Id = IraqId, Name = "Iraq", IsDeleted = false, IsActive = true },
        new Country { Id = UnitedStatesId, Name = "United States", IsDeleted = false, IsActive = true },
        new Country { Id = UnitedKingdomId, Name = "United Kingdom", IsDeleted = false, IsActive = true },
        new Country { Id = CanadaId, Name = "Canada", IsDeleted = false, IsActive = true },
        new Country { Id = GermanyId, Name = "Germany", IsDeleted = false, IsActive = true }
    ];

    public Country[] GetData() => _data;
}
