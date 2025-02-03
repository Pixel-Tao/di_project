using UnityEngine;

// GameObject에서 직접 DIContainer를 주입받을 수 있도록 확장 메서드를 정의한다.
public static class DIExtensions
{
    public static void Inject<T>(this GameObject go, DIContainer container)
    {
        container.Inject(go.GetComponent<T>());
    }
}