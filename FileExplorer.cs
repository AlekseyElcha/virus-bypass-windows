using Microsoft.VisualBasic;
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

            var contextMenu = new ContextMenuStrip();
            var changeItem = contextMenu.Items.Add("Переименовать");
            var deleteItem = contextMenu.Items.Add("Удалить");

            contextMenu.Items.Add(changeItem);
            contextMenu.Items.Add(deleteItem);
            listView1.ContextMenuStrip = contextMenu;

            changeItem.Click += ChangeItem_Click;
            deleteItem.Click += DeleteItem_Click;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            ListViewItem selectedItem = listView1.SelectedItems[0];

            if (selectedItem.Tag == null) return;

            string filePath = selectedItem.Tag.ToString();

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dialogResult = MessageBox.Show($"Вы уверены, что хотите удалить файл {Path.GetFileName(filePath)}?",
                "Удаление файла", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    File.Delete(filePath);
                    listView1.Items.Remove(selectedItem); // Удаляем из интерфейса
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось удалить файл: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChangeItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            ListViewItem selectedItem = listView1.SelectedItems[0];
            if (selectedItem.Tag == null) return;

            string oldPath = selectedItem.Tag.ToString();

            if (!File.Exists(oldPath))
            {
                MessageBox.Show("Файл не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string currentName = Path.GetFileName(oldPath);
            string directory = Path.GetDirectoryName(oldPath);

            using (RenameForm renameDialog = new RenameForm(currentName))
            {
                if (renameDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string newName = renameDialog.NewName;

                    if (newName == currentName) return;

                    string newPath = Path.Combine(directory, newName);

                    try
                    {
                        File.Move(oldPath, newPath);

                        FileInfo newFileInfo = new FileInfo(newPath);
                        selectedItem.Text = newFileInfo.Name;
                        selectedItem.SubItems[1].Text = newFileInfo.Extension;
                        selectedItem.Tag = newPath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не удалось переименовать файл: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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

                        item.Tag = filePath;

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
