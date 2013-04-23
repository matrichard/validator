namespace Validator.Test
{
    using ValidationVisitor;

    public class Entity2 : IValidatable<Entity2>
    {
        public string StringProperty2 { get; set; }
        public int IntProperty2 { get; set; }
        public object ObjectProperty2 { get; set; }

        public double DoubleProperty2 { get; set; }

        public bool IsValid(IValidator<Entity2> validator)
        {
            return validator.Validate(this);
        }
    }
}
