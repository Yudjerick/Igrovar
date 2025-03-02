using UnityEngine;

public class RuleChangeManager : MonoBehaviour
{
    public static RuleChangeManager instance;

    public DistanceWord distanceWordBuff;
    public DirectionWord directionWordBuff;
    void Start()
    {
        instance = this;
    }
}
