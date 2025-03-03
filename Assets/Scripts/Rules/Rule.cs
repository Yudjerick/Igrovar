using System.Collections.Generic;
using UnityEngine;

public abstract class Rule : MonoBehaviour
{
    public abstract string GetRuleAsString();

    public abstract void Execute();

    public abstract List<Vector2> GetAtackFields(Pawn pawn);

    // Update is called once per frame
    void Update()
    {
        
    }
}
