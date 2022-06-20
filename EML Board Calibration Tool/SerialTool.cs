using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace EML_Board_Calibration_Tool
{
	public class SerialTool
	{
		public TextBox textbox = null;

		public static TextBox textbox2 = null;

		public SerialPort serialPort = null;

		public int bufferSize = 16;

		public int readWait = 500;

		public byte[] EML_Read_Buffer = null;

		public static string[] GetLocalPorts()
		{
			return SerialPort.GetPortNames();
		}

		public bool OPEN(string portName, int baudRate)
		{
			try
			{
				serialPort = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
				serialPort.ReadTimeout = 5000;
				serialPort.ReadBufferSize = bufferSize;
				serialPort.WriteBufferSize = bufferSize;
				serialPort.Open();
				serialPort.DataReceived += SerialPort_DataReceived;
			}
			catch (Exception serialException)
			{
				Console.WriteLine(serialException.Message);
				return false;
			}
			return true;
		}

		private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			try
			{
				byte[] buffer = new byte[bufferSize];
				Thread.Sleep(readWait);
				int len = ((SerialPort)sender).Read(buffer, 0, bufferSize);
				textbox.BeginInvoke((Action)delegate
				{
					textbox.AppendText(serialPort.PortName + " Read: ");
					for (int i = 0; i < len; i++)
					{
						textbox.AppendText(buffer[i].ToString("X2") + " ");
					}
					textbox.AppendText(Environment.NewLine);
					
					if (textbox.Name.Equals("EML_LOG"))
					{
						EML_Read_Buffer = buffer;
					}
					
					textbox.AppendText(Environment.NewLine);
				});
			}
			catch
			{
			}
		}

		public float DFB_ICC_K, DFB_ICC_B, DFB_MPD_K, DFB_MPD_B, DFB_ICC_Spec_K, DFB_ICC_Spec_B, DFB_MPD_Spec_K, DFB_MPD_Spec_B;

		public bool Close()
		{
			if (serialPort != null)
			{
				serialPort.Close();
			}
			return true;
		}

		public bool write(byte[] data)
		{
			if (serialPort != null)
			{
				serialPort.Write(data, 0, data.Length);
				textbox.BeginInvoke((Action)delegate
				{
					textbox.AppendText(serialPort.PortName + " Write: ");
					for (int i = 0; i < data.Length; i++)
					{
						textbox.AppendText(data[i].ToString("X2") + " ");
					}
					textbox.AppendText(Environment.NewLine);
				});
			}
			return true;
		}

		public bool write(byte[] data, int sendWait)
		{
			bool b = write(data);
			Thread.Sleep(sendWait);
			return b;
		}

		public bool write(byte[] data, int sendWait, int readWait)
		{
			this.readWait = readWait;
			bool b = write(data);
			Thread.Sleep(sendWait);
			return b;
		}
	}
}
