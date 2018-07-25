using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentasUNOA
{
    public partial class VentasDiarias : Form
    {
        public string printer;
        public VentasDiarias()
        {
            InitializeComponent();
            consultaVentasDiarias();
        }

        List<Venta> ventas = new List<Venta>();

        public void consultaVentasDiarias()
        {
            textBox1.Clear();
            this.ventas.Clear();
            grid.Rows.Clear();
            ConfigFile cf = new ConfigFile();
            this.printer = cf.printer;
            Database db = new Database();
            this.ventas = db.consulta_dia(this.dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));
            for (int i = 0; i < this.ventas.Count; i++)
            {
                grid.Rows.Add(this.ventas[i].idVenta, this.ventas[i].fecha, this.ventas[i].medioPago, this.ventas[i].valor);
                
            }

            double total = 0;
            foreach (DataGridViewRow row in grid.Rows)
            {
                total += Convert.ToDouble(row.Cells["Column4"].Value);
            }
            textBox1.Text = total.ToString();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VentasDiarias_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Print pr = new Print();
            pr.printer = this.printer;
            pr.imprimir_ventas_dia(double.Parse(textBox1.Text));
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            consultaVentasDiarias();
        }
    }
}
