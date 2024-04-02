using System.Diagnostics;

namespace TestLib
{
    public class Test
    {

        public string Show(string data)
        {
            Debug.WriteLine(data);
            Console.WriteLine(data);
            return data;
        }


    }
}
