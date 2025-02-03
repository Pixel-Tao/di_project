using UnityEngine;

public class CameraManager : BaseManager, ICameraManager
{
    public Camera MainCamera { get; private set; }
    
    public CameraManager(DIContainer container) : base(container)
    {
        MainCamera = Camera.main;
    }
    
    public void Follow(Transform target)
    {
        Debug.Log("Following " + target.name);
    }
}
