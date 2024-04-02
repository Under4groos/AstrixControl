using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace sv_AstrixControl.Module
{
    public class AssemblyLoader : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public Action EventLoaded;
        public Dictionary<string, AssemblyMethod> MethodLoaded = new System.Collections.Generic.Dictionary<string, AssemblyMethod>();
        public void OnEventLoaded()
        {
            if (EventLoaded != null)
                EventLoaded();
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public FileInfo DLLFile
        {
            get; set;
        }

        public bool RunMethod(string name, object?[]? objects, Action<object> Event_Return)
        {
            if (!MethodLoaded.ContainsKey(name))
            {
                Logger.Append($"Error! {name}");
                return false;
            }
            try
            {
                var v_ = MethodLoaded[name].Invoke(objects);
                if (Event_Return != null)
                {
                    Event_Return(v_);
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;

        }

        public bool Load(string pathdllfile)
        {
            if (!File.Exists(pathdllfile))
                return true;
            DLLFile = new FileInfo(pathdllfile);
            if (!DLLFile.Extension.ToLower().EndsWith(".dll"))
                return true;
            try
            {
                Assembly assembly = Assembly.LoadFile(pathdllfile);

                foreach (Type item in assembly.GetTypes())
                {
                    var properties = item.GetProperties();
                    foreach (MethodInfo _MethodInfo in item.GetMethods())
                    {
                        AssemblyMethod assemblyMethod = new AssemblyMethod()
                        {
                            Name = _MethodInfo.Name,
                            Attributes = (from atr in _MethodInfo.GetCustomAttributes(false) select atr.GetType().Name).ToList(),
                            methodInfo = _MethodInfo,
                            TypeMethod = item
                        };

                        MethodLoaded.Add($"{_MethodInfo.DeclaringType.FullName}.{_MethodInfo.Name}", assemblyMethod);


                    }
                }



                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();


                OnEventLoaded();
                return false;
            }
            catch (Exception e)
            {

                Logger.Append(e.Message);
            }
            return true;
        }
    }
}
