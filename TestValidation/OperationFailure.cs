using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestValidation
{
    public sealed class OperationFailure : IOperationFailure
    {
        public string PropertyName { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}
