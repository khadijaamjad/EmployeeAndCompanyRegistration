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
    public partial class EmpReg : Form
    {
        public EmpReg()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            XmlTextWriter XMLWrite = new XmlTextWriter("empreg.xml", System.Text.Encoding.UTF8);

            XMLWrite.WriteStartDocument();
            XMLWrite.WriteStartElement("EmployeeInfo");
            XMLWrite.WriteStartElement("Employee");
            XMLWrite.WriteElementString("FirstName", tbName.Text);
            XMLWrite.WriteElementString("LastName", tbLname.Text);
            XMLWrite.WriteElementString("EmployeeId", tbEmpid.Text);
            XMLWrite.WriteElementString("Dept", tbDept.Text);
            XMLWrite.WriteEndElement();
            XMLWrite.WriteEndElement();
            XMLWrite.WriteEndDocument();

            XMLWrite.Flush();
            XMLWrite.Close();
            MessageBox.Show("Employee information saved");
            tbName.Text = "";
            tbLname.Text = "";
            tbDept.Text = "";
            tbEmpid.Text = "";

        }

        private void Viewbtn_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            label7.Visible = true;
            string fn = "empreg.xml";
            XmlTextReader xr = new XmlTextReader(fn);
            while (xr.Read())
            {
                if (xr.LocalName.Equals("FirstName"))
                    label7.Text += "Name:" + xr.ReadString() + " ";
                if (xr.LocalName.Equals("LastName"))
                    label7.Text += xr.ReadString() + "\n ";
                if (xr.LocalName.Equals("EmployeeId"))
                    label7.Text += "EmployeeID:" + xr.ReadString() + "\n ";
                if (xr.LocalName.Equals("Dept"))
                    label7.Text += "Department:" + xr.ReadString() + "\n ";
            }

        }

        private void EmpReg_Load(object sender, EventArgs e)
        {
            label7.Visible = false;
            label6.Visible = false;
        }
    }
}
