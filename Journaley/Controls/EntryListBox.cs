namespace Journaley.Controls
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    using Journaley.Models;
    using Journaley.Properties;

    /// <summary>
    /// Customized ListBox control for displaying the list of journal entries prettier.
    /// </summary>
    internal class EntryListBox : ListBox
    {
        /// <summary>
        /// The month height
        /// </summary>
        private static readonly int MonthHeight = 19;

        /// <summary>
        /// The entry height
        /// </summary>
        private static readonly int EntryHeight = 85;

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
        private static readonly int EntryRightWidth = 52;

        /// <summary>
        /// The entry right small height
        /// </summary>
        private static readonly int EntryRightSmallHeight = 20;

        /// <summary>
        /// The entry center margin
        /// </summary>
        private static readonly int EntryCenterMargin = 0;

        /// <summary>
        /// The photo width including the 1px borders.
        /// </summary>
        private static readonly int PhotoWidth = 56;

        /// <summary>
        /// The photo height including the 1px borders.
        /// </summary>
        private static readonly int PhotoHeight = 69;

        /// <summary>
        /// The entry text font
        /// </summary>
        private static readonly Font EntryTextFont = new Font("Segoe UI Semilight", 9.0f, System.Drawing.FontStyle.Regular);

        /// <summary>
        /// The entry day font
        /// </summary>
        private static readonly Font EntryDayFont = new Font(EntryTextFont.FontFamily, 26.0f, FontStyle.Bold);

        /// <summary>
        /// The entry day of week font
        /// </summary>
        private static readonly Font EntryDayOfWeekFont = new Font(EntryTextFont.FontFamily, 11.0f, FontStyle.Regular);

        /// <summary>
        /// The entry time font
        /// </summary>
        private static readonly Font EntryTimeFont = new Font(EntryTextFont.FontFamily, 8.9f);

        /// <summary>
        /// Brush for filling the background of month entries
        /// </summary>
        private static readonly Brush MonthBackgroundBrush = new SolidBrush(Color.FromArgb(37, 40, 44));

        /// <summary>
        /// Brush for month text
        /// </summary>
        private static readonly Brush MonthTextBrush = new SolidBrush(Color.FromArgb(187, 187, 187));

        /// <summary>
        /// Brush for filling the background of normal journal entries.
        /// </summary>
        private static readonly Brush EntryBackgroundNormalBrush = new SolidBrush(Color.FromArgb(38, 46, 60));

        /// <summary>
        /// Brush for filling the background of selected journal entries.
        /// </summary>
        private static readonly Brush EntryBackgroundSelectedBrush = new SolidBrush(Color.FromArgb(0, 147, 255));

        /// <summary>
        /// The boundary line pen
        /// </summary>
        private static readonly Pen BoundaryLinePen = Pens.Black;

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

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int newDelta = e.Delta == 0 ? 0 : e.Delta / Math.Abs(e.Delta);
            MouseEventArgs args = new MouseEventArgs(e.Button, e.Clicks, e.X, e.Y, newDelta);
            base.OnMouseWheel(args);
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
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Trimming = StringTrimming.EllipsisCharacter;

            Rectangle bounds = e.Bounds;
            bounds.Height -= 1;

            e.Graphics.FillRectangle(MonthBackgroundBrush, bounds);
            e.Graphics.DrawString(text, e.Font, MonthTextBrush, bounds, stringFormat);

            // Line at the bottom
            e.Graphics.DrawLine(BoundaryLinePen, 0, e.Bounds.Bottom - 1, e.Bounds.Right - 1, e.Bounds.Bottom - 1);
        }

        /// <summary>
        /// Draws an entry. This method subsequently calls other Draw methods.
        /// </summary>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        /// <param name="entry">The entry.</param>
        private void DrawEntry(DrawItemEventArgs e, Entry entry)
        {
            this.DrawEntryBackground(e, entry);
            this.DrawEntryText(e, entry);
            this.DrawPhoto(e, entry);
            this.DrawDay(e, entry);
            this.DrawDayOfWeek(e, entry);
            this.DrawTime(e, entry);

            // Line at the bottom
            e.Graphics.DrawLine(BoundaryLinePen, 0, e.Bounds.Bottom - 1, e.Bounds.Right - 1, e.Bounds.Bottom - 1);
        }

        /// <summary>
        /// Draws the entry background.
        /// </summary>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        /// <param name="entry">The entry.</param>
        private void DrawEntryBackground(DrawItemEventArgs e, Entry entry)
        {
            Rectangle bounds = e.Bounds;
            bounds.Height -= 1;

            Brush brush = (e.State & DrawItemState.Selected) == DrawItemState.Selected ? EntryBackgroundSelectedBrush : EntryBackgroundNormalBrush;
            e.Graphics.FillRectangle(brush, bounds);
        }

        /// <summary>
        /// Draws the entry text.
        /// </summary>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        /// <param name="entry">The entry.</param>
        private void DrawEntryText(DrawItemEventArgs e, Entry entry)
        {
            Rectangle bounds = e.Bounds;
            bounds.Height -= 1;
            bounds.Inflate(-EntryPadding, -EntryPadding);
            bounds.Width -= EntryRightWidth + EntryCenterMargin;

            if (entry.PhotoPath != null)
            {
                bounds.X += PhotoWidth + EntryCenterMargin;
                bounds.Width -= PhotoWidth + EntryCenterMargin;
            }

            Brush brush = (e.State & DrawItemState.Selected) == DrawItemState.Selected ? Brushes.Black : Brushes.White;

            StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault);
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.FormatFlags = StringFormatFlags.LineLimit;
            stringFormat.Trimming = StringTrimming.EllipsisCharacter;

            e.Graphics.DrawString(entry.EntryText, EntryTextFont, brush, bounds, stringFormat);
        }

        /// <summary>
        /// Draws the photo. When the image cannot be loaded for some reason, use the default icon instead.
        /// </summary>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        /// <param name="entry">The entry.</param>
        private void DrawPhoto(DrawItemEventArgs e, Entry entry)
        {
            if (entry.PhotoPath == null)
            {
                return;
            }

            Rectangle bounds = e.Bounds;
            bounds.Height -= 1;
            bounds.X -= 1;
            bounds.Y += (bounds.Height - PhotoHeight) / 2;
            bounds.Width = PhotoWidth;
            bounds.Height = PhotoHeight;
            bounds.Inflate(-1, -1);

            try
            {
                using (Image image = Image.FromFile(entry.PhotoPath))
                {
                    this.DrawToFit(e.Graphics, image, bounds);
                }
            }
            catch (Exception)
            {
                this.DrawToFit(e.Graphics, Resources.Image_32x32, bounds);
            }

            bounds.Inflate(1, 1);
            e.Graphics.DrawRectangle(BoundaryLinePen, bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1);
        }

        /// <summary>
        /// Draws to fit in the destination rectangle.
        /// If the given image is smaller, the image is not stretched and centered in the rectangle.
        /// Otherwise, the image is scaled down while keeping the aspect ratio.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="image">The image.</param>
        /// <param name="rect">The destination rectangle.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when any of the given arguments is null</exception>
        private void DrawToFit(Graphics g, Image image, Rectangle rect)
        {
            if (g == null || image == null || rect == null)
            {
                throw new ArgumentNullException();
            }

            // If not, reduce the size but keep the aspect ratio.
            if ((double)image.Width / (double)rect.Width >= (double)image.Height / (double)rect.Height)
            {
                double ratio = (double)image.Height / (double)rect.Height;
                int srcWidth = (int)(rect.Width * ratio);

                g.DrawImage(image, rect, new Rectangle((image.Width - srcWidth) / 2, 0, srcWidth, image.Height), GraphicsUnit.Pixel);
            }
            else
            {
                double ratio = (double)image.Width / (double)rect.Width;
                int srcHeight = (int)(rect.Height * ratio);

                g.DrawImage(image, rect, new Rectangle(0, (image.Height - srcHeight) / 2, image.Width, srcHeight), GraphicsUnit.Pixel);
            }
        }

        /// <summary>
        /// Draws the day.
        /// </summary>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        /// <param name="entry">The entry.</param>
        private void DrawDay(DrawItemEventArgs e, Entry entry)
        {
            Rectangle bounds = e.Bounds;
            bounds.Height -= 1;
            bounds.Inflate(-EntryPadding, -EntryPadding);
            bounds.X += bounds.Width - EntryRightWidth - 4; // Some offset should be given to make them all aligned.
            bounds.Y += EntryRightSmallHeight;
            bounds.Width = EntryRightWidth;
            bounds.Height -= EntryRightSmallHeight + EntryRightSmallHeight;

            Brush brush = entry.Starred ? Brushes.Yellow :
                (e.State & DrawItemState.Selected) == DrawItemState.Selected ? Brushes.Black : Brushes.White;

            StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault);
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(entry.LocalTime.ToString("%d"), EntryDayFont, brush, bounds, stringFormat);
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
            bounds.Height -= 1;
            bounds.Inflate(-EntryPadding, -EntryPadding);
            bounds.X += bounds.Width - EntryRightWidth;
            bounds.Width = EntryRightWidth;
            bounds.Height = EntryRightSmallHeight;

            Brush brush = entry.Starred ? Brushes.Yellow :
                (e.State & DrawItemState.Selected) == DrawItemState.Selected ? Brushes.Black : Brushes.White;

            StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault);
            stringFormat.Alignment = StringAlignment.Near;

            e.Graphics.DrawString(entry.LocalTime.ToString("ddd"), EntryDayOfWeekFont, brush, bounds, stringFormat);
        }

        /// <summary>
        /// Draws the time.
        /// </summary>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        /// <param name="entry">The entry.</param>
        private void DrawTime(DrawItemEventArgs e, Entry entry)
        {
            Rectangle bounds = e.Bounds;
            bounds.Height -= 1;

            bounds.Inflate(-EntryPadding, -EntryPadding);
            bounds.X += bounds.Width - EntryRightWidth;
            bounds.Width = EntryRightWidth;
            bounds.Y += bounds.Height - EntryRightSmallHeight;
            bounds.Height = EntryRightSmallHeight;

            Brush brush = entry.Starred ? Brushes.Yellow :
                (e.State & DrawItemState.Selected) == DrawItemState.Selected ? Brushes.Black : Brushes.White;

            StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault);
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(entry.LocalTime.ToString("h:mm tt").ToLower(), EntryTimeFont, brush, bounds, stringFormat);
        }
    }
}
