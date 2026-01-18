namespace PhysicsSimulator
{
    public class ContainerCircle
    {

        public float X { get; set; }
        public float Y { get; set; }
        public float Radius { get; set; }
        public Pen Pencil { get; set; }

        public ContainerCircle(float x, float y, float radius, Pen pencil)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
            this.Pencil = new Pen(Color.Black, 12);
        }
        public void Draw(Graphics g)
        {
            float diameter = Radius * 2;
            g.DrawEllipse(Pencil, X - Radius, Y - Radius, diameter, diameter);

        }
    }
}
