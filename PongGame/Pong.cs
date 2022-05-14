namespace br.com.bonus630.Game.Pong
{
    public partial class Pong : Form
    {
        public Pong()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            PongGame p = new PongGame(this);
            p.Start();
        }
    }
}