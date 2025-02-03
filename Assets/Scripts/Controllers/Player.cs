using UnityEngine;

public class Player : MonoBehaviour
{
    [Inject] private IGameManager _gameManager;
    [Inject] private ICameraManager _cameraManager;
    
    public void Start()
    {
        _cameraManager.Follow(transform);
    }
}