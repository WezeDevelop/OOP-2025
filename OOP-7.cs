using System;
using System.Drawing;
using System.Windows.Forms;

namespace MultiWindowTextEditor
{
    public class MainForm : Form
    {
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenu, newWindowMenu, saveMenu, exitMenu;
        private RichTextBox richTextBox;

        public MainForm()
        {
            Text = "Багатовіконний Текстовий Редактор";
            Width = 800;
            Height = 600;

            menuStrip = new MenuStrip();

            fileMenu = new ToolStripMenuItem("Файл");
            newWindowMenu = new ToolStripMenuItem("Нове вікно", null, NewWindow);
            saveMenu = new ToolStripMenuItem("Зберегти", null, SaveFile);
            exitMenu = new ToolStripMenuItem("Вийти", null, (s, e) => Close());

            fileMenu.DropDownItems.Add(newWindowMenu);
            fileMenu.DropDownItems.Add(saveMenu);
            fileMenu.DropDownItems.Add(exitMenu);
            menuStrip.Items.Add(fileMenu);
            Controls.Add(menuStrip);

            richTextBox = new RichTextBox { Dock = DockStyle.Fill }; 
            Controls.Add(richTextBox);
        }

        private void NewWindow(object sender, EventArgs e)
        {
            MainForm newForm = new MainForm();
            newForm.Show();
        }

        private void SaveFile(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog { Filter = "RTF Files|*.rtf" })
            {
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox.SaveFile(saveDialog.FileName);
                }
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
