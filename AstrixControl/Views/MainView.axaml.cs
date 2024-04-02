using AstrixControl.Model.JsonObjects;
using AstrixControl.Module;
using Avalonia.Controls;
using Newtonsoft.Json;
using System.Text;

namespace AstrixControl.Views;

public partial class MainView : UserControl
{
    private NetUdpClient netUdpClient = new NetUdpClient()
    {
        EnableBroadcast = true,

    };
    public MainView()
    {
        InitializeComponent();

        _button.Click += _button_Click;
        _button2.Click += _button2_Click;
    }

    private async void _button2_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string json = JsonConvert.SerializeObject(new json_AssemblyMethod()
        {
            AssemblyMethodName = "TestLib.Test.Hide" // "TestLib.Test.Hide"
        });
        netUdpClient.SendString(json, null);


        var v = await netUdpClient.ReceiveAsync();
        _text_box.Text = Encoding.UTF8.GetString(v.Buffer); ;
    }

    private async void _button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {


        string json = JsonConvert.SerializeObject(new json_AssemblyMethod()
        {
            AssemblyMethodName = "TestLib.Test.Show" // "TestLib.Test.Hide"
        });
        netUdpClient.SendString(json, null);


        var v = await netUdpClient.ReceiveAsync();
        _text_box.Text = Encoding.UTF8.GetString(v.Buffer); ;



    }
}
