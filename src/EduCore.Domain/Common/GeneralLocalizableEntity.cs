using EduCore.Domain.Entities;
using System.Globalization;

namespace EduCore.Domain.Common;

public class GeneralLocalizableEntity : BaseEntity
{
    public string Localize(string textAr, string textEN)
    {
        CultureInfo CultureInfo = Thread.CurrentThread.CurrentCulture;
        if (CultureInfo.TwoLetterISOLanguageName.ToLower().Equals("ar"))
            return textAr;
        return textEN;
    }
}
