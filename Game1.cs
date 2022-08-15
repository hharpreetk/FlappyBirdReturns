/* HKaurFinalProject.cs
* Final Project
* Revision History
* Harpreet Kaur, 2019.12.08: Created
*/
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace HKaurFinalProject
{
    /// <summary>
    /// This is main class of my game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen currentScreen;
        public MenuScreen menuScreen;
        public HelpScreen helpScreen;
        public GameScreen gameScreen;
        public LevelScreen levelScreen;
        public AboutScreen aboutScreen;
        public Lvl2GameScreen lvl2GameScreen;
        public Lvl3GameScreen lvl3GameScreen;
        //Declare List of menu Items 
        private List<string> menuItems = new List<string>
        {
            "Start Game",
            "Help",
            "Level",
            "About",
            "Quit"

        };
        //Declare List of levelItems
        private List<string> levelItems = new List<string>
        {
            "EasyLevel",
            "NormalLevel",
            "HardLevel"
        };
        //Game1 constructor
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //change the windows size
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 600;
            //change window title
            Window.Title = "Flappy Bird Returns";
            graphics.ApplyChanges();

            //Assign Content and Graphics to the static variables of Static class
            STATICS.CONTENT = Content;
            STATICS.GRAPHICS = GraphicsDevice;
            //STATICS.SPRITEBATCH = spriteBatch;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
           
            spriteBatch = new SpriteBatch(GraphicsDevice);
            STATICS.SPRITEBATCH = spriteBatch;
            menuScreen = new MenuScreen(this,menuItems);
          
            //load the Game Screen and call its constructor to load it
            gameScreen = new GameScreen(this);
            //load the Help Screen
            helpScreen = new HelpScreen(this);
            //load the Lvl3GameScreen
            lvl3GameScreen = new Lvl3GameScreen(this);
            //load the Lvl2GameScreen
            lvl2GameScreen = new Lvl2GameScreen(this);
            //load the levelScreen
            levelScreen = new LevelScreen(this, levelItems);
            aboutScreen = new AboutScreen(this);
            //initialize currentScene to menuScene
            currentScreen = menuScreen;
            //call the Load Content method of currentScreen
            this.currentScreen.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
           
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //set the Gametitme static variable 
            STATICS.GAMETIME = gameTime;
            //Update the currentScreen
            currentScreen.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Call draw method of currentScreen 
            currentScreen.Draw();
            base.Draw(gameTime);
        }
        /// <summary>
        /// The method takes in Screen class and action as parameter
        /// Changes the current Screen depending upon the sender and action in parameter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="action"></param>
        public void Notify(Screen sender, string action)
         {
            //if MenuScreen is sender, check the action evoked
            if (sender is MenuScreen)
            {
                switch (action)
                {
                    case "Start Game":
                        currentScreen = levelScreen;
                        break;
                    case "Help":
                        currentScreen = helpScreen;
                        break;
                    case "Level":
                        currentScreen = levelScreen;
                        break;
                    case "About":
                        currentScreen = aboutScreen;
                        break;
                    case "Quit":
                        Exit();
                        break;
                }

            }   
            //else if GameScreen is sender, check the action
            //reset the game before exiting
            //this will start the game at the initial state
            else if (sender is GameScreen)
            {
                switch(action)
                {
                    case "Escape":
                        gameScreen.Reset();
                       
                        currentScreen = gameScreen;
                       
                        break;
                    case "Backspace":
                        gameScreen.Reset();
                        currentScreen = menuScreen;
                        break;
                    case "Levels":
                        gameScreen.Reset();
                        currentScreen = levelScreen;
                        break;
                }
                currentScreen = menuScreen;
            }
            //else if Lvl2GameScreen is sender, check the action
            //reset the game before exiting
            //this will start the game at the initial state
            else if (sender is Lvl2GameScreen)
            {
                switch (action)
                {
                    case "Escape":
                        lvl2GameScreen.Reset();

                        currentScreen = lvl3GameScreen;

                        break;
                    case "Backspace":
                        lvl2GameScreen.Reset();
                        currentScreen = menuScreen;
                        break;
                    case "Levels":
                        lvl2GameScreen.Reset();
                        currentScreen = levelScreen;
                        break;
                }
                currentScreen = menuScreen;
            }
            //else if Lvl3GameScreen is sender, check the action
            //reset the game before exiting
            //this will start the game at the initial state
            else if (sender is Lvl3GameScreen)
            {
                switch (action)
                {
                    case "Escape":
                        lvl3GameScreen.Reset();

                        currentScreen = lvl3GameScreen;

                        break;
                    case "Backspace":
                        lvl3GameScreen.Reset();
                        currentScreen = menuScreen;
                        break;
                    case "Levels":
                        lvl3GameScreen.Reset();
                        currentScreen = levelScreen;
                        break;
                }
                currentScreen = menuScreen;
            }
            //if HelpScreen is a sender, set the screen visible to menuScreen
            else if (sender is HelpScreen)
            {
                currentScreen = menuScreen;
            }
            //if Level Screen is sender check the action
            else if (sender is LevelScreen)
            {
                switch (action)
                {
                    case "EasyLevel":
                        currentScreen = gameScreen;
                        break;
                    case "NormalLevel":
                        currentScreen = lvl2GameScreen;
                        break;
                    case "HardLevel":
                        currentScreen = lvl3GameScreen;
                        break;
                    case "Menu":
                        currentScreen = menuScreen;
                        break;
                }
               
            }
            //if AboutScreen is a sender, set the screen visible to menuScreen
            else if (sender is AboutScreen)
            {
                currentScreen = menuScreen;
            }
            //show the current Screen

        }
    }
}
