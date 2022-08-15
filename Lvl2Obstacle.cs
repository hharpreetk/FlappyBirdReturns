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
    public class Lvl2Obstacle
    {
        public Texture2D texture;
        public Vector2 position;
        public bool scored = false;
        Random rn = new Random();
        Texture2D pixTexture;
        public Lvl2Obstacle()
        {
            this.texture = STATICS.CONTENT.Load<Texture2D>("Images/pipetex");
            pixTexture = STATICS.CONTENT.Load<Texture2D>("Images/pixel");
            this.position = new Vector2(600, rn.Next(-100, 0));
        }

        public void Draw()
        {
            STATICS.SPRITEBATCH.Draw(this.texture, this.position, Color.White);
            STATICS.SPRITEBATCH.Draw(this.pixTexture, this.TopBound, new Color(1f, 0f, 0f, 0.3f));
            STATICS.SPRITEBATCH.Draw(this.pixTexture, this.BottomBound, new Color(1f, 0f, 0f, 0.3f));
        }
        public void Update()
        {
            this.position.X -= 3f;
        }
        public Rectangle TopBound { get { return new Rectangle((int)this.position.X, (int)this.position.Y, 65, 346); } }
        public Rectangle BottomBound { get { return new Rectangle((int)this.position.X, (int)this.position.Y + 517, 65, 383); } }
    }
}
