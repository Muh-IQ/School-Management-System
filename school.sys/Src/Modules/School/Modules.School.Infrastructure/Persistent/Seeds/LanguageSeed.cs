using Modules.School.Domain.Entities;

namespace Modules.School.Infrastructure.Persistent.Seeds;

public class LanguageSeed : IEntitySeed<Language>
{
    public static readonly Guid EnglishId = new("d0000001-0000-0000-0000-000000000001");
    public static readonly Guid ArabicId = new("d0000002-0000-0000-0000-000000000002");
    public static readonly Guid FrenchId = new("d0000003-0000-0000-0000-000000000003");
    public static readonly Guid SpanishId = new("d0000004-0000-0000-0000-000000000004");
    public static readonly Guid ChineseMandarinId = new("d0000005-0000-0000-0000-000000000005");
    public static readonly Guid HindiId = new("d0000006-0000-0000-0000-000000000006");
    public static readonly Guid PortugueseId = new("d0000007-0000-0000-0000-000000000007");
    public static readonly Guid BengaliId = new("d0000008-0000-0000-0000-000000000008");
    public static readonly Guid RussianId = new("d0000009-0000-0000-0000-000000000009");
    public static readonly Guid JapaneseId = new("d000000a-0000-0000-0000-00000000000a");
    public static readonly Guid GermanId = new("d000000b-0000-0000-0000-00000000000b");
    public static readonly Guid KoreanId = new("d000000c-0000-0000-0000-00000000000c");
    public static readonly Guid ItalianId = new("d000000d-0000-0000-0000-00000000000d");
    public static readonly Guid TurkishId = new("d000000e-0000-0000-0000-00000000000e");
    public static readonly Guid VietnameseId = new("d000000f-0000-0000-0000-00000000000f");
    public static readonly Guid PersianId = new("d0000010-0000-0000-0000-000000000010");
    public static readonly Guid UrduId = new("d0000011-0000-0000-0000-000000000011");
    public static readonly Guid IndonesianId = new("d0000012-0000-0000-0000-000000000012");
    public static readonly Guid DutchId = new("d0000013-0000-0000-0000-000000000013");
    public static readonly Guid PolishId = new("d0000014-0000-0000-0000-000000000014");
    public static readonly Guid ThaiId = new("d0000015-0000-0000-0000-000000000015");
    public static readonly Guid GreekId = new("d0000016-0000-0000-0000-000000000016");
    public static readonly Guid SwedishId = new("d0000017-0000-0000-0000-000000000017");
    public static readonly Guid RomanianId = new("d0000018-0000-0000-0000-000000000018");
    public static readonly Guid CzechId = new("d0000019-0000-0000-0000-000000000019");
    public static readonly Guid HungarianId = new("d000001a-0000-0000-0000-00000000001a");
    public static readonly Guid HebrewId = new("d000001b-0000-0000-0000-00000000001b");
    public static readonly Guid UkrainianId = new("d000001c-0000-0000-0000-00000000001c");
    public static readonly Guid MalayId = new("d000001d-0000-0000-0000-00000000001d");
    public static readonly Guid SwahiliId = new("d000001e-0000-0000-0000-00000000001e");
    public static readonly Guid TamilId = new("d000001f-0000-0000-0000-00000000001f");
    public static readonly Guid KurdishId = new("d0000020-0000-0000-0000-000000000020");
    public static readonly Guid DanishId = new("d0000021-0000-0000-0000-000000000021");
    public static readonly Guid NorwegianId = new("d0000022-0000-0000-0000-000000000022");
    public static readonly Guid FinnishId = new("d0000023-0000-0000-0000-000000000023");
    public static readonly Guid SlovakId = new("d0000024-0000-0000-0000-000000000024");
    public static readonly Guid BulgarianId = new("d0000025-0000-0000-0000-000000000025");
    public static readonly Guid CroatianId = new("d0000026-0000-0000-0000-000000000026");
    public static readonly Guid SerbianId = new("d0000027-0000-0000-0000-000000000027");
    public static readonly Guid CatalanId = new("d0000028-0000-0000-0000-000000000028");
    public static readonly Guid AfrikaansId = new("d0000029-0000-0000-0000-000000000029");
    public static readonly Guid NepaliId = new("d000002a-0000-0000-0000-00000000002a");
    public static readonly Guid SinhalaId = new("d000002b-0000-0000-0000-00000000002b");
    public static readonly Guid MarathiId = new("d000002c-0000-0000-0000-00000000002c");
    public static readonly Guid PunjabiId = new("d000002d-0000-0000-0000-00000000002d");
    public static readonly Guid GujaratiId = new("d000002e-0000-0000-0000-00000000002e");
    public static readonly Guid AmharicId = new("d000002f-0000-0000-0000-00000000002f");
    public static readonly Guid HausaId = new("d0000030-0000-0000-0000-000000000030");
    public static readonly Guid YorubaId = new("d0000031-0000-0000-0000-000000000031");
    public static readonly Guid SomaliId = new("d0000032-0000-0000-0000-000000000032");
    public static readonly Guid LithuanianId = new("d0000033-0000-0000-0000-000000000033");
    public static readonly Guid LatvianId = new("d0000034-0000-0000-0000-000000000034");
    public static readonly Guid EstonianId = new("d0000035-0000-0000-0000-000000000035");
    public static readonly Guid SlovenianId = new("d0000036-0000-0000-0000-000000000036");
    public static readonly Guid AlbanianId = new("d0000037-0000-0000-0000-000000000037");
    public static readonly Guid MacedonianId = new("d0000038-0000-0000-0000-000000000038");
    public static readonly Guid ArmenianId = new("d0000039-0000-0000-0000-000000000039");
    public static readonly Guid GeorgianId = new("d000003a-0000-0000-0000-00000000003a");
    public static readonly Guid KazakhId = new("d000003b-0000-0000-0000-00000000003b");
    public static readonly Guid UzbekId = new("d000003c-0000-0000-0000-00000000003c");
    public static readonly Guid AzerbaijaniId = new("d000003d-0000-0000-0000-00000000003d");
    public static readonly Guid KyrgyzId = new("d000003e-0000-0000-0000-00000000003e");
    public static readonly Guid TurkmenId = new("d000003f-0000-0000-0000-00000000003f");
    public static readonly Guid TajikId = new("d0000040-0000-0000-0000-000000000040");
    public static readonly Guid MongolianId = new("d0000041-0000-0000-0000-000000000041");
    public static readonly Guid BurmeseId = new("d0000042-0000-0000-0000-000000000042");
    public static readonly Guid KhmerId = new("d0000043-0000-0000-0000-000000000043");
    public static readonly Guid LaoId = new("d0000044-0000-0000-0000-000000000044");
    public static readonly Guid TagalogId = new("d0000045-0000-0000-0000-000000000045");
    public static readonly Guid IcelandicId = new("d0000046-0000-0000-0000-000000000046");
    public static readonly Guid MalteseId = new("d0000047-0000-0000-0000-000000000047");
    public static readonly Guid WelshId = new("d0000048-0000-0000-0000-000000000048");
    public static readonly Guid IrishId = new("d0000049-0000-0000-0000-000000000049");
    public static readonly Guid ScottishGaelicId = new("d000004a-0000-0000-0000-00000000004a");
    public static readonly Guid BasqueId = new("d000004b-0000-0000-0000-00000000004b");
    public static readonly Guid GalicianId = new("d000004c-0000-0000-0000-00000000004c");
    public static readonly Guid BosnianId = new("d000004d-0000-0000-0000-00000000004d");
    public static readonly Guid LuxembourgishId = new("d000004e-0000-0000-0000-00000000004e");
    public static readonly Guid PashtoId = new("d000004f-0000-0000-0000-00000000004f");
    public static readonly Guid SindhiId = new("d0000050-0000-0000-0000-000000000050");

