using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboBox(); 
            load();
        }
        Model1 db= new Model1();
        public List<Class1> listmodel = new List<Class1>();
        public void load()
        {
            var pb = db.Faculty.ToList();
            var list = db.Student.ToList();
            foreach (var item in list)
            {
                Class1 model = new Class1();
                model.StudentID = item.StudentID;
                model.FullName = item.FullName;
                model.AverageScore = item.AverageScore;
                model.FacultyName = pb.Where(s => s.FacultyID == item.FacultyID).FirstOrDefault().FacultyName;
                listmodel.Add(model);
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listmodel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newUser = new Student
            {
                StudentID = Convert.ToInt32(textBox2.Text),
                FullName = textBox1.Text,
                FacultyID = Convert.ToInt32(comboBox1.SelectedValue.ToString()),
                AverageScore = float.Parse(textBox3.Text),
            };
            db.Student.Add(newUser);
            db.SaveChanges();
            dataGridView1.DataSource = null;
            listmodel.Clear();
            load();
            
        }
        private void LoadComboBox()
        {
            var db = new Model1();
            var p = db.Faculty.ToList();
            comboBox1.DisplayMember = "FacultyName";
            comboBox1.ValueMember = "FacultyID";
            comboBox1.DataSource = p;
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            textBox2.Text = row.Cells[0].Value.ToString();
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            comboBox1.Text = row.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var index = dataGridView1.SelectedRows[0].Index;
                var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value.ToString());

                var sua = db.Student.FirstOrDefault(u => u.StudentID == id);

                if (sua != null)
                {
                    sua.StudentID = Convert.ToInt32(textBox2.Text);
                    sua.FullName = textBox1.Text;
                    sua.FacultyID = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                    sua.AverageScore = float.Parse(textBox3.Text);
                    db.SaveChanges();
                    dataGridView1.DataSource = null;
                    listmodel.Clear();
                    load();
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var index = dataGridView1.SelectedRows[0].Index;
                var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value.ToString());

                var xoa = db.Student.FirstOrDefault(u => u.StudentID == id);

                if (xoa != null)
                {
                    db.Student.Remove(xoa);
                    db.SaveChanges();
                    var lists = db.Student.ToList();
                    dataGridView1.DataSource = lists;
                }

            }
        }
       
    }
}
