using SOLIDWebApplication.DAL.Interfaces;
using System.Collections.Generic;

namespace SOLIDWebApplication.Validation
{
    public class OperationResult<TResult> : IOperationResult<TResult>
    {
        public IReadOnlyList<IOperationFailure> Failures { get; set; }

        public bool Succeed { get; set; }

        public OperationResult(IReadOnlyList<IOperationFailure> failures)
        {
            Failures = failures == null ? new List<IOperationFailure>() : failures;
            Succeed = Failures.Count > 0 ? false : true;
        }
    }
}
