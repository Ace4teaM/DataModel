namespace DataModel.Model.BDD
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class NameAttribute : System.Attribute
    {
        public string? SQLName { get; set; }
        public NameAttribute(string? sqlName = null) { SQLName = sqlName; }
    }
}
