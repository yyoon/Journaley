namespace Journaley.Controls
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    using Journaley.Core.Models;
    using Journaley.Properties;
    using Journaley.Utilities;

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
        /// The photo width including the 1 pixel borders.
        /// </summary>
        private static readonly int PhotoWidth = 56;

        /// <summary>
        /// The wide photo width including the 1 pixel borders.
        /// </summary>
        private static readonly int WidePhotoWidth = 155;

        /// <summary>
        /// The photo height including the 1 pixel borders.
        /// </summary>
        private static readonly int PhotoHeight = 69;

        /// <summary>
        /// The entry text font
        /// </summary>
        private static readonly Font EntryTextFont = new Font("Segoe UI Semilight", 9.0f, System.Drawing.FontStyle.Regular);

        /// <summary>
        /// The entry title font
        /// </summary>
        private static readonly Font EntryTitleFont = new Font("Segoe UI Semibold", 9.0f, System.Drawing.FontStyle.Regular);

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
        /// Brush for filling the background of selected and starred journal entries.
        /// </summary>
        private static readonly Brush EntryBackgroundSelectedStarredBrush = Brushes.Yellow;

        /// <summary>
        /// The boundary line pen
        /// </summary>
        private static readonly Pen BoundaryLinePen = Pens.Black;

        /// <summary>
        /// The thumbnail cache
        /// </summary>
        private ImageCache thumbnailCache = new ImageCache();

        /// <summary>
        /// The wide thumbnail cache
        /// </summary>
        private ImageCache wideThumbnailCache = new ImageCache();

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
        /// Gets or sets the entry text provider.
        /// </summary>
        /// <value>
        /// The entry text provider.
        /// </value>
        public IEntryTextProvider EntryTextProvider { get; set; }

        /// <summary>
        /// Gets the thumbnail cache.
        /// </summary>
        /// <value>
        /// The thumbnail cache.
        /// </value>
        private ImageCache ThumbnailCache
        {
            get
            {
                return this.thumbnailCache;
            }
        }

        /// <summary>
        /// Gets the wide thumbnail cache.
        /// </summary>
        /// <value>
        /// The wide thumbnail cache.
        /// </value>
        private ImageCache WideThumbnailCache
        {
            get
            {
                return this.wideThumbnailCache;
            }
        }

        /// <summary>
        /// The list's window procedure.
        /// </summary>
        /// <param name="m">A Windows Message Object.</param>
        protected override void WndProc(ref Message m)
        {
            switch ((PInvoke.WindowsMessages)m.Msg)
            {
                case PInvoke.WindowsMessages.WM_MOUSEWHEEL:
                    this.OnMouseWheel(ref m);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
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
            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;

            Rectangle bounds = new Rectangle(0, 0, e.Bounds.Width, e.Bounds.Height);
            using (BufferedGraphics bufferedGraphics = currentContext.Allocate(e.Graphics, bounds))
            {
                DrawItemEventArgs args = new DrawItemEventArgs(
                    bufferedGraphics.Graphics, e.Font, bounds, e.Index, e.State, e.ForeColor, e.BackColor);

                if (e.Index < 0 || e.Index >= this.Items.Count)
                {
                    return;
                }

                object obj = this.Items[e.Index];

                // Draw the item
                if (obj is DateTime)
                {
                    this.DrawMonth(args, (DateTime)obj);
                }
                else if (obj is Entry)
                {
                    this.DrawEntry(args, (Entry)obj);
                }
                else
                {
                    // Unknown type. do nothing.
                }

                // Copy the bufferedGraphics into destination.
                PInvoke.BitBlt(
                    e.Graphics.GetHdc(),
                    e.Bounds.X,
                    e.Bounds.Y,
                    e.Bounds.Width,
                    e.Bounds.Height,
                    bufferedGraphics.Graphics.GetHdc(),
                    0,
                    0,
                    PInvoke.TernaryRasterOperations.SRCCOPY);
            }
        }

        /// <summary>
        /// Called when [mouse wheel].
        /// Eat the mouse wheel event, and send the SB_LINEUP / SB_LINEDOWN message instead.
        /// </summary>
        /// <param name="m">The windows message object.</param>
        private void OnMouseWheel(ref Message m)
        {
            int wheelDelta = unchecked((short)((long)m.WParam >> 16));

            if (wheelDelta > 0)
            {
                // Positive value: wheel rotating forward, away from the user.
                PInvoke.SendMessage(this.Handle, (int)PInvoke.WindowsMessages.WM_VSCROLL, (IntPtr)PInvoke.ScrollBarCommands.SB_LINEUP, IntPtr.Zero);
            }
            else if (wheelDelta < 0)
            {
                // Negative value: wheel rotating backward, toward the user.
                PInvoke.SendMessage(this.Handle, (int)PInvoke.WindowsMessages.WM_VSCROLL, (IntPtr)PInvoke.ScrollBarCommands.SB_LINEDOWN, IntPtr.Zero);
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
            Tuple<string, string> previewText = this.EntryTextProvider != null
                ? this.EntryTextProvider.GetTextForEntry(entry)
                : new Tuple<string, string>(null, entry.EntryText);

            this.DrawEntryBackground(e, entry);
            this.DrawEntryText(e, entry, previewText);
            this.DrawPhoto(e, entry, previewText);
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

            Brush brush = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? (entry.Starred ? EntryBackgroundSelectedStarredBrush : EntryBackgroundSelectedBrush)
                : EntryBackgroundNormalBrush;
            e.Graphics.FillRectangle(brush, bounds);
        }

        /// <summary>
        /// Draws the entry text.
        /// </summary>
        /// <param name="e">The <see cref="DrawItemEventArgs" /> instance containing the event data.</param>
        /// <param name="entry">The entry.</param>
        /// <param name="previewText">The preview text.</param>
        private void DrawEntryText(DrawItemEventArgs e, Entry entry, Tuple<string, string> previewText)
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

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color textColor = selected ? Color.Black : Color.White;

            TextFormatFlags textFormat =
                TextFormatFlags.EndEllipsis |
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.WordBreak;

            string entryTitle = previewText.Item1;
            string entryText = previewText.Item2;

            if (string.IsNullOrEmpty(entryTitle))
            {
                TextRenderer.DrawText(e.Graphics, entryText, EntryTextFont, bounds, textColor, textFormat);
            }
            else
            {
                // Measure.
                var titleMeasure = TextRenderer.MeasureText(entryTitle, EntryTitleFont);
                int titleHeight = titleMeasure.Height;

                var textMeasure = TextRenderer.MeasureText(e.Graphics, entryText, EntryTextFont, new Size(bounds.Width, bounds.Height - titleHeight), textFormat);
                int textHeight = textMeasure.Height;

                int totalHeight = Math.Min(titleHeight + textHeight, bounds.Height);

                // Draw title
                Rectangle titleBounds = bounds;
                titleBounds.Y += (bounds.Height - totalHeight) / 2;
                titleBounds.Height = titleHeight;

                TextRenderer.DrawText(e.Graphics, entryTitle, EntryTitleFont, titleBounds, textColor, textFormat | TextFormatFlags.SingleLine);

                // Draw first sentence
                Rectangle textBounds = bounds;
                textBounds.Y = titleBounds.Bottom;
                textBounds.Height = totalHeight - titleHeight;

                TextRenderer.DrawText(e.Graphics, entryText, EntryTextFont, textBounds, textColor, textFormat);
            }
        }

        /// <summary>
        /// Draws the photo. When the image cannot be loaded for some reason, use the default icon instead.
        /// </summary>
        /// <param name="e">The <see cref="DrawItemEventArgs" /> instance containing the event data.</param>
        /// <param name="entry">The entry.</param>
        /// <param name="previewText">The preview text.</param>
        private void DrawPhoto(DrawItemEventArgs e, Entry entry, Tuple<string, string> previewText)
        {
            if (entry.PhotoPath == null)
            {
                return;
            }

            bool wide = string.IsNullOrEmpty(previewText.Item1) && string.IsNullOrEmpty(previewText.Item2);

            Rectangle bounds = e.Bounds;
            bounds.Height -= 1;
            bounds.X -= 1;
            bounds.Y += (bounds.Height - PhotoHeight) / 2;
            bounds.Width = wide ? WidePhotoWidth : PhotoWidth;
            bounds.Height = PhotoHeight;
            bounds.Inflate(-1, -1);

            ImageCache cache = wide ? this.WideThumbnailCache : this.ThumbnailCache;

            try
            {
                if (cache.HasCachedImage(entry))
                {
                    Image cachedImage = cache.GetCachedImage(entry);
                    if (cachedImage != null)
                    {
                        e.Graphics.DrawImage(cachedImage, bounds.X, bounds.Y);
                    }
                    else
                    {
                        this.DrawToFit(e.Graphics, Resources.sidebar_btn_image_norm, bounds);
                    }
                }
                else
                {
                    // Spawn a new thread that loads the specified image.
                    this.LoadImageToCache(e.Index, entry, cache, bounds);
                }
            }
            catch (Exception)
            {
                this.DrawToFit(e.Graphics, Resources.sidebar_btn_image_norm, bounds);
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

            Brush brush = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? Brushes.Black
                : (entry.Starred ? Brushes.Yellow : Brushes.White);

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

            Brush brush = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? Brushes.Black
                : (entry.Starred ? Brushes.Yellow : Brushes.White);

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

            Brush brush = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? Brushes.Black
                : (entry.Starred ? Brushes.Yellow : Brushes.White);

            StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault);
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(entry.LocalTime.ToString("h:mm tt").ToLower(), EntryTimeFont, brush, bounds, stringFormat);
        }

        /// <summary>
        /// Loads the image thumbnail to image cache in a background thread.
        /// When the loading is complete, invalidate the item rectangle to make it redraw.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="entry">The entry.</param>
        /// <param name="cache">The cache.</param>
        /// <param name="bounds">The bounds.</param>
        private void LoadImageToCache(int index, Entry entry, ImageCache cache, Rectangle bounds)
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += delegate(object sender, DoWorkEventArgs args)
            {
                Image thumbnailImage = new Bitmap(bounds.Width, bounds.Height);

                using (Image image = Image.FromFile(entry.PhotoPath))
                {
                    this.DrawToFit(Graphics.FromImage(thumbnailImage), image, new Rectangle(0, 0, bounds.Width, bounds.Height));
                }

                cache.AddCachedImage(entry, thumbnailImage);
            };

            worker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs args)
            {
                this.Invalidate(this.GetItemRectangle(index));
            };

            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Class for caching thumbnail images. Avoid reading the images from the file over and over again.
        /// </summary>
        private class ImageCache
        {
            /// <summary>
            /// The thumbnail cache dictionary. The keys are UUIDString of the entry,
            /// and the values are the corresponding thumbnail images.
            /// </summary>
            private IDictionary<string, Image> thumbnailCache = new ConcurrentDictionary<string, Image>();

            /// <summary>
            /// Determines whether there is a cached thumbnail image for the given entry.
            /// </summary>
            /// <param name="entry">The entry.</param>
            /// <returns>true if there is a cached thumbnail image, false otherwise.</returns>
            public bool HasCachedImage(Entry entry)
            {
                return this.thumbnailCache.ContainsKey(entry.UUIDString);
            }

            /// <summary>
            /// Adds the cached image.
            /// </summary>
            /// <param name="entry">The entry.</param>
            /// <param name="thumbnail">The thumbnail.</param>
            public void AddCachedImage(Entry entry, Image thumbnail)
            {
                if (this.thumbnailCache.ContainsKey(entry.UUIDString))
                {
                    this.thumbnailCache.Remove(entry.UUIDString);
                }

                this.thumbnailCache.Add(entry.UUIDString, thumbnail);

                // Make sure the clear the cache whe the photo is changed.
                entry.PhotoChanged += new Entry.PhotoChangedHandler(this.Entry_PhotoChanged);
            }

            /// <summary>
            /// Gets the cached image.
            /// </summary>
            /// <param name="entry">The entry.</param>
            /// <returns>The cached image object, or null if there is no cached image.</returns>
            public Image GetCachedImage(Entry entry)
            {
                if (this.HasCachedImage(entry))
                {
                    return this.thumbnailCache[entry.UUIDString];
                }

                return null;
            }

            /// <summary>
            /// Called when a PhotoPath is changed for an entry.
            /// </summary>
            /// <param name="sender">The sender.</param>
            private void Entry_PhotoChanged(Entry sender)
            {
                if (this.thumbnailCache.ContainsKey(sender.UUIDString))
                {
                    this.thumbnailCache.Remove(sender.UUIDString);
                }
            }
        }
    }
}
