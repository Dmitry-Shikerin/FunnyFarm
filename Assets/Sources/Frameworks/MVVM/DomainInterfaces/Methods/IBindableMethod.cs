namespace Sources.Frameworks.MVVM.DomainInterfaces.Methods
{
    public interface IBindableMethod<T>
    {
        void Invoke(params object[] args);
    }
}