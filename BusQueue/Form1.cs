using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial
{


    public partial class Form1 : Form
    {
        //cola de pasajeros a espera de subir a la combi.
        Queue<string> cola = new Queue<string>();

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void btnAnotar_Click(object sender, EventArgs e)
        {
            string dato = textBox1.Text;
            cola.Enqueue(dato);
            mostrarListaEspera();
            textBox1.Text = "";
        }

        private void mostrarListaEspera()
        {
            string dato = textBox1.Text;
            listBox1.Items.Add(dato);
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            //Uso un array simple para llenar la combi.
            string[] combi = new string[3];

            //si la lista de espera tiene menor cantidad de pasajeros a subir, la combi por ende no podrá llenarse.
            if (cola.Count < 3 && cola.Count != 0)
            {
                MessageBox.Show("La combi aún tiene espacio, permanecerá en la Terminal.");
            }
            else if (cola.Count == 0)
            {
                MessageBox.Show("La combi se va a la terminal de Puerto Madero.");
            }
            else {
                //si la lista de espera tiene suficiente gente para llenar la combi, entonces se recorre la combi:
                for (int i = 0; i < combi.Length; i++)
                {
                    //ingreso al primer lugar de la combi el primer pasajero de la lista de espera.
                    combi[i] = cola.Peek();
                    //lo remuevo de la lista de espera.
                    listBox1.Items.Remove(cola.Peek());
                    //lo remuevo de la cola.
                    cola.Dequeue();
                }

                MessageBox.Show("La combi está llena.");
            }
        }

        private void InitializeDataGridView()
        {

            //Horarios
            string[] row1 = new string[] { "Lun-Jue", "07:00 a 20:00" };
             string[] row2 = new string[] { "Vie", "07:00 a 23:00" };
             string[] row3 = new string[] { "Sab", "10:00 a 19:00" };

             object[] rows = new object[] { row1, row2, row3 };

             foreach (string[] rowArray in rows)
             {
                 dataGridView1.Rows.Add(rowArray);
             }
        }
    }
}

