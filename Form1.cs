namespace PhysicsSimulator;

public partial class Form1 : Form
{

    public static List<Ball> BALLS = new List<Ball>();

    public Form1()
    {
        this.DoubleBuffered = true;
        InitializeComponent();
        CreateCanvas();

        BALLS.Add(new Ball((1920 / 2), (1080 / 2), 10));


    }
    private void CreateCanvas()
    {

        Panel panel1 = new Panel();
        panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        panel1.BackColor = System.Drawing.Color.White;

        panel1.Dock = DockStyle.Fill;
        panel1.Paint += new PaintEventHandler(paint_circle);

        this.Controls.Add(panel1);


    }

    private void paint_circle(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


        Panel drawingPanel = sender as Panel;
        if (drawingPanel == null) return;

        using Pen penBlack = new Pen(Color.Black, 5);
        using SolidBrush blackBrush = new SolidBrush(Color.Black);
        {
            int diameter = 800;

            int x = (drawingPanel.Width / 2) - (diameter / 2);
            int y = (drawingPanel.Height / 2) - (diameter / 2);

            g.DrawEllipse(penBlack, x, y, diameter, diameter);
        }
        foreach (Ball ball in BALLS)
        {
            ball.Draw(g);
        }
    }
}
