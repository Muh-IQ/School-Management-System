using Modules.School.Domain.Entities.Place;

namespace Modules.School.Infrastructure.Persistent.Seeds;

public class AreaSeed : IEntitySeed<Area>
{
    public static class BaghdadAreaSeed
    {
        public static readonly Guid KarkhId = new("00000001-0001-0001-0000-000000000000");
        public static readonly Guid RusafaId = new("00000001-0001-0002-0000-000000000000");
        public static readonly Guid KarradaId = new("00000001-0001-0003-0000-000000000000");
        public static readonly Guid AdhamiyahId = new("00000001-0001-0004-0000-000000000000");
        public static readonly Guid MansourId = new("00000001-0001-0005-0000-000000000000");
        public static readonly Guid SadrCityId = new("00000001-0001-0006-0000-000000000000");
        public static readonly Guid DoraId = new("00000001-0001-0007-0000-000000000000");
        public static readonly Guid GhazaliyaId = new("00000001-0001-0008-0000-000000000000");
        public static readonly Guid AmiriyaId = new("00000001-0001-0009-0000-000000000000");
        public static readonly Guid ZayounaId = new("00000001-0001-0010-0000-000000000000");
        public static readonly Guid PalestineStreetId = new("00000001-0001-0011-0000-000000000000");
        public static readonly Guid HurriyaId = new("00000001-0001-0012-0000-000000000000");
        public static readonly Guid BayaaId = new("00000001-0001-0013-0000-000000000000");
        public static readonly Guid ShaabId = new("00000001-0001-0014-0000-000000000000");
        public static readonly Guid JadiriyahId = new("00000001-0001-0015-0000-000000000000");
        public static readonly Guid ShurjaId = new("00000001-0001-0016-0000-000000000000");
        public static readonly Guid FadhilId = new("00000001-0001-0017-0000-000000000000");
        public static readonly Guid SheikhOmarId = new("00000001-0001-0018-0000-000000000000");
        public static readonly Guid JesrDiyalaId = new("00000001-0001-0019-0000-000000000000");
        public static readonly Guid AbuDisherId = new("00000001-0001-0020-0000-000000000000");
        public static readonly Guid YarmoukId = new("00000001-0001-0021-0000-000000000000");
        public static readonly Guid AlHebnaaId = new("00000001-0001-0022-0000-000000000000");
        public static readonly Guid AlMahmudiyahId = new("00000001-0001-0023-0000-000000000000");
        public static readonly Guid BabAlMoathamId = new("00000001-0001-0024-0000-000000000000");
        public static readonly Guid BabAlSharqiId = new("00000001-0001-0025-0000-000000000000");
        public static readonly Guid AlFathelId = new("00000001-0001-0026-0000-000000000000");
        public static readonly Guid AlUbedyId = new("00000001-0001-0027-0000-000000000000");
        public static readonly Guid AlWashashId = new("00000001-0001-0028-0000-000000000000");
        public static readonly Guid AlWazireyaId = new("00000001-0001-0029-0000-000000000000");
        public static readonly Guid HayyUrId = new("00000001-0001-0030-0000-000000000000");
        public static readonly Guid HayyAlJamiyaId = new("00000001-0001-0031-0000-000000000000");
        public static readonly Guid AlAdelId = new("00000001-0001-0032-0000-000000000000");
        public static readonly Guid AlKhadhraaId = new("00000001-0001-0033-0000-000000000000");
        public static readonly Guid HayyAlJihadId = new("00000001-0001-0034-0000-000000000000");
        public static readonly Guid HayyAlAamelId = new("00000001-0001-0035-0000-000000000000");
        public static readonly Guid HayyAoorId = new("00000001-0001-0036-0000-000000000000");
        public static readonly Guid HayyAlShurttaId = new("00000001-0001-0037-0000-000000000000");
        public static readonly Guid IskanId = new("00000001-0001-0038-0000-000000000000");
        public static readonly Guid AlGazaliyahId = new("00000001-0001-0039-0000-000000000000");
        public static readonly Guid AlSalamId = new("00000001-0001-0040-0000-000000000000");
        public static readonly Guid AlIntisarId = new("00000001-0001-0041-0000-000000000000");
        public static readonly Guid AlBaladiyat2Id = new("00000001-0001-0042-0000-000000000000");
        public static readonly Guid AlDawoodiId = new("00000001-0001-0043-0000-000000000000");
        public static readonly Guid AlDhuhbaatId = new("00000001-0001-0044-0000-000000000000");
        public static readonly Guid AlElwiyaId = new("00000001-0001-0045-0000-000000000000");
        public static readonly Guid AlKhansaaId = new("00000001-0001-0046-0000-000000000000");
        public static readonly Guid AlLatifiyaId = new("00000001-0001-0047-0000-000000000000");
        public static readonly Guid HaifaStreetId = new("00000001-0001-0048-0000-000000000000");
        public static readonly Guid AlMaidanId = new("00000001-0001-0049-0000-000000000000");
        public static readonly Guid SinaaId = new("00000001-0001-0050-0000-000000000000");
        public static readonly Guid AlKaramaId = new("00000001-0001-0051-0000-000000000000");
        public static readonly Guid AlWaziriyaId = new("00000001-0001-0052-0000-000000000000");
        public static readonly Guid AlMustansiriyaId = new("00000001-0001-0053-0000-000000000000");
        public static readonly Guid AlKhaleejId = new("00000001-0001-0054-0000-000000000000");
        public static readonly Guid AlKhilaniId = new("00000001-0001-0055-0000-000000000000");
        public static readonly Guid AlAmilId = new("00000001-0001-0056-0000-000000000000");
        public static readonly Guid AlHurriyaId = new("00000001-0001-0057-0000-000000000000");
        public static readonly Guid AlHarthiyaId = new("00000001-0001-0058-0000-000000000000");
        public static readonly Guid AlQahiraId = new("00000001-0001-0059-0000-000000000000");
        public static readonly Guid AlRasheedId = new("00000001-0001-0060-0000-000000000000");
        public static readonly Guid AlNidalId = new("00000001-0001-0061-0000-000000000000");
        public static readonly Guid AlShorjaId = new("00000001-0001-0062-0000-000000000000");
        public static readonly Guid AlMansour2Id = new("00000001-0001-0063-0000-000000000000");
        public static readonly Guid AlShaab2Id = new("00000001-0001-0064-0000-000000000000");
        public static readonly Guid AlHurriya2Id = new("00000001-0001-0065-0000-000000000000");
        public static readonly Guid AlShurta2Id = new("00000001-0001-0066-0000-000000000000");
        public static readonly Guid AlBaladiyat3Id = new("00000001-0001-0067-0000-000000000000");
        public static readonly Guid AlMansour3Id = new("00000001-0001-0068-0000-000000000000");
        public static readonly Guid AlAdel2Id = new("00000001-0001-0069-0000-000000000000");
        public static readonly Guid AlKadhraa2Id = new("00000001-0001-0070-0000-000000000000");
        public static readonly Guid AlZaafaranId = new("00000001-0001-0071-0000-000000000000");
        public static readonly Guid AlKhalisId = new("00000001-0001-0072-0000-000000000000");
        public static readonly Guid AlRasheed2Id = new("00000001-0001-0073-0000-000000000000");
        public static readonly Guid AlJadriyaId = new("00000001-0001-0074-0000-000000000000");
        public static readonly Guid AlMaamilId = new("00000001-0001-0075-0000-000000000000");
        public static readonly Guid AlHurriyah3Id = new("00000001-0001-0076-0000-000000000000");
        public static readonly Guid AlRashid3Id = new("00000001-0001-0077-0000-000000000000");
        public static readonly Guid AlMansour4Id = new("00000001-0001-0078-0000-000000000000");
        public static readonly Guid AlShaab3Id = new("00000001-0001-0079-0000-000000000000");
        public static readonly Guid AlKadisiyaId = new("00000001-0001-0080-0000-000000000000");
        public static readonly Guid AlAmeenId = new("00000001-0001-0081-0000-000000000000");
        public static readonly Guid AlSalam2Id = new("00000001-0001-0082-0000-000000000000");
        public static readonly Guid AlWaziriyah2Id = new("00000001-0001-0083-0000-000000000000");
        public static readonly Guid AlRashidiyahId = new("00000001-0001-0084-0000-000000000000");
        public static readonly Guid AlMutanabbiId = new("00000001-0001-0085-0000-000000000000");
        public static readonly Guid AlShurta3Id = new("00000001-0001-0086-0000-000000000000");
        public static readonly Guid AlAdel3Id = new("00000001-0001-0087-0000-000000000000");
        public static readonly Guid AlKhadhraa3Id = new("00000001-0001-0088-0000-000000000000");
        public static readonly Guid AlQahira2Id = new("00000001-0001-0089-0000-000000000000");
        public static readonly Guid AlHurriya4Id = new("00000001-0001-0090-0000-000000000000");
        public static readonly Guid AlKarama2Id = new("00000001-0001-0091-0000-000000000000");
        public static readonly Guid AlMaidan2Id = new("00000001-0001-0092-0000-000000000000");
        public static readonly Guid AlShaab4Id = new("00000001-0001-0093-0000-000000000000");
        public static readonly Guid AlBaladiyat4Id = new("00000001-0001-0094-0000-000000000000");
        public static readonly Guid AlJadriya2Id = new("00000001-0001-0095-0000-000000000000");
        public static readonly Guid AlAmiriya2Id = new("00000001-0001-0096-0000-000000000000");
        public static readonly Guid AlDora2Id = new("00000001-0001-0097-0000-000000000000");
        public static readonly Guid AlSadrCity2Id = new("00000001-0001-0098-0000-000000000000");
        public static readonly Guid AlKarrada2Id = new("00000001-0001-0099-0000-000000000000");
        public static readonly Guid AlRusafa2Id = new("00000001-0001-0100-0000-000000000000");
        public static readonly Guid AlRashid4Id = new("00000001-0001-0101-0000-000000000000");
        public static readonly Guid AlHurriya5Id = new("00000001-0001-0102-0000-000000000000");
        public static readonly Guid AlShaab5Id = new("00000001-0001-0103-0000-000000000000");
        public static readonly Guid AlMansour5Id = new("00000001-0001-0104-0000-000000000000");
        public static readonly Guid AlKadisiya2Id = new("00000001-0001-0105-0000-000000000000");
        public static readonly Guid AlAmeen2Id = new("00000001-0001-0106-0000-000000000000");
        public static readonly Guid AlSalam3Id = new("00000001-0001-0107-0000-000000000000");
        public static readonly Guid AlWaziriyah3Id = new("00000001-0001-0108-0000-000000000000");
        public static readonly Guid AlRashidiyah2Id = new("00000001-0001-0109-0000-000000000000");
        public static readonly Guid AlMutanabbi2Id = new("00000001-0001-0110-0000-000000000000");
        public static readonly Guid AlShurta4Id = new("00000001-0001-0111-0000-000000000000");
        public static readonly Guid AlAdel4Id = new("00000001-0001-0112-0000-000000000000");
        public static readonly Guid AlKhadhraa4Id = new("00000001-0001-0113-0000-000000000000");
        public static readonly Guid AlQahira3Id = new("00000001-0001-0114-0000-000000000000");
        public static readonly Guid AlHurriya6Id = new("00000001-0001-0115-0000-000000000000");
        public static readonly Guid AlKarama3Id = new("00000001-0001-0116-0000-000000000000");
        public static readonly Guid AlMaidan3Id = new("00000001-0001-0117-0000-000000000000");
        public static readonly Guid AlShaab6Id = new("00000001-0001-0118-0000-000000000000");
        public static readonly Guid AlBaladiyat5Id = new("00000001-0001-0119-0000-000000000000");
        public static readonly Guid AlJadriya3Id = new("00000001-0001-0120-0000-000000000000");
    }

