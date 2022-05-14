using br.com.bonus630.GameBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bonus630.Game.Pong
{
    public class Player : GameObject2D
    {
        Brush playerColor;
        int playerWidth = 10;
        int playerHeight = 100;
        int speed = 20;
        public Player(Brush playerColor)
        {
            this.Bounds = new Rectangle(0, 0, playerWidth, playerHeight);
            this.Collider = this.Bounds;
            this.playerColor = playerColor; 
        }
        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
            graphics.FillRectangle(playerColor,Bounds);
        }
        public override void Update()
        {
            base.Update();
            if (Input.UP)
                Position.Y -= speed;
            if (Input.DOWN)
                Position.Y += speed;
            this.Bounds = new Rectangle(Position.X, Position.Y, playerWidth, playerHeight);
            this.Collider = this.Bounds;
        }
    }
}
