namespace l6fbpw.Model
{
    // Интерфейс для графических объектов (изображений)
    public interface IImage : IDrawable
    {
        int GetWidth();
        int GetHeight();
    }
}
