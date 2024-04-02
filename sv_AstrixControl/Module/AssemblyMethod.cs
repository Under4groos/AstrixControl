using System.Reflection;

namespace sv_AstrixControl.Module
{
    public class AssemblyMethod
    {
        public string Name { get; set; }
        public List<string> Attributes { get; set; } = new List<string>();

        public MethodInfo methodInfo { get; set; }

        public void Invoke()
        {

        }

        public AssemblyMethod() { }
    }
}
