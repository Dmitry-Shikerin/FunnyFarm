namespace Sources.Frameworks.MVVM.DomainInterfaces.Methods
{
    public interface IBindableViewMethod
    {
        void OnBind(object callback);
        void Unbind();
    }
}