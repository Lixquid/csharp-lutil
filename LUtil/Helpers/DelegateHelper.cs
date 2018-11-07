using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using LUtil.Helpers.Extensions;

namespace LUtil.Helpers {
    [PublicAPI]
    public static class DelegateHelper {
        /// <summary>
        ///     Returns an enumerable of results from invoking all delegates in
        ///     a multi-cast delegate.
        /// </summary>
        /// <param name="delegate">The multi-cast delegate to invoke.</param>
        /// <param name="args">Arguments to pass to the delegates.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="delegate"/> is <c>null</c>.
        /// </exception>
        public static IEnumerable<object> InvokeAll([NotNull] MulticastDelegate @delegate, params object[] args) {
            @delegate.ThrowIfNull(nameof(@delegate));
            return @delegate.GetInvocationList()
                .Select(del => del.DynamicInvoke(args));
        }

        #region Func Overloads
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<TResult>([NotNull] Func<TResult> func) {
            func.ThrowIfNull(nameof(func));
            return func.GetInvocationList().Cast<Func<TResult>>()
                .Select(f => f.Invoke());
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T, TResult>([NotNull] Func<T, TResult> func, T arg1) {
            func.ThrowIfNull(nameof(func));
            return func.GetInvocationList().Cast<Func<T, TResult>>()
                .Select(f => f.Invoke(arg1));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, TResult>([NotNull] Func<T1, T2, TResult> func, T1 arg1, T2 arg2) {
            func.ThrowIfNull(nameof(func));
            return func.GetInvocationList().Cast<Func<T1, T2, TResult>>()
                .Select(f => f.Invoke(arg1, arg2));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, TResult>([NotNull] Func<T1, T2, T3, TResult> func, T1 arg1, T2 arg2, T3 arg3) {
            func.ThrowIfNull(nameof(func));
            return func.GetInvocationList().Cast<Func<T1, T2, T3, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, TResult>([NotNull] Func<T1, T2, T3, T4, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
            func.ThrowIfNull(nameof(func));
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, TResult>([NotNull] Func<T1, T2, T3, T4, T5, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
            func.ThrowIfNull(nameof(func));
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, TResult>([NotNull] Func<T1, T2, T3, T4, T5, T6, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) {
            func.ThrowIfNull(nameof(func));
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, TResult>([NotNull] Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) {
            func.ThrowIfNull(nameof(func));
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, TResult>([NotNull] Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) {
            func.ThrowIfNull(nameof(func));
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>([NotNull] Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) {
            func.ThrowIfNull(nameof(func));
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>([NotNull] Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) {
            func.ThrowIfNull(nameof(func));
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>([NotNull] Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) {
            func.ThrowIfNull(nameof(func));
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>([NotNull] Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) {
            func.ThrowIfNull(nameof(func));
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>([NotNull] Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) {
            func.ThrowIfNull(nameof(func));
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>([NotNull] Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) {
            func.ThrowIfNull(nameof(func));
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>([NotNull] Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) {
            func.ThrowIfNull(nameof(func));
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>([NotNull] Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16) {
            func.ThrowIfNull(nameof(func));
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16));
        }
        #endregion
    }
}
