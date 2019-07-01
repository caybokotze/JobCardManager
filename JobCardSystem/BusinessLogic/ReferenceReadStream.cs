using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace JobCardSystem.BusinessLogic
{
    internal class ReferenceReadStream : Stream
    {
        private readonly Stream _inner;
        private readonly long _innerOffset;
        private readonly long _length;
        private long _position;
        private bool _disposed;

        public ReferenceReadStream(Stream inner, long offset, long length)
        {
            if (inner == null)
                throw new ArgumentNullException(nameof(inner));
            this._inner = inner;
            this._innerOffset = offset;
            this._length = length;
            this._inner.Position = offset;
        }

        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return this._inner.CanSeek;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        public override long Length
        {
            get
            {
                return this._length;
            }
        }

        public override long Position
        {
            get
            {
                return this._position;
            }
            set
            {
                this.ThrowIfDisposed();
                if (value < 0L || value > this.Length)
                    throw new ArgumentOutOfRangeException(nameof(value), (object)value, "The Position must be within the length of the Stream: " + this.Length.ToString());
                this.VerifyPosition();
                this._position = value;
                this._inner.Position = this._innerOffset + this._position;
            }
        }

        private void VerifyPosition()
        {
            if (this._inner.Position != this._innerOffset + this._position)
                throw new InvalidOperationException("The inner stream position has changed unexpectedly.");
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    this.Position = offset;
                    break;
                case SeekOrigin.End:
                    this.Position = this.Length + offset;
                    break;
                default:
                    this.Position += offset;
                    break;
            }
            return this.Position;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            this.ThrowIfDisposed();
            this.VerifyPosition();
            long num1 = Math.Min((long)count, this._length - this._position);
            int num2 = this._inner.Read(buffer, offset, (int)num1);
            this._position += (long)num2;
            return num2;
        }

        public override async Task<int> ReadAsync(
          byte[] buffer,
          int offset,
          int count,
          CancellationToken cancellationToken)
        {
            this.ThrowIfDisposed();
            this.VerifyPosition();
            long num1 = Math.Min((long)count, this._length - this._position);
            int num2 = await this._inner.ReadAsync(buffer, offset, (int)num1, cancellationToken);
            this._position += (long)num2;
            return num2;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override Task WriteAsync(
          byte[] buffer,
          int offset,
          int count,
          CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Flush()
        {
            throw new NotSupportedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposing)
                return;
            this._disposed = true;
        }

        private void ThrowIfDisposed()
        {
            if (this._disposed)
                throw new ObjectDisposedException(nameof(ReferenceReadStream));
        }
    }
}