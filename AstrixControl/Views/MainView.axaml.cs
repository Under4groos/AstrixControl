using AstrixControl.Module;
using Avalonia.Controls;
using System.Diagnostics;

namespace AstrixControl.Views;

public partial class MainView : UserControl
{
    private NetUdpClient netUdpClient = new NetUdpClient()
    {
        EnableBroadcast = true
    };
    public MainView()
    {
        InitializeComponent();

        _button.Click += _button_Click;
    }

    private void _button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Debug.WriteLine("asdas");

        netUdpClient.SendString("asdas", null);
    }
}
