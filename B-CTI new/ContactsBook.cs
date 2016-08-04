using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using AsteriskManager;
using BCTI.DialogBoxes;

namespace BCTI
{
    public partial class ContactsBook : Form
    {
        public List<ClientsData> BookOfContacts = new List<ClientsData>();
        List<ClientsData> temp = new List<ClientsData>();
        public event EventHandler<EventArgs> conBookEdited;
        string avapath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/B-Cti/avatars/";
        string filter = "";
        int exit = 0;
        public ContactsBook(List<ClientsData> CurrOfContacts)
        {
            InitializeComponent();
            BookOfContacts = CurrOfContacts;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            closeButton.BackgroundImage = closeButtonImage.Images[0];
            reload();
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                редактироватьToolStripMenuItem.ForeColor = Color.Gray;
                удалитьToolStripMenuItem.ForeColor = Color.Gray;
            }

        }

        public void reload()
        {
            if (BookOfContacts.Count <= 0) return;
            temp.Clear();
            int row = -1, i = 0;
            if (dataGridView1.CurrentRow != null)
                row = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows.Clear();
            toAvatars.Images.Clear();
            foreach (ClientsData contact in BookOfContacts)
            {

                if (contact.Number.ToLower().Contains(filter.ToLower()) | contact.SecondNumber.ToLower().Contains(filter.ToLower()) | contact.Name.ToLower().Contains(filter.ToLower()) | contact.organisation.ToLower().Contains(filter.ToLower()) | contact.email.ToLower().Contains(filter.ToLower()) | filter == "")
                {
                    if (contact.onBLF)
                    {
                        if (File.Exists(avapath + contact.ID.ToString()))
                        {
                            toAvatars.Images.Add(Image.FromFile(avapath + contact.ID.ToString() + ".jpeg"));
                            dataGridView1.Rows.Add(onBLFImage.Images[0], Image.FromFile(avapath + contact.ID.ToString()), contact.Name, contact.organisation, contact.Number, contact.SecondNumber, contact.email);
                        }
                        else
                        {
                            toAvatars.Images.Add(onBLFImage.Images[3]);
                            dataGridView1.Rows.Add(onBLFImage.Images[0], toAvatars.Images[i], contact.Name, contact.organisation, contact.Number, contact.SecondNumber, contact.email);
                        }
                    }
                    else
                    {
                        if (File.Exists(avapath + contact.ID.ToString()))
                        {
                            toAvatars.Images.Add(Image.FromFile(avapath + contact.ID.ToString() + ".jpeg"));
                            dataGridView1.Rows.Add(onBLFImage.Images[2], Image.FromFile(avapath + contact.ID.ToString()), contact.Name, contact.organisation, contact.Number, contact.SecondNumber, contact.email);
                        }
                        else
                        {
                            toAvatars.Images.Add(onBLFImage.Images[3]);
                            dataGridView1.Rows.Add(onBLFImage.Images[2], toAvatars.Images[i], contact.Name, contact.organisation, contact.Number, contact.SecondNumber, contact.email);
                        }
                    }
                    i++;
                    temp.Add(contact);
                }

            }
            if (row != -1 & row < dataGridView1.Rows.Count)
            {
                dataGridView1.Rows[row].Cells[2].Selected = true;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            conBookEdited(this, null);
            exit = 1;
            Close();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.BackgroundImage = closeButtonImage.Images[1];
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            if (exit != 1)
                closeButton.BackgroundImage = closeButtonImage.Images[0];
        }

        private Point lastCursor;
        private Point lastForm;
        private bool isDragging = false;

        private void headPanel_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;

            lastCursor = Cursor.Position;
            lastForm = this.Location;
        }

