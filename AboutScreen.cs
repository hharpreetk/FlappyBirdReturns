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
    /// About Screen class that inherits from Screen class
    /// </summary>
    public class AboutScreen: Screen
    {
        private Game1 parent;
        private Texture2D background;
        private KeyboardState oldstate;
        public AboutScreen(Game game)
        {
            this.parent = (Game1)game;
            //Load about screen
            background = STATICS.CONTENT.Load<Texture2D>("Images/about");
           
        }
        public override void Draw()
        {
            STATICS.SPRITEBATCH.Begin(); // Initialize drawing support
            STATICS.SPRITEBATCH.Draw(background, Vector2.Zero, Color.White);
            STATICS.SPRITEBATCH.End();// Inform graphics system we are done drawing
        }
        /// <summary>
        /// Allows the game to check for the key pressed
        /// and notify the Game1 Notify method
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update()
        {
            //checks the key pressed on  keyboard
            KeyboardState ks = Keyboard.GetState();
            //checks if Back key is released in oldstate and pressed in current state
            if (ks.IsKeyDown(Keys.Back) && oldstate.IsKeyUp(Keys.Back))
            {
                //call the Notify method of Game1 class
                parent.Notify(this, "Backspace");
            }
            ////set the state of keyboard to oldstate
            oldstate = ks;
        }
    }
}
