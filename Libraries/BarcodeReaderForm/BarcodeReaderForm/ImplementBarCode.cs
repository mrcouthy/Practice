using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using RawInput_dll;

namespace BarcodeReader
{
    public class ImplementBarCode
    {
        public delegate void BarCodeReadHandler(string barcode);


        public void AddSafeControls(Control control)
        {
            control.KeyPress += textBox1_KeyPress;
        }

        private bool dontWriteToTb = false;
        void bc_BarcodeReadEvent(string message)
        {
            dontWriteToTb = false;
            Debug.Write(message);
            Debug.Write("Ended");
            //  MessageBox.Show(message); MessageBox.Show(message); 
        }
        public delegate void BarCodeReadStartedHandler();

        private readonly RawInput _rawinput;
        public bool BarCodeStarted;
        private string _barcode = string.Empty;

        public ImplementBarCode(Form form)
        {
            form.KeyPreview = true;
            BarcodeReadEvent += BarcodeRead_Event;
            form.FormClosing += Keyboard_FormClosing;
            _rawinput = new RawInput(form.Handle);
            _rawinput.CaptureOnlyIfTopMostWindow = true; // Otherwise default behavior is to capture always
            _rawinput.AddMessageFilter(); // Adding a message filter will cause keypresses to be handled
            _rawinput.KeyPressed += OnKeyPressed;
            BarCodeReadStartedEvent += bc_BarCodeReadStartedEvent;
            //  Win32.DeviceAudit(); 
        }


        public event BarCodeReadHandler BarcodeReadEvent;
        public event BarCodeReadStartedHandler BarCodeReadStartedEvent;
        private void bc_BarCodeReadStartedEvent()
        {
            dontWriteToTb = true;
            Debug.Write("Started");
        }
        private void BarcodeRead_Event(string barCode)
        {
            dontWriteToTb = false;
            Debug.WriteLine("Barcode is :" + barCode);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = dontWriteToTb;
        }

        private void OnKeyPressed(object sender, InputEventArg e)
        {
            if (e.KeyPressEvent.Name == "HID Keyboard Device")
            {
                if (e.KeyPressEvent.Message == Win32.WM_KEYDOWN)
                {
                    if (BarCodeStarted == false)
                    {
                        BarCodeStarted = true;
                        BarCodeReadStartedEvent();
                    }
                    if (e.KeyPressEvent.VKeyName == "ENTER")
                    {
                        BarCodeStarted = false;
                        BarcodeReadEvent(_barcode);
                        _barcode = string.Empty;
                    }
                    else
                    {
                        _barcode = _barcode + (char)e.KeyPressEvent.VKey;
                    }
                }
            }
        }

        private void Keyboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            _rawinput.KeyPressed -= OnKeyPressed;
        }


    }
}