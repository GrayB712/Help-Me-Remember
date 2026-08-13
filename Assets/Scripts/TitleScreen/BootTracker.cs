using UnityEngine;

public class BootTracker : MonoBehaviour
{
    public static BootTracker current;

    private void Awake()
    {
        if(current == null){
            current = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}
