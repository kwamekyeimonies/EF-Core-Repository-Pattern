namespace Formula.App.Core{
    public interface IUnitOfWork
    {
        IDriverRepository Driver{get;}
        Task CompleteAsync();
    }
}