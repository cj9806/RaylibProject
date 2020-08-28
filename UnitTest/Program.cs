using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    static class Program
    {
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            int screenWidth = 800;
            int screenHeight = 450;

            rl.InitWindow(screenWidth, screenHeight, "raylib [aie] - unit test");

            rl.SetTargetFPS(60);
            //--------------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            rl.BeginDrawing();

            rl.ClearBackground(Color.RAYWHITE);

            rl.DrawText("Congrats! You created your first window!", 190, 200, 20, Color.LIGHTGRAY);

            rl.EndDrawing();

            // De-Initialization
            //--------------------------------------------------------------------------------------
            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
