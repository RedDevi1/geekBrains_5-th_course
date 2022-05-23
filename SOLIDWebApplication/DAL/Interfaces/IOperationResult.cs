using System.Collections.Generic;

namespace SOLIDWebApplication.DAL.Interfaces
{
    public interface IOperationResult <TResult>
    {
        //TResult Result { get; }
        IReadOnlyList<IOperationFailure> Failures { get; }
        bool Succeed { get; }

    }
}
