using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using LUtil.Helpers.Extensions;
using DimensionalConstructor = System.Func<decimal, System.Collections.Generic.IEnumerable<sbyte>, LUtil.Numerics.Dimension.DimensionalValue>;

namespace LUtil.Numerics.Dimension {
    [PublicAPI]
    public class DimensionalValue : IEquatable<DimensionalValue> {
        public decimal Magnitude { get; }
        public IReadOnlyList<sbyte> Dimensions { get; }

        public DimensionalValue(decimal magnitude, params sbyte[] dimensions) {
            Magnitude = magnitude;
            Dimensions = Array.AsReadOnly(dimensions);
        }

        public DimensionalValue(decimal magnitude, IEnumerable<sbyte> dimensions) : this(magnitude, dimensions.ToArray()) { }

        public bool IsCommensurable([NotNull] DimensionalValue other) {
            other.ThrowIfNull(nameof(other));
            return Dimensions.SequenceEqual(other.Dimensions);
        }

        private void AssertCommensurable(DimensionalValue other) {
            if (!IsCommensurable(other))
                throw new ArithmeticException($"Other Dimensional Value is not commensurable: {this} != {other}");
        }

        #region Arithmetic Operations
        protected DimensionalValue Add([NotNull] DimensionalValue other, [NotNull] DimensionalConstructor constructor) {
            other.ThrowIfNull(nameof(other));
            constructor.ThrowIfNull(nameof(constructor));
            AssertCommensurable(other);

            return constructor(Magnitude + other.Magnitude, Dimensions);
        }
        protected DimensionalValue Subtract([NotNull] DimensionalValue other, [NotNull] DimensionalConstructor constructor) {
            other.ThrowIfNull(nameof(other));
            constructor.ThrowIfNull(nameof(constructor));
            AssertCommensurable(other);

            return constructor(Magnitude - other.Magnitude, Dimensions);
        }
        protected DimensionalValue Multiply([NotNull] DimensionalValue other, [NotNull] DimensionalConstructor constructor) {
            other.ThrowIfNull(nameof(other));
            constructor.ThrowIfNull(nameof(constructor));

            return constructor(Magnitude * other.Magnitude,
                Dimensions.Zip(other.Dimensions, (x, y) => (sbyte)(x + y)));
        }
        protected DimensionalValue Divide([NotNull] DimensionalValue other, [NotNull] DimensionalConstructor constructor) {
            other.ThrowIfNull(nameof(other));
            constructor.ThrowIfNull(nameof(constructor));

            return constructor(Magnitude * other.Magnitude,
                Dimensions.Zip(other.Dimensions, (x, y) => (sbyte)(x - y)));
        }

        protected DimensionalValue Add(decimal value, [NotNull] DimensionalConstructor constructor) {
            constructor.ThrowIfNull(nameof(constructor));

            return constructor(Magnitude + value, Dimensions);
        }
        protected DimensionalValue Subtract(decimal value, [NotNull] DimensionalConstructor constructor) {
            constructor.ThrowIfNull(nameof(constructor));

            return constructor(Magnitude - value, Dimensions);
        }
        protected DimensionalValue Multiply(decimal factor, [NotNull] DimensionalConstructor constructor) {
            constructor.ThrowIfNull(nameof(constructor));

            return constructor(Magnitude * factor, Dimensions);
        }
        protected DimensionalValue Divide(decimal factor, [NotNull] DimensionalConstructor constructor) {
            constructor.ThrowIfNull(nameof(constructor));

            return constructor(Magnitude / factor, Dimensions);
        }
        #endregion

        #region Equality
        public virtual bool Equals(DimensionalValue other) {
            if (other is null) return false;
            return Magnitude == other.Magnitude && Dimensions.SequenceEqual(other.Dimensions);
        }

        public override bool Equals(object obj) {
            if (obj is null) return false;
            if (!(obj is DimensionalValue)) return false;
            return Equals((DimensionalValue)obj);
        }

        public override int GetHashCode() {
            unchecked {
                return (Magnitude.GetHashCode() * 397) ^ Dimensions.GetHashCode();
            }
        }

        public static bool operator ==(DimensionalValue left, DimensionalValue right) {
            return Equals(left, right);
        }

        public static bool operator !=(DimensionalValue left, DimensionalValue right) {
            return !Equals(left, right);
        }
        #endregion
    }
}
