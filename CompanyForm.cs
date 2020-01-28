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
    public partial class CompanyForm : Form
    {
        public CompanyForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            XmlTextWriter XMLWrite = new XmlTextWriter("Compreg.xml", System.Text.Encoding.UTF8);

            XMLWrite.WriteStartDocument();
            XMLWrite.WriteStartElement("CompanyInfo");
            XMLWrite.WriteStartElement("Company");
            XMLWrite.WriteElementString("Name", tbName.Text);
            XMLWrite.WriteElementString("Representative", tbRep.Text);
            XMLWrite.WriteElementString("Field", tbField.Text);
            XMLWrite.WriteElementString("Branches", tbBranches.Text);
            XMLWrite.WriteEndElement();
            XMLWrite.WriteEndElement();
            XMLWrite.WriteEndDocument();

            XMLWrite.Flush();
            XMLWrite.Close();
            MessageBox.Show("Company information saved");
            tbName.Text = "";
            tbRep.Text = "";
            tbField.Text = "";
            tbBranches.Text = "";

        }

        private void Viewbtn_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            label7.Visible = true;
            string fn = "Compreg.xml";
            XmlTextReader xr = new XmlTextReader(fn);
            while (xr.Read())
            {
                if (xr.LocalName.Equals("Name"))
                    label7.Text += "Name:" + xr.ReadString() + "\n";
                if (xr.LocalName.Equals("Representative"))
                    label7.Text += "Represented by:"+ xr.ReadString() + "\n ";
                if (xr.LocalName.Equals("Field"))
                    label7.Text += "Field:" + xr.ReadString() + "\n ";
                if (xr.LocalName.Equals("Branches"))
                    label7.Text += "No of Branches:" + xr.ReadString() + "\n ";
            }
        }
    }
}
