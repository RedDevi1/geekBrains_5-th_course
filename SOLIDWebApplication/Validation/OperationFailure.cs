﻿using SOLIDWebApplication.DAL.Interfaces;

namespace SOLIDWebApplication.Validation
{
    public sealed class OperationFailure : IOperationFailure
    {
        public string PropertyName { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}
