using UnityEngine;

public class Singletone<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject(nameof(T));
                _instance = go.AddComponent<T>();
                DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }
}