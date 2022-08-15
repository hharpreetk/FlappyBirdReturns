/* HKaurFinalProject.cs
* Final Project
* Revision History
* Harpreet Kaur, 2019.12.08: Created
*/
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKaurFinalProject
{
    /// <summary>
    /// Lvl2GameScreen class that inherits from Screen class
    /// Contains the functionality required for the current state and overrides Draw, Update etc methods
    /// Allow to play the Level 3 game
    /// </summary>
    public class Lvl2GameScreen : Screen
    {
        private Game1 parent;
        public Texture2D background1;
        public Texture2D background2;
        private Texture2D sandTexture;
        private Texture2D scrollTexture;
        private Texture2D gameOverTexture;
        private Texture2D instrucTexture;
        private Song song;
        private Bird bird;
        private ScrollingBackground scrollingbackground;
        private Ground ground;
        private Scroll scroll;
        
        public List<Lvl2Obstacle> obstacles;
        public int obstacleTimer = 1200;
        public double obstaclElapsed = 0;
        private SpriteFont scoreFont;
        public int currscore = 0;
        public bool gameOver = false;
        public Vector2 stage;
        private KeyboardState oldstate;
        /// <summary>
        /// Lvl2GameScreen constructor to load the images, fonts, music, sounds, and list of menuItems
        /// </summary>
        /// <param name="game"></param>
        /// <param name="menuItems"></param>
        public Lvl2GameScreen(Game game)
        {
            this.parent = (Game1)game;
            background1 = STATICS.CONTENT.Load<Texture2D>("Images/background-day");
            background2 = STATICS.CONTENT.Load<Texture2D>("Images/background-day");
            sandTexture = STATICS.CONTENT.Load<Texture2D>("Images/sand");
            scrollTexture = STATICS.CONTENT.Load<Texture2D>("Images/scroll");
            //
            gameOverTexture = STATICS.CONTENT.Load<Texture2D>("Images/GameOver");
            instrucTexture = STATICS.CONTENT.Load<Texture2D>("Images/instruc");
            scoreFont = STATICS.CONTENT.Load<SpriteFont>("Fonts/score");
            //add music in background

            stage = new Vector2(STATICS.STAGE_WIDTH, STATICS.STAGE_HEIGHT);
            //
            // 

            Reset();
        }
        /// <summary>
        /// Load the intial graphics, fonts, variables, sounds, music and objects 
        /// </summary>
        public void Reset()
        {
            song = STATICS.CONTENT.Load<Song>("Music/FlappyBirdThemeSong");  // Put the name of your song here instead of "song_title"
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            currscore = 0;
            Rectangle srcRect = new Rectangle(0, 0, background1.Width, background1.Height);
            Vector2 pos = new Vector2(0, 0);
            Vector2 speed = new Vector2(2, 0);
            scrollingbackground = new ScrollingBackground(background1, background2, pos, srcRect, speed);
            //bird
            bird = new Bird("Music/hit", tex1: "Lvl2Images/bluebird1", tex2: "Lvl2Images/bluebird2", tex3: "Lvl2Images/bluebird3", tex4: "Lvl2Images/bluebird4");

            //sand
            ground = new Ground(sandTexture);

            //scroll
            scroll = new Scroll(scrollTexture);

            //obstacle
            obstacles = new List<Lvl2Obstacle>()
            {
                new Lvl2Obstacle()
            };
            obstacles.Add(new Lvl2Obstacle());

            gameOver = false;

        }
        /// <summary>
        /// Method that creates the obstacles as the game time elaspes
        /// after the obstacle elasped exceeds the obstacletimer limit
        /// </summary>
        public void obstacleCreater()
        {
            obstaclElapsed += STATICS.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (obstaclElapsed > obstacleTimer)
            {
                obstacles.Add(new Lvl2Obstacle());
                obstaclElapsed = 0;

            }
        }
        public override void LoadContent()
        {

            base.LoadContent();
        }
        /// <summary>
        /// Lvl3GameScreen Draw method to draw
        /// </summary>
        public override void Draw()
        {
            STATICS.SPRITEBATCH.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap, null, null);

            STATICS.SPRITEBATCH.Draw(this.background1, Vector2.Zero, Color.White);

            scrollingbackground.Draw();

            foreach (Lvl2Obstacle item in obstacles)
            {
                item.Draw();
            }
            ground.Draw();
            scroll.Draw();
            bird.Draw();
            //score.Draw();
            STATICS.SPRITEBATCH.DrawString(scoreFont, "Score: " + this.currscore.ToString(), new Vector2(10, 10), Color.White);
            if (gameOver)
            {
                STATICS.SPRITEBATCH.Draw(gameOverTexture, new Vector2(0, stage.Y - gameOverTexture.Width), new Rectangle(0, 0, gameOverTexture.Width, gameOverTexture.Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                STATICS.SPRITEBATCH.Draw(instrucTexture, new Vector2(0, 0), Color.White);
            }
            STATICS.SPRITEBATCH.End();
            base.Draw();
        }
        /// <summary>
        /// Lvl3GameScreen update method
        /// </summary>
        public override void Update()
        {
            obstacleCreater();
            if (!gameOver)
            {
                for (int i = obstacles.Count - 1; i > -1; i--)
                {
                    //when obstacle is 10 pixel left to the game screen 
                    //remove the obstacle
                    if (obstacles[i].position.X < 10)
                    {
                        obstacles.RemoveAt(i);
                    }
                    else
                    {
                        //if birds flys past the obstacle 
                        //adds the score
                        if (!obstacles[i].scored && bird.position.X > obstacles[i].position.X + 60)
                        {
                            obstacles[i].scored = true;
                            currscore++;

                        }
                        Rectangle birdRectangle = bird.Bound;
                        Rectangle groundBound = ground.GroundBound;
                        Rectangle topObsRectangle = obstacles[i].TopBound;
                        Rectangle bottomObstacleRectangle = obstacles[i].BottomBound;
                        //checks for collision
                        //if birdRectangle intersects the top or bottom obstacle
                        //gameOver is set to true
                        if (birdRectangle.Intersects(topObsRectangle) || birdRectangle.Intersects(bottomObstacleRectangle) || birdRectangle.Intersects(groundBound))
                        {
                            gameOver = true;
                            MediaPlayer.IsRepeating = false;
                            bird.BounceBottom();

                            MediaPlayer.Stop();
                            SoundEffect gameover = STATICS.CONTENT.Load<SoundEffect>("Music/gameover");
                            gameover.Play();

                            return;
                        }
                    }
                }

            }
            //check the keyboard state and perform some action
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Escape) && oldstate.IsKeyUp(Keys.Escape))
            {
                parent.Notify(this, "Escape");
            }
            if (ks.IsKeyDown(Keys.Back) && oldstate.IsKeyUp(Keys.Back))
            {
                parent.Notify(this, "Backspace");
            }
            if (ks.IsKeyDown(Keys.LeftShift) && oldstate.IsKeyUp(Keys.LeftShift))
            {
                parent.Notify(this, "Levels");
            }
            //set the oldstate to keyboard state
            oldstate = ks;
            //update each Obstacle
            foreach (var item in obstacles)
            {
                item.Update();
            }
            scrollingbackground.Update();
            scroll.Update();
            bird.Update();

            base.Update();
        }


    }
}
