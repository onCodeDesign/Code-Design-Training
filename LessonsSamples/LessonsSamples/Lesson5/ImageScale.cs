using System;
using System.Drawing;

namespace LessonsSamples.Lesson5
{
    class ImageScale
    {
        private double errorThreshold;
        private RenderedOp image;

        public void ScaleToOneDimension(float desiredDimension, float imageDimension)
        {
            if (Math.Abs(desiredDimension - imageDimension) < errorThreshold)
                return;
            float scalingFactor = desiredDimension/imageDimension;
            scalingFactor = (float) (Math.Floor(scalingFactor*100)*0.01f);
            RenderedOp newImage = ImageUtilities.GetScaledImage(image, scalingFactor, scalingFactor);
            image.Dispose();
            System.GC.Collect();
            image = newImage;
        }

        public void Rotate(int degrees)
        {
            RenderedOp newImage = ImageUtilities.GetRotatedImage(image, degrees);

            image.Dispose();
            System.GC.Collect();
            image = newImage;
        }

        private void ReplaceImage(RenderedOp newImage)
        {
            image.Dispose();
            System.GC.Collect();
            image = newImage;
        }
    }




    class ImageUtilities
    {
        public static RenderedOp GetScaledImage(object image, float scalingFactor, float f)
        {
            throw new NotImplementedException();
        }

        public static RenderedOp GetRotatedImage(Image image, int degrees)
        {
            throw new NotImplementedException();
        }
    }

    class RenderedOp : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}