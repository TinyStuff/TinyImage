using TinyImage.Web.Services;

namespace TinyImage.Web.Providers
{
    public abstract class ImageProcessingProvider
    {
        public abstract Image Resize(byte[] image);
        public abstract Image Resize(Image image);
    }
}