using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace sv_AstrixControl.Module
{
    public class AssemblyLoader : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public Action EventLoaded;
        public Dictionary<string, string> MethodLoaded = new System.Collections.Generic.Dictionary<string, string>();
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

        public void Load(string pathdllfile)
        {
            if (!File.Exists(pathdllfile))
                return;
            DLLFile = new FileInfo(pathdllfile);
            if (!DLLFile.Extension.ToLower().EndsWith(".dll"))
                return;
            try
            {
                Assembly assembly = Assembly.LoadFile(pathdllfile);

                foreach (Type item in assembly.GetTypes())
                {
                    var properties = item.GetProperties();
                    foreach (MethodInfo _MethodInfo in item.GetMethods())
                    {
                        //if (_MethodInfo.Name.StartsWith("Show"))
                        //{

                        //}
                        //build(_MethodInfo, item, new[] { "asddas" });


                        var v = _MethodInfo.GetCustomAttributes(false).First().GetType().Name;
                        Console.WriteLine(_MethodInfo.Name);
                    }
                }



                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();


                OnEventLoaded();
            }
            catch (Exception e)
            {

                Logger.Append(e.Message);
            }

        }
    }
}
