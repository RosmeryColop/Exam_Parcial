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

namespace Exam_Parcial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Alumno> alumnos = new List<Alumno> ();
        List<Inscritos> inscripcion = new List<Inscritos>();
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void GuardarAlumno()
        {
            FileStream stream = new FileStream("Alumnos.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var al in alumnos )
            {
                writer.WriteLine(al.nombre);
                writer.WriteLine(al.grado);
                writer.WriteLine(al.fecha);

            }
            writer.Close();

        }

        private void GuardarEstado()
        {
            FileStream stream = new FileStream("Inscripciones.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var ins in inscripcion)
            {
                writer.WriteLine(ins.nombre);
                writer.WriteLine(ins.estado);
            }
            writer.Close();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Primero");
            comboBox1.Items.Add("Segundo");
            comboBox1.Items.Add("Tercero");
            comboBox1.Items.Add("Cuarto");
            comboBox1.Items.Add("Quinto");
            comboBox1.Items.Add("Sexto");
        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            Alumno al = new Alumno ();
            al.nombre = textBox1.Text;
            al.grado = comboBox1.SelectedItem.ToString();
            al.fecha = DateTime.Today;
            alumnos.Add(al);
            GuardarAlumno();
          
            string temp;
            if (radioButton2.Checked == true)
            {
                temp = "Inscrito";
            }
            else {
                temp = "Sin Inscripcion";
            }
            Inscritos ins =new Inscritos ();
            ins.nombre= textBox1.Text;
            ins.estado = temp;
            inscripcion.Add(ins);
            GuardarEstado();

            radioButton2.Checked = false;
            MessageBox.Show("Se han guardado los datos");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();

            frm.Show();
        }
    }
}
 