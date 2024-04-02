using System.Diagnostics;

namespace TestLib
{
    public class Test
    {

        public string Show(string data)
        {
            data = "Show:   " + data;
            Debug.WriteLine(data);
            Console.WriteLine(data);
            return data;
        }
        public string Hide(string data)
        {
            data = "Hide:   " + data;
            Debug.WriteLine(data);
            Console.WriteLine(data);
            return data;
        }

    }
}
