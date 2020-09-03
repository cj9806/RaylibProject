 /*******************************************************************************************
*
*   raylib [core] example - Basic window
*
*   Welcome to raylib!
*
*   To test examples, just press F6 and execute raylib_compile_execute script
*   Note that compiled executable is placed in the same folder as .c file
*
*   You can find all basic examples on C:\raylib\raylib\examples folder or
*
*   Enjoy using raylib. :)
*
*   This example has been created using raylib-cs 3.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   This example was lightly modified to provide additional 'using' directives to make
*   common math types and utilities readily available, though they are not using in this sample.
*
*   Copyright (c) 2019-2020 Academy of Interactive Entertainment (@aie_usa)
*   Copyright (c) 2013-2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
using static Raylib_cs.Raymath; // mathematics utilities and operations (Vector2Add, etc.)
using System.Numerics;          // mathematics types (Vector2, Vector3, etc.)
using raygamecsharp;
using Raylib_cs;
using System;
using System.Collections.Generic;

namespace Examples
{
    public class core_basic_window
    {
        public static int Main()
        {
            int timeLeft = 10;
            int startTime = 1;
            Random random = new Random();
            // Initialization
            //--------------------------------------------------------------------------------------
            const int screenWidth = 800;
            const int screenHeight = 450;

            InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

            SetTargetFPS(60);
            //--------------------------------------------------------------------------------------
            Player player = new Player();
            Enemy enemy = new Enemy();
            List<Powerups> powerups = new List<Powerups>();
            powerups.Add(new Powerups { });
            powerups.Add(new Powerups { });
            powerups.Add(new Powerups { });
            List<Pickup> pickup = new List<Pickup>();
            pickup.Add(new Pickup { });
            pickup.Add(new Pickup { }); 
            pickup.Add(new Pickup { }); 
            pickup.Add(new Pickup { });
            pickup.Add(new Pickup { });
            int length = pickup.Count;
            Console.WriteLine(length);
            for (int i = 0; i < pickup.Count; i++)
            {

                pickup[i].position.X = random.Next(35, 780);
                pickup[i].position.Y = random.Next(35, 430);
                
            }
            for (int i = 0; i < powerups.Count; i++)
            {
                powerups[i].position.X = random.Next(35, 780);
                powerups[i].position.Y = random.Next(35, 430);
            }
            //win boolian
            bool win = false;
            bool die = false;
            bool timeOut = false;
            // Main game loop
            while (!WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                // TODO: Update your variables here

                //colision
                //CheckCollisionPointCircle();
                bool enemyCollision = CheckCollisionCircles(enemy.position, enemy.radius, player.position, player.radius);
                if (enemyCollision)
                {
                    die = true;
                }
                for (int i = 0; i < pickup.Count; i++)
                {
                    bool pickupCollision = CheckCollisionCircles(pickup[i].position, pickup[i].radius, player.position, player.radius);
                    if (pickupCollision)
                    {
                        player.score += 100;
                        pickup[i].grabbed = true;
                        pickup.Remove(pickup[i]);
                    }
                }
                for (int i = 0; i < powerups.Count; i++)
                {
                    bool powerupCollision = CheckCollisionCircles(powerups[i].position, powerups[i].radius, player.position, player.radius);
                    if (powerupCollision)
                    {
                        enemy.afraid = true;
                        powerups[i].grabbed = true;
                        powerups.Remove(powerups[i]);
                    }
                }
                //----------------------------------------------------------------------------------
                //movement
                if (!win && !die && !timeOut)
                { 
                    player.Move();
                    if (enemy.afraid == true)
                        enemy.Fear(player.position);
                    else
                        enemy.Move(player.position);
                }
                //----------------------------------------------------------------------------------
                //Screen Wrapping

                if (player.position.X >= 806)
                {
                    player.position.X = -5;
                }
                else if (player.position.X <= -6)
                {
                    player.position.X = 805;
                }
                if (player.position.Y >= 456)
                {
                    player.position.Y = -5;
                }
                else if (player.position.Y <= -6)
                {
                    player.position.Y = 455;
                }
                // Draw
                //----------------------------------------------------------------------------------
                BeginDrawing();

                ClearBackground(RAYWHITE);
                for (int i = 0; i < pickup.Count; i++)
                {
                    pickup[i].Draw();
                }
                for (int i = 0; i < powerups.Count; i++)
                {
                    powerups[i].Draw();
                }
                if (!timeOut)
                    DrawText($"Current time: {timeLeft}", 10, 10, 20, MAROON);
                DrawText($"Current Score: {player.score}", 590,10,20,MAROON);
                enemy.Draw();
                player.Draw();
                if (win)
                {
                    DrawText("You Win!", 250, 195, 60, MAROON);
                    
                }
                else if (die)
                {
                    DrawText("You Died!", 240, 195, 60, MAROON);

                }
                else if (timeOut)
                {
                    DrawText("Out of Time!", 200, 195, 60, MAROON);

                }
                EndDrawing();
                //----------------------------------------------------------------------------------
                //add win condition
                // count down the time
                if (startTime <= GetTime() && !win)
                {
                    timeLeft -= 1;
                    startTime += 1;
                }
                if (timeLeft == 0)
                    timeOut= true;
                else if (pickup.Count == 0)
                {
                    win = true;
                }
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            CloseWindow();        // Close window and OpenGL context
            //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}