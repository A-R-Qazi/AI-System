namespace Qazi.Modules.AI
{
    public interface RootComponent
    {
        void RegisterChildren();
        T GetComponent<T>();
        T GetComponentInChildren<T>();
    }
}