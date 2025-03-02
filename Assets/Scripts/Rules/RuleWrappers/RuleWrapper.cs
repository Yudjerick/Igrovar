using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuleWrapper : MonoBehaviour
{
    public abstract string GetRuleAsString();
    public abstract List<DirectionWordContainer> GetDirectionWords();
    public abstract List<DistanceWordContainer> GetDistanceWords();

    public abstract void UpdateRule();
    public void Start()
    {
        UpdateRule();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
