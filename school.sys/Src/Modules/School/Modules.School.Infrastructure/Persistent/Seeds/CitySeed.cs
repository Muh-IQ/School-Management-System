using Modules.School.Domain.Entities.Place;

namespace Modules.School.Infrastructure.Persistent.Seeds;

public class CitySeed : IEntitySeed<City>
{
    public static readonly Guid BaghdadId =       new("00000001-0001-0000-0000-000000000000");
    public static readonly Guid BasraId =         new("00000001-0002-0000-0000-000000000000");
    public static readonly Guid MosulId =         new("00000001-0003-0000-0000-000000000000");
    public static readonly Guid ErbilId =         new("00000001-0004-0000-0000-000000000000");
    public static readonly Guid KirkukId =        new("00000001-0005-0000-0000-000000000000");
    public static readonly Guid NajafId =         new("00000001-0006-0000-0000-000000000000");
    public static readonly Guid KarbalaId =       new("00000001-0007-0000-0000-000000000000");
    public static readonly Guid SulaymaniyahId =  new("00000001-0008-0000-0000-000000000000");
    public static readonly Guid DohukId =         new("00000001-0009-0000-0000-000000000000");
    public static readonly Guid DiyalaId =        new("00000001-0010-0000-0000-000000000000");
    public static readonly Guid BabilId =         new("00000001-0011-0000-0000-000000000000");
    public static readonly Guid AnbarId =         new("00000001-0012-0000-0000-000000000000");
    public static readonly Guid WasitId =         new("00000001-0013-0000-0000-000000000000");
    public static readonly Guid DhiQarId =        new("00000001-0014-0000-0000-000000000000");
    public static readonly Guid MaysanId =        new("00000001-0015-0000-0000-000000000000");
    public static readonly Guid QadisiyahId =     new("00000001-0016-0000-0000-000000000000");
    public static readonly Guid SalahAlDinId =    new("00000001-0017-0000-0000-000000000000");
    public static readonly Guid NinevehId =       new("00000001-0018-0000-0000-000000000000");
                                                       
    public static readonly Guid AlabamaId =       new("00000002-0001-0000-0000-000000000000");
    public static readonly Guid AlaskaId =        new("00000002-0002-0000-0000-000000000000");
    public static readonly Guid ArizonaId =       new("00000002-0003-0000-0000-000000000000");
    public static readonly Guid ArkansasId =      new("00000002-0004-0000-0000-000000000000");
    public static readonly Guid CaliforniaId =    new("00000002-0005-0000-0000-000000000000");
    public static readonly Guid ColoradoId =      new("00000002-0006-0000-0000-000000000000");
    public static readonly Guid ConnecticutId =   new("00000002-0007-0000-0000-000000000000");
    public static readonly Guid DelawareId =      new("00000002-0008-0000-0000-000000000000");
    public static readonly Guid FloridaId =       new("00000002-0009-0000-0000-000000000000");
    public static readonly Guid GeorgiaId =       new("00000002-0010-0000-0000-000000000000");
    public static readonly Guid HawaiiId =        new("00000002-0011-0000-0000-000000000000");
    public static readonly Guid IdahoId =         new("00000002-0012-0000-0000-000000000000");
    public static readonly Guid IllinoisId =      new("00000002-0013-0000-0000-000000000000");
    public static readonly Guid IndianaId =       new("00000002-0014-0000-0000-000000000000");
    public static readonly Guid IowaId =          new("00000002-0015-0000-0000-000000000000");
    public static readonly Guid KansasId =        new("00000002-0016-0000-0000-000000000000");
    public static readonly Guid KentuckyId =      new("00000002-0017-0000-0000-000000000000");
    public static readonly Guid LouisianaId =     new("00000002-0018-0000-0000-000000000000");
    public static readonly Guid MaineId =         new("00000002-0019-0000-0000-000000000000");
    public static readonly Guid MarylandId =      new("00000002-0020-0000-0000-000000000000");
    public static readonly Guid MassachusettsId = new("00000002-0021-0000-0000-000000000000");
    public static readonly Guid MichiganId =      new("00000002-0022-0000-0000-000000000000");
    public static readonly Guid MinnesotaId =     new("00000002-0023-0000-0000-000000000000");
    public static readonly Guid MississippiId =   new("00000002-0024-0000-0000-000000000000");
    public static readonly Guid MissouriId =      new("00000002-0025-0000-0000-000000000000");
    public static readonly Guid MontanaId =       new("00000002-0026-0000-0000-000000000000");
    public static readonly Guid NebraskaId =      new("00000002-0027-0000-0000-000000000000");
    public static readonly Guid NevadaId =        new("00000002-0028-0000-0000-000000000000");
    public static readonly Guid NewHampshireId =  new("00000002-0029-0000-0000-000000000000");
    public static readonly Guid NewJerseyId =     new("00000002-0030-0000-0000-000000000000");
    public static readonly Guid NewMexicoId =     new("00000002-0031-0000-0000-000000000000");
    public static readonly Guid NewYorkId =       new("00000002-0032-0000-0000-000000000000");
    public static readonly Guid NorthCarolinaId = new("00000002-0033-0000-0000-000000000000");
    public static readonly Guid NorthDakotaId =   new("00000002-0034-0000-0000-000000000000");
    public static readonly Guid OhioId =          new("00000002-0035-0000-0000-000000000000");
    public static readonly Guid OklahomaId =      new("00000002-0036-0000-0000-000000000000");
    public static readonly Guid OregonId =        new("00000002-0037-0000-0000-000000000000");
    public static readonly Guid PennsylvaniaId =  new("00000002-0038-0000-0000-000000000000");
    public static readonly Guid RhodeIslandId =   new("00000002-0039-0000-0000-000000000000");
    public static readonly Guid SouthCarolinaId = new("00000002-0040-0000-0000-000000000000");
    public static readonly Guid SouthDakotaId =   new("00000002-0041-0000-0000-000000000000");
    public static readonly Guid TennesseeId =     new("00000002-0042-0000-0000-000000000000");
    public static readonly Guid TexasId =         new("00000002-0043-0000-0000-000000000000");
    public static readonly Guid UtahId =          new("00000002-0044-0000-0000-000000000000");
    public static readonly Guid VermontId =       new("00000002-0045-0000-0000-000000000000");
    public static readonly Guid VirginiaId =      new("00000002-0046-0000-0000-000000000000");
    public static readonly Guid WashingtonId =    new("00000002-0047-0000-0000-000000000000");
    public static readonly Guid WestVirginiaId =  new("00000002-0048-0000-0000-000000000000");
    public static readonly Guid WisconsinId =     new("00000002-0049-0000-0000-000000000000");
    public static readonly Guid WyomingId =       new("00000002-0050-0000-0000-000000000000");

