using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace VP8_XML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            string fan = "emp.xml";
            XmlTextReader axr = new XmlTextReader(fan);
            while (axr.Read())
            {
                if (axr.LocalName.Equals("Username"))
                {
                    if (!axr.ReadString().Equals(tbName.Text))
                        MessageBox.Show("Incorrect Username");
                }

                if (axr.LocalName.Equals("UserId"))
                {
                    if (!axr.ReadString().Equals(tbUserid.Text))
                        MessageBox.Show("Incorrect UserId");
                }
                if (!axr.LocalName.Equals("Password"))
                {
                    if (axr.ReadString().Equals(tbPassword.Text))
                        MessageBox.Show("Incorrect Password");
                }
                else
                    MessageBox.Show("Login Successful");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            XmlTextWriter XMLWrite = new XmlTextWriter("emp.xml", System.Text.Encoding.UTF8);

            XMLWrite.WriteStartDocument();
            XMLWrite.WriteStartElement("EmployeeInfo");
            XMLWrite.WriteStartElement("Employee");
            XMLWrite.WriteElementString("Username", tbName.Text);
            XMLWrite.WriteElementString("UserId", tbUserid.Text);
            XMLWrite.WriteElementString("Password", tbPassword.Text);
            XMLWrite.WriteEndElement();
            XMLWrite.WriteEndElement();
            XMLWrite.WriteEndDocument();

            XMLWrite.Flush();
            XMLWrite.Close();
            tbName.Text = "";
            tbUserid.Text = "";
            tbPassword.Text = "";



        }
    }
}
