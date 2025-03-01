using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class PawnRuleWrapper : RuleWrapper
{
    [SerializeField] private BasicChessMovementRule rule;

    public DistanceWordContainer moveDistanceWordContainer;
    public DistanceWordContainer atackDistanceWordContainer;
    public DirectionWordContainer moveDirWordContainer;
    public DirectionWordContainer atackDirWordContainer;

    [SerializeField] private string ruleTextPreview;

    public override List<DirectionWordContainer> GetDirectionWords()
    {
        var directionWords = new List<DirectionWordContainer>() {moveDirWordContainer, atackDirWordContainer };
        return directionWords;
    }

    public override List<DistanceWordContainer> GetDistanceWords()
    {
        return new List<DistanceWordContainer>() { moveDistanceWordContainer, atackDistanceWordContainer }; 
    }

    public override string GetRuleAsString()
    {
        return "ѕешка " + "ходит на " + moveDistanceWordContainer.distanceWord.word +
            " " + moveDirWordContainer.directionWord.word + " или бьет на " + atackDistanceWordContainer.distanceWord.word
            + " " + atackDirWordContainer.directionWord.word; 
    }

    // Update is called once per frame
    void Update()
    {
        ruleTextPreview = GetRuleAsString();
    }

    [Button]
    public override void UpdateRule()
    {
        rule.moveDistanceWord = moveDistanceWordContainer.distanceWord;
        rule.atackDistanceWord = atackDistanceWordContainer.distanceWord;
        rule.moveDirections.Clear();
        rule.moveDirections.AddRange(moveDirWordContainer.directionWord.directions);
        rule.atackDirections.Clear();
        rule.atackDirections.AddRange(atackDirWordContainer.directionWord.directions);
    }
}
