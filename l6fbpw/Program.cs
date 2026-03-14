using l6fbpw.Model;

namespace l6fbpw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CharacterFactory cf = new CharacterFactory();
            Character c = cf.GetCharacter('*', "coolfont", 17);
            c.Draw(1, 1);

            PrintRenderer pr = new PrintRenderer();
            ScreenRenderer screen = new ScreenRenderer();

            Document doc1 = new Document(pr);
            Document doc2 = new Document(screen);

            Page pg = doc1.CreatePage();
            Page pg2 = doc2.CreatePage();

            ImageProxy tosha = new ImageProxy("toxa-killa (bonus track)");
            pg.Add(tosha);
            pg2.Add(tosha);

            Ellipse e = new Ellipse(pr, 0, 0, 10, 10); // странно определять движок рендера здесь, потому что мы не знаем, в какой документ попадет элемент 
            Rectangle r = new Rectangle(pr, 0, 0, 10, 10);
            Line l = new Line(pr, 0, 0, 10, 10);

            pg.Add(l);
            pg.Add(r);
            pg.Add(e);
            pg2.Add(l);
            pg2.Add(r);
            pg2.Add(e);

            ImageProxy coolerimage = new ImageProxy("STYLISH");
            BorderDecorator bordered = new BorderDecorator(coolerimage, 10);
            ShadowDecorator shady = new ShadowDecorator(bordered, 10);
            OpacityDecorator transparent = new OpacityDecorator(coolerimage, 50);
            pg.Add(transparent);
            pg2.Add(transparent);

            doc1.RenderAll();
            Console.WriteLine();
            doc2.RenderAll();
        }
    }
}
