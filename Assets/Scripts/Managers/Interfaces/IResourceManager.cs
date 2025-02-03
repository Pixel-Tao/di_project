using UnityEngine;
using Object = UnityEngine.Object;

public interface IResourceManager
{
    public T LoadPrefab<T>(string path) where T : Object;
    public GameObject Instantiate(string path, Vector3 position, Transform parent = null);
    public GameObject Instantiate(GameObject prefab, Vector3 position, Transform parent = null);
}