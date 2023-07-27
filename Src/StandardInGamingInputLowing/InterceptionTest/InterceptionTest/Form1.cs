using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
namespace InterceptionTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Input input = new Input();
        private void Form1_Load(object sender, EventArgs e)
        {
            input.KeyboardFilterMode = KeyboardFilterMode.All;
            input.MouseFilterMode = MouseFilterMode.All;
            input.Load(); 
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            input.Unload();
        }
    }
}
