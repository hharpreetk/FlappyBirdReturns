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
using Microsoft.Xna.Framework.Media;
namespace HKaurFinalProject
{
    /// <summary>
    /// Simple class which draws the ground
    /// </summary>
    public class Ground
    {
        public Texture2D tex;
        public Vector2 position;
        /// <summary>
        /// Ground constructor which loads the texture and intialize variables
        /// </summary>
        /// <param name="texture"></param>
        public Ground(Texture2D texture)
        {
            this.tex = texture;
            this.position = new Vector2(0, 753);
        }
        /// <summary>
        /// Ground Draw method to draw sprites 
        /// </summary>
        public void Draw()
        {
           STATICS.SPRITEBATCH.Draw(tex, position, Color.White);
        }
        //Ground bound property 
        
        public Rectangle GroundBound { get { return new Rectangle((int)this.position.X, (int)this.position.Y, 600, 147); } }
    }
}
