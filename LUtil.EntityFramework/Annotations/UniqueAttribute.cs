using System;
using JetBrains.Annotations;

namespace LUtil.EntityFramework.Annotations {
    /// <summary>
    ///     Creates a new Unique Index on the specified column. If multiple
    ///     column names are given, a compound index will be created.
    /// </summary>
    [PublicAPI, AttributeUsage(AttributeTargets.Property)]
    public class UniqueAttribute : Attribute {
        public string[] Columns { get; set; }

        public UniqueAttribute() { }

        public UniqueAttribute(params string[] columns) {
            Columns = columns;
        }
    }
}
