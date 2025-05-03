namespace DataModel.Model.BDD
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class DefaultAttribute : System.Attribute
    {
        /// <summary>
        ///  Représente le mot clé 'default' dans SQL Server
        /// </summary>
        public struct DefaultKeyWord {
            public override string ToString()
            {
                return "DEFAULT";
            }
        }
        public static readonly DefaultKeyWord DefaultValue = new DefaultKeyWord();

        public object Value;
        public DefaultAttribute()
        {
            Value = DefaultValue;
        }
        public DefaultAttribute(object value)
        {
            Value = value;
        }
    }
}
