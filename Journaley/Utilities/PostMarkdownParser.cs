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

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            System.Text.StringBuilder paragraphBuilder = new System.Text.StringBuilder();

            var isNewLine = 0;

            string newLineString;
            string strippedOverString;

            var lines = formattedString.Split(
                new string[] { "\r\n", "\n" },
                StringSplitOptions.None);

            for (int i = 0; i < lines.Length - 1; ++i)
            {
                string line = lines[i];

                // We first incrementally check if the line begins with <p> tag. When it does,
                // We turn on the paragraphBuilder to append the remaining lines.

                // If the checks hit a line with the </p> closing, we disable check and proceed
                // to parse the text, add <br /> tags and then adding it to builder
                // where it is assembled with the rest of the file.
                
                // We dump the text to builder if it hits a <pre> tag.
                if (line.Contains("<p>"))
                {
                    isNewLine = 1;
                }
                else if (line.Contains("</p>"))
                {
                    isNewLine = 0;
                }
                else if (line.Contains("<pre>"))
                {
                    isNewLine = -1;
                }

                if (isNewLine == 1)
                {
                    paragraphBuilder.AppendLine(line);

                    if (line.Contains("</p>"))
                    {
                        // Single line strikethroughs.
                        line = Regex.Replace(line, @"(~~)(.*?)(~~)", "<del>$2</del>", RegexOptions.Multiline);
                        builder.AppendLine(line);
                        paragraphBuilder.Clear();
                        isNewLine = 0;
                    }
                }
                else if (isNewLine == 0)
                {
                    paragraphBuilder.AppendLine(line);

                    newLineString = paragraphBuilder.ToString();

                    // Multiline strikethrough.
                    if (Regex.IsMatch(newLineString, @"(~~)(.*?)(~~)"))
                    {
                        newLineString = Regex.Replace(newLineString, @"(~~)(.*?)(~~)", "<del>$2</del>", RegexOptions.Multiline);
                    }
                    else
                    {
                        newLineString = Regex.Replace(newLineString, @"<p>(~~)", "<p><del>", RegexOptions.Multiline);
                        newLineString = Regex.Replace(newLineString, @"(~~)</p>", "</del></p>", RegexOptions.Multiline);
                    }

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

            builder.AppendLine(lines.Last());
            strippedOverString = Regex.Replace(builder.ToString(), @"^(\r\s)", string.Empty, RegexOptions.Multiline);

            return strippedOverString;
        }
    }
}
