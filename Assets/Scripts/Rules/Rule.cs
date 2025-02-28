using UnityEngine;

public abstract class Rule : MonoBehaviour
{
    public abstract string GetRuleAsString();

    public abstract void Execute();

    // Update is called once per frame
    void Update()
    {
        
    }
}
