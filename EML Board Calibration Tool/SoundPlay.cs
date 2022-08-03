using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace EML_Board_Calibration_Tool
{
    internal class SoundPlay
    {
		static SoundPlayer soundPlayer = new SoundPlayer();
		public static void Play()
		{
			soundPlayer.SoundLocation = "阿肆 - 热爱105°C的你.wav";
			soundPlayer.Load();
			soundPlayer.Play();
		}

		public static void Stop()
        {
			soundPlayer.Stop();
        }
	}
}
