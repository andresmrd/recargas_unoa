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
    public partial class VentasTotales : Form
    {
        
        public VentasTotales()
        {
            InitializeComponent();
            consultaVentasTotales();
        }

        List<Venta> ventas = new List<Venta>();

        public void consultaVentasTotales()
        {
            this.ventas.Clear();
            textBox1.Clear();
            grid.Rows.Clear();
            Database db = new Database();
            this.ventas = db.consulta_total(dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"), dateTimePicker2.Value.Date.ToString("yyyy-MM-dd"));
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

        private void VentasTotales_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            consultaVentasTotales();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            consultaVentasTotales();
        }

    }
}
