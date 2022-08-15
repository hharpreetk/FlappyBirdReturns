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
    public class HelpScreen : Screen
    {
        private Game1 parent;
        private Texture2D background;
        private Texture2D controls;
        private KeyboardState oldstate;
        public HelpScreen(Game game)
        {
            this.parent = (Game1)game;
            background = STATICS.CONTENT.Load<Texture2D>("Images/b1");
            controls = STATICS.CONTENT.Load<Texture2D>("Images/help");
        }

        public override void Draw()
        {
            STATICS.SPRITEBATCH.Begin();
            STATICS.SPRITEBATCH.Draw(controls, Vector2.Zero, Color.White);
            STATICS.SPRITEBATCH.End();
        }
        public override void Update()
        {
            KeyboardState ks = Keyboard.GetState();
           
            if (ks.IsKeyDown(Keys.Back) && oldstate.IsKeyUp(Keys.Back))
            {
                parent.Notify(this, "Backspace");
            }
            oldstate = ks;
        }
    }
}
