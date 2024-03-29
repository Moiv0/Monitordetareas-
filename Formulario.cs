using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using Task = Microsoft.Win32.TaskScheduler.Task;

namespace Monitordetareas
{
    public partial class Formulario : Form
    {
        public Formulario()
        {
            InitializeComponent();
        }

        private void Formulario_Load(object sender, EventArgs e)
        {
            CbEstado.Items.Add("activo");
            CbEstado.Items.Add("error");
            CbEstado.Items.Add("inactivo");


            List<string> lista = new List<string>();
            lista.Add("Elemento 1");
            lista.Add("Elemento 2");
            lista.Add("Elemento 3");

            // Asignar la lista al ListBox
            //ListaTareas.DataSource = lista;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TaskService taskService = new TaskService())
            {
                String tarea;
                tarea = "";
                foreach (Task task in taskService.RootFolder.Tasks)
                {
                    tarea += " Task Name: " + task.Name ;
                    tarea += " Task Path: " + task.Path;
                    tarea += " Task State: " + task.State;
                    tarea += " ------------------------ ";

                }
                TxtVentana.Text = tarea;
            }
        }

        private void TxtVentana_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
