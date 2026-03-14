using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l6fbpw.Model
{
    public abstract class DrawableDecorator : IDrawable
    {
        protected IDrawable _wrappee;
        public DrawableDecorator(IDrawable wrappee)
        {
            _wrappee = wrappee;
        }

        public virtual void Draw()
        {
            _wrappee.Draw();
        }
    }
}
