/*  TESTES  C#  MROBALINHO
 *  
 *  Sistema de LOGIN
 *  Outubro 2017 - Desenvolvimento Software 
 *  Mestrado de Informática da UPT
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;  // Conecção para BD SQL

namespace WindowsLogIN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();  // Inicialização de componentes
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Confirmação para saida
            if (MessageBox.Show("Do you want to exit?", "LogIn Windows",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                  == DialogResult.Yes) { 
                this.Close();  // Fecha a aplicação
             }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Conecção - abertura BD
            SqlConnection  con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\MANUEL.ROBALINHO\DOCUMENTS\DATA.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");  // Conecção SQL
            // Select à tabela LOGIN                                                                                                                                                                                                                                                                                         // Conecção - abertura BD
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) from LOGIN where Username = '" + textBox1.Text + "' and Password ='" + textBox2.Text + "'", con);
            //
            DataTable dt = new DataTable();
            sda.Fill(dt);  // Obter dados de login

            if (dt.Rows[0][0].ToString() == "1")  // Verdadeiro
            {

                this.Hide();    // Esconde janela atual para abrir novo form
                Main ss = new Main();
                ss.Show();     // Abre segundo form
            }
            else
            {
                MessageBox.Show("Verifique o User e Password");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
