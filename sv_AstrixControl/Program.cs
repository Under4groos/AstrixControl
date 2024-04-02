
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






ThreadUdpClient threadUdpClient = new ThreadUdpClient(8888);
threadUdpClient.EvRequestData += (IPAddress adres, string data) =>
{
    // json 
    assemblyLoader.RunMethod("TestLib.Test.Show", new[] { data });
    Console.WriteLine(adres.ToString() + data);
};
threadUdpClient.Init();
//while (true)
//{
//    foreach (var item in assemblyLoader.MethodLoaded)
//    {
//        Console.WriteLine($"{item.Key}");
//    }

//    assemblyLoader.RunMethod("TestLib.Test.dShow", new[] { "sad" });

//    Console.ReadKey();
//}