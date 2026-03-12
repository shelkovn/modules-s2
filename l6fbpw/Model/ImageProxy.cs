namespace l6fbpw.Model
{
    public class ImageProxy : IImage
    {
        private string _filename;
        private HighResolutionImage _realImage;
        public ImageProxy(string filename)
        {
            _filename = filename;
            Console.WriteLine($"Создан proxy для {_filename}");
        }
        private void EnsureLoaded()
        {
            if (_realImage == null)
            {
                lock (this)
                {
                    _realImage = new HighResolutionImage( _filename );
                }
            }
        }
        public void Draw()
        {
            EnsureLoaded();
            _realImage.Draw();
        }
        public int GetWidth()
        {
            EnsureLoaded();
            return _realImage.GetWidth();
        }
        public int GetHeight()
        {
            EnsureLoaded();
            return _realImage.GetHeight();
        }
    }
}
