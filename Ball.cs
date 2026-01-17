
namespace PhysicsSimulator
{
    public class Ball
    {
        public float Xpos { get; set; }
        public float Ypos { get; set; }
        public float Radius { get; set; }
        public Brush FillBrush { get; set; }
        public Pen Pencil { get; set; }

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
    }
}



