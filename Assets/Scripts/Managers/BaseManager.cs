using UnityEngine;

public abstract class BaseManager : IInitializer
{
    public DIContainer Container { get; private set; }
    public BaseManager(DIContainer container)
    {
        Container = container;
    }
    
    public virtual void Initialize()
    {
        // Override this method in derived classes
    }
    
    public virtual void Dispose()
    {
        // Override this method in derived classes
        Container = null;
    }
}