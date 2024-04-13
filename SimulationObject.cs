using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BitmapLib
{
    public abstract class SimulationObject
    {
        private Vector2 position;
        Vector2 Position { get; }

        private Vector2 velocity;
        Vector2 Velocity { get; }

        public void Update()
        {
            position += velocity;
        }

        public abstract void Draw(); // return some (x, y, color) struct-pixels here

    }
}
