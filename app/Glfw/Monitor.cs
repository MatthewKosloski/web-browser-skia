using System.Runtime.InteropServices;

namespace Glfw
{
    /// <summary>
    ///     Wrapper around a pointer to monitor.
    /// </summary>
    /// <seealso cref="Monitor" />
    [StructLayout(LayoutKind.Sequential)]
    public struct Monitor : IEquatable<Monitor>
    {
        /// <summary>
        ///     Represents a <c>null</c> value for a <see cref="Monitor" /> object.
        /// </summary>
        public static readonly Monitor None;

        /// <summary>
        ///     Internal pointer.
        /// </summary>
        private readonly IntPtr handle;

        /// <summary>
        ///     Determines whether the specified <see cref="Monitor" />, is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="Monitor" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Monitor other) { return handle.Equals(other.handle); }

        /// <summary>
        ///     Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Monitor monitor)
                return Equals(monitor);
            return false;
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() { return handle.GetHashCode(); }

        /// <summary>
        ///     Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator ==(Monitor left, Monitor right) { return left.Equals(right); }

        /// <summary>
        ///     Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator !=(Monitor left, Monitor right) { return !left.Equals(right); }

        /// <summary>
        ///     Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() { return handle.ToString(); }
    }
}