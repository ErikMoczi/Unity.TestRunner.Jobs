namespace WorkSpace
{
    public static class Utils
    {
        public static string CommonPrefix(string[] data)
        {
            if (data.Length == 0)
            {
                return string.Empty;
            }

            if (data.Length == 1)
            {
                return data[0];
            }

            var prefixLength = 0;
            foreach (var c in data[0])
            {
                for (var index = 0; index < data.Length; index++)
                {
                    var value = data[index];
                    if (value.Length <= prefixLength || value[prefixLength] != c)
                    {
                        return data[0].Substring(0, prefixLength);
                    }
                }

                prefixLength++;
            }

            return data[0];
        }

        public static string RemoveLastItem(string value, char separator)
        {
            var lastIndex = value.LastIndexOf(separator);
            return lastIndex != -1 ? value.Substring(0, lastIndex) : value;
        }
    }
}