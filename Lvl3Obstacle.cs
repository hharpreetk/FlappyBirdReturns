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
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HKaurFinalProject
{
    public class Lvl3Obstacle
    {
        public Texture2D texture;
        public Vector2 position;
        public bool scored = false;
        Texture2D pixTexture;
        Random rn = new Random();
        public Lvl3Obstacle()
        {
            this.texture = STATICS.CONTENT.Load<Texture2D>("lvl3Images/lvl3obstacle");
            pixTexture = STATICS.CONTENT.Load<Texture2D>("lvl3Images/pixel");
            this.position = new Vector2(600, rn.Next(-100, 0));
        }

        public void Draw()
        {
            //STATICS.SPRITEBATCH.Draw(this.pixTexture, this.TopBound, new Color(1f, 0f, 0f, 0.3f));
            //STATICS.SPRITEBATCH.Draw(this.pixTexture, this.BottomBound, new Color(1f, 0f, 0f, 0.3f));
            STATICS.SPRITEBATCH.Draw(this.texture, this.position, Color.White);
        }
        public void Update()
        {
            this.position.X -= 3f;
        }
        public Rectangle TopBound { get { return new Rectangle((int)this.position.X, (int)this.position.Y, 65, 383); } }
        public Rectangle BottomBound { get { return new Rectangle((int)this.position.X, (int)this.position.Y + 517, 65, 383); } }
    }
}
