using NaughtyAttributes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KingQueenRuleWrapper: RuleWrapper
{
    [SerializeField] private BasicChessMovementRule rule;
    [SerializeField] private string figureName = "";
    

    public DistanceWordContainer distanceWordContainer;
    public DirectionWordContainer dirWordContainer;
    public DirectionWordContainer dirWordContainer2;

    [SerializeField] private TMP_Text emptyTextPrefab;

    [SerializeField] private string ruleTextPreview;

    public override List<DirectionWordContainer> GetDirectionWords()
    {
        var directionWords = new List<DirectionWordContainer>() { dirWordContainer, dirWordContainer2 };
        return directionWords;
    }

    public override List<DistanceWordContainer> GetDistanceWords()
    {
        return new List<DistanceWordContainer>() { distanceWordContainer };
    }

    public override string GetRuleAsString()
    {
        return "";
    }

    // Update is called once per frame
    void Update()
    {
        //ruleTextPreview = GetRuleAsString();
    }

    [Button]
    public override void UpdateRule()
    {
        rule.moveDistanceWord = distanceWordContainer.distanceWord;
        rule.atackDistanceWord = distanceWordContainer.distanceWord;
        rule.moveDirections.Clear();
        rule.moveDirections.AddRange(dirWordContainer.directionWord.directions);
        rule.moveDirections.AddRange(dirWordContainer2.directionWord.directions);
        rule.atackDirections.Clear();
        rule.atackDirections.AddRange(dirWordContainer.directionWord.directions);
        rule.atackDirections.AddRange(dirWordContainer2.directionWord.directions);
    }
}
