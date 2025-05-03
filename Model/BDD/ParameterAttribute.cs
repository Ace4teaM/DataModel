namespace DataModel.Model.BDD
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class ParameterAttribute : System.Attribute
    {
        public enum ParameterMode
        {
            Input,
            Output
        }

        public ParameterMode? Mode { get; set; }
        
        public ParameterAttribute(ParameterMode? mode)
        {
            Mode = mode;
        }
    }
    public class InputParameterAttribute : ParameterAttribute
    {
        public InputParameterAttribute() : base(ParameterMode.Input)
        {
        }
    }
    public class OutputParameterAttribute : ParameterAttribute
    {
        public OutputParameterAttribute() : base(ParameterMode.Output)
        {
        }
    }
}
