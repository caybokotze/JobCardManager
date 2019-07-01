using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;

namespace JobCardSystem.BusinessLogic
{
    public class FormFile : IFormFile
    {
        private const int DefaultBufferSize = 81920;
        private readonly Stream _baseStream;
        private readonly long _baseStreamOffset;

        public FormFile(
            Stream baseStream,
            long baseStreamOffset,
            long length,
            string name,
            string fileName)
        {
            this._baseStream = baseStream;
            this._baseStreamOffset = baseStreamOffset;
            this.Length = length;
            this.Name = name;
            this.FileName = fileName;
        }

        public string ContentDisposition
        {
            get
            {
                return (string)this.Headers["Content-Disposition"];
            }
            set
            {
                this.Headers["Content-Disposition"] = (String)value;
            }
        }

        public string ContentType
        {
            get
            {
                return (string)this.Headers["Content-Type"];
            }
            set
            {
                this.Headers["Content-Type"] = (String)value;
            }
        }

        public IHeaderDictionary Headers { get; set; }
        public long Length { get; }
        public string Name { get; }
        public string FileName { get; }
        public Stream OpenReadStream()
        {
            return (Stream)new ReferenceReadStream(this._baseStream, this._baseStreamOffset, this.Length);
        }

        public void CopyTo(Stream target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            using (Stream stream = this.OpenReadStream())
                stream.CopyTo(target, DefaultBufferSize);
        }

        public async Task CopyToAsync(Stream target, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            using (Stream readStream = this.OpenReadStream())
                await readStream.CopyToAsync(target, DefaultBufferSize, cancellationToken);
        }
    }
}