namespace Journaley.Core.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A utility class that helps extracting the "first sentence" from an entry text.
    /// </summary>
    public class FirstSentenceExtractor
    {
        /// <summary>
        /// The punctuation marks
        /// </summary>
        private static readonly char[] PunctuationMarks = new char[] { '.', '!', '?' };

        /// <summary>
        /// The popular abbreviations
        /// </summary>
        private static readonly string[] PopularAbbreviations = new string[] { "Mr.", "Mrs.", "Ms.", "Dr.", "vs." };

        /// <summary>
        /// Extracts the first sentence.
        /// </summary>
        /// <param name="fullText">The entry text, after processing Markdown / htmlToText.</param>
        /// <returns>The extracted (optional) title and the first sentence of the full text.</returns>
        public static Tuple<string, string> ExtractTitleAndFirstSentence(string fullText)
        {
            string[] lines = fullText.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length == 0)
            {
                return new Tuple<string, string>(null, string.Empty);
            }

            string firstLine = lines[0];
            int pos = IndexOfPunctuationMark(firstLine, 0);

            // If there is a punctuation mark, just return the first sentence without title.
            if (pos != -1)
            {
                return new Tuple<string, string>(null, firstLine.Substring(0, pos + 1));
            }

            // If not, then the first line becomes the title.
            if (lines.Length == 1)
            {
                return new Tuple<string, string>(firstLine, string.Empty);
            }

            string secondLine = lines[1];
            pos = IndexOfPunctuationMark(secondLine, 0);

            string firstSentence = pos == -1 ? secondLine : secondLine.Substring(0, pos + 1);
            return new Tuple<string, string>(firstLine, firstSentence);
        }

        /// <summary>
        /// Extracts the first line.
        /// </summary>
        /// <param name="fullText">The full text.</param>
        /// <returns>The first line of the given full text, or an empty string if there's none.</returns>
        public static string ExtractFirstLine(string fullText)
        {
            if (fullText == null)
            {
                return string.Empty;
            }

            string result = fullText
                .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault();

            return result == null ? string.Empty : result;
        }

        /// <summary>
        /// Returns the index of the first punctuation mark from the startIndex.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>The index of first punctuation mark, or -1 if none.</returns>
        /// <exception cref="System.ArgumentNullException">thrown when line is null.</exception>
        private static int IndexOfPunctuationMark(string line, int startIndex)
        {
            if (line == null)
            {
                throw new ArgumentNullException("line");
            }

            if (startIndex >= line.Length)
            {
                return -1;
            }

            int pos = line.IndexOfAny(PunctuationMarks, startIndex);
            if (pos == -1)
            {
                return -1;
            }

            // If this is the last character in the given line, return this position.
            if (pos == line.Length - 1)
            {
                return pos;
            }

            // See if this is part of the popular abbreviations.
            foreach (var abbr in PopularAbbreviations)
            {
                if (pos >= abbr.Length - 1 && line.Substring(pos - abbr.Length + 1, abbr.Length) == abbr)
                {
                    return IndexOfPunctuationMark(line, pos + 1);
                }
            }

            // See if there's a following space.
            if (line.Length > pos + 1 && char.IsWhiteSpace(line[pos + 1]))
            {
                return pos;
            }

            return IndexOfPunctuationMark(line, pos + 1);
        }
    }
}
