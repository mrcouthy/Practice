using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            bc.BarcodeReadEvent += bc_BarcodeReadEvent;
        }

        void bc_BarcodeReadEvent(string message)
        {
            
            MessageBox.Show(message); MessageBox.Show(message); 
        }
    }
}
