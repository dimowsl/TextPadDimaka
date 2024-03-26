using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextPadSotirios
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuWordWrap.Checked = !menuWordWrap.Checked;
            if (menuWordWrap.Checked)
            {
                richTextBox1.WordWrap = true;
            }
            else
            {
                richTextBox1.WordWrap = false;
            }
        }

        private void menuNew_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New menu");
            richTextBox1.Clear();
            this.Text = "Text Pad - Dimaka";
            richTextBox1.Modified = false;
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open";
            ofd.Filter = "Text Document | *.txt|Rich Text |*.rtf|All Files |*.*";
            ofd.FilterIndex = 2;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.RichText);
                this.Text = ofd.FileName;
            }

            
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuPaste_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void menuUndo_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void menuRedo_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void menuCut_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void menuSelectAll_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wordWrapToolStripMenuItem_Click(sender, e);
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text File|*.txt|Rich Text Files|*.rtf|Word files|*.docx";
                saveFileDialog.Title = "Запази";
                saveFileDialog.FilterIndex = 2;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                    return;
                }

                this.Text = "Text Pad - Dimaka" + saveFileDialog.FileName;
                richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //1
            fontDialog1.ShowColor = true;
            //2
            fontDialog1.ShowDialog();
            //3
            richTextBox1.SelectionFont = fontDialog1.Font;
            richTextBox1.SelectionColor = fontDialog1.Color;
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBox1.Modified)
            {
                DialogResult answer =
                MessageBox.Show("Do you want to  save the changes ?",
                "Confirmation",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
                if (answer == DialogResult.Yes)
                {
                    menuSave_Click(sender, e);
                }
                if (answer == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void menuSave_Click(object sender, EventArgs e)
        {

        }

        private void menuFile_Click(object sender, EventArgs e)
        {

        }

        private void menuFormat_Click(object sender, EventArgs e)
        {

        }
    }
}
