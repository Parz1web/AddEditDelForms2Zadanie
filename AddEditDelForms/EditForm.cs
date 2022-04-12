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
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "appDBDataSet.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter.Fill(this.appDBDataSet.Table);

            AppDBEntities _dbEntitites = new AppDBEntities();

            var c = (from a in _dbEntitites.Table
                     select new { Id = a.Id, Название = a.Name, Описание = a.Description, Цена = a.Price });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppDBEntities _dbEntities = new AppDBEntities();
            Table ProductTable = new Table();

            
            int id = int.Parse(comboBox1.SelectedValue.ToString());
            Table Product = _dbEntities.Table.Find(id);

            Product.Name = textBox1.Text;
            Product.Description = textBox2.Text;
            Product.Price = int.Parse(textBox3.Text);

            
            _dbEntities.SaveChanges();

            AppDBEntities _dbEntitites = new AppDBEntities();

            var c = (from a in _dbEntitites.Table
                     select new { Id = a.Id, Название = a.Name, Описание = a.Description, Цена = a.Price });
        }
    }
}
