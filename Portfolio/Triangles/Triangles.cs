using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangles
{
    public partial class Triangles : Form
    {
        public Triangles()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.White;
            this.Width = 700;
            this.Height = 700;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Pen blackPen = new Pen(Color.Black, 2);

            PointF p1 = new PointF(100, 100);
            PointF p2 = new PointF(500, 100);
            PointF p3 = new PointF(300, 446);

            DrawTrianglePattern(g, blackPen, p1, p2, p3);
        }

        private void DrawTrianglePattern(Graphics g, Pen pen, PointF a, PointF b, PointF c)
        {
            g.DrawPolygon(pen, new PointF[] { a, b, c });

            if (Distance(a, b) < 1) return;

            PointF ab = MidPoint(a, b);
            PointF bc = MidPoint(b, c);
            PointF ca = MidPoint(c, a);

            DrawTrianglePattern(g, pen, ab, bc, ca);
        }

        private PointF MidPoint(PointF p1, PointF p2)
        {
            return new PointF(
                (p1.X + p2.X) / 2f,
                (p1.Y + p2.Y) / 2f
            );
        }

        private float Distance(PointF p1, PointF p2)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
