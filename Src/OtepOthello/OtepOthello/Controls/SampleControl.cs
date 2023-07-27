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
        private static Bitmap othello = Image.FromFile("othello.png") as Bitmap;
        private static Bitmap othello_black = Image.FromFile("othello-black.png") as Bitmap;
        private static Bitmap othello_white = Image.FromFile("othello-white.png") as Bitmap;
        private static System.Drawing.Point[] othello_black_position = new System.Drawing.Point[32];
        private static System.Drawing.Point[] othello_white_position = new System.Drawing.Point[32];
        private static Texture2D texture;
        private static Texture2D[] othello_black_texture = new Texture2D[32];
        private static Texture2D[] othello_white_texture = new Texture2D[32];
        private static bool[] othello_black_switch = new bool[32];
        private static bool[] othello_white_switch = new bool[32];
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
            othello_black_position[0] = new System.Drawing.Point(240, 354);
            othello_white_position[0] = new System.Drawing.Point(1080, 354);
            othello_black_position[1] = new System.Drawing.Point(240, 354);
            othello_white_position[1] = new System.Drawing.Point(1080, 354);
            othello_black_position[2] = new System.Drawing.Point(240, 354);
            othello_white_position[2] = new System.Drawing.Point(1080, 354);
            othello_black_position[3] = new System.Drawing.Point(240, 354);
            othello_white_position[3] = new System.Drawing.Point(1080, 354);
            othello_black_position[4] = new System.Drawing.Point(240, 354);
            othello_white_position[4] = new System.Drawing.Point(1080, 354);
            othello_black_position[5] = new System.Drawing.Point(240, 354);
            othello_white_position[5] = new System.Drawing.Point(1080, 354);
            othello_black_position[6] = new System.Drawing.Point(240, 354);
            othello_white_position[6] = new System.Drawing.Point(1080, 354);
            othello_black_position[7] = new System.Drawing.Point(240, 354);
            othello_white_position[7] = new System.Drawing.Point(1080, 354);
            othello_black_position[8] = new System.Drawing.Point(240, 354);
            othello_white_position[8] = new System.Drawing.Point(1080, 354);
            othello_black_position[9] = new System.Drawing.Point(240, 354);
            othello_white_position[9] = new System.Drawing.Point(1080, 354);
            othello_black_position[10] = new System.Drawing.Point(240, 354);
            othello_white_position[10] = new System.Drawing.Point(1080, 354);
            othello_black_position[11] = new System.Drawing.Point(240, 354);
            othello_white_position[11] = new System.Drawing.Point(1080, 354);
            othello_black_position[12] = new System.Drawing.Point(240, 354);
            othello_white_position[12] = new System.Drawing.Point(1080, 354);
            othello_black_position[13] = new System.Drawing.Point(240, 354);
            othello_white_position[13] = new System.Drawing.Point(1080, 354);
            othello_black_position[14] = new System.Drawing.Point(240, 354);
            othello_white_position[14] = new System.Drawing.Point(1080, 354);
            othello_black_position[15] = new System.Drawing.Point(240, 354);
            othello_white_position[15] = new System.Drawing.Point(1080, 354);
            othello_black_position[16] = new System.Drawing.Point(240, 354);
            othello_white_position[16] = new System.Drawing.Point(1080, 354);
            othello_black_position[17] = new System.Drawing.Point(240, 354);
            othello_white_position[17] = new System.Drawing.Point(1080, 354);
            othello_black_position[18] = new System.Drawing.Point(240, 354);
            othello_white_position[18] = new System.Drawing.Point(1080, 354);
            othello_black_position[19] = new System.Drawing.Point(240, 354);
            othello_white_position[19] = new System.Drawing.Point(1080, 354);
            othello_black_position[20] = new System.Drawing.Point(240, 354);
            othello_white_position[20] = new System.Drawing.Point(1080, 354);
            othello_black_position[21] = new System.Drawing.Point(240, 354);
            othello_white_position[21] = new System.Drawing.Point(1080, 354);
            othello_black_position[22] = new System.Drawing.Point(240, 354);
            othello_white_position[22] = new System.Drawing.Point(1080, 354);
            othello_black_position[23] = new System.Drawing.Point(240, 354);
            othello_white_position[23] = new System.Drawing.Point(1080, 354);
            othello_black_position[24] = new System.Drawing.Point(240, 354);
            othello_white_position[24] = new System.Drawing.Point(1080, 354);
            othello_black_position[25] = new System.Drawing.Point(240, 354);
            othello_white_position[25] = new System.Drawing.Point(1080, 354);
            othello_black_position[26] = new System.Drawing.Point(240, 354);
            othello_white_position[26] = new System.Drawing.Point(1080, 354);
            othello_black_position[27] = new System.Drawing.Point(240, 354);
            othello_white_position[27] = new System.Drawing.Point(1080, 354);
            othello_black_position[28] = new System.Drawing.Point(240, 354);
            othello_white_position[28] = new System.Drawing.Point(1080, 354);
            othello_black_position[29] = new System.Drawing.Point(240, 354);
            othello_white_position[29] = new System.Drawing.Point(1080, 354);
            othello_black_position[30] = new System.Drawing.Point(240, 354);
            othello_white_position[30] = new System.Drawing.Point(1080, 354);
            othello_black_position[31] = new System.Drawing.Point(240, 354);
            othello_white_position[31] = new System.Drawing.Point(1080, 354);
        }
        protected override void Initialize()
        {
            base.Initialize();
            width = 960 + 406;
            height = 709 + 59;
            othello_black = new Bitmap(othello_black, new Size((int)((double)othello_black.Width / 3), (int)((double)othello_black.Height / 3)));
            othello_white = new Bitmap(othello_white, new Size((int)((double)othello_white.Width / 3), (int)((double)othello_white.Height / 3)));
            SetPosition();
            texture = GetTexture2DFromBitmap(othello);
            othello_black_texture[0] = GetTexture2DFromBitmap(othello_black);
            othello_white_texture[0] = GetTexture2DFromBitmap(othello_white);
            for (int n = 1; n < 32; n++)
            {
                othello_black_texture[n] = othello_black_texture[0];
                othello_white_texture[n] = othello_white_texture[0];
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
                for (int n = 0; n < 32; n++)
                {
                    if (mouseX >= othello_white_position[n].X + 2 & mouseX <= othello_white_position[n].X + othello_white.Width - 2 & mouseY >= othello_white_position[n].Y + 2 & mouseY <= othello_white_position[n].Y + othello_white.Height - 2)
                    {
                        if (!othello_white_switch[n])
                        {
                            othello_white_texture[n] = othello_black_texture[0];
                            othello_white_switch[n] = true;
                        }
                        else
                        {
                            othello_white_texture[n] = othello_white_texture[0];
                            othello_white_switch[n] = false;
                        }
                    }
                    if (mouseX >= othello_black_position[n].X + 2 & mouseX <= othello_black_position[n].X + othello_black.Width - 2 & mouseY >= othello_black_position[n].Y + 2 & mouseY <= othello_black_position[n].Y + othello_black.Height - 2)
                    {
                        if (!othello_black_switch[n])
                        {
                            othello_black_texture[n] = othello_white_texture[0];
                            othello_black_switch[n] = true;
                        }
                        else
                        {
                            othello_black_texture[n] = othello_black_texture[0];
                            othello_black_switch[n] = false;
                        }
                    }
                }
            }
            valchanged(1, mousepressed);
            if (wd[1] == 1)
            {
                for (int n = 0; n < 32; n++)
                {
                    if (mouseX >= othello_black_position[n].X + 2 & mouseX <= othello_black_position[n].X + othello_black.Width - 2 & mouseY >= othello_black_position[n].Y + 2 & mouseY <= othello_black_position[n].Y + othello_black.Height - 2)
                    {
                        num = n;
                        color = "black";
                    }
                    if (mouseX >= othello_white_position[n].X + 2 & mouseX <= othello_white_position[n].X + othello_white.Width - 2 & mouseY >= othello_white_position[n].Y + 2 & mouseY <= othello_white_position[n].Y + othello_white.Height - 2)
                    {
                        num = n;
                        color = "white";
                    }
                }
            }
            if (mousepressed)
            {
                for (int n = 0; n < 32; n++)
                {
                    if (num == n & color == "black")
                    {
                        othello_black_position[n].X = mouseX - othello_black.Width / 2;
                        othello_black_position[n].Y = mouseY - othello_black.Height / 2;
                    }
                    if (num == n & color == "white")
                    {
                        othello_white_position[n].X = mouseX - othello_white.Width / 2;
                        othello_white_position[n].Y = mouseY - othello_white.Height / 2;
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
            for (int n = 0; n < 32; n++)
            {
                Editor.spriteBatch.Draw(othello_black_texture[n], new Vector2(othello_black_position[n].X, othello_black_position[n].Y), Microsoft.Xna.Framework.Color.White);
                Editor.spriteBatch.Draw(othello_white_texture[n], new Vector2(othello_white_position[n].X, othello_white_position[n].Y), Microsoft.Xna.Framework.Color.White);
            }
            if (color == "black")
            {
                Editor.spriteBatch.Draw(othello_black_texture[num], new Vector2(othello_black_position[num].X, othello_black_position[num].Y), Microsoft.Xna.Framework.Color.White);
            }
            if (color == "white")
            {
                Editor.spriteBatch.Draw(othello_white_texture[num], new Vector2(othello_white_position[num].X, othello_white_position[num].Y), Microsoft.Xna.Framework.Color.White);
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