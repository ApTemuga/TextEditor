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
                rtb_Editor.Text = resText.Remove(resText.Length - 1);
            }
        }
    }
}
