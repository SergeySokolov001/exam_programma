using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Приложение
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Form1();
            form.Show();
            this.Hide(); //форма выхода в главное меню
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }

        private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); //приложение закрывается при закрытии формы
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear(); //очистка введённых значений в случай неудачного ввода данных
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var db = new Rieltor_SokolovEntities())
            {
                Риэлторы риэлторы = new Риэлторы
                {
                    Фамилия = textBox1.Text,
                    Имя = textBox2.Text,
                    Отчество = textBox3.Text,
                    Доля_от_комиссии = Convert.ToInt32(textBox4.Text)


                };
                if (textBox1.Text == null && textBox2.Text == null && textBox3.Text == null)
                {
                    MessageBox.Show("Риэлтор не может быть без фамилии, имени или отчества.");
                }
                else
                {
                    db.Риэлторы.Add(риэлторы);
                    db.SaveChanges();
                    MessageBox.Show("Риэлтор успешно добавлен");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }//Добавление данных в таблицу и их очистка после успешного добавления с проверкой на ввод фамилии, имени и отчества
            }
        }
        public class Sum
        {
            public int a = 0;
            public int b = 0;
            public int z = 0;

            public int summa(int a, int b)
            {
                return z = a + b;
            }
        }
        }
        }

