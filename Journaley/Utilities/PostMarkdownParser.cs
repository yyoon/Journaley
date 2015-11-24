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
        /// </summary>
        /// <param name="formattedString">Formatted HTML string</param>
        /// <returns>Properly formatted HTML string for publishing.</returns>
        public static string PostMarkdown(string formattedString)
        {
            // First convert all code blocks using <p> into <pre>
            // which is used in almost all implementations of
            // Markdown, even in the original Markdown specs.
            formattedString = Regex.Replace(formattedString, @"<p><code>", "<pre><code>", RegexOptions.Multiline);
            formattedString = Regex.Replace(formattedString, @"</code></p>", "</code></pre>", RegexOptions.Multiline);

            StringBuilder builder = new System.Text.StringBuilder();
            StringBuilder paragraphBuilder = new System.Text.StringBuilder();

            // 0 - stumbles upon the beginning of a <p> tag/usual parsing.
            // 1 - stumbles upon the end of </p> tag.
            // 2 - stumbles upon a <pre> tag.
            var parseState = 0;

            string newLineString;
            string singleStrike;

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
                
                // We dump the text to builder if it hits a <pre> tag.
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
                    paragraphBuilder.AppendLine(line);

                    if (line.Contains("</p>"))
                    {
                        // Single line strikethroughs.
                        singleStrike = Regex.Replace(line, @"(~~)(.*?)(~~)", "<del>$2</del>", RegexOptions.Singleline);
                        builder.AppendLine(singleStrike);
                        paragraphBuilder.Clear();
                        parseState = 0;
                    }
                }
                else if (parseState == 0)
                {
                    paragraphBuilder.AppendLine(line);

                    newLineString = paragraphBuilder.ToString();

                    // Multi line strikethrough
                    newLineString = Regex.Replace(newLineString, @"(~~)(.*?)(~~)", "<del>$2</del>", RegexOptions.Multiline);

                    // Single line breaks append with <br> tags.
                    newLineString = Regex.Replace(newLineString, @"^([\w\*\>\<\[][^\r\n]*)(?=\r?\n[\w\*\>\<\[].*$)", "$1<br />", RegexOptions.Multiline);

                    builder.AppendLine(newLineString);
                    paragraphBuilder.Clear();
                }
                else
                {
                    // For <pre> tagged text, just skip check and append to builder
                    builder.AppendLine(line);
                }
            }

            string strippedOverString = Regex.Replace(builder.ToString(), @"^(\r\s)", string.Empty, RegexOptions.Multiline);

            return strippedOverString;
        }
    }
}
