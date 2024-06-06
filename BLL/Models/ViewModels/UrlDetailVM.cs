using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.ViewModels
{
    public class UrlDetailsViewModel
    {
        public int Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreationDate { get; set; }
        public string AbsolutePath { get; set; }
        public string AbsoluteUri { get; set; }
        public string DnsSafeHost { get; set; }
        public string Fragment { get; set; }
        public string Host { get; set; }
        public UriHostNameType HostNameType { get; set; }
        public string IdnHost { get; set; }
        public bool IsAbsoluteUri { get; set; }
        public bool IsDefaultPort { get; set; }
        public bool IsFile { get; set; }
        public bool IsLoopback { get; set; }
        public bool IsUnc { get; set; }
        public string LocalPath { get; set; }
        public string OriginalString { get; set; }
        public string PathAndQuery { get; set; }
        public int Port { get; set; }
        public string Query { get; set; }
        public string Scheme { get; set; }
        public string[] Segments { get; set; }
        public bool UserEscaped { get; set; }
        public string UserInfo { get; set; }
    }
}
