using UnityEngine;

public class SingletonBase<T> : MonoBehaviour where T : Component
{
    public static T instance;

    public static T Get()
    {
        return instance;
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
