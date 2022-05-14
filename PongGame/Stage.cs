using br.com.bonus630.GameBase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bonus630.Game.Pong
{
    public class Stage: GameObject2D
    {
        Pen whiteLine = new Pen(Color.White);
      
        public Stage(Rectangle bounds)
        {
            this.Bounds = bounds;
        }
        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(Brushes.Black, this.Bounds);
            graphics.DrawLine(whiteLine, this.Bounds.Width / 2, this.Bounds.Bottom, this.Bounds.Width / 2, this.Bounds.Top);
            base.Draw(graphics);
        }
    }
}
