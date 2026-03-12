using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l6fbpw.Model
{
    public abstract class GraphicObject : IDrawable
    {
        protected IRenderingEngine _engine;
        public GraphicObject(IRenderingEngine engine)
        {
            _engine = engine;
        }
        public abstract void Draw();
        public abstract void Move(float dx, float dy);

        //remove
        //public void RenderRectangle(float x, float y, float width, float height);

        //public void RenderEllipse(float x, float y, float radiusX, float radiusY);

        //public void RenderLine(float x1, float y1, float x2, float y2);
    }

    public class Rectangle : GraphicObject
    {
        protected IRenderingEngine _engine;
        private float _x, _y, _width, _height;

        public Rectangle(IRenderingEngine engine, float x, float y, float width, float height) : base(engine)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        public override void Draw()
        {
            _engine.RenderRectangle(_x, _y, _width, _height);
        }
        public override void Move(float dx, float dy)
        {
            _x += dx;
            _y += dy;
        }
    }
}
