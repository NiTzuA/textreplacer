using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace textreplacernitzua
{
    public partial class Form1 : Form
    {
        public class KeyboardHook : IDisposable
        {
            public event Action<Keys> KeyPressed;
            private const int WH_KEYBOARD_LL = 13; // Low-level keyboard hook
            private const int WM_KEYDOWN = 0x0100; // Keydown event code

            private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

            // Import DLLs for Windows API
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);

            private IntPtr _hookID = IntPtr.Zero;
            private LowLevelKeyboardProc _proc;

            public KeyboardHook()
            {
                _proc = HookCallback;
                _hookID = SetHook(_proc);
            }

            private IntPtr SetHook(LowLevelKeyboardProc proc)
            {
                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
                }
            }

            private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    Keys key = (Keys)vkCode;
                    KeyPressed?.Invoke(key); // Trigger the event
                }
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }

            public void Dispose()
            {
                UnhookWindowsHookEx(_hookID);
            }
        }

        private KeyboardHook _hook;

        public Form1()
        {
            InitializeComponent();
        }

        private static char? KeyToChar(Keys key, bool shiftPressed)
        {
            if (key >= Keys.A && key <= Keys.Z)
            {
                return shiftPressed ? (char)key : char.ToLower((char)key);
            }
            else if (key >= Keys.D0 && key <= Keys.D9 && !shiftPressed)
            {
                return (char)(key - Keys.D0 + '0');
            }
            else if (shiftPressed)
            {
                return key switch
                {
                    Keys.D1 => '!',
                    Keys.D2 => '@',
                    Keys.D3 => '#',
                    Keys.D4 => '$',
                    Keys.D5 => '%',
                    Keys.D6 => '^',
                    Keys.D7 => '&',
                    Keys.D8 => '*',
                    Keys.D9 => '(',
                    Keys.D0 => ')',
                    Keys.OemMinus => '_',
                    Keys.Oemplus => '+',
                    Keys.OemOpenBrackets => '{',
                    Keys.OemCloseBrackets => '}',
                    Keys.OemPipe => '|',
                    Keys.OemSemicolon => ':',
                    Keys.OemQuotes => '"',
                    Keys.Oemcomma => '<',
                    Keys.OemPeriod => '>',
                    Keys.OemQuestion => '?',
                    _ => null 
                };
            }
            else
            {
                return key switch
                {
                    Keys.D1 => '1',
                    Keys.D2 => '2',
                    Keys.D3 => '3',
                    Keys.D4 => '4',
                    Keys.D5 => '5',
                    Keys.D6 => '6',
                    Keys.D7 => '7',
                    Keys.D8 => '8',
                    Keys.D9 => '9',
                    Keys.D0 => '0',
                    Keys.OemMinus => '-',
                    Keys.Oemplus => '=',
                    Keys.OemOpenBrackets => '[',
                    Keys.OemCloseBrackets => ']',
                    Keys.OemPipe => '\\',
                    Keys.OemSemicolon => ';',
                    Keys.OemQuotes => '\'',
                    Keys.Oemcomma => ',',
                    Keys.OemPeriod => '.',
                    Keys.OemQuestion => '/',
                    Keys.Space => ' ',
                    Keys.Enter => '\n',
                    Keys.Tab => '\t',
                    _ => null 
                };
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            MessageBox.Show("Stopped replacing text");
            _hook.Dispose();
        }

        private void startButton_Click_1(object sender, EventArgs e)
        {
            List<char> charQueue = new List<char>(); // replace this with a List, so that we can both do FIFO and LIFO
            String normalText = normalTextBox.Text;
            String replaceText = replaceTextBox.Text;
            int textLength = normalText.Length;
            startButton.Enabled = false;

            MessageBox.Show(normalText + " will now be replaced with " + replaceText);

            _hook = new KeyboardHook();
            _hook.KeyPressed += (key) =>
            {
                bool shiftPressed = (Control.ModifierKeys & Keys.Shift) != 0;
                char? keyChar = KeyToChar(key, shiftPressed);
                
                if (keyChar.HasValue && key != Keys.Back)
                {
                    charQueue.Add(keyChar.Value);
                    while (charQueue.Count > textLength)
                    {
                        charQueue.RemoveAt(0);
                    }
                    if (new String(charQueue.ToArray()) == normalText)
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            for (int i = 0; i < calculateBackspaces(normalText); i++)
                            {
                                SendKeys.Send("^{BACKSPACE}");
                            }
                            Clipboard.SetText(replaceText);
                            SendKeys.Send("^v");
                        });
                    }
                } else if (key == Keys.Back && charQueue.Count > 0)
                {
                    charQueue.RemoveAt(charQueue.Count - 1);
                }
            };
        }

        private int calculateBackspaces(string text)
        {
            if (text.Length == 0) return 0;
            int backSpaceCount = 0;
            bool inWord = false;
            HashSet<char> backSpaceDelimiters = new HashSet<char>()
            {
                {' '},
                { '-' },
                { '/' },
                { '.' },
                { '_' },
                { ':' },
                { ',' },
                { ';' },
                { '=' },
                { '(' },
                { ')' },
                { '[' },
                { ']' },
                { '{' },
                { '}' },
                { '!' },
                { '@' },
                { '#' },
                { '$' },
                { '%' },
                { '&' },
                { '*' },
                { '+' },
                { '^' },
                { '\\' },
            };

            for (int i = 0; i < text.Length; i++)
            {
                if (!backSpaceDelimiters.Contains(text[i])) {
                    if (!inWord)
                    {
                        inWord = true;
                        backSpaceCount++;
                    }
                }
                else
                {
                    inWord = false;
                }
            } 
            return backSpaceCount;
        }

        private void normalTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void replaceTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}