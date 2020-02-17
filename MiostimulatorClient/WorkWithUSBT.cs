using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MiostimulatorClient
{
    public class WorkWithUSBT
    {
        public static Size size_screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
        public static Point point_null = new Point(Convert.ToInt32((size_screen.Width - 436) / 2), 91);
        public static Point point_cursor = point_null;
        public static void SetData(string period_of_stimulations, string duration_of_the_stimulation, string correction, string amperage, string count_of_stimulations, string signal_shape)
        {
            // set period of stimulations

            point_cursor.X = point_null.X + 233;
            point_cursor.Y = point_null.Y + 46;
            Cursor.Position = point_cursor;
            MouseEmulator.LeftDoubleClick();
            SendKeys.SendWait(period_of_stimulations);            

            // set duration of the stimulation

            point_cursor.X = point_null.X + 233;
            point_cursor.Y = point_null.Y + 85;
            Cursor.Position = point_cursor;
            MouseEmulator.LeftDoubleClick();
            SendKeys.SendWait(duration_of_the_stimulation);

            // set correction

            point_cursor.X = point_null.X + 233;
            point_cursor.Y = point_null.Y + 127;
            Cursor.Position = point_cursor;
            MouseEmulator.LeftDoubleClick();
            SendKeys.SendWait(correction);

            // set amperage

            point_cursor.X = point_null.X + 233;
            point_cursor.Y = point_null.Y + 169;
            Cursor.Position = point_cursor;
            MouseEmulator.LeftDoubleClick();
            SendKeys.SendWait(amperage);

            // set count of stimulations

            point_cursor.X = point_null.X + 233;
            point_cursor.Y = point_null.Y + 213;
            Cursor.Position = point_cursor;
            MouseEmulator.LeftDoubleClick();
            SendKeys.SendWait(count_of_stimulations);

            // set signal shape           
        }
        public static void StartButtonClick()
        {
            point_cursor.X = point_null.X + 52;
            point_cursor.Y = point_null.Y + 519;
            Cursor.Position = point_cursor;
            MouseEmulator.LeftClick();
        }
        public static void StopButtonClick()
        {
            point_cursor.X = point_null.X + 184;
            point_cursor.Y = point_null.Y + 519;
            Cursor.Position = point_cursor;
            MouseEmulator.LeftClick();
        }
        public static void CloseButtonClick()
        {
            point_cursor.X = point_null.X + 388;
            point_cursor.Y = point_null.Y + 521;
            Cursor.Position = point_cursor;
            MouseEmulator.LeftClick();
        }
    }
}
