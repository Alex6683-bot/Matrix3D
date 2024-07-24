using System;
using Matrix3D.Rendering;
using Matrix3D.src;
using OpenTK;


namespace Matrix3D
{
    class Program
    {
        public static void Main(string[] args) 
        {
            using (Client client = new Client(WindowConfig.width, WindowConfig.height, WindowConfig.title))
            {
                client.Run();
            }
        }

    }
}