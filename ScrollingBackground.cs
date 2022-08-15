/* HKaurFinalProject.cs
* Final Project
* Revision History
* Harpreet Kaur, 2019.12.08: Created
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace HKaurFinalProject
{
    /// <summary>
    /// Class which animates the background
    /// </summary>
    public class ScrollingBackground
    {
        public Texture2D tex1, tex2;
        public Vector2 position1, position2;
        public Vector2 speed;
        public Rectangle srcRect;

        public ScrollingBackground(Texture2D tex1, Texture2D tex2, Vector2 position, Rectangle srcRect, Vector2 speed)
        {
            this.tex1 = tex1;
            this.tex2 = tex2;
            this.position1 = position;
            this.srcRect = srcRect;
            this.speed = speed;
            this.position2 = new Vector2(position.X + tex1.Width, position.Y);
        }
        public void Draw()
        {
            //draw the texture//screen

            STATICS.SPRITEBATCH.Draw(tex1, position1, srcRect, Color.White);
            
            //so we see continous two textures
            STATICS.SPRITEBATCH.Draw(tex2, position2, srcRect, Color.White);
            
        }

        public void Update()
        {
            //to scroll the background to left
            //decrease the position1 on screen by speed
            position1 -= speed;
            //change the position2 with position1
            position2 -= speed;
            //if the x-coordinate of position1 is less than the -texture width 
            //x is 0 initially
            //x becomes -texturewidth if one full screen scrolls to the left
            if (position1.X < -tex1.Width)
            {
                //new position1 will be the screen width plus the position2
                position1.X = position2.X + tex1.Width;
            }
            if (position2.X < -tex1.Width)
            {
                //if position2 goes to the left of tex.width then change the position2 to position1 plus the tex.width
                position2.X = position1.X + tex1.Width;
            }
        }
    }
}
