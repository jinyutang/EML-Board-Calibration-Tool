using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EML_Board_Calibration_Tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

		SerialTool EML_Back_SerialTool = new SerialTool();
		SerialTool EML_Switch_SerialTool = new SerialTool();

		private void button45_Click(object sender, EventArgs e)
        {
			if (button45.Text.Equals("Select ALL"))
			{
				for (int i = 0; i < 8; i++)
				{
					checkedListBox7.SetItemChecked(i, true);
				}
				button45.Text = "Deselect ALL";
			}
			else
			{
				for (int i = 0; i < 8; i++)
				{
					checkedListBox7.SetItemChecked(i, false);
				}
				button45.Text = "Select ALL";
			}
		}

        private void button44_Click(object sender, EventArgs e)
        {
			if (button44.Text.Equals("Select ALL"))
			{
				for (int i = 0; i < 48; i++)
				{
					checkedListBox6.SetItemChecked(i, true);
				}
				button44.Text = "Deselect ALL";
			}
			else
			{
				for (int i = 0; i < 48; i++)
				{
					checkedListBox6.SetItemChecked(i, false);
				}
				button44.Text = "Select ALL";
			}
		}

        private void button46_Click(object sender, EventArgs e)
        {
			if (button46.Text.Equals("OPEN"))
			{
				EML_Back_SerialTool.bufferSize = 16;
				EML_Back_SerialTool.textbox = EML_LOG;
				if (comboBox17.Text.Length > 0 && EML_Back_SerialTool.OPEN(comboBox17.Text, int.Parse(comboBox18.Text)))
				{
					button46.Text = "CLOSE";
				}
				else
				{
					MessageBox.Show("Open Serial Failed!");
				}
			}
			else
			{
				button46.Text = "OPEN";
				EML_Back_SerialTool.Close();
			}
		}

        private void button47_Click(object sender, EventArgs e)
        {
			if (button47.Text.Equals("OPEN"))
			{
				EML_Switch_SerialTool.bufferSize = 16;
				EML_Switch_SerialTool.textbox = EML_LOG;
				if (comboBox20.Text.Length > 0 && EML_Switch_SerialTool.OPEN(comboBox20.Text, int.Parse(comboBox21.Text)))
				{
					button47.Text = "CLOSE";
				}
				else
				{
					MessageBox.Show("Open Serial Failed!");
				}
			}
			else
			{
				button47.Text = "OPEN";
				EML_Switch_SerialTool.Close();
			}
		}

        private void button48_Click(object sender, EventArgs e)
        {
			if (button46.Text.Equals("OPEN"))
			{
				EML_LOG.Text = "Error! SerialPort closed! ";
				return;
			}

			EML_LOG.Text = "";
			EML_Back_SerialTool.textbox = EML_LOG;

			foreach (string si in checkedListBox7.CheckedItems)
			{
				int boardIndex = Int32.Parse(si);
				if (48 == checkedListBox6.CheckedItems.Count)
				{
					EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0x81, 0xFF, 0x00, 0x00 }));
					Thread.Sleep(1000);
				}
				else
				{
					foreach (string chn in checkedListBox6.CheckedItems)
					{
						int channel = Int32.Parse(chn) - 1;
						EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0x81, (byte)channel, 0x00, 0x00 }));
						Thread.Sleep(1000);
					}
				}
			}
		}

		private static byte[] commandHT_EML(byte[] data)
		{
			byte[] array = new byte[data.Length + 4];
			Array.Copy(data, 0, array, 2, 5);
			array[0] = 170;
			array[1] = 85;
			array[7] = 85;
			array[8] = 170;
			return array;
		}

        private void button49_Click(object sender, EventArgs e)
        {
			if (button46.Text.Equals("OPEN"))
			{
				EML_LOG.Text = "Error! SerialPort closed! ";
				return;
			}

			EML_LOG.Text = "";
			EML_Back_SerialTool.textbox = EML_LOG;

			foreach (string si in checkedListBox7.CheckedItems)
			{
				int boardIndex = Int32.Parse(si);
				if (48 == checkedListBox6.CheckedItems.Count)
				{
					EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0x80, 0xFF, 0x00, 0x00 }));
					Thread.Sleep(1000);
				}
				else
				{
					foreach (string chn in checkedListBox6.CheckedItems)
					{
						int channel = Int32.Parse(chn) - 1;
						EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0x80, (byte)channel, 0x00, 0x00 }));
						Thread.Sleep(1000);
					}
				}
			}
		}

        private void button50_Click(object sender, EventArgs e)
        {
			if (button46.Text.Equals("OPEN"))
			{
				EML_LOG.Text = "Error! SerialPort closed! ";
				return;
			}

			EML_LOG.Text = "";
			EML_Back_SerialTool.textbox = EML_LOG;

			foreach (string si in checkedListBox7.CheckedItems)
			{
				int boardIndex = Int32.Parse(si);
				if (48 == checkedListBox6.CheckedItems.Count)
				{
					EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0x82, 0xFF, 0x00, 0x00 }));
					Thread.Sleep(1000);
				}
				else
				{
					foreach (string chn in checkedListBox6.CheckedItems)
					{
						int channel = Int32.Parse(chn) - 1;
						EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0x82, (byte)channel, 0x00, 0x00 }));
						Thread.Sleep(1000);
					}
				}
			}
		}

        private void button51_Click(object sender, EventArgs e)
        {
			if (button46.Text.Equals("OPEN"))
			{
				EML_LOG.Text = "Error! SerialPort closed! ";
				return;
			}

			EML_LOG.Text = "";
			EML_Back_SerialTool.textbox = EML_LOG;

			foreach (string si in checkedListBox7.CheckedItems)
			{
				int boardIndex = Int32.Parse(si);
				if (48 == checkedListBox6.CheckedItems.Count)
				{
					EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0x83, 0xFF, 0x00, 0x00 }));
					Thread.Sleep(1000);
				}
				else
				{
					foreach (string chn in checkedListBox6.CheckedItems)
					{
						int channel = Int32.Parse(chn) - 1;
						EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0x83, (byte)channel, 0x00, 0x00 }));
						Thread.Sleep(1000);
					}
				}
			}
		}

        private void button52_Click(object sender, EventArgs e)
        {
			if (button46.Text.Equals("OPEN"))
			{
				EML_LOG.Text = "Error! SerialPort closed! ";
				return;
			}

			EML_LOG.Text = "";
			EML_Back_SerialTool.textbox = EML_LOG;

			foreach (string si in checkedListBox7.CheckedItems)
			{
				int boardIndex = Int32.Parse(si);
				foreach (string chn in checkedListBox6.CheckedItems)
				{
					int channel = Int32.Parse(chn) - 1;
					EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0xA1, (byte)channel, 0x00, 0x00 }));
					Thread.Sleep(1000);
				}
			}
		}

        private void button53_Click(object sender, EventArgs e)
        {
			if (button46.Text.Equals("OPEN"))
			{
				EML_LOG.Text = "Error! SerialPort closed! ";
				return;
			}

			EML_LOG.Text = "";
			EML_Back_SerialTool.textbox = EML_LOG;

			foreach (string si in checkedListBox7.CheckedItems)
			{
				int boardIndex = Int32.Parse(si);
				foreach (string chn in checkedListBox6.CheckedItems)
				{
					int channel = Int32.Parse(chn) - 1;
					EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0xA0, (byte)channel, 0x00, 0x00 }));
					Thread.Sleep(1000);
				}
			}
		}

        private void button54_Click(object sender, EventArgs e)
        {
			if (button46.Text.Equals("OPEN"))
			{
				EML_LOG.Text = "Error! SerialPort closed! ";
				return;
			}

			EML_LOG.Text = "";
			EML_Back_SerialTool.textbox = EML_LOG;
			int v = 0;
			if (!int.TryParse(textBox21.Text, out v))
            {
				MessageBox.Show("Please input an integaer.");
				return;
            }
				
			int value = v + 8192;
			byte valueHigh = (byte)((value & 0xFF00) >> 8);
			byte valueLow = (byte)((value & 0xFF));

			foreach (string si in checkedListBox7.CheckedItems)
			{
				int boardIndex = Int32.Parse(si);
				if (48 == checkedListBox6.CheckedItems.Count)
				{
					EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0xD0, 0xFF, valueHigh, valueLow }));
					Thread.Sleep(50000);
				}
				else
				{
					foreach (string chn in checkedListBox6.CheckedItems)
					{
						int channel = Int32.Parse(chn) - 1;
						EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0xD0, (byte)channel, valueHigh, valueLow }));
						Thread.Sleep(1000);
					}
				}
			}
		}

        private void button55_Click(object sender, EventArgs e)
        {
			if (button46.Text.Equals("OPEN"))
			{
				EML_LOG.Text = "Error! SerialPort closed! ";
				return;
			}

			EML_LOG.Text = "";
			EML_Back_SerialTool.textbox = EML_LOG;
			float v = 0;
			if (!float.TryParse(textBox22.Text, out v))
			{
				MessageBox.Show("Please input a float.");
				return;
			}
			int value = (int)(v * 10000);
			byte valueHigh = (byte)((value & 0xFF00) >> 8);
			byte valueLow = (byte)((value & 0xFF));

			foreach (string si in checkedListBox7.CheckedItems)
			{
				int boardIndex = Int32.Parse(si);
				if (48 == checkedListBox6.CheckedItems.Count)
				{
					EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0xF1, 0xFF, valueHigh, valueLow }));
					Thread.Sleep(1000);
				}
				else
				{
					foreach (string chn in checkedListBox6.CheckedItems)
					{
						int channel = Int32.Parse(chn) - 1;
						EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0xF1, (byte)channel, valueHigh, valueLow }));
						Thread.Sleep(1000);
					}
				}
			}
		}

        private void button56_Click(object sender, EventArgs e)
        {
			if (button46.Text.Equals("OPEN"))
			{
				EML_LOG.Text = "Error! SerialPort closed! ";
				return;
			}

			EML_LOG.Text = "";
			EML_Back_SerialTool.textbox = EML_LOG;

			float v = 0;
			if (!float.TryParse(textBox23.Text, out v))
			{
				MessageBox.Show("Please input a float.");
				return;
			}

			int value = (int)(v * 100 + 32767);
			byte valueHigh = (byte)((value & 0x00FF00) >> 8);
			byte valueLow = (byte)((value & 0xFF));

			foreach (string si in checkedListBox7.CheckedItems)
			{
				int boardIndex = Int32.Parse(si);
				if (48 == checkedListBox6.CheckedItems.Count)
				{
					EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0xF2, 0xFF, valueHigh, valueLow }));
					Thread.Sleep(1000);
				}
				else
				{
					foreach (string chn in checkedListBox6.CheckedItems)
					{
						int channel = Int32.Parse(chn) - 1;
						EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0xF2, (byte)channel, valueHigh, valueLow }));
						Thread.Sleep(1000);
					}
				}
			}
		}

        private void button59_Click(object sender, EventArgs e)
        {
			if (button46.Text.Equals("OPEN"))
			{
				EML_LOG.Text = "Error! SerialPort closed! ";
				return;
			}

			EML_LOG.Text = "";
			EML_Back_SerialTool.textbox = EML_LOG;

			int v = 0;
			if (!int.TryParse(textBox26.Text, out v))
			{
				MessageBox.Show("Please input an integaer.");
				return;
			}

			int value = (v * 16 + 8192);
			byte valueHigh = (byte)((value & 0xFF00) >> 8);
			byte valueLow = (byte)((value & 0xFF));

			foreach (string si in checkedListBox7.CheckedItems)
			{
				int boardIndex = Int32.Parse(si);
				if (48 == checkedListBox6.CheckedItems.Count)
				{
					EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0xD0, 0xFF, valueHigh, valueLow }));
					Thread.Sleep(1000);
				}
				else
				{
					foreach (string chn in checkedListBox6.CheckedItems)
					{
						int channel = Int32.Parse(chn) - 1;
						EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0xD0, (byte)channel, valueHigh, valueLow }));
						Thread.Sleep(1000);
					}
				}
			}
		}

        private void button58_Click(object sender, EventArgs e)
        {
			if (button46.Text.Equals("OPEN"))
			{
				EML_LOG.Text = "Error! SerialPort closed! ";
				return;
			}

			EML_LOG.Text = "";
			EML_Back_SerialTool.textbox = EML_LOG;

			float v = 0;
			if (!float.TryParse(textBox25.Text, out v))
			{
				MessageBox.Show("Please input a float.");
				return;
			}

			int value = (int)(v * 10000);
			byte valueHigh = (byte)((value & 0xFF00) >> 8);
			byte valueLow = (byte)((value & 0xFF));

			foreach (string si in checkedListBox7.CheckedItems)
			{
				int boardIndex = Int32.Parse(si);
				if (48 == checkedListBox6.CheckedItems.Count)
				{
					EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0xF3, 0xFF, valueHigh, valueLow }));
					Thread.Sleep(1000);
				}
				else
				{
					foreach (string chn in checkedListBox6.CheckedItems)
					{
						int channel = Int32.Parse(chn) - 1;
						EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0xF3, (byte)channel, valueHigh, valueLow }));
						Thread.Sleep(1000);
					}
				}
			}
		}

        private void button57_Click(object sender, EventArgs e)
        {
			if (button46.Text.Equals("OPEN"))
			{
				EML_LOG.Text = "Error! SerialPort closed! ";
				return;
			}

			EML_LOG.Text = "";
			EML_Back_SerialTool.textbox = EML_LOG;

			float v = 0;
			if (!float.TryParse(textBox24.Text, out v))
			{
				MessageBox.Show("Please input a float.");
				return;
			}

			int value = (int)(v * 100 + 32767);
			byte valueHigh = (byte)((value & 0xFF00) >> 8);
			byte valueLow = (byte)((value & 0xFF));

			foreach (string si in checkedListBox7.CheckedItems)
			{
				int boardIndex = Int32.Parse(si);
				if (48 == checkedListBox6.CheckedItems.Count)
				{
					EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0xF4, 0xFF, valueHigh, valueLow }));
					Thread.Sleep(1000);
				}
				else
				{
					foreach (string chn in checkedListBox6.CheckedItems)
					{
						int channel = Int32.Parse(chn) - 1;
						EML_Back_SerialTool.write(commandHT_EML(new byte[] { (byte)boardIndex, 0xF4, (byte)channel, valueHigh, valueLow }));
						Thread.Sleep(1000);
					}
				}
			}
		}

        private void button61_Click(object sender, EventArgs e)
        {
			foreach (string boardIndex in checkedListBox7.CheckedItems)
				foreach (string channel in checkedListBox6.CheckedItems)
				{
					EML_Switch_SerialTool.write(commandHT_EML(new byte[] { (byte)(((byte.Parse(boardIndex) - 1) % 2 * 48) + byte.Parse(channel)), 0xA0, 0x00, 0x01, 0x00 }));
					Thread.Sleep(1000);
				}
		}

        private void button62_Click(object sender, EventArgs e)
        {
			foreach (string boardIndex in checkedListBox7.CheckedItems)
				foreach (string channel in checkedListBox6.CheckedItems)
				{
					EML_Switch_SerialTool.write(commandHT_EML(new byte[] { (byte)(((byte.Parse(boardIndex) - 1) % 2 * 48) + byte.Parse(channel)), 0xA0, 0x00, 0x00, 0x00 }));
					Thread.Sleep(1000);
				}
		}

        private void button64_Click(object sender, EventArgs e)
        {
			//Swithc板选择工作模式，此处电流模式
			EML_Switch_SerialTool.write(commandHT_EML(new byte[] { 0x61, 0xA0, 0x00, 0x01, 0x00 }));
		}

        private void button63_Click(object sender, EventArgs e)
        {
			//Swithc板选择工作模式，此处电压模式
			EML_Switch_SerialTool.write(commandHT_EML(new byte[] { 0x61, 0xA0, 0x00, 0x00, 0x00 }));
		}

		List<string> EML_Check_Votage_Current = new List<string>();

		string[] EML_VotageCheckPoints;
		string[] EML_CurrentCheckPoints;

		public SerialTool serialTool = new SerialTool();
		string EML_Voltage_GPIP_Address = "";
		string EML_Current_GPIP_Address = "";
		string EML_Floor = "";
		IList EMLboardIndexs;
		IList EMLchannels;
		IList EMLtestTypes;
		string[] EML_VotageTestPoints;
		string[] EML_CurrentTestPoints;
		Task EMLtask;
		const int GPIB_READ_TIMES = 10;
		const int GPIB_SLEEP_TIME = 3000;
		const int EML_TEST_REPEAT_TIMES = 5;
		CancellationTokenSource EMLtasktokenSource = new CancellationTokenSource();//创建取消task实例

		private void button60_Click(object sender, EventArgs e)
        {
			markTime();
			if (button46.Text.Equals("OPEN") || button47.Text.Equals("OPEN") || textBox35.Text.Equals(""))
			{
				MessageBox.Show("Please open relayboad and layer's serial port.");
				return;
			}

			if (button60.Text.Equals("Start"))
			{
				EML_LOG.Text = "";
				EML_Floor = textBox35.Text;

				EML_Voltage_GPIP_Address = "GPIB0::" + textBox29.Text + "::INSTR";
				EML_Current_GPIP_Address = "GPIB0::" + textBox30.Text + "::INSTR";
				EMLboardIndexs = checkedListBox7.CheckedItems;
				EMLchannels = checkedListBox6.CheckedItems;
				EMLtestTypes = checkedListBox8.CheckedItems;
				EML_VotageTestPoints = textBox27.Text.Split(',');
				EML_CurrentTestPoints = textBox28.Text.Split(',');

				EMLtasktokenSource = new CancellationTokenSource();
				EMLtask = new Task(() =>
				{
					DoEMLAutoCalibration(serialTool);
				}, EMLtasktokenSource.Token);

				EMLtasktokenSource.Token.Register(() => {
					Console.WriteLine("task is to cancel");
					button60.Text = "Start";
				});
				EMLtask.Start();
				button60.Text = "Stop";
			}
			else
			{
				if (EMLtask.Status != TaskStatus.RanToCompletion)
				{
					EMLtasktokenSource.Cancel();
				}
				EMLtask = null;

				button60.Text = "Start";
			}
		}

        private void button65_Click(object sender, EventArgs e)
        {
			markTime();
			if (button46.Text.Equals("OPEN") || button47.Text.Equals("OPEN") || textBox35.Text.Equals(""))
			{
				MessageBox.Show("Please open relayboad and layer's serial port.");
				return;
			}

			if (button65.Text.Equals("Start"))
			{
				EML_LOG.Invoke((Action)delegate
				{
					EML_LOG.Clear();
				});
				EML_Floor = textBox35.Text;

				EML_Voltage_GPIP_Address = "GPIB0::" + textBox37.Text + "::INSTR";
				EML_Current_GPIP_Address = "GPIB0::" + textBox36.Text + "::INSTR";
				EMLboardIndexs = checkedListBox7.CheckedItems;
				EMLchannels = checkedListBox6.CheckedItems;
				EMLtestTypes = checkedListBox9.CheckedItems;
				EML_VotageCheckPoints = textBox39.Text.Split(',');
				EML_CurrentCheckPoints = textBox38.Text.Split(',');

				EMLtasktokenSource = new CancellationTokenSource();
				EMLtask = new Task(() =>
				{
					DoEMLAutoCheck(serialTool);
				}, EMLtasktokenSource.Token);

				EMLtasktokenSource.Token.Register(() => {
					Console.WriteLine("Task is to cancel.");
					EML_LOG.Invoke((Action)delegate
					{
						button65.Text = "Start";
					});
				});
				EMLtask.Start();
				EML_LOG.Invoke((Action)delegate
				{
					button65.Text = "Stop";
				});
				
			}
			else
			{
				if (EMLtask.Status != TaskStatus.RanToCompletion)
				{
					EMLtasktokenSource.Cancel();
				}
				EMLtask = null;
				EML_LOG.Invoke((Action)delegate
				{
					button65.Text = "Start";
				});
			}
		}

		/// <summary>
		/// EML自动校验
		/// </summary>
		/// <param name="state"></param>
		private void DoEMLAutoCheck(object state)
		{
			GPIB gPIB_V = new GPIB();
			GPIB gPIB_A = new GPIB();
			try
			{
				gPIB_V.Open(EML_Voltage_GPIP_Address);
				gPIB_A.Open(EML_Current_GPIP_Address);

				//Keithley2401Init(gPIB_V, gPIB_A);

				EML_Check_Votage_Current.Clear();

				foreach (string boardIndex in EMLboardIndexs)
				{
					foreach (string type in EMLtestTypes)
					{

						//电源板和switch板状态初始化
						EMLCalibrationCloseInit(boardIndex);

						//选择继电器板测量模式（电流/电压）
						if (type.Equals("Check Votage"))
						{
							//Switch板选择工作模式，此处电压模式
							EML_LOG.Invoke((Action)delegate
							{
								EML_LOG.AppendText(String.Format("Relay board votage model" + Environment.NewLine));
							});
							EML_Switch_SerialTool.write(commandHT_EML(new byte[] { 0x61, 0xA0, 0x00, 0x00, 0x00 }));
							Thread.Sleep(1000);

							Keithley2401CheckVotage(gPIB_V, gPIB_A);
						}
						else if (type.Equals("Check Current"))
						{
							//Switch板选择工作模式，此处电流模式
							EML_LOG.Invoke((Action)delegate
							{
								EML_LOG.AppendText(String.Format("Relay board currrent model" + Environment.NewLine));
							});
							EML_Switch_SerialTool.write(commandHT_EML(new byte[] { 0x61, 0xA0, 0x00, 0x01, 0x00 }));
							Thread.Sleep(1000);

							Keithley2401CheckCurrent(gPIB_V, gPIB_A);
						}
						else
						{
							MessageBox.Show("Relay board Error！");
							return;
						}


						foreach (string channel in EMLchannels)
						{
							int switchChannel = byte.Parse(channel) + (byte.Parse(boardIndex) + 1) % 2 * 48;
							//Switch板打开当前通道
							EML_LOG.Invoke((Action)delegate
							{
								EML_LOG.AppendText(String.Format("Open Relay board channel {0}。" + Environment.NewLine, byte.Parse(channel)));
							});
							EML_Switch_SerialTool.write(commandHT_EML(new byte[] { (byte)switchChannel, 0xA0, 0x00, 0x01, 0x00 }));
							Thread.Sleep(1000);

							EML_LOG.Invoke((Action)delegate
							{
								EML_LOG.AppendText(String.Format("Start Check，Check Type:{0} Board:{1} Channel:{2}" + Environment.NewLine, type, boardIndex, channel));
							});

							if (EMLtasktokenSource.Token.IsCancellationRequested)
							{
								//终止退出
								//电源板和switch板状态初始化
								EMLCalibrationCloseInit(boardIndex);

								EML_LOG.Invoke((Action)delegate
								{
									EML_LOG.AppendText(Environment.NewLine + "Stop!");
								});
								return;
							}

							if (type.Equals("Check Current"))
							{
								//Switch板选择工作模式，此处电流模式
								EML_LOG.Invoke((Action)delegate
								{
									EML_LOG.AppendText(String.Format("Relay board current mode" + Environment.NewLine));
								});
								EML_Switch_SerialTool.write(commandHT_EML(new byte[] { 0x61, 0xA0, 0x00, 0x01, 0x00 }));
								Thread.Sleep(1000);

								EMLAutoCheckCurrent(byte.Parse(boardIndex), (byte)(byte.Parse(channel) - 1), gPIB_A);
							}
							else if (type.Equals("Check Votage"))
							{
								//Switch板选择工作模式，此处电压模式
								EML_LOG.Invoke((Action)delegate
								{
									EML_LOG.AppendText(String.Format("Relay board votage mode" + Environment.NewLine));
								});
								EML_Switch_SerialTool.write(commandHT_EML(new byte[] { 0x61, 0xA0, 0x00, 0x00, 0x00 }));
								Thread.Sleep(1000);

								EMLAutoCheckVotage(byte.Parse(boardIndex), (byte)(byte.Parse(channel) - 1), gPIB_V);
							}
							else
							{
								return;
							}

							//Switch板关闭当前通道
							EML_LOG.Invoke((Action)delegate
							{
								EML_LOG.AppendText(String.Format("Close relay borad channel {0}。" + Environment.NewLine, switchChannel));
							});
							EML_Switch_SerialTool.write(commandHT_EML(new byte[] { (byte)switchChannel, 0xA0, 0x00, 0x00, 0x00 }));
							Thread.Sleep(1000);

						}
						//电源板和switch板状态初始化
						EMLCalibrationCloseInit(boardIndex);

						Keithley2401OutPutOFF(gPIB_V, gPIB_A);
					}

					EML_Save_Check_Log(boardIndex);
				}

				SoundPlay.Play();
			}
			catch (Exception e)
			{
				MessageBox.Show(String.Format(e.Message + Environment.NewLine));
			}
			finally
			{
				gPIB_V.Dispose();
				gPIB_A.Dispose();
				EML_LOG.Invoke((Action)delegate
				{
					EML_LOG.AppendText(String.Format("Check Finish。" + Environment.NewLine));
					button65.Text = "Start";
				});
			}
			Console.WriteLine("DoEMLAutoCheck finished. ");
			
			//MessageBox.Show("Done!");
			return;
		}


		/// <summary>
		/// EML 检验电压
		/// </summary>
		/// <param name="boardIndex"></param>
		/// <param name="channel"></param>
		/// <param name="gPIB"></param>
		/// <returns></returns>
		private void EMLAutoCheckVotage(byte boardIndex, byte channel, GPIB gPIB)
		{
			EML_B_difference = 0;
			EML_K_difference = 0;

			//打开输出
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} channel {1} power on." + Environment.NewLine, boardIndex, channel + 1));
			});
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0x81, channel, 0x00, 0x00 }));
			Thread.Sleep(1000);

			//电源板设置为电压模式
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} channel {1} votage model." + Environment.NewLine, boardIndex, channel + 1));
			});
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0x83, channel, 0x00, 0x00 }));
			Thread.Sleep(2000);

			//设置输出电压xV
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} channel {1} set votage:{2}mV" + Environment.NewLine, boardIndex, channel + 1, EML_VotageCheckPoints[1]));
			});
			int value = (int)(float.Parse(EML_VotageCheckPoints[1])) + 8192;
			byte valueHigh = (byte)((value & 0xFF00) >> 8);
			byte valueLow = (byte)((value & 0xFF));
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0xD0, channel, valueHigh, valueLow }));
			Thread.Sleep(2000);

			//读取外部测量电压,循环读取待电压稳定
			int votageReadTimes = 30;
			double readGPIBTemp = 0;
			double readGPIB = 0;
			do
			{
				Thread.Sleep(1000);
				gPIB.write(":MEASure:VOLTage:DC?");
				if (keithleyTypeVotage == 0)
				{
					readGPIB = double.Parse(gPIB.read()) * 1000;
				}
				else if (keithleyTypeVotage == 1)
				{
					string temp = gPIB.read();
					Console.WriteLine("GPIB read votage: " + temp);
					readGPIB = double.Parse(ChangeDataToD(temp.Split(',')[0])) * 1000;
				}
				else
				{
					EML_LOG.AppendText("Keithley type error.");
					return;
				}


				EML_LOG.Invoke((Action)delegate
				{
					EML_LOG.AppendText(String.Format("Board {0} channel {1} votage read from keithley:{2}mV。" + Environment.NewLine, boardIndex, channel + 1, readGPIB));
				});
				if (Math.Abs(readGPIBTemp - readGPIB) < 0.1)
				{
					break;
				}
				readGPIBTemp = readGPIB;
			} while (votageReadTimes-- > 0);


			//记录测量值
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} votage check channel {1} tagert votage:{2}mV votage read from keithley：{3}mV" + Environment.NewLine, boardIndex, channel + 1, EML_VotageCheckPoints[1], readGPIB));
			});
			EML_Check_Votage_Current.Add(String.Format("Board,{0},Voltage Channel,{1},Votage Target,{2},mV,Voltage Measure,{3},mV,{4}" + Environment.NewLine, boardIndex, channel + 1, EML_VotageCheckPoints[1], readGPIB, readGPIB > (int)(float.Parse(EML_VotageCheckPoints[1]) + 100) || readGPIB < (int)(float.Parse(EML_VotageCheckPoints[1]) - 100) ? "Fail" : "Pass"));


			//电源板设置电压输出0V
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} channel {1} set votage:0V。" + Environment.NewLine, boardIndex, channel + 1));
			});
			value = 8192;
			valueHigh = (byte)(((value & 0xFF00) >> 8) & 0xFF);
			valueLow = (byte)((value & 0xFF));
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0xD0, channel, valueHigh, valueLow }));
			Thread.Sleep(500);

			//电源板关闭输出
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} channel {1} power off." + Environment.NewLine, boardIndex, channel + 1));
			});
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0x80, channel, 0x00, 0x00 }));
			Thread.Sleep(1000);

		}

		/// <summary>
		/// EML 检验电流
		/// </summary>
		/// <param name="boardIndex"></param>
		/// <param name="channel"></param>
		/// <param name="gPIB"></param>
		private void EMLAutoCheckCurrent(byte boardIndex, byte channel, GPIB gPIB)
		{
			//电源板打开输出
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} channel {1} power on." + Environment.NewLine, boardIndex, channel + 1));
			});
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0x81, channel, 0x00, 0x00 }));
			Thread.Sleep(1000);


			//设置恒流模式
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} channel {1} current model." + Environment.NewLine, boardIndex, channel + 1));
			});
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0x82, channel, 0x00, 0x00 }));
			Thread.Sleep(2000);


			//设置输出电流
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} channel {1} set current:{2}mA" + Environment.NewLine, boardIndex, channel + 1, EML_CurrentCheckPoints[1]));
			});
			int value = (int)(float.Parse(EML_CurrentCheckPoints[1])) * 16 + 8192;
			byte valueHigh = (byte)(((value & 0xFF00) >> 8) & 0xFF);
			byte valueLow = (byte)((value & 0xFF));
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0xD0, channel, valueHigh, valueLow }));
			Thread.Sleep(2000);

			//测量电流，等待电流稳定
			int votageReadTimes = 30;
			double readGPIBTemp = 0;
			double readGPIB = 0;
			do
			{
				Thread.Sleep(1000);
				gPIB.write(":MEASure:CURRent:DC?");
				if (keithleyTypeCurrent == 0)
				{
					readGPIB = double.Parse(gPIB.read()) * 1000;
				}
				else if (keithleyTypeCurrent == 1)
				{
					readGPIB = double.Parse(ChangeDataToD(gPIB.read().Split(',')[1])) * 1000;
				}
				else
				{
					EML_LOG.AppendText("Keithley type error.");
					return;
				}
				EML_LOG.Invoke((Action)delegate
				{
					EML_LOG.AppendText(String.Format("Board {0} channel {1} current read from keithley:{2}mA。" + Environment.NewLine, boardIndex, channel + 1, readGPIB));
				});
				if (Math.Abs(readGPIBTemp - readGPIB) < 0.1)
				{
					break;
				}
				readGPIBTemp = readGPIB;
			} while (votageReadTimes-- > 0);

			//记录测量值
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} current check channel {1} tagert current:{2}mA read current from keithley：{3}mA" + Environment.NewLine, boardIndex, channel + 1, EML_CurrentCheckPoints[1], readGPIB));
			});
			EML_Check_Votage_Current.Add(String.Format("Board,{0},Current Channel,{1},Current Target,{2},mA,Current Measure,{3},mA,{4}" + Environment.NewLine, boardIndex, channel + 1, EML_CurrentCheckPoints[1], readGPIB, readGPIB > (int)(float.Parse(EML_CurrentCheckPoints[1]) + 5) || readGPIB < (int)(float.Parse(EML_CurrentCheckPoints[1]) - 5) ? "Fail" : "Pass"));


			//校准完成了，把电源板切换成电压模式，0v，关闭输出
			//电源板设置为电压模式
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1} votage model." + Environment.NewLine, boardIndex, channel + 1));
			});
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0x83, channel, 0x00, 0x00 }));
			Thread.Sleep(1000);

			//电源板设置电压输出0V
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1}set voatge 0V." + Environment.NewLine, boardIndex, channel + 1));
			});
			value = 8192;
			valueHigh = (byte)(((value & 0xFF00) >> 8) & 0xFF);
			valueLow = (byte)((value & 0xFF));
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0xD0, channel, valueHigh, valueLow }));
			Thread.Sleep(500);

			//电源板关闭输出
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1} power off." + Environment.NewLine, boardIndex, channel + 1));
			});
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0x80, channel, 0x00, 0x00 }));
			Thread.Sleep(1000);

		}


		private void EML_Save_Check_Log(string boardIndex)
		{
			string filename = @"log\EML_Check_" + EML_Floor + "_" + boardIndex + " " + DateTime.Now.ToString("yyyy_MM_dd HH_mm_ss") + ".csv";

			foreach (string s in EML_Check_Votage_Current)
			{
				File.AppendAllText(filename, s);
			}


		}

		
		private void DoEMLAutoCalibration(object state)
		{
			GPIB gPIB_V = new GPIB();
			GPIB gPIB_A = new GPIB();
			try
			{
				gPIB_V.Open(EML_Voltage_GPIP_Address);
				gPIB_A.Open(EML_Current_GPIP_Address);

				//Keithley2401Init(gPIB_V, gPIB_A);

				EML_Calibration_K_B.Clear();

				foreach (string boardIndex in EMLboardIndexs)
				{
					foreach (string type in EMLtestTypes)
					{
						//电源板和switch板状态初始化
						EMLCalibrationCloseInit(boardIndex);

						//打开输出
						EML_LOG.Invoke((Action)delegate
						{
							EML_LOG.AppendText(String.Format("Board power on" + Environment.NewLine));
						});
						EML_Back_SerialTool.write(commandHT_EML(new byte[] { byte.Parse(boardIndex), 0x81, 0xFF, 0x00, 0x00 }));
						Thread.Sleep(1000);

						//选择继电器板测量模式（电流/电压）初始化KB值
						if (type.Equals("Calibration Votage"))
						{
							//Switch板选择工作模式，此处电压模式
							EML_LOG.Invoke((Action)delegate
							{
								EML_LOG.AppendText(String.Format("Relay board votage model selected." + Environment.NewLine));
							});
							EML_Switch_SerialTool.write(commandHT_EML(new byte[] { 0x61, 0xA0, 0x00, 0x00, 0x00 }));
							Thread.Sleep(1000);

							Keithley2401CheckVotage(gPIB_V, gPIB_A);

							//设置k为1
							EML_LOG.Invoke((Action)delegate
							{
								EML_LOG.AppendText(String.Format("Board {0} all channel votage K=1" + Environment.NewLine, byte.Parse(boardIndex)));
							});
							int value = 1 * 10000;
							byte valueHigh = (byte)(((value & 0xFF00) >> 8) & 0xFF);
							byte valueLow = (byte)((value & 0xFF));
							EML_Back_SerialTool.write(commandHT_EML(new byte[] { byte.Parse(boardIndex), 0xF1, 0xFF, valueHigh, valueLow }));
							Thread.Sleep(2000);

							//设置b为0
							EML_LOG.Invoke((Action)delegate
							{
								EML_LOG.AppendText(String.Format("Board {0} all channel votage B=0" + Environment.NewLine, byte.Parse(boardIndex)));
							});
							value = 32767;
							valueHigh = (byte)(((value & 0xFF00) >> 8) & 0xFF);
							valueLow = (byte)((value & 0xFF));
							EML_Back_SerialTool.write(commandHT_EML(new byte[] { byte.Parse(boardIndex), 0xF2, 0xFF, valueHigh, valueLow }));
							Thread.Sleep(2000);
						}
						else if (type.Equals("Calibration Current"))
						{
							//Switch板选择工作模式，此处电流模式
							EML_LOG.Invoke((Action)delegate
							{
								EML_LOG.AppendText(String.Format("Relay board current model selected." + Environment.NewLine));
							});
							EML_Switch_SerialTool.write(commandHT_EML(new byte[] { 0x61, 0xA0, 0x00, 0x01, 0x00 }));
							Thread.Sleep(1000);

							Keithley2401CheckCurrent(gPIB_V, gPIB_A);

							//设置电流系数K为1
							EML_LOG.Invoke((Action)delegate
							{
								EML_LOG.AppendText(String.Format("Board all channel current K=1。" + Environment.NewLine));
							});
							int value = 1 * 10000;
							byte valueHigh = (byte)(((value & 0xFF00) >> 8) & 0xFF);
							byte valueLow = (byte)((value & 0xFF));
							EML_Back_SerialTool.write(commandHT_EML(new byte[] { byte.Parse(boardIndex), 0xF3, 0xFF, valueHigh, valueLow }));
							Thread.Sleep(2000);

							//设置电流系数B为0
							EML_LOG.Invoke((Action)delegate
							{
								EML_LOG.AppendText(String.Format("board all channel current B=0。" + Environment.NewLine));
							});
							value = 32767;
							valueHigh = (byte)(((value & 0xFF00) >> 8) & 0xFF);
							valueLow = (byte)((value & 0xFF));
							EML_Back_SerialTool.write(commandHT_EML(new byte[] { byte.Parse(boardIndex), 0xF4, 0xFF, valueHigh, valueLow }));
							Thread.Sleep(2000);
						}
						else
						{
							MessageBox.Show("Relay board model error.");
							return;
						}

						//关闭输出
						EML_LOG.Invoke((Action)delegate
						{
							EML_LOG.AppendText(String.Format("Board {0} power off。" + Environment.NewLine, byte.Parse(boardIndex)));
						});
						EML_Back_SerialTool.write(commandHT_EML(new byte[] { byte.Parse(boardIndex), 0x80, 0xFF, 0x00, 0x00 }));
						Thread.Sleep(1000);


						foreach (string channel in EMLchannels)
						{

							if (EMLtasktokenSource.Token.IsCancellationRequested)
							{
								//终止退出
								//电源板和switch板状态初始化
								EMLCalibrationCloseInit(boardIndex);

								EML_LOG.Invoke((Action)delegate
								{
									EML_LOG.AppendText(Environment.NewLine + "Stop!");
								});
								return;
							}

							int switchChannel = byte.Parse(channel) + (byte.Parse(boardIndex) + 1) % 2 * 48;
							//Switch板打开当前通道
							EML_LOG.Invoke((Action)delegate
							{
								EML_LOG.AppendText(String.Format("Open relay board channel {0}。" + Environment.NewLine, byte.Parse(channel)));
							});
							EML_Switch_SerialTool.write(commandHT_EML(new byte[] { (byte)switchChannel, 0xA0, 0x00, 0x01, 0x00 }));
							Thread.Sleep(1000);

							EML_LOG.Invoke((Action)delegate
							{
								EML_LOG.AppendText(String.Format("Start Calibration，type:{0} board:{1} channel:{2}" + Environment.NewLine, type, boardIndex, channel));
							});


							if (type.Equals("Calibration Current"))
							{
								//Switch板选择工作模式，此处电流模式
								EML_LOG.Invoke((Action)delegate
								{
									EML_LOG.AppendText(String.Format("Relay board current model selected." + Environment.NewLine));
								});
								EML_Switch_SerialTool.write(commandHT_EML(new byte[] { 0x61, 0xA0, 0x00, 0x01, 0x00 }));
								Thread.Sleep(1000);

								EMLAutoCalibrationCurrent(byte.Parse(boardIndex), (byte)(byte.Parse(channel) - 1), gPIB_A);
							}
							else if (type.Equals("Calibration Votage"))
							{
								//Switch板选择工作模式，此处电压模式
								EML_LOG.Invoke((Action)delegate
								{
									EML_LOG.AppendText(String.Format("Relay board votage model selected." + Environment.NewLine));
								});
								EML_Switch_SerialTool.write(commandHT_EML(new byte[] { 0x61, 0xA0, 0x00, 0x00, 0x00 }));
								Thread.Sleep(1000);

								EMLAutoCalibrationVotage(byte.Parse(boardIndex), (byte)(byte.Parse(channel) - 1), gPIB_V);
							}
							else
							{
								return;
							}

							//Switch板关闭当前通道
							EML_LOG.Invoke((Action)delegate
							{
								EML_LOG.AppendText(String.Format("Close relay board channel {0}。" + Environment.NewLine, switchChannel));
							});
							EML_Switch_SerialTool.write(commandHT_EML(new byte[] { (byte)switchChannel, 0xA0, 0x00, 0x00, 0x00 }));
							Thread.Sleep(1000);

						}
						//电源板和switch板状态初始化
						EMLCalibrationCloseInit(boardIndex);

						Keithley2401OutPutOFF(gPIB_V, gPIB_A);
					}

					EML_Calibration_K_B_Log(boardIndex);
				}
			}
			catch (Exception e)
			{
                EML_LOG.BeginInvoke((Action)delegate { EML_LOG.AppendText(String.Format(e.Message + Environment.NewLine)); });
			}
			finally
			{
				gPIB_V.Dispose();
				gPIB_A.Dispose();
				EML_LOG.Invoke((Action)delegate
				{
					EML_LOG.AppendText(String.Format("Finish." + Environment.NewLine));
					button60.Text = "Start";
				});
			}
			Console.WriteLine("DoEMLAutoCalibration finished. ");
			
			
			calibrationFinishFlag = true;
			return;
		}

		//GPIB读取
		double readGPIB = 0;

		//差值
		double EML_B_difference = 0d;
		double EML_K_difference = 0d;

		//设定值
		double EML_B_Set = 0d;
		double EML_K_Set = 0d;

		List<string> EML_Calibration_K_B = new List<string>();

		/// <summary>
		/// EML电压校准
		/// 1.k设为0，校准0电压，得到b,设置b
		/// 2.k设为1，校准目标电压
		/// </summary>
		/// <param name="boardIndex"></param>
		/// <param name="channel"></param>
		/// <param name="gPIB_V"></param>
		private void EMLAutoCalibrationVotage(byte boardIndex, byte channel, GPIB gPIB)
		{
			EML_B_difference = 0;
			EML_K_difference = 0;

			//打开输出
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1} open。" + Environment.NewLine, boardIndex, channel + 1));
			});
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0x81, channel, 0x00, 0x00 }));
			Thread.Sleep(1000);

			//电源板设置为电压模式
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1} set votage model." + Environment.NewLine, boardIndex, channel + 1));
			});
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0x83, channel, 0x00, 0x00 }));
			Thread.Sleep(2000);

			//设置输出电压0V，开始校准b值
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1} set votage: {2}mV" + Environment.NewLine, boardIndex, channel + 1, EML_VotageTestPoints[0]));
			});
			int value = (int)(float.Parse(EML_VotageTestPoints[0])) + 8192;
			byte valueHigh = (byte)(((value & 0xFF00) >> 8) & 0xFF);
			byte valueLow = (byte)((value & 0xFF));
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0xD0, channel, valueHigh, valueLow }));
			Thread.Sleep(2000);

			//读取外部测量电压,循环读取待电压稳定
			int votageReadTimes = 30;
			double readGPIBTemp = 0;
			do
			{
				Thread.Sleep(1000);
				gPIB.write(":MEASure:VOLTage:DC?");
				if (keithleyTypeVotage == 0)
				{
					readGPIB = double.Parse(gPIB.read()) * 1000;
				}
				else if (keithleyTypeVotage == 1)
				{
					readGPIB = double.Parse(ChangeDataToD(gPIB.read().Split(',')[0])) * 1000;
				}
				else
				{
					EML_LOG.AppendText("Keithley type error.");
					return;
				}
				EML_LOG.Invoke((Action)delegate
				{
					EML_LOG.AppendText(String.Format("Board {0} Channel {1} read votage from keithley:{2}mV。" + Environment.NewLine, boardIndex, channel + 1, readGPIB));
				});
				if (Math.Abs(readGPIBTemp - readGPIB) < 0.1)
				{
					break;
				}
				readGPIBTemp = readGPIB;
			} while (votageReadTimes-- > 0);

			//直接将测量值作为B值
			EML_B_difference = readGPIB;

			//电源板设置电压B值
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1} set votage B:{2}。" + Environment.NewLine, boardIndex, channel + 1, EML_B_difference));
			});
			EML_B_Set = 32767 + EML_B_difference * 100;
			valueHigh = (byte)((Convert.ToInt32(EML_B_Set) & 0xFF00) >> 8);
			valueLow = (byte)((Convert.ToInt32(EML_B_Set) & 0xFF));
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0xF2, channel, valueHigh, valueLow }));
			Thread.Sleep(3000);

			//上面校准完b值
			//下面开始校准k值
			//设置输出电压xV，开始校准k值
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1} set votage: {2} mV" + Environment.NewLine, boardIndex, channel + 1, EML_VotageTestPoints[1]));
			});
			value = (int)(float.Parse(EML_VotageTestPoints[1])) + 8192;
			valueHigh = (byte)((value & 0xFF00) >> 8);
			valueLow = (byte)((value & 0xFF));
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0xD0, channel, valueHigh, valueLow }));
			Thread.Sleep(2000);

			//读取外部测量电压,循环读取待电压稳定
			votageReadTimes = 30;
			readGPIBTemp = 0;
			do
			{
				Thread.Sleep(1000);
				gPIB.write(":MEASure:VOLTage:DC?");
				if (keithleyTypeVotage == 0)
				{
					readGPIB = double.Parse(gPIB.read()) * 1000;
				}
				else if (keithleyTypeVotage == 1)
				{
					readGPIB = double.Parse(ChangeDataToD(gPIB.read().Split(',')[0])) * 1000;
				}
				else
				{
					EML_LOG.AppendText("Keithley type error.");
					return;
				}
				EML_LOG.Invoke((Action)delegate
				{
					EML_LOG.AppendText(String.Format("Board {0} Channel {1} Read votage form keithley:{2}mV。" + Environment.NewLine, boardIndex, channel + 1, readGPIB));
				});
				if (Math.Abs(readGPIBTemp - readGPIB) < 0.1)
				{
					break;
				}
				readGPIBTemp = readGPIB;
			} while (votageReadTimes-- > 0);


			//测量值除以设定值作为K
			EML_K_difference = readGPIB / int.Parse(EML_VotageTestPoints[1]);
			EML_K_Set = EML_K_difference * 10000;

			//设置K
			valueHigh = (byte)((Convert.ToInt32(EML_K_Set) & 0xFF00) >> 8);
			valueLow = (byte)((Convert.ToInt32(EML_K_Set) & 0xFF));
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1}Set votage K:{2}" + Environment.NewLine, boardIndex, channel + 1, EML_K_difference));
			});
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0xF1, channel, valueHigh, valueLow }));
			Thread.Sleep(1000);

			//电源板设置电压输出0V
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1} Set votage:0V。" + Environment.NewLine, boardIndex, channel + 1));
			});
			value = 8192;
			valueHigh = (byte)(((value & 0xFF00) >> 8) & 0xFF);
			valueLow = (byte)((value & 0xFF));
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0xD0, channel, valueHigh, valueLow }));
			Thread.Sleep(500);

			//电源板关闭输出
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1} power off." + Environment.NewLine, boardIndex, channel + 1));
			});
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0x80, channel, 0x00, 0x00 }));
			Thread.Sleep(1000);

			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Votage Calibration Channel {1} finish，K:{2}, B:{3}。Votage now:{4}mV" + Environment.NewLine, boardIndex, channel + 1, EML_K_difference, EML_B_difference, readGPIB));
			});

			EML_Calibration_K_B.Add(String.Format("Board,{0},Voltage Channel,{1},K,{2},B,{3},Default Voltage,{4},mV" + Environment.NewLine, boardIndex, channel + 1, EML_K_difference, EML_B_difference, readGPIB));

		}

		private void EMLAutoCalibrationCurrent(byte boardIndex, byte channel, GPIB gPIB)
		{
			//电源板打开输出
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1} PowerOn." + Environment.NewLine, boardIndex, channel + 1));
			});
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0x81, channel, 0x00, 0x00 }));
			Thread.Sleep(1000);

			//设置恒流模式
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1} Set current mode." + Environment.NewLine, boardIndex, channel + 1));
			});
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0x82, channel, 0x00, 0x00 }));
			Thread.Sleep(2000);

			//设置输出电流0mA，开始校准b值
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1} Set current output: {2} mA." + Environment.NewLine, boardIndex, channel + 1, EML_CurrentTestPoints[0]));
			});
			int value = (int)(float.Parse(EML_CurrentTestPoints[0])) * 16 + 8192;
			byte valueHigh = (byte)(((value & 0xFF00) >> 8) & 0xFF);
			byte valueLow = (byte)((value & 0xFF));
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0xD0, channel, valueHigh, valueLow }));
			Thread.Sleep(2000);

			//测量电流,等待电流稳定
			int votageReadTimes = 30;
			double readGPIBTemp = 0;
			do
			{
				Thread.Sleep(1000);
				gPIB.write(":MEASure:CURRent:DC?");
				if (keithleyTypeCurrent == 0)
				{
					readGPIB = double.Parse(gPIB.read()) * 1000;
				}
				else if (keithleyTypeCurrent == 1)
				{
					readGPIB = double.Parse(ChangeDataToD(gPIB.read().Split(',')[1])) * 1000;
				}
				else
				{
					EML_LOG.AppendText("Keithley type error.");
					return;
				}
				EML_LOG.Invoke((Action)delegate
				{
					EML_LOG.AppendText(String.Format("Board {0} Channel {1} Current from keithley:{2}mA。" + Environment.NewLine, boardIndex, channel + 1, readGPIB));
				});
				if (Math.Abs(readGPIBTemp - readGPIB) < 0.1)
				{
					break;
				}
				readGPIBTemp = readGPIB;
			} while (votageReadTimes-- > 0);

			//测量值作为B
			EML_B_difference = readGPIB;
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1}Set current B value:{2}" + Environment.NewLine, boardIndex, channel + 1, EML_B_difference));
			});

			//实际设置的B值
			EML_B_Set = 32767 + EML_B_difference * 100;
			valueHigh = (byte)((Convert.ToInt32(EML_B_Set) & 0xFF00) >> 8);
			valueLow = (byte)((Convert.ToInt32(EML_B_Set) & 0xFF));
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0xF4, channel, valueHigh, valueLow }));
			Thread.Sleep(1000);

			//B值校准完成
			//设置输出电流200mA，开始校准K值
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1} Set output current: {2} mA" + Environment.NewLine, boardIndex, channel + 1, EML_CurrentTestPoints[1]));
			});
			value = (int)(float.Parse(EML_CurrentTestPoints[1])) * 16 + 8192;
			valueHigh = (byte)(((value & 0xFF00) >> 8) & 0xFF);
			valueLow = (byte)((value & 0xFF));
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0xD0, channel, valueHigh, valueLow }));
			Thread.Sleep(2000);

			//测量电流，等待电流稳定
			votageReadTimes = 30;
			readGPIBTemp = 0;
			do
			{
				Thread.Sleep(1000);
				gPIB.write(":MEASure:CURRent:DC?");
				if (keithleyTypeCurrent == 0)
				{
					readGPIB = double.Parse(gPIB.read()) * 1000;
				}
				else if (keithleyTypeCurrent == 1)
				{
					readGPIB = double.Parse(ChangeDataToD(gPIB.read().Split(',')[1])) * 1000;
				}
				else
				{
					EML_LOG.AppendText("Keithley type error.");
					return;
				}
				EML_LOG.Invoke((Action)delegate
				{
					EML_LOG.AppendText(String.Format("Board {0} Channel {1} Current from keithley:{2}mA。" + Environment.NewLine, boardIndex, channel + 1, readGPIB));
				});
				if (Math.Abs(readGPIBTemp - readGPIB) < 0.1)
				{
					break;
				}
				readGPIBTemp = readGPIB;
			} while (votageReadTimes-- > 0);

			//测量值作为K， 除以设定值
			EML_K_difference = readGPIB / float.Parse(EML_CurrentTestPoints[1]);
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1} Set Current K:{2}" + Environment.NewLine, boardIndex, channel + 1, EML_K_difference));
			});

			//实际设置的K值
			EML_K_Set = EML_K_difference * 10000;
			valueHigh = (byte)((Convert.ToInt32(EML_K_Set) & 0xFF00) >> 8);
			valueLow = (byte)((Convert.ToInt32(EML_K_Set) & 0xFF));
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0xF3, channel, valueHigh, valueLow }));
			Thread.Sleep(1000);

			//校准完成了，把电源板切换成电压模式，0v，关闭输出
			//电源板设置为电压模式
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1} Votage model." + Environment.NewLine, boardIndex, channel + 1));
			});
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0x83, channel, 0x00, 0x00 }));
			Thread.Sleep(1000);

			//电源板设置电压输出0V
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1} output 0V。" + Environment.NewLine, boardIndex, channel + 1));
			});
			value = 8192;
			valueHigh = (byte)(((value & 0xFF00) >> 8) & 0xFF);
			valueLow = (byte)((value & 0xFF));
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0xD0, channel, valueHigh, valueLow }));
			Thread.Sleep(500);

			//电源板关闭输出
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Channel {1} Power Off." + Environment.NewLine, boardIndex, channel + 1));
			});
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { boardIndex, 0x80, channel, 0x00, 0x00 }));
			Thread.Sleep(1000);


			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Current Channel{1} Calibration Finish，K:{2}, B:{3}。Current now:{4}mA" + Environment.NewLine, boardIndex, channel + 1, EML_K_difference, EML_B_difference, readGPIB));
			});

			EML_Calibration_K_B.Add(String.Format("Board,{0},Current Channel,{1},K,{2},B,{3},Default Current,{4},mA" + Environment.NewLine, boardIndex, channel + 1, EML_K_difference, EML_B_difference, readGPIB));
		}

		private void EML_Calibration_K_B_Log(string board)
		{
			string filename = @"log\EML_Calibration_" + EML_Floor + "_" + board + " " + DateTime.Now.ToString("yyyy_MM_dd HH_mm_ss") + ".csv";

			foreach (string s in EML_Calibration_K_B)
			{
				File.AppendAllText(filename, s);
			}

			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(getMarkTime());
			});
		}

		private void EMLCalibrationCloseInit(string boardIndex)
		{
			//电源板全通道下电
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Board {0} Power Off." + Environment.NewLine, boardIndex));
			});
			EML_Back_SerialTool.write(commandHT_EML(new byte[] { byte.Parse(boardIndex), 0x80, 0xFF, 0x00, 0x00 }));
			Thread.Sleep(1000);

			//Switch板关闭所有通道
			EML_LOG.Invoke((Action)delegate
			{
				EML_LOG.AppendText(String.Format("Relay board close all channel." + Environment.NewLine, boardIndex));
			});
			EML_Switch_SerialTool.write(commandHT_EML(new byte[] { 0x00, 0xA0, 0x00, 0x00, 0x00 }));
			Thread.Sleep(1000);
		}

        private void comboBox17_MouseEnter(object sender, EventArgs e)
        {
			comboBox17.Items.Clear();
			ComboBox.ObjectCollection items = comboBox17.Items;
			object[] localPorts = SerialTool.GetLocalPorts();
			items.AddRange(localPorts);
		}


        private void comboBox20_MouseEnter(object sender, EventArgs e)
        {
			comboBox20.Items.Clear();
			ComboBox.ObjectCollection items = comboBox20.Items;
			object[] localPorts = SerialTool.GetLocalPorts();
			items.AddRange(localPorts);
		}

        private void Form1_Load(object sender, EventArgs e)
        {
			comboBox18.SelectedIndex = 0;
			comboBox16.SelectedIndex = 0;
			comboBox21.SelectedIndex = 0;
			comboBox19.SelectedIndex = 0;

			comboBox1.SelectedIndex = 1;
			comboBox2.SelectedIndex = 1;

			
		}

		int keithleyTypeVotage = 1;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
			keithleyTypeVotage = comboBox1.SelectedIndex;
		}
		int keithleyTypeCurrent = 1;
		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			keithleyTypeCurrent = comboBox2.SelectedIndex;
		}

		/// <summary>
		/// 科学计数法转换
		/// </summary>
		/// <param name="strData"></param>
		/// <returns></returns>
		private string ChangeDataToD(string strData)
		{
			Decimal dData = 0.0M;
			if (strData.Contains("E"))
			{
				dData = Convert.ToDecimal(Decimal.Parse(strData.ToString().Replace(" ", ""), System.Globalization.NumberStyles.Float));
			}
			return dData.ToString();

		}


		//string[] Keithley2401CurrentMeasureInit = new string[] { "*RST", ":SOUR:FUNC VOLT", ":SOUR:VOLT:MODE FIXED", ":SOUR:VOLT:RANG 20", ":SOUR:VOLT:LEV 10", 
			//":SENS:CURR:PROT 10E-4", 
			//":SENS:FUNC \"CURR\"", 
			//":SENS:CURR:RANG 10E-4", 
			//":FORM:ELEM CURR", ":OUTP ON", };
		//string[] Keithley2401VotageMeasureInit = new string[] { "*RST", ":SOUR:FUNC CURR", ":SOUR:CURR:MODE FIXED", ":SENS:FUNC \"VOLT\"", ":SOUR:CURR:RANG MIN", ":SOUR:CURR:LEV 0", 
			//":SENS:VOLT:PROT 3", ":SENS:VOLT:RANG 20", 
			//":FORM:ELEM VOLT", ":OUTP ON", };

		string[] Keithley2401CurrentMeasureInit = new string[] { ":OUTP OFF", ":SOUR:FUNC CURR", ":SOUR:CURR:MODE FIXED", ":SOUR:CURR:RANG 0.5", ":SENSe:VOLTage:PROTection 10E-2", ":SENSe:CURRent:PROTection 200E-3", ":OUTP ON", };
		string[] Keithley2401VotageMeasureInit  = new string[] { ":OUTP OFF", ":SOUR:FUNC VOLT", ":SOUR:VOLT:MODE FIXED", ":SOUR:VOLT:RANG 3.5", ":SENSe:VOLTage:PROTection 3.5", ":SENSe:CURRent:PROTection 350E-3", ":OUTP ON", };

		//string[] Keithley2401CurrentMeasureInitForVotage = new string[] { ":OUTP OFF", "*RST", ":SOUR:FUNC CURR", ":SOUR:CURR:MODE FIXED", ":SENSe:VOLTage:PROTection 1E-1", ":SENSe:VOLTage:PROTection 1E-2", ":SENSe:VOLTage:PROTection 1E-3", ":SENSe:VOLTage:PROTection 5E-4", ":SENSe:VOLTage:PROTection 2E-4", ":OUTP ON", };
		string[] Keithley2401CurrentMeasureInitForVotage = new string[] { ":OUTP OFF", ":SOUR:FUNC CURR", ":SOUR:CURR:MODE FIXED", ":SOUR:CURR:RANG 10E-4", ":SENSe:VOLTage:PROTection 1E-1", ":SENSe:VOLTage:PROTection 1E-2", ":SENSe:VOLTage:PROTection 1E-3", ":SENSe:VOLTage:PROTection 5E-4", ":SENSe:VOLTage:PROTection 2E-4", ":OUTP ON", };


		private void Keithley2401Init(GPIB gPIB_V, GPIB gPIB_A)
        {
			//if (keithleyTypeVotage == 1)
			//{
			//	//初始化keithley 2401
			//	foreach (string s in Keithley2401VotageMeasureInit)
			//	{
			//		gPIB_V.write(s);
			//		EML_LOG.Invoke((Action)delegate
			//		{
			//			EML_LOG.AppendText("Init Keithley 2401: " + s + Environment.NewLine);
			//		});
			//		Thread.Sleep(200);
			//	}

			//}

			//if (keithleyTypeCurrent == 1)
			//{
			//	//初始化keithley 2401
			//	foreach (string s in Keithley2401CurrentMeasureInit)
			//	{
			//		gPIB_A.write(s);
			//		EML_LOG.Invoke((Action)delegate
			//		{
			//			EML_LOG.AppendText("Init Keithley 2401: " + s + Environment.NewLine);
			//		});
			//		Thread.Sleep(200);
			//	}
			//}
		}

		private void Keithley2401OutPutOFF(GPIB gPIB_V, GPIB gPIB_A)
		{
			if (keithleyTypeVotage == 1)
			{
				gPIB_V.write("OUTPUT OFF");
				EML_LOG.Invoke((Action)delegate
				{
					EML_LOG.AppendText("Init Keithley 2401: :OUTPUT OFF." + Environment.NewLine);
				});
				Thread.Sleep(200);
			}

			if (keithleyTypeCurrent == 1)
			{
				gPIB_A.write("OUTPUT OFF");
				EML_LOG.Invoke((Action)delegate
				{
					EML_LOG.AppendText("Init Keithley 2401: :OUTPUT OFF." + Environment.NewLine);
				});
				Thread.Sleep(200);

			}
		}

		private void Keithley2401CheckCurrent(GPIB gPIB_V, GPIB gPIB_A)
		{
			if (keithleyTypeVotage == 1)
			{
				gPIB_V.write("OUTPUT OFF");
				EML_LOG.Invoke((Action)delegate
				{
					EML_LOG.AppendText("Init Votage Keithley 2401: OUTPUT OFF." + Environment.NewLine);
				});
				Thread.Sleep(200);
			}

			if (keithleyTypeCurrent == 1)
			{
				//初始化keithley 2401
				foreach (string s in Keithley2401CurrentMeasureInit)
				{
					gPIB_A.write(s);
					EML_LOG.Invoke((Action)delegate
					{
						EML_LOG.AppendText("Init Current Keithley 2401: " + s + Environment.NewLine);
					});
					Thread.Sleep(200);
				}
			}


		}

		private void Keithley2401CheckVotage(GPIB gPIB_V, GPIB gPIB_A)
		{
			if (keithleyTypeVotage == 1)
			{
				//初始化keithley 2401
				foreach (string s in Keithley2401CurrentMeasureInitForVotage)
				{
					gPIB_A.write(s);
					EML_LOG.Invoke((Action)delegate
					{
						EML_LOG.AppendText("Init Current Keithley 2401: " + s + Environment.NewLine);
					});
					Thread.Sleep(200);
				}
			}

			if (keithleyTypeVotage == 1)
			{
				//初始化keithley 2401
				foreach (string s in Keithley2401VotageMeasureInit)
				{
					gPIB_V.write(s);
					EML_LOG.Invoke((Action)delegate
					{
						EML_LOG.AppendText("Init Votage Keithley 2401: " + s + Environment.NewLine);
					});
					Thread.Sleep(200);
				}
			}

		}

		DateTime MarkTime = DateTime.Now;

		private void markTime()
        {
			MarkTime = DateTime.Now;
		}
		private string getMarkTime()
        {
			return string.Format("Total Time {0} Start {1} end {2}", (DateTime.Now - MarkTime).ToString("c").Split('.')[0], MarkTime.ToString("HH:mm:ss"), DateTime.Now.ToString("HH:mm:ss")) ;
		}
		bool calibrationFinishFlag = false;
		private void button1_Click(object sender, EventArgs e)
        {
			calibrationFinishFlag = false;
			button60_Click(null, null) ;

			Task t = new Task(() => {
				while (true)
				{
					if (calibrationFinishFlag)
					{
						button65_Click(null, null);
						break;
					}
					Thread.Sleep(3000);
				}
				calibrationFinishFlag = false;
			});
            
			t.Start();

		}

        private void button2_Click(object sender, EventArgs e)
        {
			SoundPlay.Stop();
        }
    }
}
