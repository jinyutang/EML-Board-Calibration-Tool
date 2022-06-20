using NationalInstruments.Visa;

namespace EML_Board_Calibration_Tool
{
	internal class GPIB
	{
		private MessageBasedSession messageBasedSession = null;

		public void Open()
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			messageBasedSession = (MessageBasedSession)(new ResourceManager().Open("GPIB0::15::INSTR"));
			messageBasedSession.RawIO.Write(":MEASure:VOLTage:DC?");
		}

		public void Open(string address)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			messageBasedSession = (MessageBasedSession)(new ResourceManager().Open(address));
		}

		public string read()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			return messageBasedSession.RawIO.ReadString();
		}

		public void write(string message)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			messageBasedSession.RawIO.Write(message);
		}

		public void Dispose()
		{
			if (messageBasedSession != null)
			{
				messageBasedSession.Dispose();
			}
		}
	}
}
