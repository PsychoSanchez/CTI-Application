using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BCTI.Helpers
{
    public class Pattern
    {
        public string _prepend { get; set; }
        public string _prefix { get; set; }
        public string _match { get; set; }

        public Pattern()
        {
            _prepend = string.Empty;
            _prefix = string.Empty;
            _match = string.Empty;
        }
        public Pattern(string inputPattern)
        {
            var values = inputPattern.Split(';');
            if (values.Length == 3)
            {
                _prepend = values[0];
                _prefix = values[1];
                _match = values[2];
            }
        }

        public override string ToString()
        {
            return _prepend + ";" + _prefix + ";" + _match;
        }

        public List<string> CreateRules()
        {
            List<string> rules = new List<string>();

            int interval = 0;
            string intervalRule = String.Empty;
            foreach (char letter in _match)
            {
                if (letter == '[')
                {
                    interval++;
                    intervalRule += letter;
                    continue;
                }
                if (letter == ']')
                {
                    interval = 0;
                    intervalRule += letter;
                    rules.Add((string)intervalRule.Clone());
                    intervalRule = string.Empty;
                    continue;
                }
                if (interval <= 0)
                {
                    rules.Add(letter.ToString());
                    interval = 0;
                }
                else if (interval > 0)
                    intervalRule += letter;
            }
            if (!rules.Contains(intervalRule) && !string.IsNullOrEmpty(intervalRule))
                rules.Add(intervalRule);
            return rules;
        }

        public bool MatchesPattern(string mainnumber)
        {
            List<string> rules = this.CreateRules();
            int ruleIndex = 0;
            int numberIndex = 0;
            string number = (!string.IsNullOrEmpty(_prefix) && mainnumber.StartsWith(_prefix) ? mainnumber.Remove(mainnumber.IndexOf(_prefix), _prefix.Length) : mainnumber);
            while (ruleIndex < rules.Count && numberIndex < number.Length)
            {
                if (rules[ruleIndex] == "X")
                {
                    if (number[numberIndex] >= '0' && number[numberIndex] <= '9')
                    {
                        numberIndex++;
                        ruleIndex++;
                    }
                    else
                        return false;
                }
                else if (rules[ruleIndex] == ".")
                {
                    if (ruleIndex == rules.Count - 1)
                        return true;
                    else
                    {
                        ruleIndex++;
                        if (rules[ruleIndex] == "X")
                            numberIndex++;
                        else if (number.Substring(numberIndex).Contains(rules[ruleIndex]))
                            numberIndex += number.Substring(numberIndex).IndexOf(rules[ruleIndex]);
                    }
                }
                else if (rules[ruleIndex] == number[numberIndex].ToString())
                {
                    numberIndex++;
                    ruleIndex++;
                }
                else
                    return false;
            }

            int countDots = 0;
            for (int i = ruleIndex; i < rules.Count; i++)
            {
                if (rules[i] == ".")
                    countDots++;
            }
            return (number.Length == numberIndex && (ruleIndex == rules.Count - countDots) && (rules.Count - ruleIndex == countDots));
        }

        public string ChangeNumber(string number)
        {
            return number.Remove(number.IndexOf(_prefix), _prefix.Length).Insert(0, _prepend);
        }

        public string Clear(string number, List<string> rules)
        {
            foreach (var letter in number)
            {
                foreach (var rule in rules)
                {
                    if (rule.Length == 1)
                        if (letter == rule[0])
                            number = number.Remove(number.IndexOf(letter), 1);
                        else { }
                    else
                    {
                        if (rule.Contains('-'))
                        {
                            if (string.IsNullOrEmpty(rule))
                            {
                                number = number.Replace("[", "").Replace("]", "");
                            }
                            else
                            {
                                var interval = rule.Split('-');
                                if (interval[0].Length != 2 || interval[1].Length != 2)
                                {
                                    foreach (var symbol in interval[0])
                                        number = number.Replace(symbol.ToString(), "");
                                    foreach (var symbol in interval[1])
                                        number = number.Replace(symbol.ToString(), "");
                                }
                                else if (letter >= interval[0].Replace("[", "")[0] && letter <= interval[1].Replace("]", "")[0])
                                    number = number.Remove(number.IndexOf(letter), 1);
                            }
                        }
                        else
                        {
                            foreach (var symbol in rule)
                                number = number.Replace(symbol.ToString(), "");
                        }
                    }
                }
            }
            return number;
        }
    }
    class Editor
    {
        public static string filePath = string.Empty;
        public static List<Pattern> GetPatterns(string filePath)
        {
            List<Pattern> temp = new List<Pattern>();
            var patterns = File.ReadAllLines(filePath, Encoding.GetEncoding(1251));
            foreach (var pattern in patterns)
            {
                Pattern tempPattern = new Pattern(pattern);
                temp.Add(tempPattern);
            }
            return temp;
        }

        public static string CreateNumber(string number, List<Pattern> temp)
        {
            foreach (var pattern in temp)
            {
                if (pattern._prepend.ToLower() == "clear")
                {
                    var rules = pattern.CreateRules();
                    number = pattern.Clear(number, rules);
                }
                else if (pattern._prefix != "Prefix" && pattern._prepend != "Prepend" && pattern._match != "Match")
                    if (pattern.MatchesPattern(number) && number.StartsWith(pattern._prefix))
                        return pattern.ChangeNumber(number);
            }

            return number;
        }
        public static string EditNumber(string number)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                return number.Replace("\r", "").Replace("\n", "");
            }
            number = CreateNumber(number.Replace("\r", "").Replace("\n", "").Replace(" ", ""), GetPatterns(filePath));
            return number;
        }

        public static Encoding GetEncoding(string filename)
        {
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.ASCII;
        }
    }
}