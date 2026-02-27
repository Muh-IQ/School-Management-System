using Modules.School.Domain.Entities.Place;

namespace Modules.School.Infrastructure.Persistent.Seeds;

public class CitySeed : IEntitySeed<City>
{
    public static readonly Guid BaghdadId = new("a0000001-0000-0000-0000-000000000001");
    public static readonly Guid BasraId = new("a0000002-0000-0000-0000-000000000002");
    public static readonly Guid MosulId = new("a0000003-0000-0000-0000-000000000003");
    public static readonly Guid ErbilId = new("a0000004-0000-0000-0000-000000000004");
    public static readonly Guid KirkukId = new("a0000005-0000-0000-0000-000000000005");

    private static readonly City[] _data =
    [
        new City { Id = BaghdadId, Name = "Baghdad", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = BasraId, Name = "Basra", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = MosulId, Name = "Mosul", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = ErbilId, Name = "Erbil", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = KirkukId, Name = "Kirkuk", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true }
    ];

    public City[] GetData() => _data;
}
