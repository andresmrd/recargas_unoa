using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VentasUNOA
{
    public partial class Menu : Form
    {
        public string printer;
        public Menu()
        {
            InitializeComponent();
            ConfigFile cf = new ConfigFile();
            this.printer = cf.printer;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Caja c = new Caja();
            c.ShowDialog(this);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ventasDelDíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentasDiarias vd = new VentasDiarias();
            vd.ShowDialog();
        }

        private void ventasTotalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentasTotales vt = new VentasTotales();
            vt.ShowDialog();
        }

        private void imprimirUltimaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            Print pr = new Print();
            pr.printer = this.printer;
            List<Venta> venta = new List<Venta>(); 
            venta = db.consulta_ultimo_registro();
            pr.imprimir_ultimo(venta[0].idVenta,venta[0].fecha,venta[0].valor);
            
        }
    }
}
