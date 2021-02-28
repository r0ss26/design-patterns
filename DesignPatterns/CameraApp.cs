using System;

// Strategy pattern
namespace DesignPatterns
{
    public class CameraAppSimulation
    {

        public interface ShareBehaviour
        {
            void Share();
        }

        public class SocialMediaShare : ShareBehaviour
        {
            public void Share()
            {
                Console.WriteLine("You just shared a photo on social media");
            }
        }

        public class CameraApp
        {
            public void Take() { Console.WriteLine("photo taken"); }
            public void SavePhoto() { Console.WriteLine("photo saved"); }

            public ShareBehaviour ShareBehaviour { get; set; }

        }

        public class BasicCameraApp : CameraApp
        {
            public void Edit() { Console.WriteLine("Basic Edit"); }
        }

        public class CameraPlusapp : CameraApp
        {
            public void Edit() { Console.WriteLine("Plus Edit"); }
        }
        static void Main(string[] args)
        {
            var cameraApp = new BasicCameraApp
            {
                ShareBehaviour = new SocialMediaShare()
            };

            cameraApp.Take();
            cameraApp.SavePhoto();
            cameraApp.ShareBehaviour.Share();
            Console.ReadLine();
        }
    }
}
