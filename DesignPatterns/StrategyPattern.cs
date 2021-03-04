using System;

// Strategy pattern
namespace DesignPatterns
{
    public class CameraAppSimulation
    {

        public interface IShareBehaviour
        {
            void Share();
        }

        public class SocialMediaShare : IShareBehaviour
        {
            public void Share()
            {
                Console.WriteLine("You just shared a photo on social media");
            }
        }

        public class StrategyPattern
        {
            public void Take() { Console.WriteLine("photo taken"); }
            public void SavePhoto() { Console.WriteLine("photo saved"); }

            public IShareBehaviour ShareBehaviour { get; set; }

        }

        public class BasicCameraApp : StrategyPattern
        {
            public void Edit() { Console.WriteLine("Basic Edit"); }
        }

        public class CameraPlusapp : StrategyPattern
        {
            public void Edit() { Console.WriteLine("Plus Edit"); }
        }
        //static void Main(string[] args)
        //{
        //    var cameraApp = new BasicCameraApp
        //    {
        //        ShareBehaviour = new SocialMediaShare()
        //    };

        //    cameraApp.Take();
        //    cameraApp.SavePhoto();
        //    cameraApp.Edit();
        //    cameraApp.ShareBehaviour.Share();
        //    Console.ReadLine();
        //}
    }
}
