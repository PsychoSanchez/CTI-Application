using System.Collections.Generic;

namespace AsteriskManager.Utils
{
    partial class AsteriskManagerUtils
    {
        private const string RUSSIAN_LOWERCASE_ALPHABET = "а б в г д е ё ж з и й к л м н о п р с т у ф х ц ч ш щ ъ ы ь э ю я";
        private const string RUSSIAN_UPPERCASE_ALPHABET = "А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я";

        private const string ENGLISH_LOWERCASE_ALPHABET = "a b v g d e yo zh z i y k l m n o p r s t u f kh ts ch sh shch \" y ' e yu ya";
        private const string ENGLISH_UPPERCASE_ALPHABET = "A B V G D E Yo Zh Z I Y K L M N O P R S T U F Kh Ts Ch Sh Shch \" Y ' E Yu Ya";

        private static Dictionary<char, string> RusToEngMap;
        private static void InitDictionary()
        {
            RusToEngMap ??= new Dictionary<char, string>();
            var rulowercase = RUSSIAN_LOWERCASE_ALPHABET.Split(' ');
            var ruuppercase = RUSSIAN_UPPERCASE_ALPHABET.Split(' ');
            var enlowercase = ENGLISH_LOWERCASE_ALPHABET.Split(' ');
            var enuppercase = ENGLISH_UPPERCASE_ALPHABET.Split(' ');

            for (int i = 0; i < rulowercase.Length; i++)
            {
                RusToEngMap.Add(rulowercase[i][0], enlowercase[i]);
                RusToEngMap.Add(ruuppercase[i][0], enuppercase[i]);
            }
        }

        public static string ConvertToTranslit(string rustring)
        {
            if (RusToEngMap == null)
            {
                InitDictionary();
            }

            string enstring = string.Empty;
            var charstring = rustring.ToCharArray();

            for (int i = 0; i < charstring.Length; i++)
            {
                if (RusToEngMap.ContainsKey(charstring[i]))
                {
                    charstring[i] = RusToEngMap[charstring[i]][0];
                }

                enstring = enstring + charstring[i];
            }
            return enstring;
        }
    }
}