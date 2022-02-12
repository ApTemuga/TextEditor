using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class F_TextEditor : Form
    {
        FileEditor fileEditor;
        public F_TextEditor()
        {
            InitializeComponent();
        }

        void UnlockControlls()
        {
            mb_Close.Enabled = true;
            mb_Save.Enabled = true;
            mb_SaveAs.Enabled = true;
        }

        void LockControlls()
        {
            mb_Close.Enabled = false;
            mb_Save.Enabled = false;
            mb_SaveAs.Enabled = false;
        }

        private void mb_Open_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileEditor = new FileEditor(openFileDialog.FileName);
                List<string> lines = fileEditor.ReadFile();
                string resText = "";
                foreach(string line in lines)
                {
                    resText += line + "\n";
                }
                if(!String.IsNullOrEmpty(resText))
                {
                    rtb_Editor.Text = resText.Remove(resText.Length - 1);
                }
                else
                {
                    rtb_Editor.Text = "";
                }
                UnlockControlls();
            }
        }

        private void mb_Save_Click(object sender, EventArgs e)
        {
            fileEditor.WriteFile(rtb_Editor.Text);
        }

        private void F_TextEditor_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void mb_Close_Click(object sender, EventArgs e)
        {
            fileEditor = null;
            rtb_Editor.Text = "";
            LockControlls();
        }

        private void mb_SaveAs_Click(object sender, EventArgs e)
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileEditor.WriteFileAs(rtb_Editor.Text, saveFileDialog.FileName);
            }
        }

        private void cmcopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtb_Editor.SelectedText);
        }

        private void cm_cut_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtb_Editor.SelectedText);
            rtb_Editor.SelectedText = "";
        }

        private void cm_paste_Click(object sender, EventArgs e)
        {
            if (rtb_Editor.SelectedText == "")
            {
                int cursorPosition = rtb_Editor.SelectionStart;
                rtb_Editor.Text = rtb_Editor.Text.Insert(cursorPosition, Clipboard.GetText());
                rtb_Editor.SelectionStart = cursorPosition + Clipboard.GetText().Length;
            }
            else
                rtb_Editor.SelectedText = Clipboard.GetText();
        }
    }
}