    public static class WashingtonAreaSeed
    {
        public static readonly Guid GeorgetownId = new("00000002-0001-0001-0000-000000000000");
        public static readonly Guid CapitolHillId = new("00000002-0001-0002-0000-000000000000");
        public static readonly Guid DupontCircleId = new("00000002-0001-0003-0000-000000000000");
        public static readonly Guid AdamsMorganId = new("00000002-0001-0004-0000-000000000000");
        public static readonly Guid ColumbiaHeightsId = new("00000002-0001-0005-0000-000000000000");
        public static readonly Guid NavyYardId = new("00000002-0001-0006-0000-000000000000");
        public static readonly Guid FoggyBottomId = new("00000002-0001-0007-0000-000000000000");
        public static readonly Guid ShawId = new("00000002-0001-0008-0000-000000000000");
        public static readonly Guid BrooklandId = new("00000002-0001-0009-0000-000000000000");
        public static readonly Guid TenleytownId = new("00000002-0001-0010-0000-000000000000");
        public static readonly Guid AnacostiaId = new("00000002-0001-0011-0000-000000000000");
        public static readonly Guid PetworthId = new("00000002-0001-0012-0000-000000000000");
        public static readonly Guid ClevelandParkId = new("00000002-0001-0013-0000-000000000000");
        public static readonly Guid WoodleyParkId = new("00000002-0001-0014-0000-000000000000");
        public static readonly Guid MountPleasantId = new("00000002-0001-0015-0000-000000000000");
        public static readonly Guid TrinidadId = new("00000002-0001-0016-0000-000000000000");
        public static readonly Guid EckingtonId = new("00000002-0001-0017-0000-000000000000");
        public static readonly Guid BloomingdaleId = new("00000002-0001-0018-0000-000000000000");
        public static readonly Guid KaloramaId = new("00000002-0001-0019-0000-000000000000");
        public static readonly Guid LoganCircleId = new("00000002-0001-0020-0000-000000000000");
        public static readonly Guid NoMaId = new("00000002-0001-0021-0000-000000000000");
        public static readonly Guid HStreetCorridorId = new("00000002-0001-0022-0000-000000000000");
        public static readonly Guid SouthwestWaterfrontId = new("00000002-0001-0023-0000-000000000000");
        public static readonly Guid TheWharfId = new("00000002-0001-0024-0000-000000000000");
        public static readonly Guid WestEndId = new("00000002-0001-0025-0000-000000000000");
        public static readonly Guid GloverParkId = new("00000002-0001-0026-0000-000000000000");
        public static readonly Guid FriendshipHeightsId = new("00000002-0001-0027-0000-000000000000");
        public static readonly Guid BrightwoodId = new("00000002-0001-0028-0000-000000000000");
        public static readonly Guid CongressHeightsId = new("00000002-0001-0029-0000-000000000000");
        public static readonly Guid DeanwoodId = new("00000002-0001-0030-0000-000000000000");
        public static readonly Guid HillcrestId = new("00000002-0001-0031-0000-000000000000");
        public static readonly Guid FortTottenId = new("00000002-0001-0032-0000-000000000000");
        public static readonly Guid TakomaId = new("00000002-0001-0033-0000-000000000000");
        public static readonly Guid MichiganParkId = new("00000002-0001-0034-0000-000000000000");
        public static readonly Guid BellevueId = new("00000002-0001-0035-0000-000000000000");
        public static readonly Guid ChevyChaseId = new("00000002-0001-0036-0000-000000000000");
        public static readonly Guid NorthClevelandParkId = new("00000002-0001-0037-0000-000000000000");
        public static readonly Guid AmericanUniversityParkId = new("00000002-0001-0038-0000-000000000000");
        public static readonly Guid ForestHillsId = new("00000002-0001-0039-0000-000000000000");
    }
    private static readonly Area[] _data =
    [
        new Area { Id = BaghdadAreaSeed.KarkhId,           Name = "Karkh", CityId = CitySeed.BaghdadId,            IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.RusafaId,          Name = "Rusafa", CityId = CitySeed.BaghdadId,           IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.KarradaId,         Name = "Karrada", CityId = CitySeed.BaghdadId,          IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AdhamiyahId,       Name = "Adhamiyah", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.MansourId,         Name = "Mansour", CityId = CitySeed.BaghdadId,          IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.SadrCityId,        Name = "Sadr City", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.DoraId,            Name = "Dora", CityId = CitySeed.BaghdadId,             IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.GhazaliyaId,       Name = "Ghazaliya", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AmiriyaId,         Name = "Amiriya", CityId = CitySeed.BaghdadId,          IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.ZayounaId,         Name = "Zayouna", CityId = CitySeed.BaghdadId,          IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.PalestineStreetId, Name = "Palestine Street", CityId = CitySeed.BaghdadId, IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.HurriyaId,         Name = "Hurriya", CityId = CitySeed.BaghdadId,          IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.BayaaId,           Name = "Bayaa", CityId = CitySeed.BaghdadId,            IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.ShaabId,           Name = "Shaab", CityId = CitySeed.BaghdadId,            IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.JadiriyahId,       Name = "Jadiriyah", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.ShurjaId,          Name = "Shurja", CityId = CitySeed.BaghdadId,           IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.FadhilId,          Name = "Fadhil", CityId = CitySeed.BaghdadId,           IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.SheikhOmarId,      Name = "Sheikh Omar", CityId = CitySeed.BaghdadId,      IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.JesrDiyalaId,      Name = "Jesr Diyala", CityId = CitySeed.BaghdadId,      IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AbuDisherId,       Name = "Abu Disher", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.YarmoukId,         Name = "Yarmouk", CityId = CitySeed.BaghdadId,          IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlHebnaaId,        Name = "Al Hebnaa", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlMahmudiyahId,    Name = "Al Mahmudiyah", CityId = CitySeed.BaghdadId,    IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.BabAlMoathamId,    Name = "Bab Al Moatham", CityId = CitySeed.BaghdadId,   IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.BabAlSharqiId,     Name = "Bab Al Sharqi", CityId = CitySeed.BaghdadId,    IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlFathelId,        Name = "Al Fathel", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlUbedyId,         Name = "Al Ubedy", CityId = CitySeed.BaghdadId,         IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlWashashId,       Name = "Al Washash", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlWazireyaId,      Name = "Al Wazireya", CityId = CitySeed.BaghdadId,      IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.HayyUrId,          Name = "Hayy Ur", CityId = CitySeed.BaghdadId,          IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.HayyAlJamiyaId,    Name = "Hayy Al Jamiya", CityId = CitySeed.BaghdadId,   IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlAdelId,          Name = "Al Adel", CityId = CitySeed.BaghdadId,          IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlKhadhraaId,      Name = "Al Khadhraa", CityId = CitySeed.BaghdadId,      IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.HayyAlJihadId,     Name = "Hayy Al Jihad", CityId = CitySeed.BaghdadId,    IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.HayyAlAamelId,     Name = "Hayy Al Aamel", CityId = CitySeed.BaghdadId,    IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.HayyAoorId,        Name = "Hayy Aoor", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.HayyAlShurttaId,   Name = "Hayy Al Shurtta", CityId = CitySeed.BaghdadId,  IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.IskanId,           Name = "Iskan", CityId = CitySeed.BaghdadId,            IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlGazaliyahId,     Name = "Al Gazaliyah", CityId = CitySeed.BaghdadId,     IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlSalamId,         Name = "Al Salam", CityId = CitySeed.BaghdadId,         IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlIntisarId,       Name = "Al Intisar", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlBaladiyat2Id,    Name = "Al Baladiyat", CityId = CitySeed.BaghdadId,     IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlDawoodiId,       Name = "Al Dawoodi", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlDhuhbaatId,      Name = "Al Dhuhbaat", CityId = CitySeed.BaghdadId,      IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlElwiyaId,        Name = "Al Elwiya", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlKhansaaId,       Name = "Al Khansaa", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlLatifiyaId,      Name = "Al Latifiya", CityId = CitySeed.BaghdadId,      IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.HaifaStreetId,     Name = "Haifa Street", CityId = CitySeed.BaghdadId,     IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlMaidanId,        Name = "Al Maidan", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.SinaaId,           Name = "Sinaa", CityId = CitySeed.BaghdadId,            IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlKaramaId,        Name = "Al Karama", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlWaziriyaId,      Name = "Al Waziriya", CityId = CitySeed.BaghdadId,      IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlMustansiriyaId,  Name = "Al Mustansiriya", CityId = CitySeed.BaghdadId,  IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlKhaleejId,       Name = "Al Khaleej", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlKhilaniId,       Name = "Al Khilani", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlAmilId,          Name = "Al Amil", CityId = CitySeed.BaghdadId,          IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlHurriyaId,       Name = "Al Hurriya", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlHarthiyaId,      Name = "Al Harthiya", CityId = CitySeed.BaghdadId,      IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlQahiraId,        Name = "Al Qahira", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlRasheedId,       Name = "Al Rasheed", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlNidalId,         Name = "Al Nidal", CityId = CitySeed.BaghdadId,         IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlShorjaId,        Name = "Al Shorja", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlMansour2Id,      Name = "Al Mansour", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlShaab2Id,        Name = "Al Shaab", CityId = CitySeed.BaghdadId,         IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlHurriya2Id,      Name = "Al Hurriya", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlShurta2Id,       Name = "Al Shurta", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlBaladiyat3Id,    Name = "Al Baladiyat", CityId = CitySeed.BaghdadId,     IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlMansour3Id,      Name = "Al Mansour", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlAdel2Id,         Name = "Al Adel", CityId = CitySeed.BaghdadId,          IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlKadhraa2Id,      Name = "Al Kadhraa", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlZaafaranId,      Name = "Al Zaafaran", CityId = CitySeed.BaghdadId,      IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlKhalisId,        Name = "Al Khalis", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlRasheed2Id,      Name = "Al Rasheed", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlJadriyaId,       Name = "Al Jadriya", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlMaamilId,        Name = "Al Maamil", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlHurriyah3Id,     Name = "Al Hurriyah", CityId = CitySeed.BaghdadId,      IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlRashid3Id,       Name = "Al Rashid", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlMansour4Id,      Name = "Al Mansour", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlShaab3Id,        Name = "Al Shaab", CityId = CitySeed.BaghdadId,         IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlKadisiyaId,      Name = "Al Kadisiya", CityId = CitySeed.BaghdadId,      IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlAmeenId,         Name = "Al Ameen", CityId = CitySeed.BaghdadId,         IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlSalam2Id,        Name = "Al Salam", CityId = CitySeed.BaghdadId,         IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlWaziriyah2Id,    Name = "Al Waziriyah", CityId = CitySeed.BaghdadId,     IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlRashidiyahId,    Name = "Al Rashidiyah", CityId = CitySeed.BaghdadId,    IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlMutanabbiId,     Name = "Al Mutanabbi", CityId = CitySeed.BaghdadId,     IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlShurta3Id,       Name = "Al Shurta", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlAdel3Id,         Name = "Al Adel", CityId = CitySeed.BaghdadId,          IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlKhadhraa3Id,     Name = "Al Khadhraa", CityId = CitySeed.BaghdadId,      IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlQahira2Id,       Name = "Al Qahira", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlHurriya4Id,      Name = "Al Hurriya", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlKarama2Id,       Name = "Al Karama", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlMaidan2Id,       Name = "Al Maidan", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlShaab4Id,        Name = "Al Shaab", CityId = CitySeed.BaghdadId,         IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlBaladiyat4Id,    Name = "Al Baladiyat", CityId = CitySeed.BaghdadId,     IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlJadriya2Id,      Name = "Al Jadriya", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlAmiriya2Id,      Name = "Al Amiriya", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlDora2Id,         Name = "Al Dora", CityId = CitySeed.BaghdadId,          IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlSadrCity2Id,     Name = "Al Sadr City", CityId = CitySeed.BaghdadId,     IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlKarrada2Id,      Name = "Al Karrada", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlRusafa2Id,       Name = "Al Rusafa", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlRashid4Id,       Name = "Al Rashid", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlHurriya5Id,      Name = "Al Hurriyah", CityId = CitySeed.BaghdadId,      IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlShaab5Id,        Name = "Al Shaab", CityId = CitySeed.BaghdadId,         IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlMansour5Id,      Name = "Al Mansour", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlKadisiya2Id,     Name = "Al Kadisiya", CityId = CitySeed.BaghdadId,      IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlAmeen2Id,        Name = "Al Ameen", CityId = CitySeed.BaghdadId,         IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlSalam3Id,        Name = "Al Salam", CityId = CitySeed.BaghdadId,         IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlWaziriyah3Id,    Name = "Al Waziriyah", CityId = CitySeed.BaghdadId,     IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlRashidiyah2Id,   Name = "Al Rashidiyah", CityId = CitySeed.BaghdadId,    IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlMutanabbi2Id,    Name = "Al Mutanabbi", CityId = CitySeed.BaghdadId,     IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlShurta4Id,       Name = "Al Shurta", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlAdel4Id,         Name = "Al Adel", CityId = CitySeed.BaghdadId,          IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlKhadhraa4Id,     Name = "Al Khadhraa", CityId = CitySeed.BaghdadId,      IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlQahira3Id,       Name = "Al Qahira", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlHurriya6Id,      Name = "Al Hurriyah", CityId = CitySeed.BaghdadId,      IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlKarama3Id,       Name = "Al Karama", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlMaidan3Id,       Name = "Al Maidan", CityId = CitySeed.BaghdadId,        IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlShaab6Id,        Name = "Al Shaab", CityId = CitySeed.BaghdadId,         IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlBaladiyat5Id,    Name = "Al Baladiyat", CityId = CitySeed.BaghdadId,     IsDeleted = false, IsActive = true },
        new Area { Id = BaghdadAreaSeed.AlJadriya3Id,      Name = "Al Jadriya", CityId = CitySeed.BaghdadId,       IsDeleted = false, IsActive = true },


        new Area { Id = WashingtonAreaSeed.GeorgetownId,             Name = "Georgetown",               CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.CapitolHillId,            Name = "Capitol Hill",             CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.DupontCircleId,           Name = "Dupont Circle",            CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.AdamsMorganId,            Name = "Adams Morgan",             CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.ColumbiaHeightsId,        Name = "Columbia Heights",         CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.NavyYardId,               Name = "Navy Yard",                CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.FoggyBottomId,            Name = "Foggy Bottom",             CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.ShawId,                   Name = "Shaw",                     CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.BrooklandId,              Name = "Brookland",                CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.TenleytownId,             Name = "Tenleytown",               CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.AnacostiaId,              Name = "Anacostia",                CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.PetworthId,               Name = "Petworth",                 CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.ClevelandParkId,          Name = "Cleveland Park",           CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.WoodleyParkId,            Name = "Woodley Park",             CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.MountPleasantId,          Name = "Mount Pleasant",           CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.TrinidadId,               Name = "Trinidad",                 CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.EckingtonId,              Name = "Eckington",                CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.BloomingdaleId,           Name = "Bloomingdale",             CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.KaloramaId,               Name = "Kalorama",                 CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.LoganCircleId,            Name = "Logan Circle",             CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.NoMaId,                   Name = "NoMa",                     CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.HStreetCorridorId,        Name = "H Street Corridor",        CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.SouthwestWaterfrontId,    Name = "Southwest Waterfront",     CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.TheWharfId,               Name = "The Wharf",                CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.WestEndId,                Name = "West End",                 CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.GloverParkId,             Name = "Glover Park",              CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.FriendshipHeightsId,      Name = "Friendship Heights",       CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.BrightwoodId,             Name = "Brightwood",               CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.CongressHeightsId,        Name = "Congress Heights",         CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.DeanwoodId,               Name = "Deanwood",                 CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.HillcrestId,              Name = "Hillcrest",                CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.FortTottenId,             Name = "Fort Totten",              CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.TakomaId,                 Name = "Takoma",                   CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.MichiganParkId,           Name = "Michigan Park",            CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.BellevueId,               Name = "Bellevue",                 CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.ChevyChaseId,             Name = "Chevy Chase",              CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.NorthClevelandParkId,     Name = "North Cleveland Park",     CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.AmericanUniversityParkId, Name = "American University Park", CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true },
        new Area { Id = WashingtonAreaSeed.ForestHillsId,            Name = "Forest Hills",             CityId = CitySeed.WashingtonId, IsDeleted = false, IsActive = true }
    ];

    public Area[] GetData() => _data;
}
