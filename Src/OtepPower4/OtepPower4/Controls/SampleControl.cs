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
        private static Bitmap power4_plate = Image.FromFile("power4-plate.png") as Bitmap;
        private static Bitmap power4_transparent = Image.FromFile("power4-transparent.png") as Bitmap;
        private static Bitmap power4_red = Image.FromFile("power4-red.png") as Bitmap;
        private static Bitmap power4_yellow = Image.FromFile("power4-yellow.png") as Bitmap;
        private static System.Drawing.Point power;
        private static Texture2D texture;
        private static System.Drawing.Point[] power1 = new System.Drawing.Point[6];
        private static Texture2D[] texture1 = new Texture2D[6];
        private static System.Drawing.Point[] power2 = new System.Drawing.Point[6];
        private static Texture2D[] texture2 = new Texture2D[6];
        private static System.Drawing.Point[] power3 = new System.Drawing.Point[6];
        private static Texture2D[] texture3 = new Texture2D[6];
        private static System.Drawing.Point[] power4 = new System.Drawing.Point[6];
        private static Texture2D[] texture4 = new Texture2D[6];
        private static System.Drawing.Point[] power5 = new System.Drawing.Point[6];
        private static Texture2D[] texture5 = new Texture2D[6];
        private static System.Drawing.Point[] power6 = new System.Drawing.Point[6];
        private static Texture2D[] texture6 = new Texture2D[6];
        private static System.Drawing.Point[] power7 = new System.Drawing.Point[6];
        private static Texture2D[] texture7 = new Texture2D[6];
        private static string[] color1 = new string[6];
        private static string[] color2 = new string[6];
        private static string[] color3 = new string[6];
        private static string[] color4 = new string[6];
        private static string[] color5 = new string[6];
        private static string[] color6 = new string[6];
        private static string[] color7 = new string[6];
        private static MouseState mouseState;
        private static KeyboardState keyState;
        private static int mouseX, mouseY, turncount;
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
            texture = GetTexture2DFromBitmap(power4_plate);
            power4_transparent = new Bitmap(power4_transparent, new Size((int)((double)power4_transparent.Width * 0.55f), (int)((double)power4_transparent.Height * 0.55f)));
            power4_red = new Bitmap(power4_red, new Size((int)((double)power4_red.Width * 0.55f), (int)((double)power4_red.Height * 0.55f)));
            power4_yellow = new Bitmap(power4_yellow, new Size((int)((double)power4_yellow.Width * 0.55f), (int)((double)power4_yellow.Height * 0.55f)));
            width = 346;
            height = 115;
            power = new System.Drawing.Point(width, height);
            power1[0] = new System.Drawing.Point(width + 10 + 0 * 17 + 0 * power4_transparent.Width, height + 10 + 0 * 18 + 0 * power4_transparent.Height);
            power1[1] = new System.Drawing.Point(width + 10 + 0 * 17 + 0 * power4_transparent.Width, height + 10 + 1 * 18 + 1 * power4_transparent.Height);
            power1[2] = new System.Drawing.Point(width + 10 + 0 * 17 + 0 * power4_transparent.Width, height + 10 + 2 * 18 + 2 * power4_transparent.Height);
            power1[3] = new System.Drawing.Point(width + 10 + 0 * 17 + 0 * power4_transparent.Width, height + 10 + 3 * 18 + 3 * power4_transparent.Height);
            power1[4] = new System.Drawing.Point(width + 10 + 0 * 17 + 0 * power4_transparent.Width, height + 10 + 4 * 18 + 4 * power4_transparent.Height);
            power1[5] = new System.Drawing.Point(width + 10 + 0 * 17 + 0 * power4_transparent.Width, height + 10 + 5 * 18 + 5 * power4_transparent.Height);
            power2[0] = new System.Drawing.Point(width + 10 + 1 * 17 + 1 * power4_transparent.Width, height + 10 + 0 * 18 + 0 * power4_transparent.Height);
            power2[1] = new System.Drawing.Point(width + 10 + 1 * 17 + 1 * power4_transparent.Width, height + 10 + 1 * 18 + 1 * power4_transparent.Height);
            power2[2] = new System.Drawing.Point(width + 10 + 1 * 17 + 1 * power4_transparent.Width, height + 10 + 2 * 18 + 2 * power4_transparent.Height);
            power2[3] = new System.Drawing.Point(width + 10 + 1 * 17 + 1 * power4_transparent.Width, height + 10 + 3 * 18 + 3 * power4_transparent.Height);
            power2[4] = new System.Drawing.Point(width + 10 + 1 * 17 + 1 * power4_transparent.Width, height + 10 + 4 * 18 + 4 * power4_transparent.Height);
            power2[5] = new System.Drawing.Point(width + 10 + 1 * 17 + 1 * power4_transparent.Width, height + 10 + 5 * 18 + 5 * power4_transparent.Height);
            power3[0] = new System.Drawing.Point(width + 10 + 2 * 17 + 2 * power4_transparent.Width, height + 10 + 0 * 18 + 0 * power4_transparent.Height);
            power3[1] = new System.Drawing.Point(width + 10 + 2 * 17 + 2 * power4_transparent.Width, height + 10 + 1 * 18 + 1 * power4_transparent.Height);
            power3[2] = new System.Drawing.Point(width + 10 + 2 * 17 + 2 * power4_transparent.Width, height + 10 + 2 * 18 + 2 * power4_transparent.Height);
            power3[3] = new System.Drawing.Point(width + 10 + 2 * 17 + 2 * power4_transparent.Width, height + 10 + 3 * 18 + 3 * power4_transparent.Height);
            power3[4] = new System.Drawing.Point(width + 10 + 2 * 17 + 2 * power4_transparent.Width, height + 10 + 4 * 18 + 4 * power4_transparent.Height);
            power3[5] = new System.Drawing.Point(width + 10 + 2 * 17 + 2 * power4_transparent.Width, height + 10 + 5 * 18 + 5 * power4_transparent.Height);
            power4[0] = new System.Drawing.Point(width + 10 + 3 * 17 + 3 * power4_transparent.Width, height + 10 + 0 * 18 + 0 * power4_transparent.Height);
            power4[1] = new System.Drawing.Point(width + 10 + 3 * 17 + 3 * power4_transparent.Width, height + 10 + 1 * 18 + 1 * power4_transparent.Height);
            power4[2] = new System.Drawing.Point(width + 10 + 3 * 17 + 3 * power4_transparent.Width, height + 10 + 2 * 18 + 2 * power4_transparent.Height);
            power4[3] = new System.Drawing.Point(width + 10 + 3 * 17 + 3 * power4_transparent.Width, height + 10 + 3 * 18 + 3 * power4_transparent.Height);
            power4[4] = new System.Drawing.Point(width + 10 + 3 * 17 + 3 * power4_transparent.Width, height + 10 + 4 * 18 + 4 * power4_transparent.Height);
            power4[5] = new System.Drawing.Point(width + 10 + 3 * 17 + 3 * power4_transparent.Width, height + 10 + 5 * 18 + 5 * power4_transparent.Height);
            power5[0] = new System.Drawing.Point(width + 10 + 4 * 17 + 4 * power4_transparent.Width, height + 10 + 0 * 18 + 0 * power4_transparent.Height);
            power5[1] = new System.Drawing.Point(width + 10 + 4 * 17 + 4 * power4_transparent.Width, height + 10 + 1 * 18 + 1 * power4_transparent.Height);
            power5[2] = new System.Drawing.Point(width + 10 + 4 * 17 + 4 * power4_transparent.Width, height + 10 + 2 * 18 + 2 * power4_transparent.Height);
            power5[3] = new System.Drawing.Point(width + 10 + 4 * 17 + 4 * power4_transparent.Width, height + 10 + 3 * 18 + 3 * power4_transparent.Height);
            power5[4] = new System.Drawing.Point(width + 10 + 4 * 17 + 4 * power4_transparent.Width, height + 10 + 4 * 18 + 4 * power4_transparent.Height);
            power5[5] = new System.Drawing.Point(width + 10 + 4 * 17 + 4 * power4_transparent.Width, height + 10 + 5 * 18 + 5 * power4_transparent.Height);
            power6[0] = new System.Drawing.Point(width + 10 + 5 * 17 + 5 * power4_transparent.Width, height + 10 + 0 * 18 + 0 * power4_transparent.Height);
            power6[1] = new System.Drawing.Point(width + 10 + 5 * 17 + 5 * power4_transparent.Width, height + 10 + 1 * 18 + 1 * power4_transparent.Height);
            power6[2] = new System.Drawing.Point(width + 10 + 5 * 17 + 5 * power4_transparent.Width, height + 10 + 2 * 18 + 2 * power4_transparent.Height);
            power6[3] = new System.Drawing.Point(width + 10 + 5 * 17 + 5 * power4_transparent.Width, height + 10 + 3 * 18 + 3 * power4_transparent.Height);
            power6[4] = new System.Drawing.Point(width + 10 + 5 * 17 + 5 * power4_transparent.Width, height + 10 + 4 * 18 + 4 * power4_transparent.Height);
            power6[5] = new System.Drawing.Point(width + 10 + 5 * 17 + 5 * power4_transparent.Width, height + 10 + 5 * 18 + 5 * power4_transparent.Height);
            power7[0] = new System.Drawing.Point(width + 10 + 6 * 17 + 6 * power4_transparent.Width, height + 10 + 0 * 18 + 0 * power4_transparent.Height);
            power7[1] = new System.Drawing.Point(width + 10 + 6 * 17 + 6 * power4_transparent.Width, height + 10 + 1 * 18 + 1 * power4_transparent.Height);
            power7[2] = new System.Drawing.Point(width + 10 + 6 * 17 + 6 * power4_transparent.Width, height + 10 + 2 * 18 + 2 * power4_transparent.Height);
            power7[3] = new System.Drawing.Point(width + 10 + 6 * 17 + 6 * power4_transparent.Width, height + 10 + 3 * 18 + 3 * power4_transparent.Height);
            power7[4] = new System.Drawing.Point(width + 10 + 6 * 17 + 6 * power4_transparent.Width, height + 10 + 4 * 18 + 4 * power4_transparent.Height);
            power7[5] = new System.Drawing.Point(width + 10 + 6 * 17 + 6 * power4_transparent.Width, height + 10 + 5 * 18 + 5 * power4_transparent.Height);
        }
        private void InitPlate()
        {
            turncount = 0;
            for (int n = 0; n < 6; n++)
            {
                texture1[n] = GetTexture2DFromBitmap(power4_transparent);
                texture2[n] = GetTexture2DFromBitmap(power4_transparent);
                texture3[n] = GetTexture2DFromBitmap(power4_transparent);
                texture4[n] = GetTexture2DFromBitmap(power4_transparent);
                texture5[n] = GetTexture2DFromBitmap(power4_transparent);
                texture6[n] = GetTexture2DFromBitmap(power4_transparent);
                texture7[n] = GetTexture2DFromBitmap(power4_transparent);
                color1[n] = "transparent";
                color2[n] = "transparent";
                color3[n] = "transparent";
                color4[n] = "transparent";
                color5[n] = "transparent";
                color6[n] = "transparent";
                color7[n] = "transparent";
            }
        }
        protected override void Initialize()
        {
            base.Initialize();
            base.BackColor = System.Drawing.Color.Black;
            base.ForeColor = System.Drawing.Color.Black;
            SetPosition();
            InitPlate();
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
                InitPlate();
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
                for (int n = 0; n < 6; n++)
                {
                    if (mouseX >= power1[n].X + 2 & mouseX <= power1[n].X + power4_transparent.Width - 2 & mouseY >= power1[n].Y + 2 & mouseY <= power1[n].Y + power4_transparent.Height - 2)
                    {
                        if (color1[n] == "transparent")
                        {
                            if (turncount < 1)
                            {
                                if (n == 5)
                                {
                                    texture1[n] = GetTexture2DFromBitmap(power4_red);
                                    color1[n] = "red";
                                    turncount++;
                                }
                                else if (n < 5)
                                {
                                    if (color1[n + 1] != "transparent")
                                    {
                                        texture1[n] = GetTexture2DFromBitmap(power4_red);
                                        color1[n] = "red";
                                        turncount++;
                                    }
                                }
                            }
                            else if (turncount > 0)
                            {
                                if (n == 5)
                                {
                                    texture1[n] = GetTexture2DFromBitmap(power4_yellow);
                                    color1[n] = "yellow";
                                    turncount++;
                                }
                                else if (n < 5)
                                {
                                    if (color1[n + 1] != "transparent")
                                    {
                                        texture1[n] = GetTexture2DFromBitmap(power4_yellow);
                                        color1[n] = "yellow";
                                        turncount++;
                                    }
                                }
                            }
                        }
                    }
                    if (mouseX >= power2[n].X + 2 & mouseX <= power2[n].X + power4_transparent.Width - 2 & mouseY >= power2[n].Y + 2 & mouseY <= power2[n].Y + power4_transparent.Height - 2)
                    {
                        if (color2[n] == "transparent")
                        {
                            if (turncount < 1)
                            {
                                if (n == 5)
                                {
                                    texture2[n] = GetTexture2DFromBitmap(power4_red);
                                    color2[n] = "red";
                                    turncount++;
                                }
                                else if (n < 5)
                                {
                                    if (color2[n + 1] != "transparent")
                                    {
                                        texture2[n] = GetTexture2DFromBitmap(power4_red);
                                        color2[n] = "red";
                                        turncount++;
                                    }
                                }
                            }
                            else if (turncount > 0)
                            {
                                if (n == 5)
                                {
                                    texture2[n] = GetTexture2DFromBitmap(power4_yellow);
                                    color2[n] = "yellow";
                                    turncount++;
                                }
                                else if (n < 5)
                                {
                                    if (color2[n + 1] != "transparent")
                                    {
                                        texture2[n] = GetTexture2DFromBitmap(power4_yellow);
                                        color2[n] = "yellow";
                                        turncount++;
                                    }
                                }
                            }
                        }
                    }
                    if (mouseX >= power3[n].X + 2 & mouseX <= power3[n].X + power4_transparent.Width - 2 & mouseY >= power3[n].Y + 2 & mouseY <= power3[n].Y + power4_transparent.Height - 2)
                    {
                        if (color3[n] == "transparent")
                        {
                            if (turncount < 1)
                            {
                                if (n == 5)
                                {
                                    texture3[n] = GetTexture2DFromBitmap(power4_red);
                                    color3[n] = "red";
                                    turncount++;
                                }
                                else if (n < 5)
                                {
                                    if (color3[n + 1] != "transparent")
                                    {
                                        texture3[n] = GetTexture2DFromBitmap(power4_red);
                                        color3[n] = "red";
                                        turncount++;
                                    }
                                }
                            }
                            else if (turncount > 0)
                            {
                                if (n == 5)
                                {
                                    texture3[n] = GetTexture2DFromBitmap(power4_yellow);
                                    color3[n] = "yellow";
                                    turncount++;
                                }
                                else if (n < 5)
                                {
                                    if (color3[n + 1] != "transparent")
                                    {
                                        texture3[n] = GetTexture2DFromBitmap(power4_yellow);
                                        color3[n] = "yellow";
                                        turncount++;
                                    }
                                }
                            }
                        }
                    }
                    if (mouseX >= power4[n].X + 2 & mouseX <= power4[n].X + power4_transparent.Width - 2 & mouseY >= power4[n].Y + 2 & mouseY <= power4[n].Y + power4_transparent.Height - 2)
                    {
                        if (color4[n] == "transparent")
                        {
                            if (turncount < 1)
                            {
                                if (n == 5)
                                {
                                    texture4[n] = GetTexture2DFromBitmap(power4_red);
                                    color4[n] = "red";
                                    turncount++;
                                }
                                else if (n < 5)
                                {
                                    if (color4[n + 1] != "transparent")
                                    {
                                        texture4[n] = GetTexture2DFromBitmap(power4_red);
                                        color4[n] = "red";
                                        turncount++;
                                    }
                                }
                            }
                            else if (turncount > 0)
                            {
                                if (n == 5)
                                {
                                    texture4[n] = GetTexture2DFromBitmap(power4_yellow);
                                    color4[n] = "yellow";
                                    turncount++;
                                }
                                else if (n < 5)
                                {
                                    if (color4[n + 1] != "transparent")
                                    {
                                        texture4[n] = GetTexture2DFromBitmap(power4_yellow);
                                        color4[n] = "yellow";
                                        turncount++;
                                    }
                                }
                            }
                        }
                    }
                    if (mouseX >= power5[n].X + 2 & mouseX <= power5[n].X + power4_transparent.Width - 2 & mouseY >= power5[n].Y + 2 & mouseY <= power5[n].Y + power4_transparent.Height - 2)
                    {
                        if (color5[n] == "transparent")
                        {
                            if (turncount < 1)
                            {
                                if (n == 5)
                                {
                                    texture5[n] = GetTexture2DFromBitmap(power4_red);
                                    color5[n] = "red";
                                    turncount++;
                                }
                                else if (n < 5)
                                {
                                    if (color5[n + 1] != "transparent")
                                    {
                                        texture5[n] = GetTexture2DFromBitmap(power4_red);
                                        color5[n] = "red";
                                        turncount++;
                                    }
                                }
                            }
                            else if (turncount > 0)
                            {
                                if (n == 5)
                                {
                                    texture5[n] = GetTexture2DFromBitmap(power4_yellow);
                                    color5[n] = "yellow";
                                    turncount++;
                                }
                                else if (n < 5)
                                {
                                    if (color5[n + 1] != "transparent")
                                    {
                                        texture5[n] = GetTexture2DFromBitmap(power4_yellow);
                                        color5[n] = "yellow";
                                        turncount++;
                                    }
                                }
                            }
                        }
                    }
                    if (mouseX >= power6[n].X + 2 & mouseX <= power6[n].X + power4_transparent.Width - 2 & mouseY >= power6[n].Y + 2 & mouseY <= power6[n].Y + power4_transparent.Height - 2)
                    {
                        if (color6[n] == "transparent")
                        {
                            if (turncount < 1)
                            {
                                if (n == 5)
                                {
                                    texture6[n] = GetTexture2DFromBitmap(power4_red);
                                    color6[n] = "red";
                                    turncount++;
                                }
                                else if (n < 5)
                                {
                                    if (color6[n + 1] != "transparent")
                                    {
                                        texture6[n] = GetTexture2DFromBitmap(power4_red);
                                        color6[n] = "red";
                                        turncount++;
                                    }
                                }
                            }
                            else if (turncount > 0)
                            {
                                if (n == 5)
                                {
                                    texture6[n] = GetTexture2DFromBitmap(power4_yellow);
                                    color6[n] = "yellow";
                                    turncount++;
                                }
                                else if (n < 5)
                                {
                                    if (color6[n + 1] != "transparent")
                                    {
                                        texture6[n] = GetTexture2DFromBitmap(power4_yellow);
                                        color6[n] = "yellow";
                                        turncount++;
                                    }
                                }
                            }
                        }
                    }
                    if (mouseX >= power7[n].X + 2 & mouseX <= power7[n].X + power4_transparent.Width - 2 & mouseY >= power7[n].Y + 2 & mouseY <= power7[n].Y + power4_transparent.Height - 2)
                    {
                        if (color7[n] == "transparent")
                        {
                            if (turncount < 1)
                            {
                                if (n == 5)
                                {
                                    texture7[n] = GetTexture2DFromBitmap(power4_red);
                                    color7[n] = "red";
                                    turncount++;
                                }
                                else if (n < 5)
                                {
                                    if (color7[n + 1] != "transparent")
                                    {
                                        texture7[n] = GetTexture2DFromBitmap(power4_red);
                                        color7[n] = "red";
                                        turncount++;
                                    }
                                }
                            }
                            else if (turncount > 0)
                            {
                                if (n == 5)
                                {
                                    texture7[n] = GetTexture2DFromBitmap(power4_yellow);
                                    color7[n] = "yellow";
                                    turncount++;
                                }
                                else if (n < 5)
                                {
                                    if (color7[n + 1] != "transparent")
                                    {
                                        texture7[n] = GetTexture2DFromBitmap(power4_yellow);
                                        color7[n] = "yellow";
                                        turncount++;
                                    }
                                }
                            }
                        }
                    }
                }
                if (turncount > 1)
                    turncount = 0;
            }
            base.Draw();
            Editor.spriteBatch.Begin(); 
            Editor.BackgroundColor = Microsoft.Xna.Framework.Color.Black;
            Editor.spriteBatch.Draw(texture, new Vector2(power.X, power.Y), Microsoft.Xna.Framework.Color.White);
            for (int n = 0; n < 6; n++)
            {
                Editor.spriteBatch.Draw(texture1[n], new Vector2(power1[n].X, power1[n].Y), Microsoft.Xna.Framework.Color.White);
                Editor.spriteBatch.Draw(texture2[n], new Vector2(power2[n].X, power2[n].Y), Microsoft.Xna.Framework.Color.White);
                Editor.spriteBatch.Draw(texture3[n], new Vector2(power3[n].X, power3[n].Y), Microsoft.Xna.Framework.Color.White);
                Editor.spriteBatch.Draw(texture4[n], new Vector2(power4[n].X, power4[n].Y), Microsoft.Xna.Framework.Color.White);
                Editor.spriteBatch.Draw(texture5[n], new Vector2(power5[n].X, power5[n].Y), Microsoft.Xna.Framework.Color.White);
                Editor.spriteBatch.Draw(texture6[n], new Vector2(power6[n].X, power6[n].Y), Microsoft.Xna.Framework.Color.White);
                Editor.spriteBatch.Draw(texture7[n], new Vector2(power7[n].X, power7[n].Y), Microsoft.Xna.Framework.Color.White);
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