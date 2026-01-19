
namespace PhysicsSimulator
{
    public class Ball
    {

        public float bounceFactor = (float)1.1;
        public static List<Ball> BALLS = new List<Ball>();


        public float Xpos { get; set; }
        public float Ypos { get; set; }
        public float Xspeed { get; set; }
        public float Yspeed { get; set; }
        public float Radius { get; set; }
        public Brush FillBrush { get; set; }
        public Pen Pencil { get; set; }
        List<Ball> OtherBalls { get; set; }

        public Ball(float x, float y, float radius)
        {
            Xpos = x;
            Ypos = y;
            Radius = radius;
            FillBrush = new SolidBrush(Color.Black);
            Pencil = new Pen(Color.Black, 10);
        }
        public void Draw(Graphics g)
        {
            g.FillEllipse(FillBrush, Xpos - Radius, Ypos - Radius, Radius * 2, Radius * 2);
            g.DrawEllipse(Pencil, Xpos - Radius, Ypos - Radius, Radius * 2, Radius * 2);
        }
        public void Gravity()
        {
            this.Xspeed += 0;
            this.Yspeed += 0.2f;
            this.Ypos += this.Yspeed;
            this.Xpos += this.Xspeed;
        }
        public void CheckCircleColisitons(ContainerCircle circle)
        {
            float Xvec = this.Xpos - circle.X;
            float Yvec = this.Ypos - circle.Y;

            float Distance = (float)Math.Sqrt(Xvec * Xvec + Yvec * Yvec);

            float colisionBoundary = circle.Radius - this.Radius;

            float NormalX = Xvec / Distance;
            float NormalY = Yvec / Distance;

            if (Distance > colisionBoundary)
            {
                this.Xpos = circle.X + NormalX * colisionBoundary;
                this.Ypos = circle.Y + NormalY * colisionBoundary;

                float dotProdcuct = this.Xspeed * NormalX + this.Yspeed * NormalY;

                this.Xspeed = (this.Xspeed - 2 * dotProdcuct * NormalX) * bounceFactor;
                this.Yspeed = (this.Yspeed - 2 * dotProdcuct * NormalY) * bounceFactor;
            }



        }
        public void CheckBallColisions(List<Ball> ballslist)
        {
            this.OtherBalls = ballslist.Where(ball => ball != this).ToList();

            foreach (Ball ball in OtherBalls)
            {
                float Xvec = this.Xpos - ball.Xpos;
                float Yvec = this.Ypos - ball.Ypos;

                float Distance = (float)Math.Sqrt(Xvec * Xvec + Yvec * Yvec);
                float colisionBoundary = this.Radius + ball.Radius;

                float NormalX = Xvec / Distance;
                float NormalY = Yvec / Distance;


                if (Distance < colisionBoundary)
                {
                    this.Xpos = ball.Xpos + NormalX * colisionBoundary;
                    this.Ypos = ball.Ypos + NormalY * colisionBoundary;

                    float dotProdcuct = this.Xspeed * NormalX + this.Yspeed * NormalY;

                    this.Xspeed = (this.Xspeed - 2 * dotProdcuct * NormalX) * bounceFactor;
                    this.Yspeed = (this.Yspeed - 2 * dotProdcuct * NormalY) * bounceFactor;
                }

            }
        }
    }
}



