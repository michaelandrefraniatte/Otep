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
        private static Bitmap checkers = Image.FromFile("checkers.png") as Bitmap;
        private static Bitmap checker_black = Image.FromFile("checker-black.png") as Bitmap;
        private static Bitmap checker_white = Image.FromFile("checker-white.png") as Bitmap;
        private static Bitmap checked_black = Image.FromFile("checked-black.png") as Bitmap;
        private static Bitmap checked_white = Image.FromFile("checked-white.png") as Bitmap;
        private static System.Drawing.Point[] checker_black_position = new System.Drawing.Point[20];
        private static System.Drawing.Point[] checker_white_position = new System.Drawing.Point[20];
        private static Texture2D texture;
        private static Texture2D[] checker_black_texture = new Texture2D[20];
        private static Texture2D[] checker_white_texture = new Texture2D[20];
        private static bool[] checked_black_switch = new bool[20];
        private static bool[] checked_white_switch = new bool[20];
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
            checker_black_position[0] = new System.Drawing.Point(174 + 406 / 2, 54 + 59 / 2);
            checker_white_position[0] = new System.Drawing.Point(735 + 406 / 2, 118 + 59 / 2);
            checker_black_position[1] = new System.Drawing.Point(174 + 406 / 2, 177 + 59 / 2);
            checker_white_position[1] = new System.Drawing.Point(735 + 406 / 2, 240 + 59 / 2);
            checker_black_position[2] = new System.Drawing.Point(174 + 406 / 2, 302 + 59 / 2);
            checker_white_position[2] = new System.Drawing.Point(735 + 406 / 2, 362 + 59 / 2);
            checker_black_position[3] = new System.Drawing.Point(174 + 406 / 2, 424 + 59 / 2);
            checker_white_position[3] = new System.Drawing.Point(735 + 406 / 2, 486 + 59 / 2);
            checker_black_position[4] = new System.Drawing.Point(174 + 406 / 2, 547 + 59 / 2);
            checker_white_position[4] = new System.Drawing.Point(735 + 406 / 2, 608 + 59 / 2);
            checker_black_position[5] = new System.Drawing.Point(240 + 406 / 2, 118 + 59 / 2);
            checker_white_position[5] = new System.Drawing.Point(674 + 406 / 2, 54 + 59 / 2);
            checker_black_position[6] = new System.Drawing.Point(240 + 406 / 2, 240 + 59 / 2);
            checker_white_position[6] = new System.Drawing.Point(674 + 406 / 2, 177 + 59 / 2);
            checker_black_position[7] = new System.Drawing.Point(240 + 406 / 2, 362 + 59 / 2);
            checker_white_position[7] = new System.Drawing.Point(674 + 406 / 2, 302 + 59 / 2);
            checker_black_position[8] = new System.Drawing.Point(240 + 406 / 2, 486 + 59 / 2);
            checker_white_position[8] = new System.Drawing.Point(674 + 406 / 2, 424 + 59 / 2);
            checker_black_position[9] = new System.Drawing.Point(240 + 406 / 2, 608 + 59 / 2);
            checker_white_position[9] = new System.Drawing.Point(674 + 406 / 2, 547 + 59 / 2);
            checker_black_position[10] = new System.Drawing.Point(305 + 406 / 2, 54 + 59 / 2);
            checker_white_position[10] = new System.Drawing.Point(613 + 406 / 2, 118 + 59 / 2);
            checker_black_position[11] = new System.Drawing.Point(305 + 406 / 2, 177 + 59 / 2);
            checker_white_position[11] = new System.Drawing.Point(613 + 406 / 2, 240 + 59 / 2);
            checker_black_position[12] = new System.Drawing.Point(305 + 406 / 2, 302 + 59 / 2);
            checker_white_position[12] = new System.Drawing.Point(613 + 406 / 2, 362 + 59 / 2);
            checker_black_position[13] = new System.Drawing.Point(305 + 406 / 2, 424 + 59 / 2);
            checker_white_position[13] = new System.Drawing.Point(613 + 406 / 2, 486 + 59 / 2);
            checker_black_position[14] = new System.Drawing.Point(305 + 406 / 2, 547 + 59 / 2);
            checker_white_position[14] = new System.Drawing.Point(613 + 406 / 2, 608 + 59 / 2);
            checker_black_position[15] = new System.Drawing.Point(368 + 406 / 2, 118 + 59 / 2);
            checker_white_position[15] = new System.Drawing.Point(550 + 406 / 2, 54 + 59 / 2);
            checker_black_position[16] = new System.Drawing.Point(368 + 406 / 2, 240 + 59 / 2);
            checker_white_position[16] = new System.Drawing.Point(550 + 406 / 2, 177 + 59 / 2);
            checker_black_position[17] = new System.Drawing.Point(368 + 406 / 2, 362 + 59 / 2);
            checker_white_position[17] = new System.Drawing.Point(550 + 406 / 2, 302 + 59 / 2);
            checker_black_position[18] = new System.Drawing.Point(368 + 406 / 2, 486 + 59 / 2);
            checker_white_position[18] = new System.Drawing.Point(550 + 406 / 2, 424 + 59 / 2);
            checker_black_position[19] = new System.Drawing.Point(368 + 406 / 2, 608 + 59 / 2);
            checker_white_position[19] = new System.Drawing.Point(550 + 406 / 2, 547 + 59 / 2);
        }
        protected override void Initialize()
        {
            base.Initialize();
            width = 960 + 406;
            height = 709 + 59;
            checker_black = new Bitmap(checker_black, new Size(checker_black.Width / 4, checker_black.Height / 4));
            checker_white = new Bitmap(checker_white, new Size(checker_white.Width / 4, checker_white.Height / 4));
            checked_black = new Bitmap(checked_black, new Size(checked_black.Width / 4, checked_black.Height / 4));
            checked_white = new Bitmap(checked_white, new Size(checked_white.Width / 4, checked_white.Height / 4));
            SetPosition();
            texture = GetTexture2DFromBitmap(checkers);
            checker_black_texture[0] = GetTexture2DFromBitmap(checker_black);
            checker_white_texture[0] = GetTexture2DFromBitmap(checker_white);
            for (int n = 1; n < 20; n++)
            {
                checker_black_texture[n] = checker_black_texture[0];
                checker_white_texture[n] = checker_white_texture[0];
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
            valchanged(0, mouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed);
            if (wu[0] == 1)
            {
                for (int n = 0; n < 20; n++)
                {
                    if (mouseX >= checker_white_position[n].X + 2 & mouseX <= checker_white_position[n].X + checker_white.Width - 2 & mouseY >= checker_white_position[n].Y + 2 & mouseY <= checker_white_position[n].Y + checker_white.Height - 2)
                    {
                        if (!checked_white_switch[n])
                        {
                            checker_white_texture[n] = GetTexture2DFromBitmap(checked_white);
                            checked_white_switch[n] = true;
                        }
                        else
                        {
                            checker_white_texture[n] = GetTexture2DFromBitmap(checker_white);
                            checked_white_switch[n] = false;
                        }
                    }
                    if (mouseX >= checker_black_position[n].X + 2 & mouseX <= checker_black_position[n].X + checker_black.Width - 2 & mouseY >= checker_black_position[n].Y + 2 & mouseY <= checker_black_position[n].Y + checker_black.Height - 2)
                    {
                        if (!checked_black_switch[n])
                        {
                            checker_black_texture[n] = GetTexture2DFromBitmap(checked_black);
                            checked_black_switch[n] = true;
                        }
                        else
                        {
                            checker_black_texture[n] = GetTexture2DFromBitmap(checker_black);
                            checked_black_switch[n] = false;
                        }
                    }
                }
            }
            valchanged(1, mousepressed);
            if (wd[1] == 1)
            {
                for (int n = 0; n < 20; n++)
                {
                    if (mouseX >= checker_black_position[n].X + 2 & mouseX <= checker_black_position[n].X + checker_black.Width - 2 & mouseY >= checker_black_position[n].Y + 2 & mouseY <= checker_black_position[n].Y + checker_black.Height - 2)
                    {
                        num = n;
                        color = "black";
                    }
                    if (mouseX >= checker_white_position[n].X + 2 & mouseX <= checker_white_position[n].X + checker_white.Width - 2 & mouseY >= checker_white_position[n].Y + 2 & mouseY <= checker_white_position[n].Y + checker_white.Height - 2)
                    {
                        num = n;
                        color = "white";
                    }
                }
            }
            if (mousepressed)
            {
                for (int n = 0; n < 20; n++)
                {
                    if (num == n & color == "black")
                    {
                        checker_black_position[n].X = mouseX - checker_black.Width / 2;
                        checker_black_position[n].Y = mouseY - checker_black.Height / 2;
                    }
                    if (num == n & color == "white")
                    {
                        checker_white_position[n].X = mouseX - checker_white.Width / 2;
                        checker_white_position[n].Y = mouseY - checker_white.Height / 2;
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
            for (int n = 0; n < 20; n++)
            {
                Editor.spriteBatch.Draw(checker_black_texture[n], new Vector2(checker_black_position[n].X, checker_black_position[n].Y), Microsoft.Xna.Framework.Color.White);
                Editor.spriteBatch.Draw(checker_white_texture[n], new Vector2(checker_white_position[n].X, checker_white_position[n].Y), Microsoft.Xna.Framework.Color.White);
            }
            if (color == "black")
            {
                Editor.spriteBatch.Draw(checker_black_texture[num], new Vector2(checker_black_position[num].X, checker_black_position[num].Y), Microsoft.Xna.Framework.Color.White);
            }
            if (color == "white")
            {
                Editor.spriteBatch.Draw(checker_white_texture[num], new Vector2(checker_white_position[num].X, checker_white_position[num].Y), Microsoft.Xna.Framework.Color.White);
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