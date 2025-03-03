using UnityEngine;

public class ChangeRulesCardAction : CardAction
{
    [SerializeField] Word word;
    public override void Execute()
    {
        if(word is DistanceWord)
        {
            RuleChangeManager.instance.StartDistanceWordReplacing((DistanceWord)word);
        }
        else if(word is DirectionWord) 
        {
            RuleChangeManager.instance.StartDirectionWordReplacing((DirectionWord)word);
        }
        else
        {
            Debug.LogWarning("word invalid AAAAAAAAAAA");
        }
    }
}
