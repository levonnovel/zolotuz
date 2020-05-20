using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
	public class Image
	{
		public string Name { get; set; }
		public string Url { get; set; }

            public static ImageCodecInfo GetEncoderInfo(string mimeType)
            {
                // Get image codecs for all image formats 
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

                // Find the correct image codec 
                for (int i = 0; i < codecs.Length; i++)
                    if (codecs[i].MimeType == mimeType)
                        return codecs[i];

                return null;
            }
            public static void SaveJpeg(string path, System.Drawing.Image img, int quality)
            {
                if (quality < 0 || quality > 100)
                    throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");

                // Encoder parameter for image quality 
                EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, quality);
                // JPEG image codec 
                ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
                EncoderParameters encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = qualityParam;
                img.Save(path, jpegCodec, encoderParams);
            }

    }
    
}
