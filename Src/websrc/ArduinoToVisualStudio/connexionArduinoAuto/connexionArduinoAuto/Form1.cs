using System;
using System.Management;
using System.Collections.Generic;
using System.IO.Ports;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private String Rx;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnON_OFF_Click(object sender, EventArgs e)
        {
            if (btnON_OFF.Text == "ON")
            {
                serialPort1.Write("ON\n");
            }
            else
            {
                serialPort1.Write("OFF\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string arduinoLine="";
            string arduPort="";
            int arduinoItem = -1;
            using (var searcher = new ManagementObjectSearcher
                ("SELECT * FROM WIN32_SerialPort"))
            {
                string[] portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList();
                var tList = (from n in portnames
                             join p in ports on n equals p["DeviceID"].ToString()
                             select n + " - " + p["Caption"]).ToList();
                
                foreach (string s in tList)
                {
                    comboBox1.Items.Add(s);
                    if (s.Contains("Arduino")) 
                    {
                        arduinoLine = s;
                        arduinoItem = comboBox1.Items.IndexOf(s);
                        arduPort = s.Substring(0,5).Replace(" ",string.Empty);
                    }
                }
                if (arduinoItem > -1)
                {
                    comboBox1.SelectedIndex = arduinoItem;
                    serialPort1.PortName = arduPort;
                    try
                    {
                        serialPort1.Open();
                        toolStripStatusLabel1.Text = "Connecté à " + arduinoLine;
                        comboBox1.Enabled = false;
                        timer1.Enabled = true;
                        serialPort1.Write("STATUS\n");
                    }
                    catch
                    {
                        DialogResult result;
                        result = MessageBox.Show("Impossible d'ouvrir le port " + serialPort1.PortName + " !\n" +
                                                 "Ce port est peut être déja ouvert.\n" +
                                                 "Voulez-vous recommencé ?" 
                                                 , "Erreur !", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (result == DialogResult.Yes) Application.Restart();
                        else Application.Exit();
                    }
                }
                else
                {
                    DialogResult result;
                    result=MessageBox.Show("Pas de carte Arduino détectée !\nConnectez une Arduino maintenant.", "Erreur !", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.OK) Application.Restart();
                    else Application.Exit();
                }
                
            } 
        }

        private void btPort_Click(object sender, EventArgs e)
        {
            if (btPort.Text == "Connecter")
            {
                timer1.Enabled = false;
                serialPort1.Close();
                serialPort1.PortName = comboBox1.SelectedItem.ToString().Substring(0, 5).Replace(" ", string.Empty);
                try
                { 
                    serialPort1.Open();
                    comboBox1.Enabled = false;
                    btPort.Text = "Modifier";
                    toolStripStatusLabel1.Text = "Connecté à " + comboBox1.SelectedItem.ToString();
                    timer1.Enabled = true;
                    serialPort1.Write("STATUS\n");
                }
                catch
                {
                    DialogResult result;
                    result = MessageBox.Show("Impossible d'ouvrir le port " + serialPort1.PortName + " !\n" +
                                                 "Ce port est peut être déja ouvert.\n" +
                                                 "Voulez-vous recommencé ?"
                                                 , "Erreur !", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (result == DialogResult.Yes) Application.Restart();
                    else Application.Exit();
                }
            }
            else if (comboBox1.Enabled)
            {
                comboBox1.Enabled = false;
                btPort.Text = "Modifier";
            }
            else
            {
                comboBox1.Enabled = true;
                btPort.Text = "Connecter";
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Rx = serialPort1.ReadTo("\r\n");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Rx == "ON")
            {
                pictureBox1.Image = WindowsFormsApplication1.Properties.Resources.red_led_on;
                btnON_OFF.Text = "OFF";
            }

            if (Rx == "OFF")
            {
                pictureBox1.Image = WindowsFormsApplication1.Properties.Resources.red_led_off;
                btnON_OFF.Text = "ON";
            }
        }


    }
}
