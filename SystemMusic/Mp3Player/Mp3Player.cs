using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace SystemMusic
{
    class Mp3Player : IDisposable
    {
        public bool Repeat { get; set; }
        // Constructor, sets the filesName and path to where the file is.
        public Mp3Player(string fileName)
        {
            const string FORMAT = @"open ""{0}"" type mpegvideo alias MediaFile"; // Odd that it is mpeg video not audio, anyway I cannot change that.
            string command = String.Format(FORMAT, fileName);
            mciSendString(command, null, 0, IntPtr.Zero); // Call mciSendString, we do not care about return information so null.
        }
        // Play method
        public void Play()
        {
            string command = "play MediaFile";
            if (Repeat) command += "REPEAT";
            mciSendString(command, null, 0, IntPtr.Zero);
        }
        // Pause method
        public void Pause()
        {
            string command = "pause MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
        }
        // Stop method
        public void Stop()
        {
            string command = "stop MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
        }
        /*
         * Pause and stop both do the same thing, I cannot understand why though.
         * Maybe because of mciSendString? Anyway stop acts like pause meanwhile pause acts like pause.
         */
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand,
            StringBuilder strReturn, int iReturnLength, IntPtr handCallback);
        // Ignore return information, I mean we do not need it.

        // Implement the IDisposeable interface.
        public void Dispose()
        {
            string command = "close MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
        }
    }
}
