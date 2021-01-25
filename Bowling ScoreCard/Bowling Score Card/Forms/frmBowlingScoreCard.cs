using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Bowling_Score_Card.Utilities;
using Bowling_Score_Card.Forms;
using System.Windows.Forms;

namespace Bowling_Score_Card
{
    public partial class frmBowlingScoreCard : Form
    {
        int intPlayerCount = 0;

        public frmBowlingScoreCard()
        {
            InitializeComponent();
        }
       
        private void frmBowlingScoreCard_Load(object sender, EventArgs e)
        {            
            //Add score card to panel on form. Panel is used for scrollbars, since the scroll bars on the table panel are glitchy
            Tables ScoreCard = new Tables();
            TableLayoutPanel tlpScoreCard = ScoreCard.ScoreCardTable();
            panel.Controls.Add(tlpScoreCard);

            //Size the panel to hold the score card and scrollbar
            panel.Width = tlpScoreCard.Width + 25;

            //Size the form to hold the resized panel
            this.Width = panel.Width + 40;

            //Center the title on the form
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Size.Width) / 2;

            //Make the title lable and panel appear transparent
            Visual trans = new Visual();
            trans.TransParentBackground(this, lblTitle);
            trans.TransParentBackground(this, panel);

            //Center the form on the screen
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.ClientSize.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.ClientSize.Height) / 2;                     
        }

        private void addPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbAddPlayer_Click(sender, e);
        }

        private void FillScoreCard(string strPlayer)
        {
            var item = panel.Controls.Find("tlpScoreCard", false);            
            TableLayoutPanel tlpScoreCard = (TableLayoutPanel)item[0];

            //Create the frame tables
            Tables Frame = new Tables();
            TableLayoutPanel[] tlpArray = new TableLayoutPanel[10];
            for (int intFrame = 0; intFrame< 10; intFrame++)
            {
                tlpArray[intFrame] = Frame.FrameTable(intPlayerCount, intFrame + 1);            
            }

            //Add a new row to the score card and set the size        
            tlpScoreCard.RowCount += 1;
            tlpScoreCard.RowStyles.Add(new RowStyle(SizeType.Absolute, 80f));
            tlpScoreCard.Controls.Add(new Label() { Name = "lblPlayer-" + intPlayerCount, Text = strPlayer }, 0,tlpScoreCard.RowCount - 1);

            for (int intFrame = 0; intFrame< 10; intFrame++)
            {
                tlpScoreCard.Controls.Add(tlpArray[intFrame], intFrame + 1, tlpScoreCard.RowCount - 1);                
            }

            tlpScoreCard.Controls.Add(new Label() { Name = "lblScore-" + intPlayerCount, Text = "0", TextAlign = ContentAlignment.MiddleRight }, 11, tlpScoreCard.RowCount - 1);

            //Resize the font in the player and total score 
            foreach (Control item1 in tlpScoreCard.Controls)
            {
                item1.Font = new Font(item1.Font.FontFamily, 12);
            }
        }

        private void tsbAddPlayer_Click(object sender, EventArgs e)
        {
            //Get player from user input
            string strPlayer = "";
            Screen screen = Screen.FromControl(this);
            frmAddPlayer addPlayer = new frmAddPlayer(screen);
            addPlayer.FormClosed += (sender2, e2) =>
            {
                strPlayer = addPlayer.strPlayer;
            };
            
            addPlayer.ShowDialog();

            //Fill score card if a player was entered
            if (strPlayer != "")
            {
                intPlayerCount++;
                FillScoreCard(strPlayer);
                //Send focus to first score box
                panel.SelectNextControl(panel, true, true, true, true);
            }

            //Hide horizontal scrollbar
            panel.HorizontalScroll.Maximum = 0;
            panel.AutoScroll = false;
            panel.VerticalScroll.Visible = false;
            panel.AutoScroll = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {         
            //Clear controls in panel
            panel.Controls.Clear();

            //Add score card to panel on form.
            Tables ScoreCard = new Tables();
            TableLayoutPanel tlpScoreCard = ScoreCard.ScoreCardTable();
            panel.Controls.Add(tlpScoreCard);

            //Reset player count
            intPlayerCount = 0;
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            //Variables to return controls from form
            TextBox txtTextBox = new TextBox();
            Label lblLabelBox = new Label();
            string strBoxName = "";

            //Clears out scores so a new game can be played
            for (int intPlayer = 1; intPlayer < intPlayerCount + 1; intPlayer++)
            {
                for (int intFrame = 1; intFrame < 11; intFrame++)
                {
                    strBoxName = "txtScore-" + intPlayer + "-" + intFrame + "-" + 1;
                    var item1 = panel.Controls.Find(strBoxName, true);
                    txtTextBox = (TextBox)item1[0];
                    txtTextBox.Text = "";                    
                }
            }

            //Send focus to first score box
            panel.SelectNextControl(panel, true, true, true, true);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbNew_Click(sender, e);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbClear_Click(sender, e);
        }

        private void addPlayerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tsbAddPlayer_Click(sender, e);
        }

        private void newGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tsbNew_Click(sender, e);
        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tsbClear_Click(sender, e);
        }
    }
}
