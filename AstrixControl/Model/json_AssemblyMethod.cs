namespace AstrixControl.Model.JsonObjects
{
    public class json_AssemblyMethod : json_BaseJsonObject
    {
        public json_AssemblyMethod()
        {
            Description = "method";
        }
        public string AssemblyMethodName
        {
            get; set;
        }

    }
}
