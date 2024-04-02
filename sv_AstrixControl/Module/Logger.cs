using System.Diagnostics;

namespace sv_AstrixControl.Module
{
    public static class Logger
    {
        public static void Append(string data)
        {
            Console.WriteLine(data);
            Debug.WriteLine(data);
        }
    }
}
