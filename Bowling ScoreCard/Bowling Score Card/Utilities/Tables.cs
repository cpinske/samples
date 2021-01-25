using System;
using System.Windows.Forms;
using System.Drawing;

namespace Bowling_Score_Card.Utilities
{
    class Tables
    {
        int intColumnWidth = 100;

        public TableLayoutPanel ScoreCardTable()
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //Creates the score card table that we will add players and frames too
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            int intHeaderRowHeight = 20;         

            //Create the Score Card Table with 12 columns and one row for headings
            TableLayoutPanel ScoreCard = new TableLayoutPanel() { Name="tlpScoreCard", BackColor = Color.Blue, ForeColor = Color.White, CellBorderStyle = TableLayoutPanelCellBorderStyle.Single, Width = intColumnWidth, Height = intHeaderRowHeight, AutoSize = true };
            ScoreCard.ColumnCount = 12;
            ScoreCard.RowCount = 1;

            //Size the columns
            ScoreCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, intColumnWidth));
            ScoreCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, intColumnWidth));
            ScoreCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, intColumnWidth));
            ScoreCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, intColumnWidth));
            ScoreCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, intColumnWidth));
            ScoreCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, intColumnWidth));
            ScoreCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, intColumnWidth));
            ScoreCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, intColumnWidth));
            ScoreCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, intColumnWidth));
            ScoreCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, intColumnWidth));
            ScoreCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, intColumnWidth));
            ScoreCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, intColumnWidth));

            //Size the row
            ScoreCard.RowStyles.Add(new RowStyle(SizeType.Absolute, intHeaderRowHeight));         

            //Create heading labels
            ScoreCard.Controls.Add(new Label() { Name = "lblPlayer", Text = "Player" }, 0, ScoreCard.RowCount - 1);
            ScoreCard.Controls.Add(new Label() { Name = "lblFrame1", Text = "Frame 1" }, 1, ScoreCard.RowCount - 1);
            ScoreCard.Controls.Add(new Label() { Name = "lblFrame2", Text = "Frame 2" }, 2, ScoreCard.RowCount - 1);
            ScoreCard.Controls.Add(new Label() { Name = "lblFrame3", Text = "Frame 3" }, 3, ScoreCard.RowCount - 1);
            ScoreCard.Controls.Add(new Label() { Name = "lblFrame4", Text = "Frame 4" }, 4, ScoreCard.RowCount - 1);
            ScoreCard.Controls.Add(new Label() { Name = "lblFrame5", Text = "Frame 5" }, 5, ScoreCard.RowCount - 1);
            ScoreCard.Controls.Add(new Label() { Name = "lblFrame6", Text = "Frame 6" }, 6, ScoreCard.RowCount - 1);
            ScoreCard.Controls.Add(new Label() { Name = "lblFrame7", Text = "Frame 7" }, 7, ScoreCard.RowCount - 1);
            ScoreCard.Controls.Add(new Label() { Name = "lblFrame8", Text = "Frame 8" }, 8, ScoreCard.RowCount - 1);
            ScoreCard.Controls.Add(new Label() { Name = "lblFrame9", Text = "Frame 9" }, 9, ScoreCard.RowCount - 1);
            ScoreCard.Controls.Add(new Label() { Name = "lblFrame10", Text = "Frame 10" }, 10, ScoreCard.RowCount - 1);
            ScoreCard.Controls.Add(new Label() { Name = "lblTotal", Text = "Total Score" }, 11, ScoreCard.RowCount - 1);

            //Resize the font in the header row 
            foreach (Control item in ScoreCard.Controls)
            {                
                item.Font = new Font(item.Font.FontFamily, 12);
            }

            return ScoreCard;
        }

        public TableLayoutPanel FrameTable(int intPlayer, int intFrame)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //Creates the frame table that will be added to the score card as players are added
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            int intRowHeight = 30;
            int intCols = 2;
            
            if (intFrame == 10)
            {
                intCols = 3;
            }

            //Create the frame table            
            TableLayoutPanel Frame = new TableLayoutPanel() { Name = "tlpFrame", Width = intColumnWidth, TabIndex = intFrame };                                                                
            Frame.ColumnCount = intCols;
            Frame.RowCount = 1;

            //Size the columns in the frame table
            if (intCols == 3)
            {
                Frame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
                Frame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
                Frame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            }
            else
            {
                Frame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
                Frame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            }

            //Size the row in the frame table
            Frame.RowStyles.Add(new RowStyle(SizeType.Absolute, intRowHeight));

            //Add test boxes to the frame table to capture the score
            var textbox1 = CreateTextBox(intPlayer, intFrame, 1);
            var textbox2 = CreateTextBox(intPlayer, intFrame, 2);
            Frame.Controls.Add(textbox1, 0, Frame.RowCount - 1);
            Frame.Controls.Add(textbox2, 1, Frame.RowCount - 1);         
            if (intCols == 3)
            {
                var textbox3 = CreateTextBox(intPlayer, intFrame, 3);
                Frame.Controls.Add(textbox3, 2, Frame.RowCount - 1);
            }            

            //Add a new row to the frame table with a label to display points
            var label = CreateLabel(intPlayer, intFrame);
            Frame.RowCount += 1;
            Frame.RowStyles.Add(new RowStyle(SizeType.Absolute, intRowHeight));
            Frame.Controls.Add(label);
            Frame.SetCellPosition(label, new TableLayoutPanelCellPosition(0, 1));
            if (intCols == 3)
            {
                Frame.SetColumnSpan(label, 3);
            }
            else
            {
                Frame.SetColumnSpan(label, 2);
            }

            //Resize the font in the frames 
            foreach (Control item in Frame.Controls)
            {
                item.Font = new Font(item.Font.FontFamily, 12);
            }

            return Frame;
        }

        public TextBox CreateTextBox(int intPlayer, int intFrame, int intScore)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //Creates the text box for the score to be keyed in
            ////////////////////////////////////////////////////////////////////////////////////////////////////    

            //Create text box
            TextBox textbox = new TextBox();

            //Set properties
            textbox.Name = "txtScore-" + intPlayer + "-" + intFrame + "-" + intScore;
            textbox.Width = 20;
            textbox.MaxLength = 1;
            textbox.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            textbox.CharacterCasing = CharacterCasing.Upper;
            if (intScore == 3)
            {
                textbox.Enabled = false;
            }

            //Code to execute when text box is entered
            textbox.Enter += (sender, e) =>
            {
                //highlight text in textbox
                textbox.SelectionStart = 0;
                textbox.SelectionLength = textbox.MaxLength;
            };

            //Code to execute when text box is clicked
            textbox.Click += (sender, e) =>
            {
                //highlight text in textbox
                textbox.SelectionStart = 0;
                textbox.SelectionLength = textbox.MaxLength;
            };

            //Code to execute when a key is pressed
            textbox.KeyPress += (sender, e) =>
            {
                //Variables to return controls from form
                Control contFrame = textbox.Parent;
                TableLayoutPanel tlpFrame = (TableLayoutPanel)contFrame;
                TextBox txtOtherTextBox = new TextBox();
                string strOtherBoxName = "";
                int intOtherScore = 0;

                //Get which textbox it is
                string[] strNameParts = textbox.Name.Split('-');
                string strName = strNameParts[0];
                int intPlayerBox = Convert.ToInt32(strNameParts[1]);
                int intFrameBox = Convert.ToInt32(strNameParts[2]);
                int intScoreBox = Convert.ToInt32(strNameParts[3]); 
                
                if (intScoreBox != 1)
                {
                    //Get Score in prior box
                    intOtherScore = intScoreBox - 1;
                    strOtherBoxName = strName + "-" + intPlayerBox + "-" + intFrameBox + "-" + intOtherScore;
                    var item = tlpFrame.Controls.Find(strOtherBoxName, false);
                    txtOtherTextBox = (TextBox)item[0];
                    string strScore = txtOtherTextBox.Text;
                    
                    //Dont allow score to be entered if prior score has not been entered for frame
                    if (strScore == "")
                    {
                        e.Handled = true;
                    }
                }

                //Allow - for zero in any box
                if (e.KeyChar.ToString() == "-")
                {
                    goto done;
                }

                //Allow X for strike only in first box
                if (char.ToUpper(e.KeyChar) == (char)Keys.X && intScoreBox == 1)
                {                    
                    goto done;
                }

                //Allow / for spare only in second box, unless the frame is 10. Frame 10 has special handeling
                if (e.KeyChar.ToString() == "/" && intScoreBox == 2 && intFrame != 10)
                {
                    goto done;
                }

                //Continue to check numeric if frame is not 10. This part will be specific to frame 10
                if (intFrameBox != 10)
                {
                    goto numCheck;
                }

                //Get Score in first box of frame 10
                intOtherScore = 1;
                strOtherBoxName = strName + "-" + intPlayerBox + "-" + intFrameBox + "-" + intOtherScore;
                var item1 = tlpFrame.Controls.Find(strOtherBoxName, false);
                txtOtherTextBox = (TextBox)item1[0];
                string strScore1 = txtOtherTextBox.Text;

                //Allow / for spare in second box only when there was no strike in the first box
                if (e.KeyChar.ToString() == "/" && intScoreBox == 2 && strScore1 != "X")
                {
                    goto done;
                }
                
                //Allow X for strike in second box only when strike in first box
                if (char.ToUpper(e.KeyChar) == (char)Keys.X && intScoreBox == 2 && strScore1 == "X")
                {
                    goto done;
                }

                //Get Score in first box of frame 10
                intOtherScore = 2;
                strOtherBoxName = strName + "-" + intPlayerBox + "-" + intFrameBox + "-" + intOtherScore;
                var item2 = tlpFrame.Controls.Find(strOtherBoxName, false);
                txtOtherTextBox = (TextBox)item2[0];
                string strScore2 = txtOtherTextBox.Text;

                //Allow X for strike in third box only when strike or spare in second box
                if (char.ToUpper(e.KeyChar) == (char)Keys.X && intScoreBox == 3 && (strScore2 == "X" || strScore2 == "/"))
                {
                    goto done;
                }

                //Allow / for spare in third box only when there was no strike or spare in the second box
                if (e.KeyChar.ToString() == "/" && intScoreBox == 3 && (strScore2 != "X" && strScore2 != "/"))
                {
                    goto done;
                }

            numCheck:
                { }

                //Allow only numbers
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }      

            done:
                { }
            };

            //Code to execute when the value of the textbox changes
            textbox.TextChanged += (sender, e) =>
            {
                //Variables to return controls from form
                Control contFrame1 = textbox.Parent;
                TableLayoutPanel tlpFrame = (TableLayoutPanel)contFrame1;
                Control contFrame2 = tlpFrame.Parent;
                TableLayoutPanel tlpScoreCard = (TableLayoutPanel)contFrame2;
                TextBox txtOtherTextBox = new TextBox();
                string strOtherBoxName = "";
                int intOtherScore = 0;

                //Get which textbox it is
                string[] strNameParts = textbox.Name.Split('-');
                string strName = strNameParts[0];
                int intPlayerBox = Convert.ToInt32(strNameParts[1]);
                int intFrameBox = Convert.ToInt32(strNameParts[2]);
                int intScoreBox = Convert.ToInt32(strNameParts[3]);

                //change to dash if zero is entered
                if (textbox.Text == "0")
                {
                    textbox.Text = "-";
                }


                //Check text entered and determine if next steps are needed
                switch (textbox.Text)
                {
                    case "X":
                        if (intFrameBox == 10)
                        {
                            if (intScoreBox == 1)
                            {
                                //Clear second box when first changes
                                intOtherScore = 2;
                                strOtherBoxName = strName + "-" + intPlayerBox + "-" + intFrameBox + "-" + intOtherScore;
                                var item1 = tlpFrame.Controls.Find(strOtherBoxName, false);
                                txtOtherTextBox = (TextBox)item1[0];
                                txtOtherTextBox.Text = "";

                                //Enable third box in tenth frame when a strike is in first box
                                intOtherScore = 3;
                                strOtherBoxName = strName + "-" + intPlayerBox + "-" + intFrameBox + "-" + intOtherScore;
                                var item2 = tlpFrame.Controls.Find(strOtherBoxName, false);
                                txtOtherTextBox = (TextBox)item2[0];
                                txtOtherTextBox.Enabled = true;
                            }                          
                        }
                        else
                        {
                            //Disable second box in other frames when strike is in first box
                            intOtherScore = intScoreBox + 1;
                            strOtherBoxName = strName + "-" + intPlayerBox + "-" + intFrameBox + "-" + intOtherScore;
                            var item = tlpFrame.Controls.Find(strOtherBoxName, false);
                            txtOtherTextBox = (TextBox)item[0];
                            txtOtherTextBox.Enabled = false;
                            txtOtherTextBox.Text = "";
                        }
                        break;
                    case "/":
                        if (intFrameBox == 10)
                        {
                            if (intScoreBox == 2)
                            {
                                //Enable third box in tenth frame when a spare is in second box
                                intOtherScore = 3;
                                strOtherBoxName = strName + "-" + intPlayerBox + "-" + intFrameBox + "-" + intOtherScore;
                                var item = tlpFrame.Controls.Find(strOtherBoxName, false);
                                txtOtherTextBox = (TextBox)item[0];
                                txtOtherTextBox.Enabled = true;
                            }
                        }
                        break;
                    default:
                        if (intFrameBox == 10)
                        {                            
                            //Get score from box one of tenth frame
                            intOtherScore = 1;
                            strOtherBoxName = strName + "-" + intPlayerBox + "-" + intFrameBox + "-" + intOtherScore;
                            var item1 = tlpFrame.Controls.Find(strOtherBoxName, false);
                            TextBox txtOtherTextBox1 = (TextBox)item1[0];
                            string strScore1 = txtOtherTextBox1.Text;

                            //Get score from box two of tenth frame
                            intOtherScore = 2;
                            strOtherBoxName = strName + "-" + intPlayerBox + "-" + intFrameBox + "-" + intOtherScore;
                            var item2 = tlpFrame.Controls.Find(strOtherBoxName, false);
                            TextBox txtOtherTextBox2 = (TextBox)item2[0];
                            string strScore2 = txtOtherTextBox2.Text;

                            //Clear second box when first changes
                            if (intScoreBox == 1)
                            {                             
                                txtOtherTextBox2.Text = "";
                                strScore2 = "";
                            }

                            //Get score from box three of tenth frame
                            intOtherScore = 3;
                            strOtherBoxName = strName + "-" + intPlayerBox + "-" + intFrameBox + "-" + intOtherScore;
                            var item3 = tlpFrame.Controls.Find(strOtherBoxName, false);
                            TextBox txtOtherTextBox3 = (TextBox)item3[0];
                            string strScore3 = txtOtherTextBox3.Text;

                            //Clear second box when first changes
                            if (intScoreBox == 2)
                            {
                                txtOtherTextBox3.Text = "";
                                strScore3 = "";
                            }

                            if (strScore1 != "X" && strScore2 != "/")
                            {
                                //Disable the third box in tenth frame when first is no longer a strike and second is no longer a spare
                                intOtherScore = 3;
                                strOtherBoxName = strName + "-" + intPlayerBox + "-" + intFrameBox + "-" + intOtherScore;
                                var item = tlpFrame.Controls.Find(strOtherBoxName, false);
                                txtOtherTextBox = (TextBox)item[0];
                                txtOtherTextBox.Enabled = false;
                                txtOtherTextBox.Text = "";
                            }
                        }
                        else
                        {
                            if (intScoreBox == 1)
                            {
                                //Enable second box in other frames when first is no longer a strike
                                intOtherScore = 2;
                                strOtherBoxName = strName + "-" + intPlayerBox + "-" + intFrameBox + "-" + intOtherScore;
                                var item = tlpFrame.Controls.Find(strOtherBoxName, false);
                                txtOtherTextBox = (TextBox)item[0];
                                txtOtherTextBox.Enabled = true;
                                txtOtherTextBox.Text = "";
                            }                            
                        }
                        break;
                }

                if (intScoreBox == 2 || intScoreBox == 3)
                {
                    //Make the value a spare if value entered plus the value of prior score is equal to or excceds 10
                    intOtherScore = intScoreBox - 1;
                    strOtherBoxName = strName + "-" + intPlayerBox + "-" + intFrameBox + "-" + intOtherScore;
                    var item = tlpFrame.Controls.Find(strOtherBoxName, false);
                    txtOtherTextBox = (TextBox)item[0];
                    string strScore1 = txtOtherTextBox.Text;                 
                    string strScore2 = textbox.Text;
                    var isNumeric1 = int.TryParse(strScore1, out int intScore1);
                    var isNumeric2 = int.TryParse(strScore2, out int intScore2);
                    if (strScore1 == "-")
                    {
                        isNumeric1 = true;
                        intScore1 = 0;
                    }
                    if (strScore2 == "-")
                    {
                        isNumeric2 = true;
                        intScore2 = 0;
                    }
                    if (isNumeric1 && isNumeric2)
                    {                        
                        if (intScore1 + intScore2 >= 10)
                        {
                            textbox.Text = "/";
                        }
                    }
                }

                //Calculate score               
                CalculateScore(tlpScoreCard, strName, intPlayer);               

                //Send focus to next score box
                tlpScoreCard.SelectNextControl(textbox, true, true, true, true);
            };                        

            return textbox;
        }

        public Label CreateLabel(int intPlayer, int intFrame)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //Creates the labels for the score to be displayed
            //////////////////////////////////////////////////////////////////////////////////////////////////// 
            
            //Create label
            Label label = new Label();

            //Set properties
            label.Name = "lblScore-" + intPlayer + "-" + intFrame;
            label.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            label.TextAlign = ContentAlignment.MiddleRight;         

            return label;
        }

        public void CalculateScore(TableLayoutPanel tlpScoreCard, string strName, int intPlayer)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //Calculates the scores for each frame and displays them
            //////////////////////////////////////////////////////////////////////////////////////////////////// 
            
            //Variables to return controls from form
            TextBox txtTextBox = new TextBox();
            Label lblLabelBox = new Label();
            string strBoxName = "";
            int intScoreBox = 0;

            //Array to hold scores from frames
            string[] strScore1 = new string[10];
            string[] strScore2 = new string[10];            
            string[] strFrameTotal = new string[10];
            
            //Other score variables
            string strScore3 = "";
            string strTempScore = "";            
            int intFrameTotal = 0;
            int intTotal = 0;

            //Fill score arrays with scores
            for (int intFrame = 1; intFrame < 11; intFrame++)
            {
                intScoreBox = 1;
                strBoxName = strName + "-" + intPlayer + "-" + intFrame + "-" + intScoreBox;
                var item1 = tlpScoreCard.Controls.Find(strBoxName, true);
                txtTextBox = (TextBox)item1[0];
                strScore1[intFrame - 1] = txtTextBox.Text;
                intScoreBox = 2;
                strBoxName = strName + "-" + intPlayer + "-" + intFrame + "-" + intScoreBox;
                var item2 = tlpScoreCard.Controls.Find(strBoxName, true);
                txtTextBox = (TextBox)item2[0];
                strScore2[intFrame - 1] = txtTextBox.Text;
                if (intFrame == 10)
                {
                    intScoreBox = 3;
                    strBoxName = strName + "-" + intPlayer + "-" + intFrame + "-" + intScoreBox;
                    var item3 = tlpScoreCard.Controls.Find(strBoxName, true);
                    txtTextBox = (TextBox)item3[0];
                    if (txtTextBox.Enabled == false)
                    {
                        //Setting to D for disabled
                        strScore3 = "D";
                    }
                    else
                    {                        
                        strScore3 = txtTextBox.Text;
                    }
                }
            }            

            //Fill the score array
            for (int intFrame = 0; intFrame < 10; intFrame++)
            {
                if (intFrame == 9)
                {                    
                    if (strScore1[intFrame] != "" && strScore2[intFrame] != "" && strScore3 != "")
                    {
                        intFrameTotal = ParseScore(strScore1[intFrame], strScore2[intFrame], strScore3);
                        strFrameTotal[intFrame] = intFrameTotal.ToString();
                    }
                }
                else
                {                   
                    if (strScore1[intFrame] == "X")
                    {
                        //For a strike add next two scores. Use both scores from next frame if both filled in
                        if (strScore1[intFrame + 1] != "" && strScore2[intFrame + 1] != "")
                        {
                            intFrameTotal = ParseScore(strScore1[intFrame + 1], strScore2[intFrame + 1], "0") + 10;
                            strFrameTotal[intFrame] = intFrameTotal.ToString();
                        }
                        else
                        {
                            if (intFrame == 8)
                            {
                                //For a strike add next two scores. When frame 9 use first two scores from frame 10 if both filled in
                                strTempScore = strScore2[intFrame + 1];
                            }
                            else
                            {
                                //For a strike add next two scores. Use first score from next frame if it is a strike, and first score from frame after that
                                strTempScore = strScore1[intFrame + 2];
                            }
                            if (strScore1[intFrame + 1] == "X" && strTempScore != "")
                            {                    
                                //For a strike add next two scores. Using determined scores
                                intFrameTotal = ParseScore(strScore1[intFrame + 1], strTempScore, "0") + 10;
                                strFrameTotal[intFrame] = intFrameTotal.ToString();
                            }
                        }
                    }
                    if (strScore2[intFrame] == "/")
                    {
                        if (strScore1[intFrame + 1] != "")
                        {
                            //For a spare add next scores. Use first score from next frame if filled in
                            intFrameTotal = ParseScore(strScore1[intFrame + 1], "0", "0") + 10;
                            strFrameTotal[intFrame] = intFrameTotal.ToString();
                        }
                    }
                    if (strScore1[intFrame] != "X" && strScore1[intFrame] != "" && strScore2[intFrame] != "/" && strScore2[intFrame] != "")
                    {
                        //For frames that do not have a strike or a spare use both scores from the current frame
                        intFrameTotal = ParseScore(strScore1[intFrame], strScore2[intFrame], "0");
                        strFrameTotal[intFrame] = intFrameTotal.ToString();
                    }
                }
            }

            //Display scores in the labels
            for (int intFrame = 1; intFrame < 11; intFrame++)
            {
                intScoreBox = 1;
                strBoxName = "lblScore-" + intPlayer + "-" + intFrame;
                var item = tlpScoreCard.Controls.Find(strBoxName, true);
                lblLabelBox = (Label)item[0];
                lblLabelBox.Text = strFrameTotal[intFrame - 1];
                if (strFrameTotal[intFrame - 1] != "")
                {
                    intTotal = intTotal + Convert.ToInt32(strFrameTotal[intFrame - 1]);
                }
            }

            strBoxName = "lblScore-" + intPlayer;
            var item4 = tlpScoreCard.Controls.Find(strBoxName, true);
            lblLabelBox = (Label)item4[0];
            lblLabelBox.Text = intTotal.ToString();            
        }

        public int ParseScore(string strScore1, string strScore2, string strScore3)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //Parses the scores based on input provided
            //////////////////////////////////////////////////////////////////////////////////////////////////// 
            
            int intScore1 = 0;
            int intScore2 = 0;
            int intScore3 = 0;
            int intTotal = 0;

            switch (strScore1)
            {
                case "X":
                    intScore1 = 10;                  
                    break;
                case "-":
                    intScore1 = 0;
                    break;          
                default:
                    intScore1 = Convert.ToInt32(strScore1);
                    break;
            }

            switch (strScore2)
            {
                case "X":
                    intScore2 = 10;
                    break;
                case "/":
                    intScore2 = 10 - intScore1;
                    break;
                case "-":
                    intScore2 = 0;
                    break;
                case "":
                    intScore2 = 0;
                    break;
                default:
                    intScore2 = Convert.ToInt32(strScore2);
                    break;
            }

            switch (strScore3)
            {
                case "D":
                    intScore3 = 0;
                    break;
                case "X":
                    intScore3 = 10;
                    break;
                case "/":
                    intScore3 = 10 - intScore2;
                    break;
                case "-":
                    intScore3 = 0;
                    break;
                case "":
                    intScore3 = 0;
                    break;
                default:
                    intScore3 = Convert.ToInt32(strScore3);
                    break;
            }

            intTotal = intScore1 + intScore2 + intScore3;

            return intTotal;
        }
    }
}
