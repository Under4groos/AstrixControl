
using Newtonsoft.Json;
using sv_AstrixControl.Model.JsonObjects;
using sv_AstrixControl.Module;
using System.Net;
AssemblyLoader assemblyLoader = new AssemblyLoader();

string _directory = Path.GetFullPath("Libs");
if (!Directory.Exists(_directory))
    Directory.CreateDirectory(_directory);

Console.WriteLine($"Loading libs...");
foreach (string item in Directory.GetFiles(_directory, "*.dll", SearchOption.AllDirectories))
{
    Console.WriteLine($"Load: {item}");
    if (assemblyLoader.Load(item))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error load: {item}");
        Console.ForegroundColor = ConsoleColor.White;
    }

}


ThreadUdpClient threadUdpClient = new ThreadUdpClient(8881);
threadUdpClient.EvRequestData += (IPAddress adres, string data) =>
{
    json_AssemblyMethod json_object = JsonConvert.DeserializeObject<json_AssemblyMethod>(data);


    if (json_object != null)
    {
        if (assemblyLoader.RunMethod(json_object.AssemblyMethodName, new[] { data }, (obj) =>
        {
            threadUdpClient.Send(obj.ToString());
        }))
        {

        }
        else
        {
            threadUdpClient.Send("-");
        }

    }
};
threadUdpClient.Init();
