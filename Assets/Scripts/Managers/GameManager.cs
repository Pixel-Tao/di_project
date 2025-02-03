using UnityEngine;

public class GameManager : BaseManager, IGameManager
{
    [Inject] public IResourceManager ResourceManager { get; private set; }
    public GameManager(DIContainer container) : base(container)
    {
        
    }

    public void StartGame()
    {
        GameObject go = ResourceManager.Instantiate("Prefabs/Player", Vector3.zero);
        go.name = "Player";
        go.Inject<Player>(Container);
        Debug.Log("Game Started");
    }
    
    public void StopGame()
    {
        Debug.Log("Game Over");
    }
}