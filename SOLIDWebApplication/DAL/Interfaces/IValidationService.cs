using System.Collections.Generic;

namespace SOLIDWebApplication.DAL.Interfaces
{
    public interface IValidationService<TEntity> where TEntity : class
    {
        IReadOnlyList<IOperationFailure> ValidateEntity(TEntity item);
    }
}
