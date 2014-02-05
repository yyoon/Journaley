namespace Journaley.Controls
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    using Journaley.Models;

    /// <summary>
    /// Customized ListBox control for displaying the list of journal entries prettier.
    /// </summary>
    internal class EntryListBox : ListBox
    {
        /// <summary>
        /// The month height
        /// </summary>
        private static readonly int MonthHeight = 22;

        /// <summary>
        /// The entry height
        /// </summary>
        private static readonly int EntryHeight = 78;

        /// <summary>
        /// The month format
        /// </summary>
        private static readonly string MonthFormat = "MMMM yyyy";

        /// <summary>
        /// The entry padding
        /// </summary>
        private static readonly int EntryPadding = 5;

        /// <summary>
        /// The entry right width
        /// </summary>
        private static readonly int EntryRightWidth = 80;

        /// <summary>
        /// The entry right small width
        /// </summary>
        private static readonly int EntryRightSmallWidth = 20;

        /// <summary>
        /// The entry right small height
        /// </summary>
        private static readonly int EntryRightSmallHeight = 20;

        /// <summary>
        /// The entry center margin
        /// </summary>
        private static readonly int EntryCenterMargin = 10;

        /// <summary>
        /// The entry text font
        /// </summary>
        private static readonly Font EntryTextFont = SystemFonts.DefaultFont;

        /// <summary>
        /// The entry day font
        /// </summary>
        private static readonly Font EntryDayFont = new Font(SystemFonts.DefaultFont.FontFamily, 28.0f, FontStyle.Bold);

        /// <summary>
        /// The entry day of week font
        /// </summary>
        private static readonly Font EntryDayOfWeekFont = new Font(SystemFonts.DefaultFont.FontFamily, 11.0f, FontStyle.Bold);

        /// <summary>
        /// The entry time font
        /// </summary>
        private static readonly Font EntryTimeFont = new Font(SystemFonts.DefaultFont.FontFamily, 9.0f);

        /// <summary>
        /// Initializes a new instance of the <see cref="EntryListBox"/> class.
        /// </summary>
        public EntryListBox()
            : base()
        {
            this.ScrollAlwaysVisible = true;

            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ListBox.MeasureItem" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MeasureItemEventArgs" /> that contains the event data.</param>
        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);

            // This can happen when there is no items at all.
            if (e.Index < 0 || e.Index >= this.Items.Count)
            {
                return;
            }

            object obj = this.Items[e.Index];

            // Set the item height
            if (obj is DateTime)
            {
                e.ItemHeight = MonthHeight;
            }
            else if (obj is Entry)
            {
                e.ItemHeight = EntryHeight;
            }
            else
            {
                // Unknown type. do nothing.
                Debug.Assert(false, "Wrong control flow.");
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ListBox.DrawItem" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.DrawItemEventArgs" /> that contains the event data.</param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index < 0 || e.Index >= this.Items.Count)
            {
                return;
            }

            object obj = this.Items[e.Index];

            // Draw the item
            if (obj is DateTime)
            {
                this.DrawMonth(e, (DateTime)obj);
            }
            else if (obj is Entry)
            {
                this.DrawEntry(e, (Entry)obj);
            }
            else
            {
                // Unknown type. do nothing.
            }
        }

        /// <summary>
        /// Draws a month line in-between the entries.
        /// </summary>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        /// <param name="dateTime">The date time.</param>
        private void DrawMonth(DrawItemEventArgs e, DateTime dateTime)
        {
            string text = dateTime.ToString(MonthFormat);

            StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault);
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Trimming = StringTrimming.EllipsisCharacter;

            e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
            e.Graphics.DrawString(text, e.Font, Brushes.White, e.Bounds, stringFormat);
        }

        /// <summary>
        /// Draws an entry. This method subsequently calls other Draw methods.
        /// </summary>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        /// <param name="entry">The entry.</param>
        private void DrawEntry(DrawItemEventArgs e, Entry entry)
        {
            this.DrawEntryText(e, entry);
            this.DrawDay(e, entry);
            this.DrawDayOfWeek(e, entry);
            this.DrawStar(e, entry);
            this.DrawTime(e, entry);
        }

        /// <summary>
        /// Draws the entry text.
        /// </summary>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        /// <param name="entry">The entry.</param>
        private void DrawEntryText(DrawItemEventArgs e, Entry entry)
        {
            Rectangle bounds = e.Bounds;
            bounds.Inflate(-EntryPadding, -EntryPadding);
            bounds.Width -= EntryRightWidth + EntryCenterMargin;

            StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault);
            stringFormat.FormatFlags = StringFormatFlags.LineLimit;
            stringFormat.Trimming = StringTrimming.EllipsisCharacter;

            e.Graphics.DrawString(entry.EntryText, EntryTextFont, Brushes.Black, bounds, stringFormat);
        }

        /// <summary>
        /// Draws the day.
        /// </summary>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        /// <param name="entry">The entry.</param>
        private void DrawDay(DrawItemEventArgs e, Entry entry)
        {
            Rectangle bounds = e.Bounds;
            bounds.Inflate(-EntryPadding, -EntryPadding);
            bounds.X += bounds.Width - EntryRightWidth + EntryRightSmallWidth;
            bounds.Width = EntryRightWidth - EntryRightSmallWidth;
            bounds.Height -= EntryRightSmallHeight;

            StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault);
            stringFormat.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(entry.LocalTime.ToString("%d"), EntryDayFont, Brushes.Black, bounds, stringFormat);
            e.Graphics.ResetTransform();
        }

        /// <summary>
        /// Draws the day of week.
        /// </summary>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        /// <param name="entry">The entry.</param>
        private void DrawDayOfWeek(DrawItemEventArgs e, Entry entry)
        {
            Rectangle bounds = e.Bounds;
            bounds.Inflate(-EntryPadding, -EntryPadding);
            bounds.X += bounds.Width - EntryRightWidth + EntryRightSmallWidth - EntryRightSmallHeight;
            bounds.Y += bounds.Height - EntryRightSmallWidth;
            bounds.Width = bounds.Height - EntryRightSmallHeight;
            bounds.Height = EntryRightSmallWidth;

            StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault);
            stringFormat.Alignment = StringAlignment.Center;

            e.Graphics.TranslateTransform(bounds.X, bounds.Y);
            e.Graphics.RotateTransform(270.0f);
            e.Graphics.TranslateTransform(-bounds.X, -bounds.Y);

            e.Graphics.DrawString(entry.LocalTime.ToString("ddd").ToUpper(), EntryDayOfWeekFont, Brushes.Black, bounds, stringFormat);
            e.Graphics.ResetTransform();
        }

        /// <summary>
        /// Draws the star.
        /// </summary>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        /// <param name="entry">The entry.</param>
        private void DrawStar(DrawItemEventArgs e, Entry entry)
        {
            Image starImage = entry.Starred ? Properties.Resources.StarYellow_16x16 : Properties.Resources.StarGray_16x16;

            Point p = new Point(e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height);
            p.X -= EntryPadding + EntryRightWidth;
            p.X += (EntryRightSmallWidth - starImage.Width) / 2;
            p.Y -= EntryPadding + EntryRightSmallHeight;
            p.Y += (EntryRightSmallHeight - starImage.Height) / 2;

            e.Graphics.DrawImage(starImage, p);
        }

        /// <summary>
        /// Draws the time.
        /// </summary>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        /// <param name="entry">The entry.</param>
        private void DrawTime(DrawItemEventArgs e, Entry entry)
        {
            Rectangle bounds = e.Bounds;
            bounds.Inflate(-EntryPadding, -EntryPadding);
            bounds.X += bounds.Width - EntryRightWidth + EntryRightSmallWidth;
            bounds.Width = EntryRightWidth - EntryRightSmallWidth;
            bounds.Y += bounds.Height - EntryRightSmallHeight;
            bounds.Height = EntryRightSmallHeight;

            StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault);
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(entry.LocalTime.ToString("h:mm tt").ToLower(), EntryTimeFont, Brushes.Black, bounds, stringFormat);
        }
    }
}
