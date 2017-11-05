using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace ComPairSE
{
    public interface IOCR
    {
        string GetText(Bitmap bmp);
    }

    class TesseractOCR : IOCR
    {
        public string GetText(Bitmap bmp)
        {
           //Test output
           //bmp.Contrast().ToGreyscale().Save("pic.jpg");

            var ocrtext = string.Empty;
            using (var engine = new TesseractEngine(@"../../tessdata", "lit4", EngineMode.Default, @"../../config"))
            {
                using (var img = PixConverter.ToPix(bmp.Contrast().ToGreyscale()))
                {
                    using (var page = engine.Process(img))
                    {
                        ocrtext = page.GetText();
                    }
                }
            }

            return ocrtext;
        }

    }
}
