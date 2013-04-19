namespace ValidationVisitor
{
    public interface IValidator<in T>
    {
        bool Validate(T e);
    }
}