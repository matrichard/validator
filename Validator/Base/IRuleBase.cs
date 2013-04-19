namespace Validator.Base
{
    public interface IRuleBase<in TEntity>
    {
        bool IsValid(TEntity entity);
    }
}