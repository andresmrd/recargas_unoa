using System;
using System.Windows.Forms;

namespace VentasUNOA
{
    public class CreaTicket
    {
        private string ticket = "";

        private string parte1;

        private string parte2;

        private string impresora;

        private int max;

        private int cort;

        public CreaTicket(string impresora)
        {
            this.impresora = impresora;
        }
        public void LineasGuion()
        {
            this.ticket = "----------------------------------------\n";
            RawPrinterHelper.SendStringToPrinter(this.impresora, this.ticket);
        }

        public void LineasAsterisco()
        {
            this.ticket = "****************************************\n";
            RawPrinterHelper.SendStringToPrinter(this.impresora, this.ticket);
        }

        public void LineasIgual()
        {
            this.ticket = "========================================\n";
            RawPrinterHelper.SendStringToPrinter(this.impresora, this.ticket);
        }

        public void LineasTotales()
        {
            this.ticket = "                             -----------\n";
            RawPrinterHelper.SendStringToPrinter(this.impresora, this.ticket);
        }

        public void EncabezadoVenta()
        {
            this.ticket = "Articulo        Can    P.Unit    Importe\n";
            RawPrinterHelper.SendStringToPrinter(this.impresora, this.ticket);
        }

        public void TextoIzquierda(string par1)
        {
            this.max = par1.Length;
            if (this.max > 40)
            {
                this.cort = this.max - 40;
                this.parte1 = par1.Remove(40, this.cort);
            }
            else
            {
                this.parte1 = par1;
            }
            this.ticket = this.parte1 + "\n";
            RawPrinterHelper.SendStringToPrinter(this.impresora, this.ticket);
        }

        public void TextoDerecha(string par1)
        {
            this.ticket = "";
            this.max = par1.Length;
            if (this.max > 40)
            {
                this.cort = this.max - 40;
                this.parte1 = par1.Remove(40, this.cort);
            }
            else
            {
                this.parte1 = par1;
            }
            this.max = 40 - par1.Length;
            for (int i = 0; i < this.max; i++)
            {
                this.ticket += " ";
            }
            this.ticket = this.ticket + this.parte1 + "\n";
            RawPrinterHelper.SendStringToPrinter(this.impresora, this.ticket);
        }

        public void TextoCentro(string par1)
        {
            this.ticket = "";
            this.max = par1.Length;
            if (this.max > 40)
            {
                this.cort = this.max - 40;
                this.parte1 = par1.Remove(40, this.cort);
            }
            else
            {
                this.parte1 = par1;
            }
            this.max = (40 - this.parte1.Length) / 2;
            for (int i = 0; i < this.max; i++)
            {
                this.ticket += " ";
            }
            this.ticket = this.ticket + this.parte1 + "\n";
            RawPrinterHelper.SendStringToPrinter(this.impresora, this.ticket);
        }

        public void TextoExtremos(string par1, string par2)
        {
            this.max = par1.Length;
            if (this.max > 18)
            {
                this.cort = this.max - 18;
                this.parte1 = par1.Remove(18, this.cort);
            }
            else
            {
                this.parte1 = par1;
            }
            this.ticket = this.parte1;
            this.max = par2.Length;
            if (this.max > 18)
            {
                this.cort = this.max - 18;
                this.parte2 = par2.Remove(18, this.cort);
            }
            else
            {
                this.parte2 = par2;
            }
            this.max = 40 - (this.parte1.Length + this.parte2.Length);
            for (int i = 0; i < this.max; i++)
            {
                this.ticket += " ";
            }
            this.ticket = this.ticket + this.parte2 + "\n";
            RawPrinterHelper.SendStringToPrinter(this.impresora, this.ticket);
        }

        public void AgregaTotales(string par1, double total)
        {
            this.max = par1.Length;
            if (this.max > 25)
            {
                this.cort = this.max - 25;
                this.parte1 = par1.Remove(25, this.cort);
            }
            else
            {
                this.parte1 = par1;
            }
            this.ticket = this.parte1;
            this.parte2 = total.ToString("c");
            this.max = 40 - (this.parte1.Length + this.parte2.Length);
            for (int i = 0; i < this.max; i++)
            {
                this.ticket += " ";
            }
            this.ticket = this.ticket + this.parte2 + "\n";
            RawPrinterHelper.SendStringToPrinter(this.impresora, this.ticket);
        }

        public void AgregaArticulo(string par1, int cant, double precio, double total)
        {
            if (cant.ToString().Length <= 3 && precio.ToString("c").Length <= 10 && total.ToString("c").Length <= 11)
            {
                this.max = par1.Length;
                if (this.max > 16)
                {
                    this.cort = this.max - 16;
                    this.parte1 = par1.Remove(16, this.cort);
                }
                else
                {
                    this.parte1 = par1;
                }
                this.ticket = this.parte1;
                this.max = 3 - cant.ToString().Length + (16 - this.parte1.Length);
                for (int i = 0; i < this.max; i++)
                {
                    this.ticket += " ";
                }
                this.ticket += cant.ToString();
                this.max = 10 - precio.ToString("c").Length;
                for (int j = 0; j < this.max; j++)
                {
                    this.ticket += " ";
                }
                this.ticket += precio.ToString("c");
                this.max = 11 - total.ToString().Length;
                for (int k = 0; k < this.max; k++)
                {
                    this.ticket += " ";
                }
                this.ticket = this.ticket + total.ToString("c") + "\n";
                RawPrinterHelper.SendStringToPrinter(this.impresora, this.ticket);
                return;
            }
            MessageBox.Show("Valores fuera de rango");
            RawPrinterHelper.SendStringToPrinter(this.impresora, "Error, valor fuera de rango\n");
        }

        public void CortaTicket()
        {
            string szString = "\u001bm";
            string szString2 = "\u001bd\t";
            RawPrinterHelper.SendStringToPrinter(this.impresora, szString2);
            RawPrinterHelper.SendStringToPrinter(this.impresora, szString);
        }

        public void AbreCajon()
        {
            string szString = "\u001bp\0\u000f\u0096";
            RawPrinterHelper.SendStringToPrinter(this.impresora, szString);
        }
    }
}
