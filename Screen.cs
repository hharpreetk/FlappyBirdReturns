using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKaurFinalProject
{
    /// <summary>
    /// Simple abstract class which contains three standard XNA methods, LoadContent, Update and Draw.
    /// Allows different screen to inherit its method
    /// </summary>
    public abstract class Screen
    {
        public virtual void LoadContent() { }
        public virtual void Update() { }
        public virtual void Draw() { }
    }
}
