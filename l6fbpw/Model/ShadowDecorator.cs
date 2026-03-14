namespace l6fbpw.Model
{
    public class ShadowDecorator : DrawableDecorator
    {
        private int _shadowLength;

        public ShadowDecorator(IDrawable wrappee, int shadowLength) : base(wrappee)

        {
            _shadowLength = shadowLength;
        }

        public override void Draw()
        {
            base.Draw();
            Console.Write($" [Тень толщиной {_shadowLength}]");
        }
    }
}
