using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace I.A
{
    public partial class Form1 : Form
    {
        public string TraducirEspeciales(string cadena)
        {
            return cadena.Replace("á", "�").Replace("é", "�").Replace("í", "�").Replace("ó", "�").Replace("ú", "�").Replace("ñ", "�");
        }
        public class Win32
        {
            [DllImport("kernel32.dll")]
            public static extern Boolean AllocConsole();
            [DllImport("kernel32.dll")]
            public static extern Boolean FreeConsole();
        }

        Entrenador Maestro;

        public Form1()
        {
            InitializeComponent();
        }

        private void bUrl_Click(object sender, EventArgs e)
        {
            lbUrl.Items.Add(tbUrl.Text);
        }

        private void bCampo1_Click(object sender, EventArgs e)
        {
            lbCampo1.Items.Add(tbCampo1.Text);
        }

        private void bCampo2_Click(object sender, EventArgs e)
        {
            lbCampo2.Items.Add(tbCampo2.Text);
        }

        private void bCampo3_Click(object sender, EventArgs e)
        {
            lbCampo3.Items.Add(tbCampo3.Text);
        }

        private void bCampo4_Click(object sender, EventArgs e)
        {
            lbCampo4.Items.Add(tbCampo4.Text);
        }

        private void bEntrenar_Click(object sender, EventArgs e)
        {
            string[] url = new string[lbUrl.Items.Count];
            string[] campo1 = new string[lbUrl.Items.Count];
            string[] campo2 = new string[lbUrl.Items.Count];
            string[] campo3 = new string[lbUrl.Items.Count];
            string[] campo4 = new string[lbUrl.Items.Count];
            string[] campo5 = new string[lbUrl.Items.Count];

            for (int i = 0; i < lbUrl.Items.Count; i++)
            {
                url[i] = lbUrl.Items[i].ToString();
                campo1[i] = lbCampo1.Items[i].ToString();
                //Comenzamos a comprobar si hay mas de un campo
                if (lbCampo2.Items.Count > 0)
                    campo2[i] = lbCampo2.Items[i].ToString();
                if (lbCampo3.Items.Count > 0)
                    campo3[i] = lbCampo3.Items[i].ToString();
                if (lbCampo4.Items.Count > 0)
                    campo4[i] = lbCampo4.Items[i].ToString();
                if (lbCampo5.Items.Count > 0)
                    campo5[i] = lbCampo5.Items[i].ToString();
            }

            Entrenador maestro = new Entrenador(url, campo1, campo2, campo3, campo4, campo5);
            Maestro = maestro;
        }

        private void tbUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbUrl_Click(object sender, EventArgs e)
        {
            tbUrl.SelectionStart = 0;
            tbUrl.SelectionLength = tbUrl.Text.Length;
        }

        private void tbCampo1_Click(object sender, EventArgs e)
        {
            tbCampo1.SelectionStart = 0;
            tbCampo1.SelectionLength = tbCampo1.Text.Length;
        }

        private void tbCampo2_Click(object sender, EventArgs e)
        {
            tbCampo2.SelectionStart = 0;
            tbCampo2.SelectionLength = tbCampo2.Text.Length;
        }

        private void tbCampo3_Click(object sender, EventArgs e)
        {
            tbCampo3.SelectionStart = 0;
            tbCampo3.SelectionLength = tbCampo3.Text.Length;
        }

        private void tbCampo4_Click(object sender, EventArgs e)
        {
            tbCampo4.SelectionStart = 0;
            tbCampo4.SelectionLength = tbCampo4.Text.Length;
        }

        private void tbCampo5_Click(object sender, EventArgs e)
        {
            tbCampo5.SelectionStart = 0;
            tbCampo5.SelectionLength = tbCampo5.Text.Length;
        }

        private void bEjec1_Click(object sender, EventArgs e)
        {
            Win32.AllocConsole();
            Maestro.EjecutarPagina(tbFiltro.Text);
            Win32.FreeConsole();
        }

        private void bEjecTodos_Click(object sender, EventArgs e)
        {
            Win32.AllocConsole();
            StreamReader lector = new StreamReader("./sitemap.txt");
            string enlace;
            while ((enlace = lector.ReadLine()) != null)
            {
                    if (enlace.IndexOf(".html") > 0)
                    {
                        Maestro.EjecutarPagina(enlace);
                    }
            }
            Win32.FreeConsole();
        }

        private void lbUrl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbCampo4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbCampo1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
