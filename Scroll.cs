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
    /// Scroll class to draw scroll and animate it
    /// </summary>
    public class Scroll
    {
       
        private Texture2D texture;
        private Vector2 position;
        public int animTimer = 100;
        public double animElapsed = 0;
        private int decalX = 0;
        /// <summary>
        /// Scroll constructor which loads the texture and initialize the position of Scroll
        /// </summary>
        /// <param name="texture"></param>
        public Scroll(Texture2D texture) 
        {
           
            this.texture = texture;
            this.position = new Vector2(0, 753);
        }
        /// <summary>
        /// Scroll Draw method
        /// </summary>
        public void Draw()
        {
            
            STATICS.SPRITEBATCH.Draw(this.texture, position, new Rectangle(this.decalX, 0, (int)STATICS.STAGE_WIDTH, 12), Color.White);
        }

        public void Update()
        {
            animElapsed += STATICS.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (animElapsed > animTimer)
            {
                this.decalX++;
                if (this.decalX > 12)
                {
                    decalX = 0;

                }
                animElapsed = 0;
            }
           
        }
    }
}
