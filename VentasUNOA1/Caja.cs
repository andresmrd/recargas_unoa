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
    public partial class Caja : Form
    {
        private Database db;
        public string printer;

        public Caja()
        {
            InitializeComponent();
            this.db = new Database();
            ConfigFile cf = new ConfigFile();
            this.printer = cf.printer;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "1000";
            this.radioButton1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "2000";
            this.radioButton1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "3000";
            this.radioButton1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "5000";
            this.radioButton1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "10000";
            this.radioButton1.Focus();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = textBox3.Text;
        }

        private void Caja_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
            {
                this.textBox1.Text = "1000";
                this.radioButton1.Focus();
            }
            if (e.KeyCode == Keys.D2)
            {
                this.textBox1.Text = "2000";
                this.radioButton1.Focus();
            }
            if (e.KeyCode == Keys.D3)
            {
                this.textBox1.Text = "3000";
                this.radioButton1.Focus();
            }
            if (e.KeyCode == Keys.D4)
            {
                this.textBox1.Text = "5000";
                this.radioButton1.Focus();
            }
            if (e.KeyCode == Keys.D5)
            {
                this.textBox1.Text = "10000";
                this.radioButton1.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void radioButton1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                this.textBox2.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                this.button6.Focus();
            }
        }

        private void radioButton2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                this.button6.Focus();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                this.radioButton1.Focus();
            }
        }

        private void Caja_Load(object sender, EventArgs e)
        {
            this.groupBox3.Focus();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            this.textBox2.BackColor = Color.DeepSkyBlue;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            this.textBox2.BackColor = Color.White;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            this.textBox3.BackColor = Color.DeepSkyBlue;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            this.textBox3.BackColor = Color.White;
        }

        private void radioButton1_Enter(object sender, EventArgs e)
        {
            this.radioButton1.BackColor = Color.DeepSkyBlue;
        }

        private void radioButton1_Leave(object sender, EventArgs e)
        {
            this.radioButton1.BackColor = Color.White;
        }

        private void radioButton2_Enter(object sender, EventArgs e)
        {
            this.radioButton1.BackColor = Color.DeepSkyBlue;
        }

        private void radioButton2_Leave(object sender, EventArgs e)
        {
            this.radioButton1.BackColor = Color.White;
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.DeepSkyBlue;
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

        private void button3_Enter(object sender, EventArgs e)
        {
            this.button3.BackColor = Color.DeepSkyBlue;
        }

        private void button3_Leave(object sender, EventArgs e)
        {
            this.button3.BackColor = Color.LightBlue;
        }
        private void button4_Enter(object sender, EventArgs e)
        {
            this.button4.BackColor = Color.DeepSkyBlue;
        }

        private void button4_Leave(object sender, EventArgs e)
        {
            this.button4.BackColor = Color.LightBlue;
        }
        private void button5_Enter(object sender, EventArgs e)
        {
            this.button5.BackColor = Color.DeepSkyBlue;
        }

        private void button5_Leave(object sender, EventArgs e)
        {
            this.button5.BackColor = Color.LightBlue;
        }

        private void button6_Enter(object sender, EventArgs e)
        {
            this.button6.BackColor = Color.YellowGreen;
        }

        private void button6_Leave(object sender, EventArgs e)
        {
            this.button6.BackColor = Color.Coral;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true && string.IsNullOrWhiteSpace(this.textBox2.Text))
            {
                MessageBox.Show("Digite la cantidad Recibida.");
                this.textBox2.Focus();
            }
            else
            {
                Boolean flag = db.Insert(this.dFecha.Value, 'E', Double.Parse(this.textBox1.Text));
                if (flag == true)
                {
                    Print pr = new Print();
                    pr.textBox1.Text = this.textBox1.Text;
                    double total = 0;
                    double pago = 0;
                    double devol = 0;
                    double.TryParse(this.textBox1.Text, out total);
                    double.TryParse(this.textBox2.Text, out pago);
                    if (pago > 0)
                    {
                        devol = pago - total;
                        pr.textBox2.Text = devol.ToString();
                        pr.textBox2.BackColor = Color.YellowGreen;
                        pr.recibi = this.textBox2.Text;
                        db.consulta_id();
                        pr.mid = db.maxid;
                        pr.printer = this.printer;
                    }
                    else
                    {
                        db.consulta_id();
                        pr.mid = db.maxid;
                        pr.printer = this.printer;
                    }

                    pr.ShowDialog();
                    limpiar_campos();
                    this.button1.Focus();
                }
                else
                {
                    this.Close();
                }
            }   

        }

        private void limpiar_campos()
        {
            this.textBox1.ResetText();
            this.textBox2.ResetText();
            this.textBox3.ResetText();
            this.radioButton1.Checked = true;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            this.textBox2.Enabled = true;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            this.textBox2.Enabled = false;
        }

    }
}
