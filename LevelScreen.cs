using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace HKaurFinalProject
{
    /// <summary>
    /// Level Screen class that inherits from Screen class
    /// Displays the Level difficulty options on screen
    /// </summary>
    public class LevelScreen: Screen
    {
        private Game1 parent;
        private int selectedIndex;
        private List<string> menuItems;
        private Texture2D easyLevel;
        private Texture2D normalLevel;
        private Texture2D hardLevel;
        private SoundEffect buttonClick;
        private bool isPlayButton = false;
        private KeyboardState oldState;
        /// <summary>
        /// LevelScreen constructor to load the images, fonts, music, sounds, and list of menuItems
        /// </summary>
        /// <param name="game"></param>
        /// <param name="menuItems"></param>
        public LevelScreen(Game game, List<string> menuItems)
        {
            this.parent = (Game1)game;
            this.menuItems = menuItems;
            easyLevel = STATICS.CONTENT.Load<Texture2D>("LevelImages/levelScreen1");
            normalLevel = STATICS.CONTENT.Load<Texture2D>("LevelImages/levelScreen2");
            hardLevel = STATICS.CONTENT.Load<Texture2D>("LevelImages/levelScreen3");
            buttonClick = STATICS.CONTENT.Load<SoundEffect>("Music/button");
        }
        /// <summary>
        /// Draw method to draw LevelScreen
        /// </summary>
        public override void Draw()
        {
            STATICS.SPRITEBATCH.Begin();
            STATICS.SPRITEBATCH.Draw(easyLevel, Vector2.Zero, Color.White);
            switch(selectedIndex)
            {
                case 0:
                    STATICS.SPRITEBATCH.Draw(easyLevel, Vector2.Zero, Color.White);
                    isPlayButton = true;
                    break;
                case 1:
                    STATICS.SPRITEBATCH.Draw(normalLevel, Vector2.Zero, Color.White);
                    isPlayButton = true;
                    break;
                case 2:
                    STATICS.SPRITEBATCH.Draw(hardLevel, Vector2.Zero, Color.White);
                    isPlayButton = true;
                    break;
                
            }
            STATICS.SPRITEBATCH.End();
        }
        /// <summary>
        /// Update method to check the keyboard state and perform some action
        /// </summary>
        public override void Update()
        {
            KeyboardState ks = Keyboard.GetState();
            if (isPlayButton)
            {
                if (ks.IsKeyDown(Keys.Right) && oldState.IsKeyUp(Keys.Right))
                {
                    IsPlayButton();
                    selectedIndex = MathHelper.Clamp(selectedIndex + 1, 0, menuItems.Count - 1);
                   
                }
                if (ks.IsKeyDown(Keys.Left) && oldState.IsKeyUp(Keys.Left))
                {
                    IsPlayButton();
                   
                    selectedIndex = MathHelper.Clamp(selectedIndex - 1, 0, menuItems.Count - 1);
                }
                if (ks.IsKeyDown(Keys.Space) && oldState.IsKeyUp(Keys.Space))
                {
                    IsPlayButton();
                    //notify from menuscene
                    //Call notify method of Game1 
                    //pass MenuScene as sender and action as the Menu Item choosen
                    parent.Notify(this, menuItems[selectedIndex]);
                }
                if (ks.IsKeyDown(Keys.Back) && oldState.IsKeyUp(Keys.Back))
                {
                    IsPlayButton();

                    parent.Notify(this, "Menu");
                }
                oldState = ks;
                //want to go up and down one at a time
                //set the state of keyboard to oldstate
               
            }
            base.Update();
        }
        /// <summary>
        /// method that plays the buttonclick sound
        /// </summary>
        public void IsPlayButton()
        {
            if (isPlayButton == true)
            {
                buttonClick.Play();
            }

        }
    }
}
