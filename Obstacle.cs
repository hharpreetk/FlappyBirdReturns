using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
namespace HKaurFinalProject
{
    /// <summary>
    /// Obstacle class which draws the pipes at different heights
    /// </summary>
    public class Obstacle
    {
        public Texture2D texture;
        public Vector2 position;
        public bool scored = false;
        Random rn = new Random();
        /// <summary>
        /// Obstacle constructor which loads the Obstacle texture and initialize the random position of Obstacle
        /// </summary>
        public Obstacle()
        {
            this.texture = STATICS.CONTENT.Load<Texture2D>("Images/pipetex");
            this.position = new Vector2(600, rn.Next(-100, 0));
        }

        public void Draw()
        {
            STATICS.SPRITEBATCH.Draw(this.texture, this.position, Color.White);
        }
        public void Update()
        {
            this.position.X -= 3f;
        }
        public Rectangle TopBound { get { return new Rectangle((int)this.position.X, (int)this.position.Y, 65, 346); } }
        public Rectangle BottomBound { get { return new Rectangle((int)this.position.X, (int)this.position.Y + 517, 65, 383); } }
    }
}
