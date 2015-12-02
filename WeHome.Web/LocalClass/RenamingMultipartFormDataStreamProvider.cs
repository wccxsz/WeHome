using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace WeHome.Web.LocalClass
{
    public class RenamingMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public RenamingMultipartFormDataStreamProvider(string rootPath) : base(rootPath)
        {
        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            return headers.ContentDisposition.FileName.Replace("\"", string.Empty);
        }
    }
}