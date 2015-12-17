namespace Journaley.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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
        /// - makes the first sentence into a header.
        /// - properly parses code blocks enclosed in p tags into pre.
        /// - auto-linking (converting bare URLs and enclose in a tags).
        /// </summary>
        /// <param name="formattedString">Formatted HTML string</param>
        /// <returns>Properly formatted HTML string for publishing.</returns>
        public static string PostMarkdown(string formattedString)
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder paragraphBuilder = new StringBuilder();

            // Auto-link regex. Only detects http/https links.
            Regex autoLink = new Regex(@"(?i)\b((?:https?://|www\d{0,3}[.]|[a-z0-9.\-]+[.][a-z]{2,4}/)(?:[^\s()<>]+|\(([^\s()<>]+|(\([^\s()<>]+\)))*\))+(?:\(([^\s()<>]+|(\([^\s()<>]+\)))*\)|[^\s`!()\[\]{};:'"".,<>?«»“”‘’]))", RegexOptions.Multiline);

            // -1 - skips check and just dumps the line to builder.
            // 0 - stumbles upon the beginning of a <p> tag/usual parsing.
            // 1 - stumbles upon the end of </p> tag.
            var parseState = -1;

            string line;
            using (StringReader reader = new StringReader(formattedString))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.Contains("<a href=\"") && !line.Contains("<img src=\""))
                    {
                        // Do not replace on links wrapped on img tags or already wrapped a tags.
                        line = autoLink.Replace(line, "<a href=\"$1\">$1</a>");
                    }

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
                            builder.AppendLine(line);
                            parseState = -1;
                        }
                        else
                        {
                            paragraphBuilder.AppendLine(line + "<br />");
                        }
                    }
                    else if (parseState == 0)
                    {
                        paragraphBuilder.AppendLine(line);

                        string paragraph = paragraphBuilder.ToString();

                        builder.Append(paragraph);
                        paragraphBuilder.Clear();
                        parseState = -1;
                    }
                    else
                    {
                        builder.AppendLine(line);
                    }
                }
            }

            return builder.ToString();
        }
    }
}
