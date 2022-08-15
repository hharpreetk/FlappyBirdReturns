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
    /// <summary>
    /// Bird class which draw and animates the bird
    /// </summary>
    public class Bird
    {
        
        public Texture2D[] Textures;
        public float ySpeed;
        public int texturePosition;
        public float Rotation;
        public Vector2 position;
        public int jumpTimer = 500;
        public double jumpElapsed = 0;
        private KeyboardState _ks;
        private KeyboardState _oldState;
        Texture2D pixTexture;
        public bool gameover = false;
        private SoundEffect hitSound;
        public int animTimer = 100;
        public double animElapsed = 0;
        public int textureAdd = 1;
        public bool canJump = true;

        /// <summary>
        /// bird constructor which loads the texture and sounds
        /// </summary>
        /// <param name="sound">Sound effect</param>
        /// <param name="tex1">Bird sprite</param>
        /// <param name="tex2">Bird sprite</param>
        /// <param name="tex3">Bird sprite</param>
        /// <param name="tex4">Bird sprite</param>
        public Bird(string sound, string tex1, string tex2, string tex3, string tex4)
        {
            Textures = new Texture2D[4];
            this.Textures[0] = STATICS.CONTENT.Load<Texture2D>(tex1);
            this.Textures[1] = STATICS.CONTENT.Load<Texture2D>(tex2);
            this.Textures[2] = STATICS.CONTENT.Load<Texture2D>(tex3);
            this.Textures[3] = STATICS.CONTENT.Load<Texture2D>(tex4);
            ySpeed = 0;
            //initial position of flappy bird
            this.position = new Vector2(100, 500);
            pixTexture = STATICS.CONTENT.Load<Texture2D>("Images/pixel");
            hitSound = STATICS.CONTENT.Load<SoundEffect>(sound);
        }
        /// <summary>
        /// Bird update method to perform some action based on the position of bird
        /// </summary>
        public void Update()
        {
            _ks = Keyboard.GetState();

            //bird either falls or fly depeding upon the ySpeed
            //if bird falls
            //bird can't fly again
            
            if (this.position.Y < 710)
            {
                ySpeed += 0.2f;

                jumpElapsed += STATICS.GAMETIME.ElapsedGameTime.TotalMilliseconds;

                if (jumpElapsed > jumpTimer)
                {
                    canJump = true;
                    jumpElapsed = 0;
                }
                animElapsed += STATICS.GAMETIME.ElapsedGameTime.TotalMilliseconds;
                if (animElapsed > animTimer)
                {
                    //increase the textureposition
                    //by increasing texture position 
                    //texture array will  load different textures after 100 milliseconds
                    this.texturePosition++;
                    //if texturePosition is greater than or equal to textures.length
                    //decrease the textureposition to 0
                    if (this.texturePosition == 3)
                    {
                        this.texturePosition = 0;
                    }
                    animElapsed = 0;
                }

                this.position.Y += ySpeed;

                if (_oldState.IsKeyUp(Keys.Space) && _ks.IsKeyDown(Keys.Space))
                {
                    if (canJump)
                    {
                        //if time elasped since last update is greater than 500 milliseconds and Space Key is pressed
                        //Bird position is changed by speed
                        //bird will go up by 2f
                        ySpeed = -2;
                    }
                }
                if (_ks != null)
                {
                    _ks = _oldState;
                }
                //rotate the bird depending upon the vertical direction
                Rotation = (float)Math.Atan2(ySpeed, 10);
            }
        }

        public Rectangle Bound { get { return new Rectangle((int)this.position.X - 8, (int)this.position.Y - 12, 60, 53); } set { } }
        public Rectangle DragonBound { get { return new Rectangle((int)this.position.X - 8, (int)this.position.Y - 12, 60, 53); } set { } }
        public void Draw()
        {
           
            STATICS.SPRITEBATCH.Draw(this.Textures[this.texturePosition], this.position, null, Color.White, this.Rotation, new Vector2(20, 20), 0.6f, SpriteEffects.None, 0f);
            //STATICS.SPRITEBATCH.Draw(this.pixTexture, this.DragonBound, new Color(1f, 0f, 0f, 0.3f));
        }
        public void BounceBottom()
        {
            hitSound.Play();
        }
    }
}
