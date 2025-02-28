using UnityEngine;

public class RuleMovedToField : Rule
{
    private void OnEnable()
    {
        //RuleEventBus.MovedToFieldEvent += Execute;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public override string GetRuleAsString()
    {
        throw new System.NotImplementedException();
    }

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}
