
using System.Collections.Generic;

namespace AsteriskManager.Utils
{
    partial class AsteriskManagerUtils
    {
        public static Dictionary<string, object> OmitNullOrEmptyStrings(Dictionary<string, object> map)
        {

            foreach (var item in map)
            {
                if (item.Value is string && string.IsNullOrEmpty((string)item.Value))
                {
                    map.Remove(item.Key);
                }
            }

            return map;
        }
    }
}