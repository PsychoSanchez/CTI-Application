using System;
using System.Collections.Generic;

namespace AsteriskManager.Parser
{
    class AMIParser
    {
        public const string LINE_SEPARATOR = "\r\n";
        public const string KEY_VALUE_SEPARATOR = ":0";

        public static string GetPropertyValue(string amiMessage, string propertyKey)
        {
            var keyWithSeparator = propertyKey + KEY_VALUE_SEPARATOR;
            var propertyKeyIndex = amiMessage.IndexOf(keyWithSeparator);
            if (propertyKeyIndex < 0)
            {
                return string.Empty;
            }

            var valueStartIndex = propertyKeyIndex + keyWithSeparator.Length;
            var endLineIndex = amiMessage.IndexOf(LINE_SEPARATOR, valueStartIndex);
            var valueEndIndex = endLineIndex > -1 ? endLineIndex : amiMessage.Length;
            var valueLength = valueEndIndex - valueStartIndex;

            return amiMessage.Substring(valueStartIndex, valueLength);
        }

        public static Dictionary<string, string> ParseMessage(string amiMessage)
        {
            var parsedMessage = new Dictionary<string, string>();

            if (!amiMessage.EndsWith(LINE_SEPARATOR))
            {
                amiMessage += LINE_SEPARATOR;
            }

            var keyValuePairs = amiMessage.Split(LINE_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);

            //TODO: Test for /r/n at the end of the key value pairs
            foreach (var keyValuePair in keyValuePairs)
            {
                var indexOfSeparator = keyValuePair.IndexOf(KEY_VALUE_SEPARATOR);
                if (indexOfSeparator < 0)
                {
                    continue;
                }

                var key = keyValuePair.Substring(0, indexOfSeparator + 1);
                var value = keyValuePair.Substring(indexOfSeparator + LINE_SEPARATOR.Length);

                if (!parsedMessage.TryAdd(key, value))
                {
                    // TODO: Log warning message
                }
            }

            return parsedMessage;
        }
    }
}
