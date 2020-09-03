using System;
using System.Collections.Generic;
using System.Text;
using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
using static Raylib_cs.Raymath; // mathematics utilities and operations (Vector2Add, etc.)
using System.Numerics;          // mathematics types (Vector2, Vector3, etc.)

namespace raygamecsharp
{
    class Powerups : Sprite
    {
        public bool grabbed = false;
        new public void Draw()
        {
            DrawCircle((int)position.X, (int)position.Y, radius, YELLOW);
        }
    }
}
