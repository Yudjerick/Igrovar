using UnityEngine;

public class ChangeRulesCardAction : CardAction
{
    [SerializeField] Word word;
    public override void Execute()
    {
        if(word is DistanceWord)
        {
            RuleChangeManager.instance.StartDistanceWordReplacing((DistanceWord)word);
            GameStateManager.instance.gameState = GameState.ChangingRules;
        }
        else if(word is DirectionWord) 
        {
            RuleChangeManager.instance.StartDirectionWordReplacing((DirectionWord)word);
            GameStateManager.instance.gameState = GameState.ChangingRules;
        }
        else
        {
            Debug.LogWarning("word invalid AAAAAAAAAAA");
        }
        
    }
}
