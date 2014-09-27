using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeReader
{
    public partial class BarcodeReaderFormSample : Form
    {
        public BarcodeReaderFormSample()
        {
            InitializeComponent();
        }

        private void BarcodeReaderFormSample_Load(object sender, EventArgs e)
        {
            ImplementBarCode bc = new ImplementBarCode(this);
            bc.AddSafeControls( textBox1);
            bc.AddSafeControls(textBox2);

            
            //bc.BarcodeReadEvent += bc_BarcodeReadEvent;
            //bc.BarCodeReadStartedEvent += bc_BarCodeReadStartedEvent;
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("a");
        }

        private void button1_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

     
        //private void bc_BarCodeReadStartedEvent()
        //{
        //    dontWriteToTb = true;
        //    Debug.Write("Started");
        //}

        //void bc_BarcodeReadEvent(string message)
        //{
        //    dontWriteToTb = false;
        //    Debug.Write(message);
        //    Debug.Write("Ended");
        //    //  MessageBox.Show(message); MessageBox.Show(message); 
        //}

     
    
    }
}
