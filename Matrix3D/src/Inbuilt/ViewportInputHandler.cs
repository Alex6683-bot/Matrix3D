using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix3D.src.Inbuilt
{
    class ViewportInputHandler
    {
        MouseState mouse;
        KeyboardState keyboard;
        public ViewportInputHandler(MouseState mouse, KeyboardState keyboard)
        {
            this.mouse = mouse; 
            this.keyboard = keyboard;
        }

    }
}
