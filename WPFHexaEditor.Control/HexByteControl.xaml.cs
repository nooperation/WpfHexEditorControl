﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using WPFHexaEditor.Control.Core;

namespace WPFHexaEditor.Control
{
    /// <summary>
    /// Interaction logic for HexControl.xaml
    /// </summary>
    public partial class HexByteControl : UserControl
    {
        private byte? _byte;
        private bool _isByteModified;
        private bool _isSelected = false;
        private bool _readOnlyMode = false;
        private KeyDownLabel _keyDownLabel = KeyDownLabel.FirstChar;

        public event EventHandler ByteModified;
        public event EventHandler MouseSelection;
        public event EventHandler Click;
        public event EventHandler MoveNext;

        private enum KeyDownLabel
        {
            FirstChar,
            SecondChar,
            NextPosition
        }

        public HexByteControl()
        {
            InitializeComponent();

            DataContext = this;
        }
        
        public byte? Byte
        {
            get
            {
                return this._byte;
            }
            set
            {
                this._byte = value;

                UpdateLabelFromByte();
                
                if (IsByteModified)
                    if (ByteModified != null)
                        ByteModified(this, new EventArgs());
            }
        }

        public long BytePositionInFile { get; set; } = -1;

        public bool IsByteModified
        {
            get
            {
                return this._isByteModified;
            }
            set
            {
                this._isByteModified = value;

                UpdateBackGround();
            }
        }

        public bool ReadOnlyMode
        {
            get
            {
                return _readOnlyMode;
            }
            set
            {
                _readOnlyMode = value;
            }
        }


        /// <summary>
        /// Get the hex string representation of this byte
        /// </summary>
        public string HexString
        {
            get
            {
                return ((string)FirstHexChar.Content + (string)SecondHexChar.Content).ToString();
            }
        }

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }

            set
            {
                _isSelected = value;

                _keyDownLabel = KeyDownLabel.FirstChar;

                UpdateBackGround();
            }
        }
        
        /// <summary>
        /// Update Background
        /// </summary>
        private void UpdateBackGround()
        {
            if (_isSelected)
            {
                FirstHexChar.Foreground = Brushes.White;
                SecondHexChar.Foreground = Brushes.White;
                this.Background = Brushes.Blue;
            }
            else if (_isByteModified)
            {
                this.Background = Brushes.LightGray;
                FirstHexChar.Foreground = Brushes.Black;
                SecondHexChar.Foreground = Brushes.Black;
            }
            else
            {
                this.Background = Brushes.Transparent;
                FirstHexChar.Foreground = Brushes.Black;
                SecondHexChar.Foreground = Brushes.Black;
            }
        }

        private void UpdateLabelFromByte()
        {
            if (_byte != null)
            {
                string hexabyte = Converters.ByteToHex(_byte.Value);

                FirstHexChar.Content = hexabyte.Substring(0, 1);
                SecondHexChar.Content = hexabyte.Substring(1, 1);
            }else
            {
                FirstHexChar.Content = "";
                SecondHexChar.Content = "";
            }
        }

        private void HexChar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.Focus();

                if (Click != null)
                    Click(this, e);
            }
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ReadOnlyMode)
                if (KeyValidator.IsHexKey(e.Key))
                {
                    string key;
                    if (KeyValidator.IsNumericKey(e.Key))
                        key = KeyValidator.GetDigitFromKey(e.Key).ToString();
                    else
                        key = e.Key.ToString().ToLower();

                    switch (_keyDownLabel)
                    {
                        case KeyDownLabel.FirstChar:
                            FirstHexChar.Content = key;
                            _keyDownLabel = KeyDownLabel.SecondChar;
                            break;
                        case KeyDownLabel.SecondChar:
                            SecondHexChar.Content = key;
                            _keyDownLabel = KeyDownLabel.NextPosition;

                            //Move focus event
                            if (MoveNext != null)
                                MoveNext(this, new EventArgs());
                            break;
                    }
                    
                    IsByteModified = true;
                    Byte = Converters.HexToByte(FirstHexChar.Content.ToString() + SecondHexChar.Content.ToString())[0];                    
                }
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            if (_byte != null)
                if (!IsByteModified && !_isSelected)
                    this.Background = Brushes.SlateGray;

            if (e.LeftButton == MouseButtonState.Pressed)
                if (MouseSelection != null)
                    MouseSelection(this, e);
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            if (_byte != null)
                if (!IsByteModified && !_isSelected)
                    this.Background = Brushes.Transparent;
        }
    }
}