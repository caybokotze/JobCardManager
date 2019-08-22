using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace JobCardSystem.Blob
{
    public class StorageHandler
    {
        private const string StorageAccountName = "sqlva22pmwurmpo7sc";
        private const string StorageAccountKey = "kwHela38uV3bGkHlSt1Tn3JokMQW3PnC38DxqEzprupaq1etrwPdNlUsbmgFkWFv4koftlMi7W/g3dYH443Bww==";

        public static void Upload(string source, string unmappedLocation)
        {
            var StorageAccount = new CloudStorageAccount(new StorageCredentials(StorageAccountName, StorageAccountKey), true);
            var blobClient = StorageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("primary-container");
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions()
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            var blob = container.GetBlockBlobReference(unmappedLocation.Remove(0, 2));
            blob.UploadFromFile(source);
        }
    }
}