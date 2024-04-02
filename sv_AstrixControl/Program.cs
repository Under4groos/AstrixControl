// See https://aka.ms/new-console-template for more information
using System.Reflection;
object build(MethodInfo methodInfo, Type type, object[] parameters)
{
    var initiatedObject = Activator.CreateInstance(type);
    return methodInfo.Invoke(initiatedObject, parameters);
}



while (true)
{

    try
    {



        Assembly assembly = Assembly.LoadFile(@"C:\Users\UnderKo\source\repos\AstrixControl\TestLib\bin\Debug\net8.0\TestLib.dll");

        foreach (Type item in assembly.GetTypes())
        {
            var properties = item.GetProperties();
            foreach (MethodInfo _MethodInfo in item.GetMethods())
            {
                if (_MethodInfo.Name.StartsWith("Show"))
                    build(_MethodInfo, item, new[] { "asddas" });


                var v = _MethodInfo.GetCustomAttributes(false).First().GetType().Name;
                Console.WriteLine(_MethodInfo.Name);
            }
        }



        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }


    Console.ReadKey();
}