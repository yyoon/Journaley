using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DayOneWindowsClient.Controls
{
    class EntryListBox : ListBox
    {
        public EntryListBox()
            : base()
        {
            this.ScrollAlwaysVisible = true;

            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;

            if (ENTRY_TEXT_FONT == null)
                ENTRY_TEXT_FONT = this.Font;

            if (ENTRY_DAY_FONT == null)
                ENTRY_DAY_FONT = new Font(this.Font.FontFamily, 28.0f, FontStyle.Bold);

            if (ENTRY_DAY_OF_WEEK_FONT == null)
                ENTRY_DAY_OF_WEEK_FONT = new Font(this.Font.FontFamily, 11.0f, FontStyle.Bold);

            if (ENTRY_TIME_FONT == null)
                ENTRY_TIME_FONT = new Font(this.Font.FontFamily, 9.0f);
        }

        private static readonly int MONTH_HEIGHT = 22;
        private static readonly int ENTRY_HEIGHT = 78;

        private static readonly string MONTH_FORMAT = "MMMM yyyy";

        private static readonly int ENTRY_PADDING = 5;
        private static readonly int ENTRY_RIGHT_WIDTH = 80;
        private static readonly int ENTRY_RIGHT_SMALL_WIDTH = 20;
        private static readonly int ENTRY_RIGHT_SMALL_HEIGHT = 20;
        private static readonly int ENTRY_CENTER_MARGIN = 10;

        private static Font ENTRY_TEXT_FONT;
        private static Font ENTRY_DAY_FONT;
        private static Font ENTRY_DAY_OF_WEEK_FONT;
        private static Font ENTRY_TIME_FONT;

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
                e.ItemHeight = MONTH_HEIGHT;
            }
            else if (obj is Entry)
            {
                e.ItemHeight = ENTRY_HEIGHT;
            }
            else
            {
                // Unknown type. do nothing.
            }
        }

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
                DrawMonth(e, (DateTime)obj);
            }
            else if (obj is Entry)
            {
                DrawEntry(e, (Entry)obj);
            }
            else
            {
                // Unknown type. do nothing.
            }
        }

        private static void DrawMonth(DrawItemEventArgs e, DateTime dateTime)
        {
            string text = dateTime.ToString(MONTH_FORMAT);

            StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault);
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Trimming = StringTrimming.EllipsisCharacter;

            e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
            e.Graphics.DrawString(text, e.Font, Brushes.White, e.Bounds, stringFormat);
        }

        private void DrawEntry(DrawItemEventArgs e, Entry entry)
        {
            DrawEntryText(e, entry);
            DrawDay(e, entry);
            DrawDayOfWeek(e, entry);
            DrawStar(e, entry);
            DrawTime(e, entry);
        }

        private void DrawEntryText(DrawItemEventArgs e, Entry entry)
        {
            Rectangle bounds = e.Bounds;
            bounds.Inflate(-ENTRY_PADDING, -ENTRY_PADDING);
            bounds.Width -= (ENTRY_RIGHT_WIDTH + ENTRY_CENTER_MARGIN);

            StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault);
            stringFormat.FormatFlags = StringFormatFlags.LineLimit;
            stringFormat.Trimming = StringTrimming.EllipsisCharacter;

            e.Graphics.DrawString(entry.EntryText, ENTRY_TEXT_FONT, Brushes.Black, bounds, stringFormat);
        }

        private void DrawDay(DrawItemEventArgs e, Entry entry)
        {
            Rectangle bounds = e.Bounds;
            bounds.Inflate(-ENTRY_PADDING, -ENTRY_PADDING);
            bounds.X += (bounds.Width - ENTRY_RIGHT_WIDTH + ENTRY_RIGHT_SMALL_WIDTH);
            bounds.Width = ENTRY_RIGHT_WIDTH - ENTRY_RIGHT_SMALL_WIDTH;
            bounds.Height -= ENTRY_RIGHT_SMALL_HEIGHT;

            StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault);
            stringFormat.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(entry.LocalTime.ToString("%d"), ENTRY_DAY_FONT, Brushes.Black, bounds, stringFormat);
            e.Graphics.ResetTransform();
        }

        private void DrawDayOfWeek(DrawItemEventArgs e, Entry entry)
        {
            Rectangle bounds = e.Bounds;
            bounds.Inflate(-ENTRY_PADDING, -ENTRY_PADDING);
            bounds.X += (bounds.Width - ENTRY_RIGHT_WIDTH + ENTRY_RIGHT_SMALL_WIDTH - ENTRY_RIGHT_SMALL_HEIGHT);
            bounds.Y += (bounds.Height - ENTRY_RIGHT_SMALL_WIDTH);
            bounds.Width = bounds.Height - ENTRY_RIGHT_SMALL_HEIGHT;
            bounds.Height = ENTRY_RIGHT_SMALL_WIDTH;

            StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault);
            stringFormat.Alignment = StringAlignment.Center;

            e.Graphics.TranslateTransform(bounds.X, bounds.Y);
            e.Graphics.RotateTransform(270.0f);
            e.Graphics.TranslateTransform(-bounds.X, -bounds.Y);

            e.Graphics.DrawString(entry.LocalTime.ToString("ddd").ToUpper(), ENTRY_DAY_OF_WEEK_FONT, Brushes.Black, bounds, stringFormat);
            e.Graphics.ResetTransform();
        }

        private void DrawStar(DrawItemEventArgs e, Entry entry)
        {
            Image starImage = entry.Starred ? Properties.Resources.StarYellow_16x16 : Properties.Resources.StarGray_16x16;

            Point p = new Point(e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height);
            p.X -= (ENTRY_PADDING + ENTRY_RIGHT_WIDTH);
            p.X += (ENTRY_RIGHT_SMALL_WIDTH - starImage.Width) / 2;
            p.Y -= (ENTRY_PADDING + ENTRY_RIGHT_SMALL_HEIGHT);
            p.Y += (ENTRY_RIGHT_SMALL_HEIGHT - starImage.Height) / 2;

            e.Graphics.DrawImage(starImage, p);
        }

        private void DrawTime(DrawItemEventArgs e, Entry entry)
        {
            Rectangle bounds = e.Bounds;
            bounds.Inflate(-ENTRY_PADDING, -ENTRY_PADDING);
            bounds.X += (bounds.Width - ENTRY_RIGHT_WIDTH + ENTRY_RIGHT_SMALL_WIDTH);
            bounds.Width = ENTRY_RIGHT_WIDTH - ENTRY_RIGHT_SMALL_WIDTH;
            bounds.Y += (bounds.Height - ENTRY_RIGHT_SMALL_HEIGHT);
            bounds.Height = ENTRY_RIGHT_SMALL_HEIGHT;

            StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault);
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(entry.LocalTime.ToString("h:mm tt").ToLower(), ENTRY_TIME_FONT, Brushes.Black, bounds, stringFormat);
        }
    }
}
