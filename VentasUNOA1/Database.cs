using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Configuration;



namespace VentasUNOA
{
    class Database
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public int maxid;

        public Database()
        {
            read_file();
            Initialize();
        }
        private void Initialize()
        {
            connection = new MySqlConnection("server=" + this.server + "; database=" + this.database + "; Uid=" + this.uid + "; pwd=" + this.password + ";");
        }
        private void read_file()
        {
            ConfigFile cf = new ConfigFile();
            this.server = cf.Server;
            this.database = cf.DataBase;
            this.uid = cf.user;
            this.password = cf.password;
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    case 1042:
                        MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public bool Insert(DateTime fecha, char formaPago, double valorRecarga)
        {

            string query = "INSERT INTO REGISTROS (fecha, formaPago, valorRecarga) VALUES(@fecha,@formaPago,@valorRecarga)";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@formaPago", formaPago);
                cmd.Parameters.AddWithValue("@valorRecarga", valorRecarga);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
                return true;
            }
            else
            {
                return false;
            }
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public List<Venta> consulta_ultimo_registro()
        {
            consulta_id();
            string query = "SELECT * FROM REGISTROS WHERE idRegistro ="+this.maxid;
            int id;
            DateTime fecha;
            char medioPago;
            double valor;
            List<Venta> ventas = new List<Venta>();

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    fecha = DateTime.Parse(reader.GetString(1));
                    medioPago = char.Parse(reader.GetString(2));
                    valor = double.Parse(reader.GetString(3));

                    Venta v = new Venta(id, fecha, medioPago, valor);

                    ventas.Add(v);

                }
                //close connection
                this.CloseConnection();
            }
            return ventas;

        }

        //consulta último id guardado
        public void consulta_id()
        {

            string query = "SELECT MAX(idRegistro) FROM REGISTROS";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    this.maxid = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    
                }


                //close connection
                this.CloseConnection();

            }
        }

        //Consulta de Registros Diarios
        public List<Venta> consulta_dia(String datetime)
        {
            //Date fecha = ifecha.Date.ToShortDateString();
            string query = "SELECT * FROM REGISTROS WHERE Date(fecha) = '" + datetime + "'";


            int id;
            DateTime fecha;
            char medioPago;
            double valor;
            List<Venta> ventas = new List<Venta>();

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    fecha = DateTime.Parse(reader.GetString(1));
                    medioPago = char.Parse(reader.GetString(2));
                    valor = double.Parse(reader.GetString(3));

                    Venta v = new Venta(id, fecha, medioPago, valor);
                    Console.Write(v);
                    ventas.Add(v);

                }
                //close connection
                this.CloseConnection();
            }
            return ventas;
        }

        //Consulta de Registros Totales
        public List<Venta> consulta_total(String fechaIni, String fechaFin)
        {
            //Date fecha = ifecha.Date.ToShortDateString();
            string query = "SELECT * FROM REGISTROS WHERE Date(fecha) BETWEEN '" + fechaIni + "' AND  '" + fechaFin + "'";


            int id;
            DateTime fecha;
            char medioPago;
            double valor;
            List<Venta> ventas = new List<Venta>();

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    fecha = DateTime.Parse(reader.GetString(1));
                    medioPago = char.Parse(reader.GetString(2));
                    valor = double.Parse(reader.GetString(3));

                    Venta v = new Venta(id, fecha, medioPago, valor);

                    ventas.Add(v);

                }
                //close connection
                this.CloseConnection();
            }
            return ventas;
        }
    }
}
