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
        List<Reporte> reportes = new List<Reporte>();


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
        public void guardarInscripciones()
        {
            Inscripciones inscripcioness = new Inscripciones();

            inscripcioness.DpiAlumnos = Convert.ToInt32(comboBoxAlumnos.SelectedValue);
            inscripcioness.CodTaller = Convert.ToInt32(textBox1.Text);
            inscripcioness.Fecha = DateTime.Now;

            inscripciones.Add(inscripcioness);
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            guardarInscripciones();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = inscripciones;
            dataGridView1.Refresh();

            datos();
        }

        private void buttonOrdenar_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            dataGridView3.Refresh();
            dataGridView3.DataSource = "";

            Reporte reporte = reportes.OrderByDescending(a => a.Nombre).First();
            reportes.Clear();
            reportes.Add(reporte);


            dataGridView3.DataSource = null;
            dataGridView3.DataSource = reportes;
            dataGridView3.Refresh();

        }
        public void datos()
        {
            

            foreach (Alumnos alumnoss in alumnos)
            {
                foreach (Talleres talleress in talleres)
                {
                    foreach (Inscripciones inscripcioness in inscripciones)
                    {
                        
                        if (alumnoss.Dpi == inscripcioness.DpiAlumnos)
                        {
                            Reporte reporte = new Reporte();
                            reporte.Nombre = alumnoss.Nombre;
                            reporte.Teller = talleress.NombreTaller;



                            reportes.Add(reporte);
                        }
                    }
                    
                    
                }
            }

            dataGridView3.DataSource = null;
            dataGridView3.DataSource = reportes;
            dataGridView3.Refresh();

        }
    }
}
