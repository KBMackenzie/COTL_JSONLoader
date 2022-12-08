using System;
using System.Collections.Generic;
using System.Text;

namespace COTL_JSONLoader.Helpers;

// This is so I don't have to repeat myself making 232903902 dictionaries for enums.
// It creates a Dictionary<string, EnumValue> on its own.
// This should also be faster than casting a string to an enum every time. = u=
internal class EnumDictionary<T> where T : Enum
{
    private readonly Dictionary<string, T> _enumValues = new();
    private readonly T? _defaultEnumValue;
    public T Default => _defaultEnumValue ?? _enumValues.First().Value;
    public int Count => _enumValues.Count;

    public EnumDictionary()
    {
        CreateDictionary();
    }

    public EnumDictionary(T newDefault)
    {
        _defaultEnumValue = newDefault;
        CreateDictionary();
    }

    private void CreateDictionary()
    {
        string[] names = Enum.GetNames(typeof(T));
        T[]? values = Enum.GetValues(typeof(T)) as T[];

        if (values == null) return;

        for (int i = 0; i < names.Length; i++)
        {
            // ToLower() is so it'll be more forgiving.
            // JSON users can be bad with capitalization, after all.
            // I don't think this will lead to duplicate keys; I mean, what are the chances?? What kind of enum has two keys that are identical except for capitalization??

            _enumValues.Add(names[0].ToLower(), values[0]);
        }
    }

    public T Get(string? key)
    {
        key = key?.Trim()?.ToLower() ?? string.Empty;

        return _enumValues.ContainsKey(key)
            ? _enumValues[key]
            : this.Default;
    }
}
