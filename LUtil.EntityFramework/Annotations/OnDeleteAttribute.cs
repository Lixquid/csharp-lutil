using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace LUtil.EntityFramework.Annotations {
    /// <summary>
    ///     Modifies the <c>ON DELETE</c> action for a column.
    /// </summary>
    [PublicAPI, AttributeUsage(AttributeTargets.Property)]
    public class OnDeleteAttribute : Attribute {
        public DeleteBehavior Behavior { get; }

        public OnDeleteAttribute(DeleteBehavior behavior) {
            Behavior = behavior;
        }
    }
}
