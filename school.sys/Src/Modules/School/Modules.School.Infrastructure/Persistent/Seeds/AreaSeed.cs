using Modules.School.Domain.Entities.Place;

namespace Modules.School.Infrastructure.Persistent.Seeds;

public class AreaSeed : IEntitySeed<Area>
{
    public static readonly Guid KarkhId = new("b0000001-0000-0000-0000-000000000001");
    public static readonly Guid RusafaId = new("b0000002-0000-0000-0000-000000000002");
    public static readonly Guid AlFaoId = new("b0000003-0000-0000-0000-000000000003");
    public static readonly Guid ShattAlArabId = new("b0000004-0000-0000-0000-000000000004");
    public static readonly Guid OldCityId = new("b0000005-0000-0000-0000-000000000005");
    public static readonly Guid NinevehPlainsId = new("b0000006-0000-0000-0000-000000000006");

    private static readonly Area[] _data =
    [
        new Area { Id = KarkhId, Name = "Karkh", CityId = CitySeed.BaghdadId, IsDeleted = false, IsActive = true },
        new Area { Id = RusafaId, Name = "Rusafa", CityId = CitySeed.BaghdadId, IsDeleted = false, IsActive = true },
        new Area { Id = AlFaoId, Name = "Al-Fao", CityId = CitySeed.BasraId, IsDeleted = false, IsActive = true },
        new Area { Id = ShattAlArabId, Name = "Shatt Al-Arab", CityId = CitySeed.BasraId, IsDeleted = false, IsActive = true },
        new Area { Id = OldCityId, Name = "Old City", CityId = CitySeed.MosulId, IsDeleted = false, IsActive = true },
        new Area { Id = NinevehPlainsId, Name = "Nineveh Plains", CityId = CitySeed.MosulId, IsDeleted = false, IsActive = true }
    ];

    public Area[] GetData() => _data;
}
