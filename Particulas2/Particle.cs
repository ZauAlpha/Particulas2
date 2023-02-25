using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particulas2
{
    public class Particle
    {
        public float x;
        public float y;
        public float radio;
        private int time;
        private Color color;
        private float speedX;
        private float speedY;
        private float initialX;
        private float initialY;
        private float changeAlpha;
        private int initialAlpha;


        public Particle(float x, float y)
        {

            var random = new Random();
            this.radio = random.Next(15) + 5;
            initialAlpha = random.Next(55) + 200;
            color = Color.FromArgb(initialAlpha, 255, random.Next(25) + 230, random.Next(20) );
            speedX = random.Next(-4,0);
            speedY = random.Next(-4,4);
            time = random.Next(50) + 50;
            changeAlpha = color.A / time;
            this.initialX = this.x = x - radio;
            this.initialY = this.y = y - radio;



        }
        public void Draw()
        {
            Form1.graphics.DrawImage(Resource1.Star, x, y);
            
            if (color.A - changeAlpha >= 0)
            {
                color = Color.FromArgb((int)(color.A - changeAlpha), color.R, color.G, color.B);
            }
            else
            {
                x = initialX;
                y = initialY;
                color = Color.FromArgb(initialAlpha, color.R, color.G, color.B);
            }
        }
        public void Move()
        {
            x += speedX;
            y += speedY;

        }
    }
}
