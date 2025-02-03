using UnityEngine;
using Object = UnityEngine.Object;

public class ResourceManager : BaseManager, IResourceManager
{
    public ResourceManager(DIContainer container) : base(container)
    {
        
    }
    
    public T LoadPrefab<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }
    public GameObject Instantiate(string path, Vector3 position, Transform parent = null)
    {
        GameObject prefab = LoadPrefab<GameObject>(path);
        return Instantiate(prefab, position, parent);
    }
    public GameObject Instantiate(GameObject prefab, Vector3 position, Transform parent = null)
    {
        GameObject instance = Object.Instantiate(prefab, position, Quaternion.identity, parent);
        return instance;
    }
}