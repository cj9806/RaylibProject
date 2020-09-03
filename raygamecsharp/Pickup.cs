using System;
using System.Collections.Generic;
using System.Text;
using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
using static Raylib_cs.Raymath; // mathematics utilities and operations (Vector2Add, etc.)
using System.Numerics;

namespace raygamecsharp
{
    
    class Pickup:Sprite
    {
        Random random = new Random();
        public bool grabbed = false;
        //System.Random random = new Random();
        //int xPos = random
        new public void Draw()
        {
            if (!grabbed)
                DrawCircle((int)position.X,(int)position.Y,radius, BLUE);
        }
    }
}
