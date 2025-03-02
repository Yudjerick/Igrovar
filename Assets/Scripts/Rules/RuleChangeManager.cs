using System.Collections.Generic;
using UnityEngine;

public class RuleChangeManager : MonoBehaviour
{
    public static RuleChangeManager instance;

    public DistanceWord distanceWordBuff;
    public DirectionWord directionWordBuff;
    [SerializeField] private List<GameObject> rules;
    void Start()
    {
        instance = this;
    }
}
