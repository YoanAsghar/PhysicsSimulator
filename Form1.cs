namespace PhysicsSimulator;

public partial class Form1 : Form
{

    static private System.Windows.Forms.Timer gameTimer = null!;
    DoubleBufferedPanel drawingPanel = null!;
    private ContainerCircle MainCircle = null!;

    public Form1()
    {
        //for listening keyaboard EventArgs

        this.KeyPreview = true;
        this.KeyDown += (sender, e) =>
        {

            if (e.KeyCode == Keys.R) {
                foreach (Ball ball in Ball.BALLS)
                {
                    ball.Xpos = this.Width / 2;
                    ball.Ypos = this.Height / 2;
                    ball.Xspeed = 0;
                    ball.Yspeed = 0.2f;
                }

            }
            if (e.KeyCode == Keys.N)
            {
                Ball.BALLS.Add(new Ball((drawingPanel.Height / 2 + 2), (drawingPanel.Width / 2 + 2), 10));
            }
        };

        this.DoubleBuffered = true;
        InitializeComponent();
        CreateCanvas();
        startTimer();


        Ball.BALLS.Add(new Ball((drawingPanel.Height / 2 + 2), (drawingPanel.Width / 2 + 2), 10));
        MainCircle = new ContainerCircle(drawingPanel.Width / 2, drawingPanel.Height / 2, 450, new Pen(Color.Black, 12));


    }
    private void CreateCanvas()
    {

        drawingPanel = new DoubleBufferedPanel();
        drawingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        drawingPanel.BackColor = System.Drawing.Color.White;
        drawingPanel.Height = 960;
        drawingPanel.Width = 960;

        drawingPanel.Dock = DockStyle.Fill;
        drawingPanel.Paint += new PaintEventHandler(paint_canvas!);

        this.Controls.Add(drawingPanel);


    }

    private void paint_canvas(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


        MainCircle.Draw(g);
        foreach (Ball ball in Ball.BALLS)
        {
            ball.Draw(g);
        }

        // Muestra la posicion de la pelota y su velocidad;
        using Font font = new Font("Georgia", 14);
        using SolidBrush textBrush = new SolidBrush(Color.Black);

        g.DrawString($"x Position: {Ball.BALLS[0].Xpos}", font, textBrush, 15, 10);
        g.DrawString($"y Position: {Ball.BALLS[0].Ypos}", font, textBrush, 15, 60);
        g.DrawString($"x speed: {Ball.BALLS[0].Xspeed}", font, textBrush, 15, 110);
        g.DrawString($"y speed: {Ball.BALLS[0].Yspeed}", font, textBrush, 15, 160);
    }
    private void startTimer()

    {
        gameTimer = new System.Windows.Forms.Timer();
        gameTimer.Interval = 16;
        gameTimer.Tick += GameLoop_Tick!;
        gameTimer.Start();
    }
    private void GameLoop_Tick(object sender, EventArgs e)
    {
        foreach (Ball ball in Ball.BALLS)
        {
            ball.Gravity();
            ball.CheckCircleColisitons(MainCircle);
            ball.CheckBallColisions(Ball.BALLS);
        }
        drawingPanel.Invalidate();
    }
}
