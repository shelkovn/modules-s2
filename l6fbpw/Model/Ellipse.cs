namespace l6fbpw.Model
{
    public class Ellipse : GraphicObject
    {
        private float _x, _y, _radiusX, _radiusY;

        public Ellipse(IRenderingEngine engine, float x, float y, float radiusX, float radiusY) : base(engine)
        {
            _x = x;
            _y = y;
            _radiusX = radiusX;
            _radiusY = radiusY;
        }

        public override void Draw()
        {
            _engine.RenderEllipse(_x, _y, _radiusX, _radiusY);
        }
        public override void Move(float dx, float dy)
        {
            _x += dx;
            _y += dy;
        }
    }
}
