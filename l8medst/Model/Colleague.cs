namespace l8medst.Model
{
    public abstract class Colleague
    {
        protected IMediator Mediator;
        // Метод для инъекции посредника
        public void SetMediator(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
