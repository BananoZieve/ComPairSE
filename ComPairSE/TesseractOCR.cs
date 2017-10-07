using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace ComPairSE
{
    class TesseractOCR
    {
        public string GetText(string picture)
        {
            Bitmap myBmp = (Bitmap)Image.FromFile(picture);
            var ocrtext = string.Empty;
            using (var engine = new TesseractEngine(@"../../tessdata", "lit", EngineMode.Default))
            {
                using (var img = PixConverter.ToPix(myBmp))
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
