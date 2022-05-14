using br.com.bonus630.GameBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bonus630.Game.Pong
{
    public  class Ball : GameObject2D
    {
        int radius = 10;
        int angle = 0;
        int directionX = 1;
        int directionY = 1;
        int speed = 15;
        public int DirectionX { get { return directionX; } set { directionX = value; }  }
        public int DirectionY { get { return directionY; } set { directionY = value; }  }
        public int Angle { get { return angle; } set { angle = value; }  }
        public Ball()
        {
            
        }
        public override void Draw(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Yellow, this.Bounds);
        }
        public override void Update()
        {
            base.Update();
            int x = (int)(speed * directionX * Math.Cos(angle * Math.PI / 180));
            int y = (int)(speed * directionY * Math.Sin(angle * Math.PI / 180));
            this.Move(new Vector2(x,y));
            this.Bounds = new Rectangle(this.Position.X , this.Position.Y , radius, radius);
            this.Collider = this.Bounds;
        }
       
    }
}
