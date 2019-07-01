using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace JobCardSystem.BusinessLogic
{
    internal struct HashCodeCombiner
    {
        private long _combinedHash64;

        public int CombinedHash
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this._combinedHash64.GetHashCode();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private HashCodeCombiner(long seed)
        {
            this._combinedHash64 = seed;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(IEnumerable e)
        {
            if (e == null)
            {
                this.Add(0);
            }
            else
            {
                int i = 0;
                foreach (object o in e)
                {
                    this.Add(o);
                    ++i;
                }
                this.Add(i);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int(HashCodeCombiner self)
        {
            return self.CombinedHash;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(int i)
        {
            this._combinedHash64 = (this._combinedHash64 << 5) + this._combinedHash64 ^ (long)i;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(string s)
        {
            this.Add(s != null ? s.GetHashCode() : 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(object o)
        {
            this.Add(o != null ? o.GetHashCode() : 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add<TValue>(TValue value, IEqualityComparer<TValue> comparer)
        {
            this.Add((object)value != null ? comparer.GetHashCode(value) : 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HashCodeCombiner Start()
        {
            return new HashCodeCombiner(5381L);
        }
    }
}