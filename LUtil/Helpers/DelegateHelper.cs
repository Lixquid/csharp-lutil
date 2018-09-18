using System;
using System.Collections.Generic;
using System.Linq;

namespace LUtil.Helpers {
    public static class DelegateHelper {
        /// <summary>
        ///     Returns an enumerable of results form invoking all delegates in
        ///     a multi-cast delegate.
        /// </summary>
        /// <param name="delegate">The multi-cast delegate to invoke.</param>
        /// <param name="args">Arguments to pass to the delegates.</param>
        public static IEnumerable<object> InvokeAll(MulticastDelegate @delegate, params object[] args) {
            return @delegate.GetInvocationList()
                .Select(del => del.DynamicInvoke(args));
        }

        #region Func Overloads
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<TResult>(Func<TResult> func) {
            return func.GetInvocationList().Cast<Func<TResult>>()
                .Select(f => f.Invoke());
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T, TResult>(Func<T, TResult> func, T arg1) {
            return func.GetInvocationList().Cast<Func<T, TResult>>()
                .Select(f => f.Invoke(arg1));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, TResult>(Func<T1, T2, TResult> func, T1 arg1, T2 arg2) {
            return func.GetInvocationList().Cast<Func<T1, T2, TResult>>()
                .Select(f => f.Invoke(arg1, arg2));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func, T1 arg1, T2 arg2, T3 arg3) {
            return func.GetInvocationList().Cast<Func<T1, T2, T3, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) {
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) {
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) {
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) {
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) {
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) {
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) {
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) {
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) {
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) {
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15));
        }
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16) {
            return func.GetInvocationList().Cast<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>>()
                .Select(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16));
        }
        #endregion
    }
}
