namespace AdventOfCode.Common.Extensions;

public static class StringExtensions
{
    public static T[] SplitAndConvert<T>(this string input,
        char separator,
        Func<string, T>? converter = null)
    {
        ArgumentNullException.ThrowIfNull(input);

        if (converter == null && typeof(T) != typeof(string))
        {
            throw new ArgumentNullException(nameof(converter), "Converter cannot be null if T is not string.");
        }


        var count = 1;
        foreach (var t in input)
        {
            if (t == separator)
            {
                count++;
            }
        }

        var result = new T[count];

        var start = 0;
        var index = 0;
        for (var i = 0; i <= input.Length; i++)
        {
            if (i != input.Length && input[i] != separator)
            {
                continue;
            }

            var slice = input.AsSpan(start, i - start);

            if (converter != null)
            {
                result[index++] = converter(slice.ToString());
            }
            else
            {
                result[index++] = (T)(object)slice.ToString();
            }

            start = i + 1;
        }

        return result;
    }
}
