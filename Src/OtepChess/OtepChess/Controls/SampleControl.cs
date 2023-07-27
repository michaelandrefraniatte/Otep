using Microsoft.Xna.Framework;
using MonoGame.Forms.Controls;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
namespace MonoGame.Forms.DX.Controls
{
    public class SampleControl : MonoGameControl
    {
        private static int width, height;
        private static Bitmap chess = Image.FromFile("chess.png") as Bitmap;
        private static Bitmap chess_black_tower = Image.FromFile("chess-black-tower.png") as Bitmap;
        private static Bitmap chess_white_tower = Image.FromFile("chess-white-tower.png") as Bitmap;
        private static Bitmap chess_black_queen = Image.FromFile("chess-black-queen.png") as Bitmap;
        private static Bitmap chess_white_queen = Image.FromFile("chess-white-queen.png") as Bitmap;
        private static Bitmap chess_black_pion = Image.FromFile("chess-black-pion.png") as Bitmap;
        private static Bitmap chess_white_pion = Image.FromFile("chess-white-pion.png") as Bitmap;
        private static Bitmap chess_black_king = Image.FromFile("chess-black-king.png") as Bitmap;
        private static Bitmap chess_white_king = Image.FromFile("chess-white-king.png") as Bitmap;
        private static Bitmap chess_black_horse = Image.FromFile("chess-black-horse.png") as Bitmap;
        private static Bitmap chess_white_horse = Image.FromFile("chess-white-horse.png") as Bitmap;
        private static Bitmap chess_black_fool = Image.FromFile("chess-black-fool.png") as Bitmap;
        private static Bitmap chess_white_fool = Image.FromFile("chess-white-fool.png") as Bitmap;
        private static System.Drawing.Point[] chess_black_position = new System.Drawing.Point[16];
        private static System.Drawing.Point[] chess_white_position = new System.Drawing.Point[16];
        private static Texture2D texture;
        private static Texture2D[] chess_black_texture = new Texture2D[16];
        private static Texture2D[] chess_white_texture = new Texture2D[16];
        private static MouseState mouseState;
        private static KeyboardState keyState;
        private static string color;
        private static int mouseX, mouseY, num;
        private static bool mousepressed = false;
        private static int[] wd = { 2, 2, 2, 2, 2 };
        private static int[] wu = { 2, 2, 2, 2, 2 };
        private static void valchanged(int n, bool val)
        {
            if (val)
            {
                if (wd[n] <= 1)
                {
                    wd[n] = wd[n] + 1;
                }
                wu[n] = 0;
            }
            else
            {
                if (wu[n] <= 1)
                {
                    wu[n] = wu[n] + 1;
                }
                wd[n] = 0;
            }
        }
        protected void SetPosition()
        {
            chess_black_position[0] = new System.Drawing.Point(153 + 412 / 2, 0 + 120 / 2);
            chess_white_position[0] = new System.Drawing.Point(723 + 412 / 2, 0 + 120 / 2);
            chess_black_position[1] = new System.Drawing.Point(153 + 412 / 2, 570 + 120 / 2);
            chess_white_position[1] = new System.Drawing.Point(723 + 412 / 2, 570 + 120 / 2);
            chess_black_position[2] = new System.Drawing.Point(153 + 412 / 2, 81 + 120 / 2);
            chess_white_position[2] = new System.Drawing.Point(723 + 412 / 2, 81 + 120 / 2);
            chess_black_position[3] = new System.Drawing.Point(153 + 412 / 2, 485 + 120 / 2);
            chess_white_position[3] = new System.Drawing.Point(723 + 412 / 2, 485 + 120 / 2);
            chess_black_position[4] = new System.Drawing.Point(153 + 412 / 2, 161 + 120 / 2);
            chess_white_position[4] = new System.Drawing.Point(723 + 412 / 2, 161 + 120 / 2);
            chess_black_position[5] = new System.Drawing.Point(153 + 412 / 2, 408 + 120 / 2);
            chess_white_position[5] = new System.Drawing.Point(723 + 412 / 2, 408 + 120 / 2);
            chess_black_position[6] = new System.Drawing.Point(153 + 412 / 2, 245 + 120 / 2);
            chess_white_position[6] = new System.Drawing.Point(723 + 412 / 2, 245 + 120 / 2);
            chess_black_position[7] = new System.Drawing.Point(153 + 412 / 2, 326 + 120 / 2);
            chess_white_position[7] = new System.Drawing.Point(723 + 412 / 2, 326 + 120 / 2);
            chess_black_position[8] = new System.Drawing.Point(235 + 412 / 2, 0 + 120 / 2);
            chess_white_position[8] = new System.Drawing.Point(640 + 412 / 2, 0 + 120 / 2);
            chess_black_position[9] = new System.Drawing.Point(235 + 412 / 2, 570 + 120 / 2);
            chess_white_position[9] = new System.Drawing.Point(640 + 412 / 2, 570 + 120 / 2);
            chess_black_position[10] = new System.Drawing.Point(235 + 412 / 2, 81 + 120 / 2);
            chess_white_position[10] = new System.Drawing.Point(640 + 412 / 2, 81 + 120 / 2);
            chess_black_position[11] = new System.Drawing.Point(235 + 412 / 2, 485 + 120 / 2);
            chess_white_position[11] = new System.Drawing.Point(640 + 412 / 2, 485 + 120 / 2);
            chess_black_position[12] = new System.Drawing.Point(235 + 412 / 2, 161 + 120 / 2);
            chess_white_position[12] = new System.Drawing.Point(640 + 412 / 2, 161 + 120 / 2);
            chess_black_position[13] = new System.Drawing.Point(235 + 412 / 2, 408 + 120 / 2);
            chess_white_position[13] = new System.Drawing.Point(640 + 412 / 2, 408 + 120 / 2);
            chess_black_position[14] = new System.Drawing.Point(235 + 412 / 2, 245 + 120 / 2);
            chess_white_position[14] = new System.Drawing.Point(640 + 412 / 2, 245 + 120 / 2);
            chess_black_position[15] = new System.Drawing.Point(235 + 412 / 2, 326 + 120 / 2);
            chess_white_position[15] = new System.Drawing.Point(640 + 412 / 2, 326 + 120 / 2);
        }
        protected override void Initialize()
        {
            base.Initialize();
            width = 954 + 412;
            height = 648 + 120;
            chess_black_tower = new Bitmap(chess_black_tower, new Size((int)((double)chess_black_tower.Width * 0.9f), (int)((double)chess_black_tower.Height * 0.9f)));
            chess_white_tower = new Bitmap(chess_white_tower, new Size((int)((double)chess_white_tower.Width * 0.9f), (int)((double)chess_white_tower.Height * 0.9f)));
            chess_black_horse = new Bitmap(chess_black_horse, new Size((int)((double)chess_black_horse.Width * 0.9f), (int)((double)chess_black_horse.Height * 0.9f)));
            chess_white_horse = new Bitmap(chess_white_horse, new Size((int)((double)chess_white_horse.Width * 0.9f), (int)((double)chess_white_horse.Height * 0.9f)));
            chess_black_fool = new Bitmap(chess_black_fool, new Size((int)((double)chess_black_fool.Width * 0.9f), (int)((double)chess_black_fool.Height * 0.9f)));
            chess_white_fool = new Bitmap(chess_white_fool, new Size((int)((double)chess_white_fool.Width * 0.9f), (int)((double)chess_white_fool.Height * 0.9f)));
            chess_black_queen = new Bitmap(chess_black_queen, new Size((int)((double)chess_black_queen.Width * 0.9f), (int)((double)chess_black_queen.Height * 0.9f)));
            chess_white_queen = new Bitmap(chess_white_queen, new Size((int)((double)chess_white_queen.Width * 0.9f), (int)((double)chess_white_queen.Height * 0.9f)));
            chess_black_king = new Bitmap(chess_black_king, new Size((int)((double)chess_black_king.Width * 0.9f), (int)((double)chess_black_king.Height * 0.9f)));
            chess_white_king = new Bitmap(chess_white_king, new Size((int)((double)chess_white_king.Width * 0.9f), (int)((double)chess_white_king.Height * 0.9f)));
            chess_black_pion = new Bitmap(chess_black_pion, new Size((int)((double)chess_black_pion.Width * 0.9f), (int)((double)chess_black_pion.Height * 0.9f)));
            chess_white_pion = new Bitmap(chess_white_pion, new Size((int)((double)chess_white_pion.Width * 0.9f), (int)((double)chess_white_pion.Height * 0.9f)));
            SetPosition();
            texture = GetTexture2DFromBitmap(chess);
            chess_black_texture[0] = GetTexture2DFromBitmap(chess_black_tower);
            chess_white_texture[0] = GetTexture2DFromBitmap(chess_white_tower);
            chess_black_texture[1] = chess_black_texture[0];
            chess_white_texture[1] = chess_white_texture[0];
            chess_black_texture[2] = GetTexture2DFromBitmap(chess_black_horse);
            chess_white_texture[2] = GetTexture2DFromBitmap(chess_white_horse);
            chess_black_texture[3] = chess_black_texture[2];
            chess_white_texture[3] = chess_white_texture[2];
            chess_black_texture[4] = GetTexture2DFromBitmap(chess_black_fool);
            chess_white_texture[4] = GetTexture2DFromBitmap(chess_white_fool);
            chess_black_texture[5] = chess_black_texture[4];
            chess_white_texture[5] = chess_white_texture[4];
            chess_black_texture[6] = GetTexture2DFromBitmap(chess_black_queen);
            chess_white_texture[6] = GetTexture2DFromBitmap(chess_white_queen);
            chess_black_texture[7] = GetTexture2DFromBitmap(chess_black_king);
            chess_white_texture[7] = GetTexture2DFromBitmap(chess_white_king);
            chess_black_texture[8] = GetTexture2DFromBitmap(chess_black_pion);
            chess_white_texture[8] = GetTexture2DFromBitmap(chess_white_pion);
            for (int n = 9; n < 16; n++)
            {
                chess_black_texture[n] = chess_black_texture[8];
                chess_white_texture[n] = chess_white_texture[8];
            }
        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        protected override void Draw()
        {
            keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
            {
                Application.Exit();
            }
            if (keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                SetPosition();
            }
            mouseState = Mouse.GetState();
            mouseX = mouseState.X;
            mouseY = mouseState.Y;
            if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                mousepressed = true;
            }
            else
            {
                mousepressed = false;
            }
            valchanged(0, mousepressed);
            if (wd[0] == 1)
            {
                for (int n = 0; n < 16; n++)
                {
                    if (mouseX >= chess_black_position[n].X + 2 & mouseX <= chess_black_position[n].X + chess_black_pion.Width - 2 & mouseY >= chess_black_position[n].Y + 2 & mouseY <= chess_black_position[n].Y + chess_black_pion.Height - 2)
                    {
                        num = n;
                        color = "black";
                    }
                    if (mouseX >= chess_white_position[n].X + 2 & mouseX <= chess_white_position[n].X + chess_white_pion.Width - 2 & mouseY >= chess_white_position[n].Y + 2 & mouseY <= chess_white_position[n].Y + chess_white_pion.Height - 2)
                    {
                        num = n;
                        color = "white";
                    }
                }
            }
            if (mousepressed)
            {
                for (int n = 0; n < 16; n++)
                {
                    if (num == n & color == "black")
                    {
                        chess_black_position[n].X = mouseX - chess_black_pion.Width / 2;
                        chess_black_position[n].Y = mouseY - chess_black_pion.Height / 2;
                    }
                    if (num == n & color == "white")
                    {
                        chess_white_position[n].X = mouseX - chess_white_pion.Width / 2;
                        chess_white_position[n].Y = mouseY - chess_white_pion.Height / 2;
                    }
                }
            }
            else
            {
                color = "";
            }
            base.Draw();
            Editor.spriteBatch.Begin();
            Editor.spriteBatch.Draw(texture, new Vector2(0, 0), new Microsoft.Xna.Framework.Rectangle(0, 0, width, height), Microsoft.Xna.Framework.Color.White);
            for (int n = 0; n < 16; n++)
            {
                Editor.spriteBatch.Draw(chess_black_texture[n], new Vector2(chess_black_position[n].X, chess_black_position[n].Y), Microsoft.Xna.Framework.Color.White);
                Editor.spriteBatch.Draw(chess_white_texture[n], new Vector2(chess_white_position[n].X, chess_white_position[n].Y), Microsoft.Xna.Framework.Color.White);
            }
            if (color == "black")
            {
                Editor.spriteBatch.Draw(chess_black_texture[num], new Vector2(chess_black_position[num].X, chess_black_position[num].Y), Microsoft.Xna.Framework.Color.White);
            }
            if (color == "white")
            {
                Editor.spriteBatch.Draw(chess_white_texture[num], new Vector2(chess_white_position[num].X, chess_white_position[num].Y), Microsoft.Xna.Framework.Color.White);
            }
            Editor.spriteBatch.End();
        }
        public Texture2D GetTexture2DFromBitmap(Bitmap bmp)
        {
            Texture2D tx = null;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                tx = Texture2D.FromStream(Editor.graphics, ms);
            }
            return tx;
        }
    }
}