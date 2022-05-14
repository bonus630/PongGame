using br.com.bonus630.GameBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bonus630.Game.Pong
{
    public  class Score : GameObject2D
    {
        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawString(Value.ToString(), new Font("Arial", 25),
                Brushes.White, new PointF(this.Position.X, this.Position.Y));
        }
    }
}
