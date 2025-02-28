using UnityEngine;

public class RuleAtackPlayed : Rule
{
    public PawnWord target;
    public int damage;
    public override void Execute()
    {
        throw new System.NotImplementedException();
    }

    public override string GetRuleAsString()
    {
        return "Атака: " + target.GetStringWord() + "наносит " + damage;
    }

    private void OnEnable()
    {
        RuleEventBus.AtackPlayedEvent += Execute;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
