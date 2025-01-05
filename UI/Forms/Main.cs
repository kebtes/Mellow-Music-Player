using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mellow_Music_Player.UI
{
    public partial class Main : Form
    {
        private bool isBtnFeedHovered = false;
        private bool isBtnFeedSelected = true;
        private bool isBtnPlaylistHovered = false;
        private bool isBtnPlaylistSelected = false;

        private Image feedIcon;
        private Image feedSelectedIcon;
        private Image playlistIcon;
        private Image playlistSelectedIcon;

        public Main()
        {
            InitializeComponent();

            feedIcon = Image.FromFile(Constants.FeedIcon);
            feedSelectedIcon = Image.FromFile(Constants.FeedSelectedIcon);
            playlistIcon = Image.FromFile(Constants.PlaylistIcon); 
            playlistSelectedIcon = Image.FromFile(Constants.PlaylistSelectedIcon);

            LoadPage(new panelFeed());
            UpdateButtonStates();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            feedIcon?.Dispose();
            feedSelectedIcon?.Dispose();
            playlistIcon?.Dispose();
            playlistSelectedIcon?.Dispose();
        }

        private void UpdateButtonStates()
        {
            buttonFeed.BackColor = isBtnFeedSelected
                ? ColorTranslator.FromHtml(Constants.HoverBlue)
                : ColorTranslator.FromHtml(Constants.DarkBlue);

            buttonFeed.ForeColor = isBtnFeedSelected
                ? ColorTranslator.FromHtml(Constants.OrangeColor)
                : Color.White;

            buttonFeed.Image = isBtnFeedSelected? feedSelectedIcon : feedIcon;

            buttonPlaylist.BackColor = isBtnPlaylistSelected
                ? ColorTranslator.FromHtml(Constants.HoverBlue)
                : ColorTranslator.FromHtml(Constants.DarkBlue);

            buttonPlaylist.ForeColor = isBtnPlaylistSelected
                ? ColorTranslator.FromHtml(Constants.OrangeColor)
                : Color.White;

            buttonPlaylist.Image = isBtnPlaylistSelected? playlistSelectedIcon : playlistIcon;

            buttonFeed.Invalidate();
            buttonPlaylist.Invalidate();
        }

        //FEED BUTTON SECTION
        private void buttonFeed_Paint(object sender, PaintEventArgs e)
        {
            if (isBtnFeedSelected)
            {
                using (Pen pen = new Pen(ColorTranslator.FromHtml(Constants.OrangeColor), Constants.HoverPenWidth))
                {
                    e.Graphics.DrawLine(pen, 0, 0, 0, buttonFeed.Height);
                }
            }
            else if (isBtnFeedHovered)
            {
                using (Pen pen = new Pen(ColorTranslator.FromHtml(Constants.HoverGrey), Constants.HoverPenWidth))
                {
                    e.Graphics.DrawLine(pen, 0, 0, 0, buttonFeed.Height);
                }
            }
        }
        private void buttonFeed_MouseEnter(object sender, EventArgs e)
        {
            if (isBtnFeedSelected) return;

            isBtnFeedHovered = true;
            buttonFeed.Invalidate();
        }

        private void buttonFeed_MouseLeave(object sender, EventArgs e)
        {
            if (isBtnFeedSelected) return;

            isBtnFeedHovered = false;
            buttonFeed.Invalidate();
        }


        private void buttonFeed_MouseClick(object sender, MouseEventArgs e)
        {
            if (!isBtnFeedSelected)
            {
                LoadPage(new panelFeed());
                isBtnFeedSelected = true;
                isBtnPlaylistSelected = false;
                UpdateButtonStates();
            }
        }

        private void buttonPlaylist_MouseClick(object sender, MouseEventArgs e)
        {
            if (!isBtnPlaylistSelected)
            {
                isBtnPlaylistSelected = true;
                isBtnFeedSelected = false;
                UpdateButtonStates();
            }
        }

        private void buttonPlaylist_MouseEnter(object sender, EventArgs e)
        {
            if (isBtnPlaylistSelected) return;

            isBtnPlaylistHovered = true;
            buttonPlaylist.Invalidate();
        }

        private void buttonPlaylist_MouseLeave(object sender, EventArgs e)
        {
            if (isBtnPlaylistSelected) return;

            isBtnPlaylistHovered = false;
            buttonPlaylist.Invalidate();
        }

        private void buttonPlaylist_Paint(object sender, PaintEventArgs e)
        {
            if (isBtnPlaylistSelected)
            {
                using (Pen pen = new Pen(ColorTranslator.FromHtml(Constants.OrangeColor), Constants.HoverPenWidth))
                {
                    e.Graphics.DrawLine(pen, 0, 0, 0, buttonPlaylist.Height);
                }
            }
            else if (isBtnPlaylistHovered)
            {
                using (Pen pen = new Pen(ColorTranslator.FromHtml(Constants.HoverGrey), Constants.HoverPenWidth))
                {
                    e.Graphics.DrawLine(pen, 0, 0, 0, buttonPlaylist.Height);
                }
            }
        }
    }
}
