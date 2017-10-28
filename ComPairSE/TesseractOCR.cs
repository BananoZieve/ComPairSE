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
            var ocrtext = string.Empty;
            using (var engine = new TesseractEngine(@"../../tessdata", "lit", EngineMode.Default))
            {
                using (var img = PixConverter.ToPix(bmp))
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
