using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace JobCardSystem.BusinessLogic
{
    public interface IFormFile
    {
        //Get raw content type header.
        string ContentType { get; }
        //Get raw content disposition of the uploaded file.
        string ContentDisposition { get; }
        //Get the header of the uploaded file.
        IHeaderDictionary Headers { get; }
        //Get file length in bytes.
        long Length { get; }
        //Get content name from content disposition header.
        string Name { get; }
        //Get file name from content disposition header.
        string FileName { get; }
        //Open request stream.
        Stream OpenReadStream();
        //Copies the contents of the uploaded file to the target stream.
        void CopyTo(Stream target);
        //async for the same thing.
        Task CopyToAsync(Stream target, CancellationToken cancellationToken = default(CancellationToken));

    }
}
