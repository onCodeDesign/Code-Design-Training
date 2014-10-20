using System;
using System.Drawing;

namespace LessonsSamples.Lesson5
{
    class ImageScale
    {
        private double errorThreshold;
        private Image image;

        public void ScaleToOneDimension(float desiredDimension, float imageDimension)
        {
            if (Math.Abs(desiredDimension - imageDimension) < errorThreshold)
                return;
            float scalingFactor = desiredDimension/imageDimension;
            scalingFactor = (float) (Math.Floor(scalingFactor*100)*0.01f);
            Image newImage = ImageUtilities.GetScaledImage(image, scalingFactor, scalingFactor);
            image.Dispose();
            System.GC.Collect();
            image = newImage;
        }

        public void Rotate(int degrees)
        {
            Image newImage = ImageUtilities.GetRotatedImage(image, degrees);

            image.Dispose();
            System.GC.Collect();
            image = newImage;
        }

        private void ReplaceImage(Image newImage)
        {
            image.Dispose();
            System.GC.Collect();
            image = newImage;
        }
    }




    class ImageUtilities
    {
        public static Image GetScaledImage(object image, float scalingFactor, float f)
        {
            throw new NotImplementedException();
        }

        public static Image GetRotatedImage(Image image, int degrees)
        {
            throw new NotImplementedException();
        }
    }
}