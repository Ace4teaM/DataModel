using System.Runtime.CompilerServices;

namespace DataModel.Model.BDD
{
    public class FieldAttribute : ColumnAttribute
    {
        public string? SQLName { get; set; }
        public FieldAttribute([CallerMemberName] string? sqlName = null) { SQLName = sqlName; }
    }
}
