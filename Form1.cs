using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MisGastos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("conceptos.txt");
            string Linea = "";
            while (sr.EndOfStream == false)
            {
                Linea = sr.ReadLine();
                lstConcepto.Items.Add(Linea);
            }
            sr.Close();
            sr.Dispose();
        }

        private void cmdCargar_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal importe = Convert.ToDecimal(txtImporte.Text);

                if (importe>0)
                {
                    StreamWriter sw = new StreamWriter("Gastos.txt", true);
                    sw.Write(dtpFecha.Text);
                    sw.Write(", ");
                    sw.Write(lstConcepto.Text);
                    sw.Write(", ");
                    sw.WriteLine(txtImporte.Text);

                    sw.Close();
                    sw.Dispose();

                    lstConcepto.SelectedIndex = 0;
                    txtImporte.Text = "";
                }
                else
                {
                    MessageBox.Show("Ingrese un importe mayor a 0", "AVISO");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique los datos ingresados", "ERROR");
            }
            
        }
    }
}
