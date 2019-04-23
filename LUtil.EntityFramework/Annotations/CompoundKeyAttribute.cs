using System;
using JetBrains.Annotations;

namespace LUtil.EntityFramework.Annotations {
    [PublicAPI, AttributeUsage(AttributeTargets.Property)]
    public class CompoundKeyAttribute : Attribute {
        public int Order { get; }

        public CompoundKeyAttribute(int order = 0) {
            Order = order;
        }
    }
}
