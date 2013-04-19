namespace ValidationVisitor
{
    public interface IValidatable<out T>
    {
        bool IsValid(IValidator<T> validator);
    }
}