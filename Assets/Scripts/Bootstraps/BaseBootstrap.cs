using UnityEngine;

public abstract class BaseBootstrap : MonoBehaviour
{
    public DIContainer Container { get; protected set; }
    private void Awake()
    {
        DI();
    }
    protected virtual void DI()
    {
        Container = new DIContainer();
    }
}
