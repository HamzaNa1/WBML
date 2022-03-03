using System.Collections.Generic;

namespace WBML.Utility;

public static class LocalizationUtils
{
    private static Dictionary<string, string> Dictionary  => LocalizedTextManager.instance.GetField<Dictionary<string, string>>("localizedText");

    public static void Add(string key, string value)
    {
        Dictionary.Add(key, value);
    }
}