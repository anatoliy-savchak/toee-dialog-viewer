using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DialogViewer
{
    public partial class FormDialogViewver : Form
    {
        Dialog dialog;

        public FormDialogViewver()
        {
            this.Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
            this.tvContent.Font = new Font(this.tvContent.Font.Name, this.tbDetails.Font.Size + 2);
            this.tbDetails.Font = new Font(this.tbDetails.Font.Name, this.tbDetails.Font.Size + 2);
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            LoadFile(tbFileName.Text);
        }

        public void LoadFile(string fileName)
        {
            dialog = DialogFormatterDlg.DeserializeFileDlg(fileName);
            ReloadView();
        }

        public void ReloadView()
        {
            if (dialog != null)
            {
                this.tvContent.BeginUpdate();
                try
                {
                    this.tvContent.Nodes.Clear();
                    foreach (DialogLine dialogLine in dialog.lines)
                    {
                        if (dialogLine.IsPCLine) continue;
                        AddSubdialog(dialogLine.Key, null);
                    }
                }
                finally
                {
                    this.tvContent.EndUpdate();
                }
            }
        }

        protected bool AddSubdialog(int key, TreeNode parent)
        {
            if (dialog == null) return false;
            int keyIndex = dialog.GetKeyIndex(key);
            if (keyIndex < 0) return false;
            TreeNode root = null;
            for (int i = keyIndex; i < dialog.lines.Length; i++)
            {
                DialogLine dialogLine = dialog.lines[i];
                if (i == keyIndex)
                {
                    if (parent == null)
                    {
                        root = this.tvContent.Nodes.Add(DialogLine2NodeText(dialogLine));
                        root.Tag = dialogLine;
                    }
                    else root = parent;
                } else
                {
                    if (!dialogLine.IsPCLine) break;
                    TreeNode child = root.Nodes.Add(DialogLine2NodeText(dialogLine));
                    child.Tag = dialogLine;
                    if (child.Level < 10)
                    {
                        AddSubdialog(dialogLine.Key, child);
                    }
                }
            }
            return true;
        }

        protected static string DialogLine2NodeText(DialogLine dialogLine)
        {
            string apx = null;
            if (dialogLine.TestSpecified)
                apx = $"   | {dialogLine.Test}";
            return $"{dialogLine.Key}: {dialogLine.Txt}{apx}";
        }

        protected static string DialogLine2DetailsText(DialogLine dialogLine)
        {
            return dialogLine.ToDlgLine();
        }

        private void tvContent_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if ((e.Node.Nodes.Count == 0) && (e.Node.Tag != null))
            {
                AddSubdialog(((DialogLine)(e.Node.Tag)).Key, e.Node);
            }
        }

        private void tvContent_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tbDetails.Text = DialogLine2DetailsText((DialogLine)(e.Node.Tag));
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbFileName.Text))
            {
                openFileDialog1.FileName = tbFileName.Text;
                openFileDialog1.InitialDirectory = Path.GetDirectoryName(openFileDialog1.FileName);
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFileName.Text = openFileDialog1.FileName;
                LoadFile(tbFileName.Text);
            }
        }

        private void FormDialogViewver_Shown(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                tbFileName.Text = args[1];
                LoadFile(tbFileName.Text);
            }
        }
    }

    internal class DialogLineTreeNode : TreeNode
    {

    }

}
