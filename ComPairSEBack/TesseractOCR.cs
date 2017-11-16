using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace ComPairSEBack
{
    public interface IOCR
    {
        string GetText(String image);
    }

    class TesseractOCR : IOCR
    {
        public string GetText(String image)
        {
            var OCRPicture = Util.PicToBitmap(image).Contrast().ToGreyscale();
            if (ImageEditing.IfRotated(OCRPicture)) OCRPicture.RotateFlip(RotateFlipType.Rotate90FlipNone);
            //Test output
            OCRPicture.Save("OCR.jpg");



            var ocrtext = string.Empty;
            using (var engine = new TesseractEngine(@"../../tessdata", "lit4", EngineMode.Default, @"../../config"))
            {
                using (var img = PixConverter.ToPix(OCRPicture))
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
