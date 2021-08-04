using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebTest.Models
{
    public static class Helper
    {
        public static void writeLog(Exception except, string source= "WebTest Application Log")
        {
            string log = "Application";
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }
            EventLog.WriteEntry(source, except.GetType().Name + ", " + except.Message, EventLogEntryType.Error);
        }

        public static int toLowerCase(char input)
        {
            var inputCode = (int)input;
            inputCode = inputCode > 96 && inputCode < 123 ? inputCode - 32 : inputCode;
            return (char)inputCode;
        }

        public static string[] split(string input, char delimiter)
        {
            var result = new List<string>();
            string temp = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != delimiter)
                {
                    temp += input[i];
                    if (i == (input.Length - 1))
                        result.Add(temp);
                    continue;
                }

                result.Add(temp);
                temp = "";
            }

            return result.ToArray();
        }

        public static string substring(string input, int startIndex, int endIndex)
        {
            string result = "";

            for (int i = startIndex; i < input.Length; i++)
            {
                if (i == endIndex)
                    break;
                result += input[i];
            }

            return result;
        }

        public static bool contains(string content, string keyword, bool caseSensitive = false)
        {
            bool isMatch = false;
            bool hasEqualChar = false;
            int j = 0;

            if (keyword.Length > 0)
            {
                for (int i = 0; i < content.Length - 1; i++)
                {
                    var charContent = caseSensitive ? content[i] : toLowerCase(content[i]);
                    var charKeyword = caseSensitive ? keyword[j] : toLowerCase(keyword[j]);

                    if (charContent == charKeyword)
                    {
                        hasEqualChar = true;
                        if (j == keyword.Length - 1)
                        {
                            isMatch = true;
                            break;
                        }
                        j++;
                    }
                    else
                    {
                        if (hasEqualChar)
                        {
                            i = i - j;
                            hasEqualChar = false;
                        }
                        j = 0;
                    }
                }
            }
            return isMatch;
        }
    }
}