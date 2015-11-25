namespace Journaley.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Helper class for fixing MarkdownDeep parsed HTML.
    /// </summary>
    public class PostMarkdownParser
    {
        /// <summary>
        /// Perform fixes after MarkdownDeep parsing for publishing
        /// to Journaley.
        /// - automatically adds break tags on single line breaks.
        /// - adds strikethrough style support.
        /// - makes the first sentence into a header.
        /// </summary>
        /// <param name="formattedString">Formatted HTML string</param>
        /// <returns>Properly formatted HTML string for publishing.</returns>
        public static string PostMarkdown(string formattedString)
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder paragraphBuilder = new StringBuilder();

            // 0 - stumbles upon the beginning of a <p> tag/usual parsing.
            // 1 - stumbles upon the end of </p> tag.
            // 2 - skips check and just dumps the line to builder.
            var parseState = -1;

            bool firstTitleParsed = false;

            var lines = formattedString.Split(
                new string[] { "\r\n", "\n" },
                StringSplitOptions.None);

            foreach (string line in lines)
            {
                // We first incrementally check if the line begins with <p> tag. When it does,
                // We turn on the paragraphBuilder to append the remaining lines.

                // If the checks hit a line with the </p> closing, we disable check and proceed
                // to parse the text, add <br /> tags and then adding it to builder
                // where it is assembled with the rest of the file.
                if (line.Contains("<p>"))
                {
                    parseState = 1;
                }
                else if (line.Contains("</p>"))
                {
                    parseState = 0;
                }
                else if (line.Contains("<pre>"))
                {
                    parseState = -1;
                }

                if (parseState == 1)
                {
                    if (line.Contains("</p>"))
                    {
                        string singleLine = line;
                        if (!firstTitleParsed)
                        {
                            singleLine = Regex.Replace(singleLine, @"(<p>)(.*?)(</p>)", "<h2>$2</h2>\n<br/>");
                            firstTitleParsed = true;
                        }

                        builder.AppendLine(ReplaceMDStrikethrough(singleLine));
                        parseState = -1;
                    }
                    else
                    {
                        paragraphBuilder.AppendLine(ReplaceMDStrikethrough(line) + "<br />");
                    }
                }
                else if (parseState == 0)
                {
                    paragraphBuilder.AppendLine(ReplaceMDStrikethrough(line));

                    builder.AppendLine(paragraphBuilder.ToString());
                    paragraphBuilder.Clear();
                    parseState = -1;
                }
                else
                {
                    // For <pre> tagged text, just skip check and append to builder
                    builder.AppendLine(line);
                }
            }

            return builder.ToString();
        }
        
        /// <summary>
        /// Replaces "~~" strikethrough Markdown tag into del HTML tags.
        /// </summary>
        /// <param name="parsedString">Any string that has strikethrough tags</param>
        /// <returns>A string with del HTML tags in place of Markdown strikethrough tags.</returns>
        private static string ReplaceMDStrikethrough(string parsedString)
        {
            parsedString = Regex.Replace(parsedString, @"(~~)(.*?)(~~)", "<del>$2</del>", RegexOptions.Singleline);
            parsedString = Regex.Replace(parsedString, @"(?<=<p>)(~~)", "<del>", RegexOptions.Singleline);
            parsedString = Regex.Replace(parsedString, @"(~~)(?=</p>)", "</del>", RegexOptions.Singleline);

            return parsedString;
        }
    }
}
