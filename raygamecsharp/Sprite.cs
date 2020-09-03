using System;
using System.Collections.Generic;
using System.Text;
using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
using static Raylib_cs.Raymath; // mathematics utilities and operations (Vector2Add, etc.)
using System.Numerics;          // mathematics types (Vector2, Vector3, etc.)
using System.Drawing;

namespace raygamecsharp
{
    class Sprite
    {
        public Vector2 position = new Vector2(0,0);
        bool lockToMouse = true;
        public float radius = 10F;
        

        public void Update()
        {
            Vector2 mPostion = GetMousePosition();
            if (lockToMouse)
            {
                position = mPostion;
            }
        }
        public void Draw()
        {
            DrawCircle((int)position.X,(int)position.Y, 10, WHITE);
        }
    }
}
