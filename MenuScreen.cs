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
using Microsoft.Xna.Framework.Media;

namespace HKaurFinalProject
{
    /// <summary>
    /// Menu Screen class that inherits from Screen class
    /// Displays the menu options on screen
    /// </summary>
    public class MenuScreen: Screen
    {
        private Game1 parent;
        private Color highlightColor = Color.Orange;
        private Color regularColor = Color.White;
        private int selectedIndex;
        private Texture2D background;
        private List<string> menuItems;
        // Support for loading and drawing of spritefonts
        private SpriteFont menuFont;
        private SpriteFont highlightFont;
        public Texture2D[] tex;
        //position of font
        private Vector2 position;
        private Vector2 mposition;
        // Support for loading and drawing of image
        private Texture2D gameTitle;
        private Texture2D highlightTexture;
        private KeyboardState oldState;

        private Texture2D cursorTex;
        private Vector2 cursorPos;

        private Rectangle[] textRect;
        private bool isClicked = false;
        private bool isHovered = false;
        // Support for media
        private SoundEffect buttonClick;
        private bool isPlayButton = false;
        private Texture2D menuTexture;
        /// <summary>
        /// MenuScreen constructor to load the images, fonts, music, sounds, and list of menuItems
        /// </summary>
        /// <param name="game"></param>
        /// <param name="menuItems"></param>
        public MenuScreen(Game game, List<string> menuItems)
        {
            //initialize the parent
            this.parent = (Game1)game;
            //Load the images and fonts
            background = STATICS.CONTENT.Load<Texture2D>("Images/background1");
            gameTitle = STATICS.CONTENT.Load<Texture2D>("Images/flappy");
            cursorTex = STATICS.CONTENT.Load<Texture2D>("Images/cursor");
            menuTexture = STATICS.CONTENT.Load<Texture2D>("Menu/button");
            highlightTexture = STATICS.CONTENT.Load<Texture2D>("Menu/highlightbutton");
            menuFont = STATICS.CONTENT.Load<SpriteFont>("Menu/menuFont");
            highlightFont = STATICS.CONTENT.Load<SpriteFont>("Menu/menuFont");
            //load the menu items
            this.menuItems = menuItems;
            //load the sounds
            buttonClick = STATICS.CONTENT.Load<SoundEffect>("Music/button");
            //initialize the position of menu buttons and text
            this.position = new Vector2(STATICS.STAGE_WIDTH / 3 + menuTexture.Width/4,  STATICS.STAGE_HEIGHT /3 + menuTexture.Height/3);
            this.mposition = new Vector2(STATICS.STAGE_WIDTH / 3, STATICS.STAGE_HEIGHT / 3);
            tex = new Texture2D[5];
            textRect = new Rectangle[5];
            
            //game.IsMouseVisible = true;
        }
        /// <summary>
        /// Draw method to draw MenuScreen
        /// </summary>
        public override void Draw()
        {
            Vector2 tempPos = position;
            Vector2 menuPos = mposition;
            STATICS.SPRITEBATCH.Begin();
            STATICS.SPRITEBATCH.Draw(background, Vector2.Zero, Color.White);

            STATICS.SPRITEBATCH.Draw(gameTitle, new Vector2(STATICS.STAGE_WIDTH / 2 - gameTitle.Width / 2, 100), Color.White);
            //loop through menu Items to draw them at right horizontal position
            for (int i = 0; i <= 4; i++)
            {
                // 
                switch (menuItems[i])
                {
                    case "Start Game":
                        tempPos.X = STATICS.STAGE_WIDTH / 3 + menuTexture.Width / 4;
                        break;
                    case "Help":
                        tempPos.X = STATICS.STAGE_WIDTH / 3 + menuTexture.Width / 4 + 27;
                        break;
                    case "Level":
                        tempPos.X = STATICS.STAGE_WIDTH / 3 + menuTexture.Width / 4 + 23;
                        break;
                    case "Credits":
                        tempPos.X = STATICS.STAGE_WIDTH / 3 + menuTexture.Width / 4 + 15;
                        break;
                    case "About":
                        tempPos.X = STATICS.STAGE_WIDTH / 3 + menuTexture.Width / 4 + 20;
                        break;
                    case "Quit":
                        tempPos.X = STATICS.STAGE_WIDTH / 3 + menuTexture.Width / 4 + 27;
                        break;
                    default:
                        tempPos.X = STATICS.STAGE_WIDTH / 3 + menuTexture.Width / 4;
                        break;
                }
                //checks the index of selected menu item
                //draw the selected menu Item with highlight texture 
                if (selectedIndex == i)
                {
                    STATICS.SPRITEBATCH.Draw(highlightTexture, menuPos, regularColor);
                    //STATICS.SPRITEBATCH.Draw();
                    STATICS.SPRITEBATCH.DrawString(highlightFont, menuItems[i], tempPos, regularColor);
                    tempPos.Y += menuFont.LineSpacing + 50;
                    
                    
                    
                }
                else
                {
                    STATICS.SPRITEBATCH.Draw(menuTexture, menuPos, regularColor);
                    STATICS.SPRITEBATCH.DrawString(menuFont, menuItems[i], tempPos, regularColor);
                    //increase the Y component of TempPos to give space between menuItems
                    //linespacing distance from baseline to baseline of font
                    isPlayButton = true;
                    tempPos.Y += menuFont.LineSpacing + 50;
                   
                }
                menuPos.Y += 75;
            }
            STATICS.SPRITEBATCH.Draw(cursorTex, cursorPos, Color.White);
            STATICS.SPRITEBATCH.End();
            base.Draw();
        }
        /// <summary>
        /// Update method to check the keyboard state and perform some action
        /// </summary>
        public override void Update()
        {
            //checks the current mouse state
            var mouseState = Mouse.GetState();
            //gets the cursor position
            cursorPos = new Vector2(mouseState.X, mouseState.Y);
            
            KeyboardState ks = Keyboard.GetState();
            
            if (isPlayButton)
            {
                if (ks.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
            {
                    IsPlayButton();
                    //Only want to go to the last MenuItem on Down key press and not further
                    //Mathhelper will restrict the max value total count of menuItems in list
                    selectedIndex = MathHelper.Clamp(selectedIndex + 1, 0, menuItems.Count - 1);

            }
            if (ks.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
            {
                    IsPlayButton();
                //Only want to go to the first MenuItem on Up key press and not further
                selectedIndex = MathHelper.Clamp(selectedIndex - 1, 0, menuItems.Count - 1);
            }

            //enter key will open another scene

                if (ks.IsKeyDown(Keys.Enter) && oldState.IsKeyUp(Keys.Enter))
                {
                    IsPlayButton();
                    //notify from menuscene
                    //Call notify method of Game1 
                    //pass MenuScene as sender and action as the Menu Item choosen
                    parent.Notify(this, menuItems[selectedIndex]);
                }
               
            }
            oldState = ks;
            //want to go up and down one at a time
            //set the state of keyboard to oldstate
            base.Update();
        }
        /// <summary>
        /// method that checks if bool isPlayButton is true
        /// and plays the buttonclick sound
        /// </summary>
        public void IsPlayButton()
        {
            if(isPlayButton == true)
            {
                buttonClick.Play();
            }
            
        }
        public override void LoadContent()
        {
            base.LoadContent();
        }
    }
}
