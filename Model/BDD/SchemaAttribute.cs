namespace DataModel.Model.BDD
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class SchemaAttribute : System.Attribute
    {
        public string? SQLName { get; set; }
        public SchemaAttribute(string? sqlName = null) { SQLName = sqlName; }
    }
}
