using System.Reflection;

namespace sv_AstrixControl.Module
{
    public class AssemblyMethod
    {
        public string Name { get; set; }
        public List<string> Attributes { get; set; } = new List<string>();
        public MethodInfo methodInfo { get; set; }
        public Type TypeMethod { get; set; }

        public object Invoke(object?[]? parametrs)
        {
            var initiatedObject = Activator.CreateInstance(TypeMethod);
            return methodInfo.Invoke(initiatedObject, parametrs);
        }

        public AssemblyMethod() { }
    }
}
