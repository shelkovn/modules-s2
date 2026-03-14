namespace l6fbpw.Model
{
    public class OpacityDecorator : DrawableDecorator
    {
        private int _opacityPercent;

        public OpacityDecorator(IDrawable wrappee, int opacityPercent) : base(wrappee)

        {
            _opacityPercent = opacityPercent;
        }

        public override void Draw()
        {
            base.Draw();
            Console.Write($" [Прозрачность изображения {_opacityPercent}]");
        }
    }
}
