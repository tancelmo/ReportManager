using System.Windows.Input;

namespace ReportManager
{
    public class SendKeys
    {
        public static void Send(Key key)
        { //Found online
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key)
            {
                RoutedEvent = Mouse.MouseEnterEvent
            };
            InputManager.Current.ProcessInput(e);
        }

    }
}