    private static readonly Language[] _data =
    [
        new Language { Id = EnglishId, Name = "English", Code = "en", IsDeleted = false, IsActive = true },
        new Language { Id = ArabicId, Name = "Arabic", Code = "ar", IsDeleted = false, IsActive = true },
        new Language { Id = FrenchId, Name = "French", Code = "fr", IsDeleted = false, IsActive = true },
        new Language { Id = SpanishId, Name = "Spanish", Code = "es", IsDeleted = false, IsActive = true },
        new Language { Id = ChineseMandarinId, Name = "Chinese (Mandarin)", Code = "zh", IsDeleted = false, IsActive = true },
        new Language { Id = HindiId, Name = "Hindi", Code = "hi", IsDeleted = false, IsActive = true },
        new Language { Id = PortugueseId, Name = "Portuguese", Code = "pt", IsDeleted = false, IsActive = true },
        new Language { Id = BengaliId, Name = "Bengali", Code = "bn", IsDeleted = false, IsActive = true },
        new Language { Id = RussianId, Name = "Russian", Code = "ru", IsDeleted = false, IsActive = true },
        new Language { Id = JapaneseId, Name = "Japanese", Code = "ja", IsDeleted = false, IsActive = true },
        new Language { Id = GermanId, Name = "German", Code = "de", IsDeleted = false, IsActive = true },
        new Language { Id = KoreanId, Name = "Korean", Code = "ko", IsDeleted = false, IsActive = true },
        new Language { Id = ItalianId, Name = "Italian", Code = "it", IsDeleted = false, IsActive = true },
        new Language { Id = TurkishId, Name = "Turkish", Code = "tr", IsDeleted = false, IsActive = true },
        new Language { Id = VietnameseId, Name = "Vietnamese", Code = "vi", IsDeleted = false, IsActive = true },
        new Language { Id = PersianId, Name = "Persian", Code = "fa", IsDeleted = false, IsActive = true },
        new Language { Id = UrduId, Name = "Urdu", Code = "ur", IsDeleted = false, IsActive = true },
        new Language { Id = IndonesianId, Name = "Indonesian", Code = "id", IsDeleted = false, IsActive = true },
        new Language { Id = DutchId, Name = "Dutch", Code = "nl", IsDeleted = false, IsActive = true },
        new Language { Id = PolishId, Name = "Polish", Code = "pl", IsDeleted = false, IsActive = true },
        new Language { Id = ThaiId, Name = "Thai", Code = "th", IsDeleted = false, IsActive = true },
        new Language { Id = GreekId, Name = "Greek", Code = "el", IsDeleted = false, IsActive = true },
        new Language { Id = SwedishId, Name = "Swedish", Code = "sv", IsDeleted = false, IsActive = true },
        new Language { Id = RomanianId, Name = "Romanian", Code = "ro", IsDeleted = false, IsActive = true },
        new Language { Id = CzechId, Name = "Czech", Code = "cs", IsDeleted = false, IsActive = true },
        new Language { Id = HungarianId, Name = "Hungarian", Code = "hu", IsDeleted = false, IsActive = true },
        new Language { Id = HebrewId, Name = "Hebrew", Code = "he", IsDeleted = false, IsActive = true },
        new Language { Id = UkrainianId, Name = "Ukrainian", Code = "uk", IsDeleted = false, IsActive = true },
        new Language { Id = MalayId, Name = "Malay", Code = "ms", IsDeleted = false, IsActive = true },
        new Language { Id = SwahiliId, Name = "Swahili", Code = "sw", IsDeleted = false, IsActive = true },
        new Language { Id = TamilId, Name = "Tamil", Code = "ta", IsDeleted = false, IsActive = true },
        new Language { Id = KurdishId, Name = "Kurdish", Code = "ku", IsDeleted = false, IsActive = true },
        new Language { Id = DanishId, Name = "Danish", Code = "da", IsDeleted = false, IsActive = true },
        new Language { Id = NorwegianId, Name = "Norwegian", Code = "no", IsDeleted = false, IsActive = true },
        new Language { Id = FinnishId, Name = "Finnish", Code = "fi", IsDeleted = false, IsActive = true },
        new Language { Id = SlovakId, Name = "Slovak", Code = "sk", IsDeleted = false, IsActive = true },
        new Language { Id = BulgarianId, Name = "Bulgarian", Code = "bg", IsDeleted = false, IsActive = true },
        new Language { Id = CroatianId, Name = "Croatian", Code = "hr", IsDeleted = false, IsActive = true },
        new Language { Id = SerbianId, Name = "Serbian", Code = "sr", IsDeleted = false, IsActive = true },
        new Language { Id = CatalanId, Name = "Catalan", Code = "ca", IsDeleted = false, IsActive = true },
        new Language { Id = AfrikaansId, Name = "Afrikaans", Code = "af", IsDeleted = false, IsActive = true },
        new Language { Id = NepaliId, Name = "Nepali", Code = "ne", IsDeleted = false, IsActive = true },
        new Language { Id = SinhalaId, Name = "Sinhala", Code = "si", IsDeleted = false, IsActive = true },
        new Language { Id = MarathiId, Name = "Marathi", Code = "mr", IsDeleted = false, IsActive = true },
        new Language { Id = PunjabiId, Name = "Punjabi", Code = "pa", IsDeleted = false, IsActive = true },
        new Language { Id = GujaratiId, Name = "Gujarati", Code = "gu", IsDeleted = false, IsActive = true },
        new Language { Id = AmharicId, Name = "Amharic", Code = "am", IsDeleted = false, IsActive = true },
        new Language { Id = HausaId, Name = "Hausa", Code = "ha", IsDeleted = false, IsActive = true },
        new Language { Id = YorubaId, Name = "Yoruba", Code = "yo", IsDeleted = false, IsActive = true },
        new Language { Id = SomaliId, Name = "Somali", Code = "so", IsDeleted = false, IsActive = true },
        new Language { Id = LithuanianId, Name = "Lithuanian", Code = "lt", IsDeleted = false, IsActive = true },
        new Language { Id = LatvianId, Name = "Latvian", Code = "lv", IsDeleted = false, IsActive = true },
        new Language { Id = EstonianId, Name = "Estonian", Code = "et", IsDeleted = false, IsActive = true },
        new Language { Id = SlovenianId, Name = "Slovenian", Code = "sl", IsDeleted = false, IsActive = true },
        new Language { Id = AlbanianId, Name = "Albanian", Code = "sq", IsDeleted = false, IsActive = true },
        new Language { Id = MacedonianId, Name = "Macedonian", Code = "mk", IsDeleted = false, IsActive = true },
        new Language { Id = ArmenianId, Name = "Armenian", Code = "hy", IsDeleted = false, IsActive = true },
        new Language { Id = GeorgianId, Name = "Georgian", Code = "ka", IsDeleted = false, IsActive = true },
        new Language { Id = KazakhId, Name = "Kazakh", Code = "kk", IsDeleted = false, IsActive = true },
        new Language { Id = UzbekId, Name = "Uzbek", Code = "uz", IsDeleted = false, IsActive = true },
        new Language { Id = AzerbaijaniId, Name = "Azerbaijani", Code = "az", IsDeleted = false, IsActive = true },
        new Language { Id = KyrgyzId, Name = "Kyrgyz", Code = "ky", IsDeleted = false, IsActive = true },
        new Language { Id = TurkmenId, Name = "Turkmen", Code = "tk", IsDeleted = false, IsActive = true },
        new Language { Id = TajikId, Name = "Tajik", Code = "tg", IsDeleted = false, IsActive = true },
        new Language { Id = MongolianId, Name = "Mongolian", Code = "mn", IsDeleted = false, IsActive = true },
        new Language { Id = BurmeseId, Name = "Burmese", Code = "my", IsDeleted = false, IsActive = true },
        new Language { Id = KhmerId, Name = "Khmer", Code = "km", IsDeleted = false, IsActive = true },
        new Language { Id = LaoId, Name = "Lao", Code = "lo", IsDeleted = false, IsActive = true },
        new Language { Id = TagalogId, Name = "Tagalog", Code = "tl", IsDeleted = false, IsActive = true },
        new Language { Id = IcelandicId, Name = "Icelandic", Code = "is", IsDeleted = false, IsActive = true },
        new Language { Id = MalteseId, Name = "Maltese", Code = "mt", IsDeleted = false, IsActive = true },
        new Language { Id = WelshId, Name = "Welsh", Code = "cy", IsDeleted = false, IsActive = true },
        new Language { Id = IrishId, Name = "Irish", Code = "ga", IsDeleted = false, IsActive = true },
        new Language { Id = ScottishGaelicId, Name = "Scottish Gaelic", Code = "gd", IsDeleted = false, IsActive = true },
        new Language { Id = BasqueId, Name = "Basque", Code = "eu", IsDeleted = false, IsActive = true },
        new Language { Id = GalicianId, Name = "Galician", Code = "gl", IsDeleted = false, IsActive = true },
        new Language { Id = BosnianId, Name = "Bosnian", Code = "bs", IsDeleted = false, IsActive = true },
        new Language { Id = LuxembourgishId, Name = "Luxembourgish", Code = "lb", IsDeleted = false, IsActive = true },
        new Language { Id = PashtoId, Name = "Pashto", Code = "ps", IsDeleted = false, IsActive = true },
        new Language { Id = SindhiId, Name = "Sindhi", Code = "sd", IsDeleted = false, IsActive = true }
    ];

    public Language[] GetData() => _data;
}
