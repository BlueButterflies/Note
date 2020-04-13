using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Note
{
    public partial class Note : Form
    {
        public Note()
        {
            InitializeComponent();
        }

        // Variable Documento Open
        public string documentOpen = " ";

        // Upload title
        private void UploadTitle(string title)
        {
            this.Text = title;
        }

        public string TextInitial = " ";

        #region Control - Text is edit
        private void Control()
        {
            if (txtBox.Text != TextInitial)
            {
                DialogResult dialog =
                    MessageBox.Show("Document is edit. You save it?", "Document is Edit", MessageBoxButtons.YesNo);

                try
                {
                    if (dialog == DialogResult.Yes)
                    {
                        SaveDocuments();
                        TextInitial = " ";
                    }

                    if (dialog == DialogResult.No)
                    {
                        TextInitial = " ";
                    }
                }
                catch
                {

                }
            }
        }
        #endregion

        #region  Save Documents
        private void SaveDocuments()
        {
            saveDocument.ShowDialog();

            try
            {
                if (saveDocument.FileName != null)
                {
                    File.WriteAllText(saveDocument.FileName, txtBox.Text);
                    documentOpen = saveDocument.FileName;
                    TextInitial = txtBox.Text;
                }
            }
            catch
            {

            }
        }
        #endregion

        #region Load Form
        private void Note_Load(object sender, EventArgs e)
        {
            // Open file with Block Note
            if (Environment.GetCommandLineArgs().Count() > 1)
            {
                string[] files = Environment.GetCommandLineArgs();
                MessageBox.Show(files[1]);
                UploadTitle(files[1]);
                txtBox.Text = File.ReadAllText(files[1]);
                TextInitial = File.ReadAllText(files[1]);
                documentOpen = files[1];
            }
            else
            {
                string[] files = Environment.GetCommandLineArgs();
            }

            // Cheched Word Wrap tool - open program
            if (Properties.Settings.Default.WordWrap == true)
            {
                txtBox.WordWrap = true;
                wordWrapTool.Checked = true;
            }
            else
            {
                txtBox.WordWrap = false;
                wordWrapTool.Checked = false;
            }

            //Charge and save font, size , color and style in start program
            if (Properties.Settings.Default.FontName != "")
            {
                FontFamily family = new FontFamily(Properties.Settings.Default.FontName);
                Font fontSelection = new Font(family, Properties.Settings.Default.FontSize,
                                     FontStyle.Regular, GraphicsUnit.Pixel);

                txtBox.Font = fontSelection;
            }

            //Charge Status Bar
            if (Properties.Settings.Default.StatusBar == true)
            {
                statusBar.Visible = true;
            }
            else
            {
                statusBar.Visible = false;
            }

            //Charge Find Search
            if (Properties.Settings.Default.FindBar == true)
            {
                panel.Visible = true;
            }
            else
            {
                panel.Visible = false;
            }

            //Charge Go to
            if (Properties.Settings.Default.GoTo == true)
            {
                toolGoTo.Visible = true;
            }
            else
            {
                toolGoTo.Visible = false;
            }
        }
        #endregion

        #region File New
        private void newFile_Click(object sender, EventArgs e)
        {
            Control();
            txtBox.Text = "";
            documentOpen = " ";
            UploadTitle("New Note");

        }
        #endregion

        #region File New Windows
        private void newWindowsFile_Click(object sender, EventArgs e)
        {
            Note noteBlock = new Note();

            noteBlock.ShowDialog();
        }
        #endregion

        #region File Open
        private void openFile_Click(object sender, EventArgs e)
        {
            if (txtBox.TextLength > 0)
            {
                Control();
            }


            openDocument.ShowDialog();

            try
            {
                if (openDocument.FileName != "")
                {
                    txtBox.Text = File.ReadAllText(openDocument.FileName);
                    TextInitial = File.ReadAllText(openDocument.FileName);
                    documentOpen = openDocument.FileName;
                    UploadTitle(openDocument.FileName);
                }
            }
            catch
            {

            }

        }
        #endregion 

        #region File Save
        private void saveFile_Click(object sender, EventArgs e)
        {
            if (documentOpen != " ")
            {
                try
                {
                    File.WriteAllText(documentOpen, txtBox.Text);
                    TextInitial = txtBox.Text;
                }
                catch
                {

                }
            }
            else
            {
                SaveDocuments();
            }

        }
        #endregion

        #region File Save As
        private void saveAsFile_Click(object sender, EventArgs e)
        {
            SaveDocuments();
        }
        #endregion

        #region File Page Setup
        private void pageSetupFile_Click(object sender, EventArgs e)
        {
            Document.DocumentName = documentOpen;

            pageSetupDialog.ShowDialog();

        }
        #endregion

        #region File Print
        private void printFile_Click(object sender, EventArgs e)
        {
            Document.DocumentName = documentOpen;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                Document.Print();
            }

        }

        private void prinDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string textForPrint = txtBox.Text;

            int characters = 0;
            int rows = 0;

            FontFamily fontFamily = new FontFamily("Arial");

            Font font = new Font(fontFamily, 16, FontStyle.Regular, GraphicsUnit.Pixel);

            e.Graphics.MeasureString(textForPrint, font, e.MarginBounds.Size, StringFormat.GenericTypographic,
                out characters, out rows);

            e.Graphics.DrawString(textForPrint, font, Brushes.Black, e.MarginBounds,
                StringFormat.GenericTypographic);

            textForPrint = textForPrint.Substring(characters);

            e.HasMorePages = textForPrint.Length > 0;
        }
        #endregion

        #region File Exit
        private void exitFile_Click(object sender, EventArgs e)
        {
            Control();
            Application.Exit();
        }
        #endregion

        #region Edit Undo, Cut, Copy, Paste, Delete
        private void undoEdit_Click(object sender, EventArgs e)
        {
            txtBox.Undo();
        }

        private void cutEdit_Click(object sender, EventArgs e)
        {
            txtBox.Cut();
        }

        private void copyEdit_Click(object sender, EventArgs e)
        {
            txtBox.Copy();
        }

        private void pasteEdit_Click(object sender, EventArgs e)
        {
            txtBox.Paste();
        }

        private void deleteEdit_Click(object sender, EventArgs e)
        {
            txtBox.SelectedText = "";
        }
        #endregion

        #region Edit Search with Google and Bing
        private void googleEdit_Click(object sender, EventArgs e)
        {
            string textSearch = txtBox.SelectedText.TrimEnd();

            Process.Start("http://www.google.com/search?qsource=hp&q=" + textSearch);

        }

        private void bingEdit_Click(object sender, EventArgs e)
        {
            string textSearch = txtBox.SelectedText.TrimEnd();

            Process.Start("http://www.bing.com/search?q=" + textSearch);

        }
        #endregion

        #region Edit Find, Find Next, Replace
        private void findToolStrip_Click(object sender, EventArgs e)
        {
            if (panel.Visible == true)
            {
                panel.Visible = false;

                Properties.Settings.Default.FindBar = false;
                Properties.Settings.Default.Save();

            }
            else
            {
                panel.Visible = true;

                Properties.Settings.Default.FindBar = true;
                Properties.Settings.Default.Save();
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtFind.TextLength == 0)
            {
                MessageBox.Show("No text to search");
            }
            else
            {
                txtBox.Focus();

                if (txtBox.TextLength > 0)
                {
                    txtBox.Find(txtFind.Text);
                }
                else
                {
                    MessageBox.Show("The text is missing");
                }
            }
        }

        private int indexOfPosition = 0;

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            try
            {
                txtBox.Focus();
                indexOfPosition = txtBox.Find(txtFind.Text, indexOfPosition, RichTextBoxFinds.None);
                txtBox.Select(indexOfPosition, txtFind.TextLength);
                indexOfPosition = indexOfPosition + txtFind.TextLength + 1;
            }
            catch
            {
                MessageBox.Show("No more text to search");
                indexOfPosition = 0;
            }
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnFindNext_Click(sender, e);
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (txtReplace.TextLength == 0 && txtFind.TextLength == 0)
            {
                MessageBox.Show("No text for replace");
            }
            else
            {
                if (txtBox.SelectedText.Length > 0)
                {

                    var selectedText = txtBox.SelectedText;
                    var replaceText = selectedText.Replace(txtBox.SelectedText, txtReplace.Text);

                    txtBox.SelectedText = replaceText;

                    txtBox.DeselectAll();
                }
                else
                {
                    MessageBox.Show("The text is missing");
                }
            }

        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnReplace_Click(sender, e);
        }
        #endregion

        #region Edit Go To
        private void goToTool_Click(object sender, EventArgs e)
        {
            if (toolGoTo.Visible == true)
            {
                toolGoTo.Visible = false;

                Properties.Settings.Default.GoTo = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                toolGoTo.Visible = true;

                Properties.Settings.Default.GoTo = true;
                Properties.Settings.Default.Save();
            }

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            var controlTextGoTo = int.TryParse(txtGoTo.Text, out int valueText);

            if (controlTextGoTo == true)
            {
                if (valueText > txtBox.Lines.Count())
                {
                    valueText = txtBox.Lines.Count();
                }
                else
                {
                    if (valueText == 0)
                    {
                        valueText = 1;
                    }
                }

                int index = txtBox.GetFirstCharIndexFromLine(valueText - 1);
                txtBox.Select(index, 0);
                txtBox.ScrollToCaret();

                if (txtBox.Lines.Count() < valueText)
                {
                    valueText = int.Parse(txtBox.Lines.Last());
                }
            }
            else
            {
                MessageBox.Show("Insert numbers");
            }
        }
        #endregion

        #region Edit Select All
        private void selectAllTool_Click(object sender, EventArgs e)
        {
            txtBox.SelectAll();
        }
        #endregion

        #region Edit Date/Time
        private string time = DateTime.Now.ToString("HH") + ":" + DateTime.Now.ToString("mm");
        private string date = DateTime.Now.ToString("dd") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("yyyy");

        private void dateTool_Click(object sender, EventArgs e)
        {
            int positionInitial = txtBox.SelectionStart;

            txtBox.Text = txtBox.Text.Insert(positionInitial, date);

        }

        private void tameTool_Click(object sender, EventArgs e)
        {
            int positionInitial = txtBox.SelectionStart;

            txtBox.Text = txtBox.Text.Insert(positionInitial, time);

        }

        private void dateAndTimeTool_Click(object sender, EventArgs e)
        {
            int positionInitial = txtBox.SelectionStart;

            txtBox.Text = txtBox.Text.Insert(positionInitial, date + " " + time);

        }
        #endregion

        #region Format Word Wrap
        private void wordWrapTool_Click(object sender, EventArgs e)
        {
            if (txtBox.WordWrap == true)
            {
                txtBox.WordWrap = false;
                wordWrapTool.Checked = false;
                Properties.Settings.Default.WordWrap = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                txtBox.WordWrap = true;
                wordWrapTool.Checked = true;
                Properties.Settings.Default.WordWrap = true;
                Properties.Settings.Default.Save();
            }
        }
        #endregion

        #region Format Font
        private void fontTool_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {

                Properties.Settings.Default.FontName = fontDialog.Font.Name;
                Properties.Settings.Default.FontSize = fontDialog.Font.Size;

                Properties.Settings.Default.Save();

                //Charge in text box selection fond, size, color and style
                FontFamily family = new FontFamily(fontDialog.Font.Name);
                Font fontSelection = new Font(family, fontDialog.Font.Size, FontStyle.Regular, GraphicsUnit.Pixel);
                txtBox.Font = fontSelection;
            }
        }
        #endregion

        #region View Zoom 
        private void zoomInTool_Click(object sender, EventArgs e)
        {
            if (txtBox.ZoomFactor < 7.0f)
            {
                txtBox.ZoomFactor += 0.3f;

                //Status Bar Zoom
                double precentZoom = txtBox.ZoomFactor * 100;
                precentZoom = (int)Math.Floor(precentZoom);
                statusZoom.Text = $"Zoom: {precentZoom}%";
            }
        }

        private void zoomOutTool_Click(object sender, EventArgs e)
        {
            if (txtBox.ZoomFactor > 0.6f)
            {
                txtBox.ZoomFactor -= 0.3f;

                //Status Bar Zoom
                double precentZoom = txtBox.ZoomFactor * 100;
                precentZoom = (int)Math.Floor(precentZoom);
                statusZoom.Text = $"Zoom: {precentZoom}%";
            }
        }
        #endregion

        #region View Status Bar
        private void statusBarTool_Click(object sender, EventArgs e)
        {
            if (statusBar.Visible == false)
            {
                statusBar.Visible = true;
                statusBarTool.Checked = true;
                Properties.Settings.Default.StatusBar = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                statusBar.Visible = false;
                statusBarTool.Checked = false;
                Properties.Settings.Default.StatusBar = false;
                Properties.Settings.Default.Save();
            }
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            charTool.Text = "Characters: " + txtBox.Text.Count();
        }
        #endregion

        #region ? Send Feedback
        private void sendFeedbackTool_Click(object sender, EventArgs e)
        {
            SendFeedback feedback = new SendFeedback();

            feedback.ShowDialog();
        }
        #endregion

        #region ? Info Note
        private void infoNoteTool_Click(object sender, EventArgs e)
        {
            Info info = new Info();

            info.ShowDialog();
        }
        #endregion

        #region Menu Context
        private void undoContext_Click(object sender, EventArgs e)
        {
            undoEdit_Click(sender, e);
        }

        private void cutContext_Click(object sender, EventArgs e)
        {
            cutEdit_Click(sender, e);
        }

        private void copyContext_Click(object sender, EventArgs e)
        {
            copyEdit_Click(sender, e);
        }

        private void pasteContext_Click(object sender, EventArgs e)
        {
            pasteEdit_Click(sender, e);
        }

        private void deleteContext_Click(object sender, EventArgs e)
        {
            deleteEdit_Click(sender, e);
        }

        private void selectAllContext_Click(object sender, EventArgs e)
        {
            selectAllTool_Click(sender, e);
        }

        private void googleContext_Click(object sender, EventArgs e)
        {
            googleEdit_Click(sender, e);
        }

        private void bingContext_Click(object sender, EventArgs e)
        {
            bingEdit_Click(sender, e);
        }
        #endregion

        #region Icons
        private void printBox_Click(object sender, EventArgs e)
        {
            printFile_Click(sender, e);
        }

        private void zoomOutBox_Click(object sender, EventArgs e)
        {
            zoomOutTool_Click(sender, e);
        }

        private void zoomInBox_Click(object sender, EventArgs e)
        {
            zoomInTool_Click(sender, e);
        }
        #endregion
    }
}