        private void headPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Location =
                    Point.Add(lastForm, new Size(Point.Subtract(Cursor.Position, new Size(lastCursor))));
            }
        }

        private void headPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void headPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized) WindowState = FormWindowState.Normal;
            else WindowState = FormWindowState.Maximized;
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            filter = searchBox.Text;
            reload();
        }

        private void ContactsBook_FormClosed(object sender, FormClosedEventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            XmlSerializer xs = new XmlSerializer(typeof(List<ClientsData>));
            if (!Directory.Exists(path + "/B-Cti")) Directory.CreateDirectory(path + "/B-Cti");
            StreamWriter sw = new StreamWriter(path + "/B-Cti/ContactsBook.xml");
            xs.Serialize(sw, BookOfContacts);
            sw.Flush();
            sw.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddToBook ATB = new AddToBook();
            ATB.ShowDialog();
            ClientsData tempContact = new ClientsData();
            if (ATB.newClient.Name != "")
            {
                tempContact = ATB.newClient;
                if (!BookOfContacts.Contains(tempContact))
                {
                    BookOfContacts.Add(tempContact);
                    reload();
                }
                else BMessageBox.Show("Контакт уже существует");
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (редактироватьToolStripMenuItem.ForeColor == Color.Gray) return;
            int i = dataGridView1.SelectedRows[0].Index;
            BookOfContacts.Remove(temp[i]);
            AddToBook ATB = new AddToBook(temp[i]);
            ATB.ShowDialog();
            BookOfContacts.Add(ATB.newClient);
            reload();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (e.RowIndex < 0) return;
                if (temp[e.RowIndex].onBLF)
                {
                    BookOfContacts[BookOfContacts.IndexOf(temp[e.RowIndex])].onBLF = false;
                    temp[e.RowIndex].onBLF = false;
                    dataGridView1.Rows[e.RowIndex].Cells[0].Value = onBLFImage.Images[0];
                }
                else
                {
                    BookOfContacts[BookOfContacts.IndexOf(temp[e.RowIndex])].onBLF = true;
                    temp[e.RowIndex].onBLF = true;
                    dataGridView1.Rows[e.RowIndex].Cells[0].Value = onBLFImage.Images[2];
                }
            }
            reload();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (редактироватьToolStripMenuItem.ForeColor == Color.Gray) return;
            int i = dataGridView1.SelectedRows[0].Index;
            BookOfContacts.Remove(temp[i]);
            reload();
        }

        private void rightSizer_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeWE;
        }

        private void rightSizer_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void downResizer_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeNS;
        }

        bool resizing = false;
        Point oldPosition = new Point();

        private void rightSizer_MouseUp(object sender, MouseEventArgs e)
        {
            resizing = false;
        }

        private void rightSizer_MouseDown(object sender, MouseEventArgs e)
        {
            resizing = true;
            oldPosition = PointToScreen(Cursor.Position);
        }

        private void rightSizer_MouseMove(object sender, MouseEventArgs e)
        {
            Point newPosition = PointToScreen(Cursor.Position);
            if (resizing)
                this.Width += (newPosition.X - oldPosition.X);
            oldPosition = newPosition;
        }

        private void leftSizer_MouseMove(object sender, MouseEventArgs e)
        {
            Point newPosition = Cursor.Position;
            if (resizing)
            {
                this.Width += -(newPosition.X - this.Location.X);
                this.Location = new Point(newPosition.X, this.Location.Y);
            }
            oldPosition = newPosition;
        }

        private void topSizer_MouseMove(object sender, MouseEventArgs e)
        {
            Point newPosition = Cursor.Position;
            if (resizing)
            {
                this.Height += -(newPosition.Y - this.Location.Y);
                this.Location = new Point(this.Location.X, newPosition.Y);
            }
            oldPosition = newPosition;
        }

        private void downResizer_MouseMove(object sender, MouseEventArgs e)
        {
            Point newPosition = PointToScreen(Cursor.Position);
            if (resizing)
                this.Height += (newPosition.Y - oldPosition.Y);
            oldPosition = newPosition;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            //if (редактироватьToolStripMenuItem.ForeColor == Color.Gray) return;
            int i = dataGridView1.SelectedRows[0].Index;
            int j = BookOfContacts.IndexOf(temp[i]);
            BookOfContacts.Remove(temp[i]);
            AddToBook ATB = new AddToBook(temp[i]);
            ATB.ShowDialog();
            BookOfContacts.Insert(j, ATB.newClient);
            reload();
        }

        private void addButton_MouseEnter(object sender, EventArgs e)
        {
            addButton.BackgroundImage = createImages.Images[1];
        }

        private void addButton_MouseLeave(object sender, EventArgs e)
        {
            addButton.BackgroundImage = createImages.Images[0];
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
    }
}
