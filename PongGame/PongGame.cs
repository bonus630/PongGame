using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using br.com.bonus630.GameBase;
using GameBase;

namespace br.com.bonus630.Game.Pong
{
    public class PongGame : Game2D
    {
        Player player1, player2;
        EmptyGameObject player1Goal,player2Goal,upBarrier,downBarrier; 
        Score score1, score2;
        Stage stage;
        Ball ball;
        public PongGame(Form gameForm) : base(gameForm)
        {
            this.Bounds =  new Rectangle(0,0, gameForm.Bounds.Width,gameForm.Bounds.Height);
            Configure();
           
        }
       
        public override void Configure()
        {
            stage = new Stage(this.Bounds);
            score1 = new Score();
            score1.Position = new GameBase.Vector2(this.Bounds.Left + 100, 100);
            score2 = new Score();
            score2.Position = new GameBase.Vector2(this.Bounds.Right -100, 100);
            player1 = new Player(Brushes.Green);
            player1.Children.Add(score1);
            player1.Position = new GameBase.Vector2(this.Bounds.Left + 10, this.Bounds.Height / 2);
            player1Goal = new EmptyGameObject();
            player1Goal.Position = new Vector2(this.Bounds.Width, 0);
            player1Goal.Collider = new Rectangle(this.Bounds.Width, 0, 10, this.Bounds.Height);
            player2 = new Player(Brushes.Blue);
            player2.Children.Add(score2);
            player2.Position = new GameBase.Vector2(this.Bounds.Width - 10 - player2.Bounds.Width, this.Bounds.Height / 2);
            player2Goal = new EmptyGameObject();
            player2Goal.Position = new Vector2(-10, 0);
            player2Goal.Collider = new Rectangle(-10, 0, 10, this.Bounds.Height);
            upBarrier = new EmptyGameObject();
            upBarrier.Position = new Vector2(0, -10);
            upBarrier.Collider = new Rectangle(0,-10, this.Bounds.Width,10);
            downBarrier = new EmptyGameObject();
            downBarrier.Position = new Vector2(0, this.Bounds.Height);
            downBarrier.Collider = new Rectangle(0, this.Bounds.Height ,  this.Bounds.Width,10);
            stage.Children.Add(player1);
            stage.Children.Add(player2);
            ball = new Ball();
            ball.Position = new GameBase.Vector2((this.Bounds.Width) / 2, (this.Bounds.Height / 2));
            stage.Children.Add(ball);
            this.Children.Add(stage);
        }
        public override void Update()
        {
            
            if (ball.HitTest(player1))
            {
                ball.DirectionX = 1;
                int x = ball.Position.Y - player1.Bounds.Bottom;
                ball.Angle = 90 * x / player1.Bounds.Height;
            }
            if (ball.HitTest(player2))
            {
                ball.DirectionX = -1;
                int x = ball.Position.Y - player2.Bounds.Bottom;
                ball.Angle = 90 * x / player2.Bounds.Height;
            }
            if (ball.HitTest(player1Goal))
            {
                score1.Value += 1;
                ball.DirectionX = -1;
                resetBall();
            }
            if (ball.HitTest(player2Goal))
            {
                score2.Value += 1;
                ball.DirectionX = 1;
                resetBall();
            }
            if (ball.HitTest(upBarrier))
            {
                ball.DirectionY = -1;
            }
            if (ball.HitTest(downBarrier))
            {
                ball.DirectionY = 1;
            }
            base.Update();
        }
        private void resetBall()
        {
            ball.Angle = 0;
            ball.Position = new GameBase.Vector2((this.Bounds.Width) / 2, (this.Bounds.Height / 2));
        }
        public override void GameOver()
        {
            throw new NotImplementedException();
        }
    }
}
