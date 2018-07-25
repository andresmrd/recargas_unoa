using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibPrintTicket;

namespace VentasUNOA
{
    public partial class Print : Form
    {
        public string recibi;
        public int mid;
        public string printer;

        public Print()
        {
            InitializeComponent();
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.YellowGreen;
        }

        private void button1_Leave(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.LightBlue;
        }

        private void button2_Enter(object sender, EventArgs e)
        {
            this.button2.BackColor = Color.DeepSkyBlue;
        }

        private void button2_Leave(object sender, EventArgs e)
        {
            this.button2.BackColor = Color.LightBlue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreaTicket creaTicket = new CreaTicket(this.printer);//crea impresora para abrir cajón
            creaTicket.AbreCajon();
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox2.Text == "")
            {
                this.textBox2.BackColor = Color.LightBlue;
            }
		         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();
            
            ticket.AddHeaderLine("FACTURA DE VENTA");

            ticket.AddSubHeaderLine("Ticket # " + this.mid);
            ticket.AddSubHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());

            ticket.AddItem("1", "Total Venta", this.textBox1.Text);

            ticket.AddTotal("TOTAL", this.textBox1.Text);
            ticket.AddTotal("", "");
            ticket.AddTotal("RECIBIDO", this.recibi);
            ticket.AddTotal("CAMBIO", this.textBox2.Text);
            ticket.AddTotal("", "");
            ticket.AddFooterLine("VUELVA PRONTO");

            ticket.PrintTicket(this.printer); //Nombre de la impresora de tickets
            CreaTicket creaTicket = new CreaTicket(this.printer);//crea impresora para abrir cajón
            creaTicket.AbreCajon();

            this.textBox1.ResetText();
            this.recibi = "";
            this.textBox2.ResetText();
            this.button2.Focus();
            this.Close();

        }

        public void imprimir_ultimo(int id, DateTime fecha, double valor)
        {
            Ticket ticket = new Ticket();

            ticket.AddHeaderLine("COPIA FACTURA DE VENTA");

            ticket.AddSubHeaderLine("Ticket # " + id);
            ticket.AddSubHeaderLine(fecha.ToShortDateString() + " " + fecha.ToLongTimeString());

            ticket.AddItem("1", "Total Venta", valor.ToString());

            ticket.AddTotal("TOTAL", valor.ToString());
            ticket.AddTotal("", "");
            ticket.AddTotal("RECIBIDO", "0");
            ticket.AddTotal("CAMBIO", "0");
            ticket.AddTotal("", "");
            ticket.AddFooterLine("VUELVA PRONTO");

            ticket.PrintTicket(this.printer); //Nombre de la impresora de tickets
            CreaTicket creaTicket = new CreaTicket(this.printer);//crea impresora para abrir cajón
        }

        private void Print_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CreaTicket creaTicket = new CreaTicket(this.printer);//crea impresora para abrir cajón
                creaTicket.AbreCajon();
                this.Close();
            }
        }

        public void imprimir_ventas_dia(double valor)
        {
            Ticket ticket = new Ticket();

            ticket.AddHeaderLine("REPORTE");

            ticket.AddSubHeaderLine("CORTE DEL DIA");
            ticket.AddSubHeaderLine(DateTime.Now.ToShortDateString()+ " " + DateTime.Now.ToShortTimeString());

            ticket.AddItem("1", "TOTAL VENTAS", valor.ToString());

            ticket.PrintTicket(this.printer); //Nombre de la impresora de tickets
            CreaTicket creaTicket = new CreaTicket(this.printer);//crea impresora para abrir cajón
        }

    }
}
