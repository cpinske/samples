using System;
using System.Windows.Forms;
using Bowling_Score_Card.Utilities;

namespace Bowling_Score_Card.Forms
{
    public partial class frmAddPlayer : Form
    {
        public string strPlayer = "";
        Screen screen; 

        public frmAddPlayer(Screen inScreen)
        {
            InitializeComponent();
            screen = inScreen;
        }

        private void frmAddPlayer_Load(object sender, EventArgs e)
        {
            //Make the title lables appear transparent
            Visual trans = new Visual();
            trans.TransParentBackground(this, lblTitle);
            trans.TransParentBackground(this, lblPlayerCap);

            //Center the form on the screen the score card is on                     
            this.Location = screen.WorkingArea.Location;
            this.Left = screen.WorkingArea.Left + ((screen.Bounds.Width - this.ClientSize.Width) / 2);
            this.Top = screen.WorkingArea.Top + ((screen.Bounds.Height - this.ClientSize.Height) / 2);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Capture player entered
            strPlayer = txtPlayer.Text.Trim();

            //Error if no player, or all spaces was enetered
            if (strPlayer == "")
            {
                MessageBox.Show("Please Enter Players Name", "Player Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPlayer.Focus();
                txtPlayer.Clear();
            }
            else
            {
                Close();
            }
        }

        private void txtPlayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            //If enter key is pressed, execute the add click 
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAdd_Click(sender, e);
            }
        }
    }
}
