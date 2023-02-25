using System;
using System.Windows.Forms;

namespace Particulas2
{
    public partial class Form1 : Form
    {
        public static Graphics graphics;
        public static List<Particle> particles;
        public static float time;
        private Bitmap bitmap, background, player;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            time = 0;

            Init();
        }
        private void Init()
        {
            particles = new List<Particle>();
            PICTURE_BOX.Width = 900;
            PICTURE_BOX.Height = 500;
            PICTURE_BOX.Location = new Point((this.Width - PICTURE_BOX.Width) / 2, (this.Height - PICTURE_BOX.Height) / 2); ;
            
            bitmap = new(PICTURE_BOX.Width, PICTURE_BOX.Height);
            graphics = Graphics.FromImage(bitmap);
            PICTURE_BOX.Image = bitmap;
            Random random= new Random();
            for (int i= 0;i<1000;i++)
            {
                particles.Add(new Particle(random.Next(502, 553), random.Next(230, 301)));
            }
            background = Resource1.Stadium;
            player = Resource1.MiniAlvarus_removebg_preview;
            
            
        }

        private void PICTURE_BOX_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void PICTURE_BOX_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            PICTURE_BOX.Location = new Point((this.Width-PICTURE_BOX.Width)/2,(this.Height - PICTURE_BOX.Height)/2);
        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            ++time;

            graphics.Clear(Color.Black);
            graphics.DrawImage(background,0,0);
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Draw();
                particles[i].Move();
            }
            graphics.DrawImage(player, 700-player.Width, 400-player.Height);
            

            

            PICTURE_BOX.Invalidate();
        }
    }
}