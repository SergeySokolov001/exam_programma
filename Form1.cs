using System;
using System.Linq;
using System.Windows.Forms;

namespace Приложение
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (var db = new Rieltor_SokolovEntities())
                {
                    dataGridView1.DataSource = db.Риэлторы.ToList();
                }
                dataGridView1.Columns[0].Visible = false;
            }

            catch
            {
                MessageBox.Show("Ошибка");
            } //вывод списка риэлторов в datagridview со значениями из базы данных

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new Rieltor_SokolovEntities())
                {
                    int id = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
                    var redel = db.Риэлторы.FirstOrDefault(item => item.ID == id);
                    db.Риэлторы.Remove(redel);
                    db.SaveChanges();
                    MessageBox.Show("Строка успешно удалена");
                    dataGridView1.DataSource = db.Риэлторы.ToList(); //удаление выделенной строки путём парсинга по ID
                }

            }

            catch
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new Rieltor_SokolovEntities())
            {
                dataGridView1.DataSource = db.Риэлторы.ToList(); //обновление датагридвью на основании данных из базы
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new Rieltor_SokolovEntities())
            {
                db.SaveChanges();
                dataGridView1.DataSource = db.Риэлторы.ToList(); //сохранение данных в базе и datagridview при редактировании и изменении данных
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form addform = new AddForm();
            addform.Show();
            this.Hide(); //переход на форму добавления данных

        }
    }

    }
    

