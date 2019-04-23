using System;
using JetBrains.Annotations;

namespace LUtil.EntityFramework.Annotations {
    /// <summary>
    ///     Adds a Primary Key to an entity comprised of all properties with
    ///     this attribute.
    /// </summary>
    [PublicAPI, AttributeUsage(AttributeTargets.Property)]
    public class CompoundKeyAttribute : Attribute {
        public int Order { get; }

        public CompoundKeyAttribute(int order = 0) {
            Order = order;
        }
    }
}
