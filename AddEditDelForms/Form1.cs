using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddEditDelForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "appDBDataSet.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter.Fill(this.appDBDataSet.Table);

            AppDBEntities _dbEntitites = new AppDBEntities();

            var c = (from a in _dbEntitites.Table
                     select new { Id = a.Id, Название = a.Name, Описание = a.Description, Цена = a.Price });
            dataGridView1.DataSource = c.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();

            addForm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm();

            editForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            AppDBEntities _dbEntitites = new AppDBEntities();

            int id = 
                int.Parse(dataGridView1.CurrentCell.Value.ToString());
            Table Product = _dbEntitites.Table.Find(id);

            _dbEntitites.Table.Attach(Product);
            _dbEntitites.Table.Remove(Product);
            _dbEntitites.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AppDBEntities _dbEntitites = new AppDBEntities();
            var c = (from a in _dbEntitites.Table
                     select new { Id = a.Id, Название = a.Name, Описание = a.Description, Цена = a.Price });
            dataGridView1.DataSource = c.ToList();
        }
    }
}
