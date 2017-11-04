using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPairSE
{
    public static class ImageEditing
    {
        //Image Processing: http://www.graficaobscura.com/interp/index.html
        //Some ColorMatrixes: http://www.graficaobscura.com/matrix/index.html
        //A nice way to combine ColorMatrixes: https://docs.rainmeter.net/tips/colormatrix-guide/

        public static Bitmap Contrast(this Bitmap bitmap)
        {

            //contrast
            float c = 2f;
            //translation parameter
            float t = (1f - c) / 2f;

            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][] {
       new float[]{ c, 0, 0, 0, 0},
       new float[]{ 0, c, 0, 0, 0},
       new float[]{ 0, 0, c, 0 , 0},
       new float[]{ 0,  0, 0, 1, 0},
       new float[]{ t,  t, t, 0, 1},

    });

            Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            Graphics graphics = Graphics.FromImage(newBitmap);
            ImageAttributes attributes = new ImageAttributes();

            attributes.SetColorMatrix(colorMatrix);

            graphics.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height),
               0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, attributes);

            graphics.Dispose();

            return newBitmap;
        }

        /* Source with explanations: https://web.archive.org/web/20110827032809/http://www.switchonthecode.com/tutorials/csharp-tutorial-convert-a-color-image-to-grayscale */
        public static Bitmap ToGreyscale(this Bitmap bitmap)
        {
            Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            Graphics g = Graphics.FromImage(newBitmap);

            //grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
                    new float[] {.3f, .3f, .3f, 0, 0},
                    new float[] {.59f, .59f, .59f, 0, 0},
                    new float[] {.11f, .11f, .11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
               });

            ImageAttributes attributes = new ImageAttributes();

            attributes.SetColorMatrix(colorMatrix);

            g.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height),
               0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, attributes);

            g.Dispose();

            return newBitmap;
        }

        public static Bitmap Brighten(this Bitmap bitmap)
        {
            float b = 0.1f;
            Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            Graphics g = Graphics.FromImage(newBitmap);

            {
                ColorMatrix colorMatrix = new ColorMatrix(
                 new float[][]
                 {
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {b, b, b, 0, 1}
                 });

                ImageAttributes attributes = new ImageAttributes();

                attributes.SetColorMatrix(colorMatrix);

                g.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                   0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, attributes);

                g.Dispose();

                return newBitmap;
            }
        }
    }
}

