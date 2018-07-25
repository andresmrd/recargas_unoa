using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentasUNOA
{
    class Venta
    {
        public int idVenta;
        public DateTime fecha;
        public char medioPago;
        public double valor;

        public Venta(int id, DateTime fecha, char medioP, double valor)
        {
            this.idVenta = id;
            this.fecha = fecha;
            this.medioPago = medioP;
            this.valor = valor;
        }
    }
}
