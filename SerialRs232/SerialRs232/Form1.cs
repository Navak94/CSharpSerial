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

namespace SerialRs232
{
    public partial class Form1 : Form
    {
        SerialPort port;

        public Form1()
        {
            InitializeComponent();
            getPortNames();
            button2.Enabled = false;
        }

         void getPortNames()
        {
            String[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
        }
        private void init()
        {
            
            try
            {

                port = new SerialPort();
                port.PortName = comboBox1.Text;
                port.BaudRate = int.Parse(comboBox2.SelectedItem.ToString());
                port.Open();
                button1.Enabled = false;
                button2.Enabled = true;

            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                init();
            
            }
            catch
            {
                MessageBox.Show("set a baud rate");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (port.IsOpen)
                {
                    port.WriteLine(comboBox3.Text);
                    String readLines = port.ReadLine();
                    byte[] ba = Encoding.Default.GetBytes(readLines);
                    var hexString = BitConverter.ToString(ba);
                    hexString = hexString.Replace("-", "");
                    richTextBox1.Text = "Ascii:" + readLines + "HEX:" + hexString;
                }
                else
                {
                    MessageBox.Show("com not connected");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}
