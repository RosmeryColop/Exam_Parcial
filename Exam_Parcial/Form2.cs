using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_Parcial
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        List<Alumno> alumnos = new List<Alumno>();
        List<Inscritos> inscripcion = new List<Inscritos>();
      
        private void CargarAlumnos()
        {
            FileStream stream = new FileStream("Alumnos.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {

                Alumno al = new Alumno();
                al.nombre= reader.ReadLine();
                al.grado= reader.ReadLine();
                al.fecha = Convert.ToDateTime(reader.ReadLine());
                alumnos.Add(al);
            }

            reader.Close();
        }
        private void CargarEstado()
        {
            FileStream stream = new FileStream("Inscripciones.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {

                Inscritos ins = new Inscritos();
                ins.nombre = reader.ReadLine();
                ins.estado = reader.ReadLine();
                inscripcion.Add(ins);

            }

            reader.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = alumnos;
            dataGridView1.Refresh();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CargarAlumnos();
            CargarEstado();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = inscripcion;
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Inscritos ins = new Inscritos();
            inscripcion= inscripcion.OrderBy(x => x.estado).ToList();


            Alumno al = new Alumno();
            alumnos= alumnos.OrderBy(x => x.grado).ToList();
        }
    }
}
