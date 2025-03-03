using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    void Start()
    {
        instance = this;
    }

    
}