    private static readonly City[] _data =
    [
        new City { Id = BaghdadId, Name = "Baghdad", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = BasraId, Name = "Basra", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = MosulId, Name = "Mosul", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = ErbilId, Name = "Erbil", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = KirkukId, Name = "Kirkuk", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = NajafId, Name = "Najaf", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = KarbalaId, Name = "Karbala", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = SulaymaniyahId, Name = "Sulaymaniyah", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = DohukId, Name = "Dohuk", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = DiyalaId, Name = "Diyala", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = BabilId, Name = "Babil", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = AnbarId, Name = "Anbar", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = WasitId, Name = "Wasit", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = DhiQarId, Name = "Dhi Qar", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = MaysanId, Name = "Maysan", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = QadisiyahId, Name = "Qadisiyah", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = SalahAlDinId, Name = "Salah al-Din", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },
        new City { Id = NinevehId, Name = "Nineveh", CountryId = CountrySeed.IraqId, IsDeleted = false, IsActive = true },

        new City { Id = AlabamaId, Name = "Alabama", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = AlaskaId, Name = "Alaska", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = ArizonaId, Name = "Arizona", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = ArkansasId, Name = "Arkansas", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = CaliforniaId, Name = "California", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = ColoradoId, Name = "Colorado", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = ConnecticutId, Name = "Connecticut", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = DelawareId, Name = "Delaware", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = FloridaId, Name = "Florida", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = GeorgiaId, Name = "Georgia", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = HawaiiId, Name = "Hawaii", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = IdahoId, Name = "Idaho", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = IllinoisId, Name = "Illinois", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = IndianaId, Name = "Indiana", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = IowaId, Name = "Iowa", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = KansasId, Name = "Kansas", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = KentuckyId, Name = "Kentucky", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = LouisianaId, Name = "Louisiana", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = MaineId, Name = "Maine", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = MarylandId, Name = "Maryland", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = MassachusettsId, Name = "Massachusetts", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = MichiganId, Name = "Michigan", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = MinnesotaId, Name = "Minnesota", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = MississippiId, Name = "Mississippi", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = MissouriId, Name = "Missouri", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = MontanaId, Name = "Montana", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = NebraskaId, Name = "Nebraska", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = NevadaId, Name = "Nevada", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = NewHampshireId, Name = "New Hampshire", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = NewJerseyId, Name = "New Jersey", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = NewMexicoId, Name = "New Mexico", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = NewYorkId, Name = "New York", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = NorthCarolinaId, Name = "North Carolina", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = NorthDakotaId, Name = "North Dakota", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = OhioId, Name = "Ohio", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = OklahomaId, Name = "Oklahoma", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = OregonId, Name = "Oregon", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = PennsylvaniaId, Name = "Pennsylvania", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = RhodeIslandId, Name = "Rhode Island", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = SouthCarolinaId, Name = "South Carolina", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = SouthDakotaId, Name = "South Dakota", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = TennesseeId, Name = "Tennessee", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = TexasId, Name = "Texas", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = UtahId, Name = "Utah", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = VermontId, Name = "Vermont", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = VirginiaId, Name = "Virginia", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = WashingtonId, Name = "Washington", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = WestVirginiaId, Name = "West Virginia", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = WisconsinId, Name = "Wisconsin", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true },
        new City { Id = WyomingId, Name = "Wyoming", CountryId = CountrySeed.UnitedStatesId, IsDeleted = false, IsActive = true }

    ];

    public City[] GetData() => _data;
}
