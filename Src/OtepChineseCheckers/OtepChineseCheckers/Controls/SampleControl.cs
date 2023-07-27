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
        private static Bitmap chinese_checkers = Image.FromFile("chinese-checkers.png") as Bitmap;
        private static Bitmap chinese_checker_red_ball = Image.FromFile("chinese-checker-red-ball.png") as Bitmap;
        private static Bitmap chinese_checker_orange_ball = Image.FromFile("chinese-checker-orange-ball.png") as Bitmap;
        private static Bitmap chinese_checker_yellow_ball = Image.FromFile("chinese-checker-yellow-ball.png") as Bitmap;
        private static Bitmap chinese_checker_green_ball = Image.FromFile("chinese-checker-green-ball.png") as Bitmap;
        private static Bitmap chinese_checker_blue_ball = Image.FromFile("chinese-checker-blue-ball.png") as Bitmap;
        private static Bitmap chinese_checker_purple_ball = Image.FromFile("chinese-checker-purple-ball.png") as Bitmap;
        private static System.Drawing.Point[] chinese_checker_red_position = new System.Drawing.Point[10];
        private static System.Drawing.Point[] chinese_checker_orange_position = new System.Drawing.Point[10];
        private static System.Drawing.Point[] chinese_checker_yellow_position = new System.Drawing.Point[10];
        private static System.Drawing.Point[] chinese_checker_green_position = new System.Drawing.Point[10];
        private static System.Drawing.Point[] chinese_checker_blue_position = new System.Drawing.Point[10];
        private static System.Drawing.Point[] chinese_checker_purple_position = new System.Drawing.Point[10];
        private static Texture2D texture;
        private static Texture2D[] chinese_checker_red_texture = new Texture2D[10];
        private static Texture2D[] chinese_checker_orange_texture = new Texture2D[10];
        private static Texture2D[] chinese_checker_yellow_texture = new Texture2D[10];
        private static Texture2D[] chinese_checker_green_texture = new Texture2D[10];
        private static Texture2D[] chinese_checker_blue_texture = new Texture2D[10];
        private static Texture2D[] chinese_checker_purple_texture = new Texture2D[10];
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
            chinese_checker_red_position[0] = new System.Drawing.Point(664, 690);
            chinese_checker_red_position[1] = new System.Drawing.Point(640, 651);
            chinese_checker_red_position[2] = new System.Drawing.Point(687, 651);
            chinese_checker_red_position[3] = new System.Drawing.Point(617, 610);
            chinese_checker_red_position[4] = new System.Drawing.Point(663, 610);
            chinese_checker_red_position[5] = new System.Drawing.Point(711, 610);
            chinese_checker_red_position[6] = new System.Drawing.Point(593, 569);
            chinese_checker_red_position[7] = new System.Drawing.Point(640, 569);
            chinese_checker_red_position[8] = new System.Drawing.Point(686, 569);
            chinese_checker_red_position[9] = new System.Drawing.Point(734, 569);
            chinese_checker_orange_position[0] = new System.Drawing.Point(869, 407);
            chinese_checker_orange_position[1] = new System.Drawing.Point(847, 447);
            chinese_checker_orange_position[2] = new System.Drawing.Point(891, 447);
            chinese_checker_orange_position[3] = new System.Drawing.Point(824, 487);
            chinese_checker_orange_position[4] = new System.Drawing.Point(870, 487);
            chinese_checker_orange_position[5] = new System.Drawing.Point(914, 487);
            chinese_checker_orange_position[6] = new System.Drawing.Point(800, 527);
            chinese_checker_orange_position[7] = new System.Drawing.Point(847, 527);
            chinese_checker_orange_position[8] = new System.Drawing.Point(893, 527);
            chinese_checker_orange_position[9] = new System.Drawing.Point(939, 527);
            chinese_checker_yellow_position[0] = new System.Drawing.Point(867, 328);
            chinese_checker_yellow_position[1] = new System.Drawing.Point(846, 287);
            chinese_checker_yellow_position[2] = new System.Drawing.Point(892, 287);
            chinese_checker_yellow_position[3] = new System.Drawing.Point(823, 246);
            chinese_checker_yellow_position[4] = new System.Drawing.Point(869, 246);
            chinese_checker_yellow_position[5] = new System.Drawing.Point(914, 246);
            chinese_checker_yellow_position[6] = new System.Drawing.Point(800, 206);
            chinese_checker_yellow_position[7] = new System.Drawing.Point(846, 206);
            chinese_checker_yellow_position[8] = new System.Drawing.Point(891, 206);
            chinese_checker_yellow_position[9] = new System.Drawing.Point(937, 206);
            chinese_checker_green_position[0] = new System.Drawing.Point(661, 45);
            chinese_checker_green_position[1] = new System.Drawing.Point(640, 85);
            chinese_checker_green_position[2] = new System.Drawing.Point(685, 85);
            chinese_checker_green_position[3] = new System.Drawing.Point(616, 127);
            chinese_checker_green_position[4] = new System.Drawing.Point(664, 127);
            chinese_checker_green_position[5] = new System.Drawing.Point(709, 127);
            chinese_checker_green_position[6] = new System.Drawing.Point(593, 167);
            chinese_checker_green_position[7] = new System.Drawing.Point(639, 167);
            chinese_checker_green_position[8] = new System.Drawing.Point(685, 167);
            chinese_checker_green_position[9] = new System.Drawing.Point(732, 167);
            chinese_checker_blue_position[0] = new System.Drawing.Point(456, 327);
            chinese_checker_blue_position[1] = new System.Drawing.Point(433, 288);
            chinese_checker_blue_position[2] = new System.Drawing.Point(480, 288);
            chinese_checker_blue_position[3] = new System.Drawing.Point(409, 248);
            chinese_checker_blue_position[4] = new System.Drawing.Point(457, 248);
            chinese_checker_blue_position[5] = new System.Drawing.Point(502, 248);
            chinese_checker_blue_position[6] = new System.Drawing.Point(388, 207);
            chinese_checker_blue_position[7] = new System.Drawing.Point(433, 207);
            chinese_checker_blue_position[8] = new System.Drawing.Point(481, 207);
            chinese_checker_blue_position[9] = new System.Drawing.Point(526, 207);
            chinese_checker_purple_position[0] = new System.Drawing.Point(457, 407);
            chinese_checker_purple_position[1] = new System.Drawing.Point(435, 448);
            chinese_checker_purple_position[2] = new System.Drawing.Point(480, 448);
            chinese_checker_purple_position[3] = new System.Drawing.Point(410, 489);
            chinese_checker_purple_position[4] = new System.Drawing.Point(457, 489);
            chinese_checker_purple_position[5] = new System.Drawing.Point(503, 489);
            chinese_checker_purple_position[6] = new System.Drawing.Point(388, 530);
            chinese_checker_purple_position[7] = new System.Drawing.Point(435, 530);
            chinese_checker_purple_position[8] = new System.Drawing.Point(480, 530);
            chinese_checker_purple_position[9] = new System.Drawing.Point(526, 530);
        }
        protected override void Initialize()
        {
            base.Initialize();
            width = 1366;
            height = 768;
            chinese_checker_red_ball = new Bitmap(chinese_checker_red_ball, new Size((int)((double)chinese_checker_red_ball.Width / 2.5), (int)((double)chinese_checker_red_ball.Height / 2.5)));
            chinese_checker_orange_ball = new Bitmap(chinese_checker_orange_ball, new Size((int)((double)chinese_checker_orange_ball.Width / 2.5), (int)((double)chinese_checker_orange_ball.Height / 2.5)));
            chinese_checker_yellow_ball = new Bitmap(chinese_checker_yellow_ball, new Size((int)((double)chinese_checker_yellow_ball.Width / 2.5), (int)((double)chinese_checker_yellow_ball.Height / 2.5)));
            chinese_checker_green_ball = new Bitmap(chinese_checker_green_ball, new Size((int)((double)chinese_checker_green_ball.Width / 2.5), (int)((double)chinese_checker_green_ball.Height / 2.5)));
            chinese_checker_blue_ball = new Bitmap(chinese_checker_blue_ball, new Size((int)((double)chinese_checker_blue_ball.Width / 2.5), (int)((double)chinese_checker_blue_ball.Height / 2.5)));
            chinese_checker_purple_ball = new Bitmap(chinese_checker_purple_ball, new Size((int)((double)chinese_checker_purple_ball.Width / 2.5), (int)((double)chinese_checker_purple_ball.Height / 2.5)));
            SetPosition();
            texture = GetTexture2DFromBitmap(chinese_checkers);
            chinese_checker_red_texture[0] = GetTexture2DFromBitmap(chinese_checker_red_ball);
            for (int n = 1; n < 10; n++)
            {
                chinese_checker_red_texture[n] = chinese_checker_red_texture[0];
            }
            chinese_checker_orange_texture[0] = GetTexture2DFromBitmap(chinese_checker_orange_ball);
            for (int n = 1; n < 10; n++)
            {
                chinese_checker_orange_texture[n] = chinese_checker_orange_texture[0];
            }
            chinese_checker_yellow_texture[0] = GetTexture2DFromBitmap(chinese_checker_yellow_ball);
            for (int n = 1; n < 10; n++)
            {
                chinese_checker_yellow_texture[n] = chinese_checker_yellow_texture[0];
            }
            chinese_checker_green_texture[0] = GetTexture2DFromBitmap(chinese_checker_green_ball);
            for (int n = 1; n < 10; n++)
            {
                chinese_checker_green_texture[n] = chinese_checker_green_texture[0];
            }
            chinese_checker_blue_texture[0] = GetTexture2DFromBitmap(chinese_checker_blue_ball);
            for (int n = 1; n < 10; n++)
            {
                chinese_checker_blue_texture[n] = chinese_checker_blue_texture[0];
            }
            chinese_checker_purple_texture[0] = GetTexture2DFromBitmap(chinese_checker_purple_ball);
            for (int n = 1; n < 10; n++)
            {
                chinese_checker_purple_texture[n] = chinese_checker_purple_texture[0];
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
            valchanged(1, mousepressed);
            if (wd[1] == 1)
            {
                for (int n = 0; n < 10; n++)
                {
                    if (mouseX >= chinese_checker_red_position[n].X + 2 & mouseX <= chinese_checker_red_position[n].X + chinese_checker_red_ball.Width - 2 & mouseY >= chinese_checker_red_position[n].Y + 2 & mouseY <= chinese_checker_red_position[n].Y + chinese_checker_red_ball.Height - 2)
                    {
                        num = n;
                        color = "red";
                    }
                    if (mouseX >= chinese_checker_orange_position[n].X + 2 & mouseX <= chinese_checker_orange_position[n].X + chinese_checker_orange_ball.Width - 2 & mouseY >= chinese_checker_orange_position[n].Y + 2 & mouseY <= chinese_checker_orange_position[n].Y + chinese_checker_orange_ball.Height - 2)
                    {
                        num = n;
                        color = "orange";
                    }
                    if (mouseX >= chinese_checker_yellow_position[n].X + 2 & mouseX <= chinese_checker_yellow_position[n].X + chinese_checker_yellow_ball.Width - 2 & mouseY >= chinese_checker_yellow_position[n].Y + 2 & mouseY <= chinese_checker_yellow_position[n].Y + chinese_checker_yellow_ball.Height - 2)
                    {
                        num = n;
                        color = "yellow";
                    }
                    if (mouseX >= chinese_checker_green_position[n].X + 2 & mouseX <= chinese_checker_green_position[n].X + chinese_checker_green_ball.Width - 2 & mouseY >= chinese_checker_green_position[n].Y + 2 & mouseY <= chinese_checker_green_position[n].Y + chinese_checker_green_ball.Height - 2)
                    {
                        num = n;
                        color = "green";
                    }
                    if (mouseX >= chinese_checker_blue_position[n].X + 2 & mouseX <= chinese_checker_blue_position[n].X + chinese_checker_blue_ball.Width - 2 & mouseY >= chinese_checker_blue_position[n].Y + 2 & mouseY <= chinese_checker_blue_position[n].Y + chinese_checker_blue_ball.Height - 2)
                    {
                        num = n;
                        color = "blue";
                    }
                    if (mouseX >= chinese_checker_purple_position[n].X + 2 & mouseX <= chinese_checker_purple_position[n].X + chinese_checker_purple_ball.Width - 2 & mouseY >= chinese_checker_purple_position[n].Y + 2 & mouseY <= chinese_checker_purple_position[n].Y + chinese_checker_purple_ball.Height - 2)
                    {
                        num = n;
                        color = "purple";
                    }
                }
            }
            if (mousepressed)
            {
                for (int n = 0; n < 10; n++)
                {
                    if (num == n & color == "red")
                    {
                        chinese_checker_red_position[n].X = mouseX - chinese_checker_red_ball.Width / 2;
                        chinese_checker_red_position[n].Y = mouseY - chinese_checker_red_ball.Height / 2;
                    }
                    if (num == n & color == "orange")
                    {
                        chinese_checker_orange_position[n].X = mouseX - chinese_checker_orange_ball.Width / 2;
                        chinese_checker_orange_position[n].Y = mouseY - chinese_checker_orange_ball.Height / 2;
                    }
                    if (num == n & color == "yellow")
                    {
                        chinese_checker_yellow_position[n].X = mouseX - chinese_checker_yellow_ball.Width / 2;
                        chinese_checker_yellow_position[n].Y = mouseY - chinese_checker_yellow_ball.Height / 2;
                    }
                    if (num == n & color == "green")
                    {
                        chinese_checker_green_position[n].X = mouseX - chinese_checker_green_ball.Width / 2;
                        chinese_checker_green_position[n].Y = mouseY - chinese_checker_green_ball.Height / 2;
                    }
                    if (num == n & color == "blue")
                    {
                        chinese_checker_blue_position[n].X = mouseX - chinese_checker_blue_ball.Width / 2;
                        chinese_checker_blue_position[n].Y = mouseY - chinese_checker_blue_ball.Height / 2;
                    }
                    if (num == n & color == "purple")
                    {
                        chinese_checker_purple_position[n].X = mouseX - chinese_checker_purple_ball.Width / 2;
                        chinese_checker_purple_position[n].Y = mouseY - chinese_checker_purple_ball.Height / 2;
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
            for (int n = 0; n < 10; n++)
            {
                Editor.spriteBatch.Draw(chinese_checker_red_texture[n], new Vector2(chinese_checker_red_position[n].X, chinese_checker_red_position[n].Y), Microsoft.Xna.Framework.Color.White);
                Editor.spriteBatch.Draw(chinese_checker_orange_texture[n], new Vector2(chinese_checker_orange_position[n].X, chinese_checker_orange_position[n].Y), Microsoft.Xna.Framework.Color.White);
                Editor.spriteBatch.Draw(chinese_checker_yellow_texture[n], new Vector2(chinese_checker_yellow_position[n].X, chinese_checker_yellow_position[n].Y), Microsoft.Xna.Framework.Color.White);
                Editor.spriteBatch.Draw(chinese_checker_green_texture[n], new Vector2(chinese_checker_green_position[n].X, chinese_checker_green_position[n].Y), Microsoft.Xna.Framework.Color.White);
                Editor.spriteBatch.Draw(chinese_checker_blue_texture[n], new Vector2(chinese_checker_blue_position[n].X, chinese_checker_blue_position[n].Y), Microsoft.Xna.Framework.Color.White);
                Editor.spriteBatch.Draw(chinese_checker_purple_texture[n], new Vector2(chinese_checker_purple_position[n].X, chinese_checker_purple_position[n].Y), Microsoft.Xna.Framework.Color.White);
            }
            if (color == "red")
            {
                Editor.spriteBatch.Draw(chinese_checker_red_texture[num], new Vector2(chinese_checker_red_position[num].X, chinese_checker_red_position[num].Y), Microsoft.Xna.Framework.Color.White);
            }
            if (color == "orange")
            {
                Editor.spriteBatch.Draw(chinese_checker_orange_texture[num], new Vector2(chinese_checker_orange_position[num].X, chinese_checker_orange_position[num].Y), Microsoft.Xna.Framework.Color.White);
            }
            if (color == "yellow")
            {
                Editor.spriteBatch.Draw(chinese_checker_yellow_texture[num], new Vector2(chinese_checker_yellow_position[num].X, chinese_checker_yellow_position[num].Y), Microsoft.Xna.Framework.Color.White);
            }
            if (color == "green")
            {
                Editor.spriteBatch.Draw(chinese_checker_green_texture[num], new Vector2(chinese_checker_green_position[num].X, chinese_checker_green_position[num].Y), Microsoft.Xna.Framework.Color.White);
            }
            if (color == "blue")
            {
                Editor.spriteBatch.Draw(chinese_checker_blue_texture[num], new Vector2(chinese_checker_blue_position[num].X, chinese_checker_blue_position[num].Y), Microsoft.Xna.Framework.Color.White);
            }
            if (color == "purple")
            {
                Editor.spriteBatch.Draw(chinese_checker_purple_texture[num], new Vector2(chinese_checker_purple_position[num].X, chinese_checker_purple_position[num].Y), Microsoft.Xna.Framework.Color.White);
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