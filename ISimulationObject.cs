using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmapLib
{
    public interface ISimulationObject
    {
        public void Update();

        public void Draw(); // return some (x, y, color) struct-pixels here
    }
}
