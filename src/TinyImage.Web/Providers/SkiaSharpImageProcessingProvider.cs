using System.IO;
using SkiaSharp;
using TinyImage.Web.Services;

namespace TinyImage.Web.Providers
{
    public class SkiaSharpImageProcessingProvider : ImageProcessingProvider
    {
        public override Image Resize(byte[] image)
        {
            var i = new Image
            {
                data = image
            };

            return Resize(i);
        }

        public override Image Resize(Image image)
        {
            int size = 150;
            int quality = 75;

            var input = new MemoryStream(image.data);

            using (var inputStream = new SKManagedStream(input))
            {
                using (var original = SKBitmap.Decode(inputStream))
                {
                    int width, height;
                    if (original.Width > original.Height)
                    {
                        width = size;
                        height = original.Height * size / original.Width;
                    }
                    else
                    {
                        width = original.Width * size / original.Height;
                        height = size;
                    }

                    using (var resized = original
                           .Resize(new SKImageInfo(width, height), SKBitmapResizeMethod.Lanczos3))
                    {
                        if (resized == null) return null;

                        using (var skimage = SKImage.FromBitmap(resized))
                        {
                            using (var output = new MemoryStream())
                            {
                                skimage.Encode(SKEncodedImageFormat.Jpeg, quality)
                                       .SaveTo(output);
                                output.Position = 0;

                                var resizedImage = new Image
                                {
                                    data = output.ToArray()
                                };

                                return resizedImage;
                            }
                        }
                    }
                }
            }
        }

     
    }
}

