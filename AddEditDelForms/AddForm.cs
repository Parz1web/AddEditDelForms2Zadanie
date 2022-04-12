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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
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
            AppDBEntities _dbEntitites = new AppDBEntities();

            Table ProductTable = new Table();

            ProductTable.Name = textBox1.Text;
            ProductTable.Description = textBox2.Text;
            ProductTable.Price = int.Parse(textBox3.Text);

            _dbEntitites.Table.Add(ProductTable);
            _dbEntitites.SaveChanges();

            var c = (from a in _dbEntitites.Table
                     select new { Id = a.Id, Название = a.Name, Описание = a.Description, Цена = a.Price });
            dataGridView1.DataSource = c.ToList();
        }
    }
}
