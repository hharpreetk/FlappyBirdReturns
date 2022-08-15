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
    /// Simple class which draws the lavaground
    /// </summary>
    public class LavaGround
    {
        public Texture2D tex;
        public Vector2 position;
        public Vector2 position1, position2;
        /// <summary>
        /// LavaGround constructor which loads the texture and intialize variables
        /// </summary>
        /// <param name="texture"></param>
        public LavaGround(Texture2D texture)
        {
            
            this.tex = texture;
            this.position = new Vector2(0, 750);
            this.position1 = position;
            this.position2 = new Vector2(position.X + tex.Width, position.Y);


        }
        public void Draw()
        {
            STATICS.SPRITEBATCH.Draw(tex, position1, Color.White);
            STATICS.SPRITEBATCH.Draw(tex, position2, Color.White);
        }
        public void Update()
        {
            Vector2 speed = new Vector2(1, 0);
            //to scroll the background to left
            //decrease the position1 on screen by speed
            position1 -= speed;
            //change the position2 with position1
            position2 -= speed;
            //if the x-coordinate of position1 is less than the -texture width 
            //x is 0 initially
            //x becomes -texturewidth if one full screen scrolls to the left
            if (position1.X < -tex.Width)
            {
                //new position1 will be the screen width plus the position2
                position1.X = position2.X + tex.Width;
            }
            if (position2.X < -tex.Width)
            {
                //if position2 goes to the left of tex.width then change the position2 to position1 plus the tex.width
                position2.X = position1.X + tex.Width;
            }
        }
        public Rectangle GroundBound { get { return new Rectangle((int)this.position.X, (int)this.position.Y, 600, 150); } }
    }
}
