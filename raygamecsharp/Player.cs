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
    class Player : Sprite
    {
        
        new public Vector2 position = new Vector2(100, 100);
        public int score = 0;
        //Image image = LoadImage(@"Sprites\PNG\Items\platformPack_item003.png");
        //Texture2D texture = LoadTextureFromImage(image);
        public void Move()
        {
            if (IsKeyDown(KeyboardKey.KEY_RIGHT))
                position.X += 5;
            else if (IsKeyDown(KeyboardKey.KEY_LEFT))
                position.X -= 5;
            if (IsKeyDown(KeyboardKey.KEY_UP))
                position.Y -= 5;
            else if (IsKeyDown(KeyboardKey.KEY_DOWN))
                position.Y += 5;
        }
        new public void Draw()
        {            
            DrawCircle((int)position.X,(int)position.Y, radius, GREEN);
        }
    }
}
