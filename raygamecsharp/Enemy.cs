using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
using static Raylib_cs.Raymath; // mathematics utilities and operations (Vector2Add, etc.)
using System.Numerics;          // mathematics types (Vector2, Vector3, etc.)
using raygamecsharp;
using Raylib_cs;
using System;
using System.Collections.Generic;

namespace raygamecsharp
{
    class Enemy:Sprite
    {
        public bool afraid = false;
        new public void Draw()
        {
            DrawCircle((int)position.X, (int)position.Y, 10, RED);
        }
        public void Move(Vector2 pp)
        {
            if (pp.X > position.X)
                position.X += 2;
            if (pp.X < position.X)
                position.X -= 2;
            if (pp.Y > position.Y)
                position.Y += 2;
            if (pp.Y < position.Y)
                position.Y -= 2;
            if (position.X < -6)
                position.X = -5;
            if (position.X > 806)
                position.X = 805;
            if (position.Y < -6)
                position.Y = -5;
            if (position.Y > 456)
                position.Y = 455;
        }
        public void Fear(Vector2 pp)
        {
            //double currentTime = GetTime();
            //double endTime = currentTime + 1;
            if (pp.X > position.X)
                position.X -= 100;
            if (pp.X < position.X)
                position.X += 100;
            if (pp.Y > position.Y)
                position.Y -= 100;
            if (pp.Y < position.Y)
                position.Y += 100;
            afraid = false;
        }

    }
}
