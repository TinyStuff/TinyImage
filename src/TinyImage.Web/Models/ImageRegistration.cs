using System;
namespace TinyImage.Web.Models
{
    public class ImageRegistration
    {
        public string Url { get; set; }
        public string CustomData { get; set; }
    }

    public class ImageRegistrationResponse
    {
        public string Token { get; set; }
        public string Url { get; set; }
        public string CustomData { get; set; }
    }
}
