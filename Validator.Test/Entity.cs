namespace Validator.Test
{
    using ValidationVisitor;

    public class Entity:IValidatable<Entity>
    {
        public string StringProperty { get; set; }
        public int IntProperty { get; set; }
        public object ObjectProperty { get; set; }

        public double DoubleProperty { get; set; }

        public Entity2 Entity2 { get; set; }

        public bool IsValid(IValidator<Entity> validator)
        {
            return validator.Validate(this);
        }
    }
}