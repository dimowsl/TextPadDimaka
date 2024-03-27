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
        string lastEditedFile = "";
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
            if (richTextBox1.Modified)
            {
                DialogResult answer = MessageBox.Show("Do you want to save the changes",
                "Confirmation", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (answer == DialogResult.Yes)
                {
                    menuSave_Click(sender, e);
                }
                if (answer == DialogResult.Cancel)
                {
                    return;
                }
            }
            richTextBox1.Clear();
            lastEditedFile = "";
            this.Text = "Text Pad - New File";
            richTextBox1.Modified = false;
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Modified)
            {
                DialogResult answer = MessageBox.Show("Do you want to save the changes",
                "Confirmation", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (answer == DialogResult.Yes)
                {
                    menuSave_Click(sender, e);
                }
                if (answer == DialogResult.Cancel)
                {
                    return;
                }
            }
            //1
            openFileDialog1.Filter = "Text files|*.txt|Rich Text Files|*.rtf|Word files|*.doc;*.docx|All files|*.*";
            openFileDialog1.FileName = "";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.Title = "Open in Text Pad";
            //2.
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            //3.
            lastEditedFile = openFileDialog1.FileName;
            this.Text = "DimPad - " + openFileDialog1.SafeFileName;
            if (openFileDialog1.FilterIndex == 1)
            {
               richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
            else if (openFileDialog1.FilterIndex == 2)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
            }
            else
            {
                MessageBox.Show("raboti samo s TXT ili RTF");
                return;
            }
            richTextBox1.Modified = false;


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
            //1
            saveFileDialog1.Filter = "Text files|*.txt|Rich Text Files|*.rtf|Word files|*.docx";
            saveFileDialog1.FileName = "";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.Title = "Open in Text Pad";
            //2.
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            //3.
            lastEditedFile = saveFileDialog1.FileName;
            this.Text = "Text Pad -" + saveFileDialog1.FileName;
            if (saveFileDialog1.FilterIndex == 2)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
            }
            else if (saveFileDialog1.FilterIndex == 1)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
            else
            {
                MessageBox.Show("Ne raboti s tozi format");
                return;
            }
            richTextBox1.Modified = false;
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
            if (lastEditedFile == "")
            {
                menuSaveAs_Click(sender, e);
            }
            else
            {
                
                richTextBox1.SaveFile(lastEditedFile, RichTextBoxStreamType.RichText);
               

            }
            richTextBox1.Modified = false;
        }

        private void menuFile_Click(object sender, EventArgs e)
        {

        }

        private void menuFormat_Click(object sender, EventArgs e)
        {

        }
    }
}
