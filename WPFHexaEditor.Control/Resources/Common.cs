using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPFHexaEditor.Resources {
    public static class Common {
        //It indicates the "margins" between hex headers and char in hextextlayer;
        public const string HexIndent = " ";
        //It indicates the width of every hexbytecontrol,it was measured by live property tree(HexHeader).
        public const double HexCharWidth = 31.25;
        public const double HexLineHeight = 22.0;

        //It indicates the width of every stringbytecontrol,it was measured by live property tree(HexHeader).
        public const double StringCharWidth = 7.8;

        public static readonly Brush ForegroundOffSetHeaderColor = new SolidColorBrush(Colors.Black);
        public static readonly FontFamily EqualWidthFontFamily = new FontFamily("Courier New");

        public static readonly double ByteControlFontSize = 13;


        #region Fonts
        public static readonly FontWeight NormalFontWeight = FontWeights.Normal;
        public static readonly FontWeight BoldFontWeight = FontWeights.Bold;
        #endregion

        #region Colors
        public static readonly SolidColorBrush BookMarkColor = new SolidColorBrush(Color.FromArgb(0xb2, 0x00, 0x00, 0xff));
        public static readonly SolidColorBrush SearchBookMarkColor = new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0x8b, 0x00));
        public static readonly SolidColorBrush SelectionStartBookMarkColor = new SolidColorBrush(Colors.Blue);
        public static readonly SolidColorBrush ByteModifiedMarkColor = new SolidColorBrush(Color.FromArgb(0xcc, 0x68, 0x71, 0x7c));
        public static readonly SolidColorBrush ByteDeletedMarkColor = new SolidColorBrush(Color.FromArgb(0xb2, 0xff, 0x00, 0x00));

        public static readonly SolidColorBrush FirstSelectedColor = new SolidColorBrush(Color.FromArgb(0xFF, 0xE0, 0xE0, 0xff));
        public static readonly SolidColorBrush SecondSelectedColor = new SolidColorBrush(Color.FromArgb(0xFF, 0xE0, 0xE0, 0xff));
        public static readonly SolidColorBrush ByteModifiedColor = new SolidColorBrush(Color.FromArgb(0xcc, 0x68, 0x71, 0x7c));
        public static readonly SolidColorBrush MouseOverColor = new SolidColorBrush(Color.FromArgb(0xb2, 0x00, 0x81, 0xff));
        public static readonly SolidColorBrush HighLightColor = new SolidColorBrush(Color.FromArgb(0xb2, 0xff, 0xff, 0x00));
        public static readonly SolidColorBrush ByteDeletedColor = new SolidColorBrush(Color.FromArgb(0xb2, 0xff, 0x00, 0x00));
        #endregion
    }
}
