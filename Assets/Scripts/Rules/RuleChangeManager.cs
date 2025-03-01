using UnityEngine;

public class RuleChangeManager : MonoBehaviour
{
    public static RuleChangeManager instance;

    public DistanceWord distanceWordBuff;
    void Start()
    {
        instance = this;
    }
}
