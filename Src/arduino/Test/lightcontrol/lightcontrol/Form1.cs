using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace lightcontrol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (port == null)
            {
                port = new SerialPort("COM5", 9600);//Set your board COM
                port.Open();
            }
        }
        SerialPort port;
        private void button1_Click(object sender, EventArgs e)
        {
            PortWrite("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PortWrite("0");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (port != null && port.IsOpen)
            {
                port.Close();
            }
        }
        private void PortWrite(string message)
        {
            port.Write(message);
        }
    }
}
