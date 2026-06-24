using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VirusBypass
{
    public partial class FileExplorer : UserControl
    {
        public FileExplorer()
        {
            InitializeComponent();
            FillDriveNodes();

            treeView1.BeforeExpand += TreeView1_BeforeExpand;
            treeView1.AfterSelect += TreeView1_AfterSelect; 
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            int totalWidth = listView1.ClientSize.Width;

            listView1.Columns[0].Width = (int)(totalWidth * 0.55);
            listView1.Columns[1].Width = (int)(totalWidth * 0.25);
            listView1.Columns[2].Width = (int)(totalWidth * 0.20);
        }

        private void FillDriveNodes()
        {
            treeView1.Nodes.Clear();

            string[] drives = Directory.GetLogicalDrives();

            foreach (string drive in drives)
            {
                TreeNode driveNode = new TreeNode(drive);
                driveNode.Tag = drive;

                driveNode.Nodes.Add(new TreeNode());

                treeView1.Nodes.Add(driveNode);
            }
        }

        private void TreeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode currentNode = e.Node;
            currentNode.Nodes.Clear();
            string currentPath = currentNode.Tag.ToString();

            try
            {
                foreach (string dir in Directory.GetDirectories(currentPath))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dir);

                    if ((dirInfo.Attributes & FileAttributes.Hidden) == 0 &&
                        (dirInfo.Attributes & FileAttributes.System) == 0)
                    {
                        TreeNode dirNode = new TreeNode(dirInfo.Name) { Tag = dir };
                        dirNode.Nodes.Add(new TreeNode());
                        currentNode.Nodes.Add(dirNode);
                    }
                }
            }
            catch (UnauthorizedAccessException) {  }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string currentPath = e.Node.Tag.ToString();
            listView1.Items.Clear();

            try
            {
                if (!Directory.Exists(currentPath)) return;

                foreach (string filePath in Directory.GetFiles(currentPath))
                {
                    FileInfo fileInfo = new FileInfo(filePath);

                    if ((fileInfo.Attributes & FileAttributes.Hidden) == 0)
                    {
                        ListViewItem item = new ListViewItem(fileInfo.Name);

                        item.SubItems.Add(fileInfo.Extension);
                        item.SubItems.Add($"{fileInfo.Length / 1024} КБ");

                        listView1.Items.Add(item);
                    }
                }

                listView1.Columns[0].Width = -2;
                listView1.Columns[1].Width = -2;
                listView1.Columns[2].Width = -2;
            }
            catch (UnauthorizedAccessException)
            {
                listView1.Items.Add(new ListViewItem("Доступ к файлам этой папки ограничен"));
            }
            catch (Exception ex)
            {
                listView1.Items.Add(new ListViewItem($"Ошибка: {ex.Message}"));
            }
        }
    }
}
