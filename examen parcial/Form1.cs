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

namespace examen_parcial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Alumnos> alumnos = new List<Alumnos>();
        List<Talleres> talleres = new List<Talleres>();
        List<Inscripciones> inscripciones = new List<Inscripciones>();


        public void CargarAlumnos()
        {
            String fileName = "Alumnos.txt";


            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Alumnos alumnoss = new Alumnos();
                alumnoss.Dpi = Convert.ToInt32(reader.ReadLine());
                alumnoss.Nombre = reader.ReadLine();
                alumnoss.Direccion = reader.ReadLine();

                alumnos.Add(alumnoss);
            }
            reader.Close();

            comboBoxAlumnos.DisplayMember = "Nombre";
            comboBoxAlumnos.ValueMember = "Dpi";
            comboBoxAlumnos.DataSource = alumnos;
            comboBoxAlumnos.Refresh();
        }

        public void cargarTalleres()
        {
            String fileName = "Talleres.txt";


            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Talleres talleress = new Talleres();
                talleress.Codigo = Convert.ToInt32(reader.ReadLine());
                talleress.NombreTaller = reader.ReadLine();
                talleress.Costo = Convert.ToDecimal(reader.ReadLine());

                talleres.Add(talleress);
            }
            reader.Close();

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = talleres;
            dataGridView2.Refresh();
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            CargarAlumnos();
            cargarTalleres();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            Inscripciones inscripcioness = new Inscripciones();

            inscripcioness.DpiAlumnos = Convert.ToInt32(comboBoxAlumnos.SelectedValue);
            inscripcioness.CodTaller = Convert.ToInt32(textBox1.Text);
            inscripcioness.Fecha = DateTime.Now;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = inscripciones;
            dataGridView1.Refresh();
        }
    }
}
