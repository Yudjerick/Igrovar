using System.Collections.Generic;
using UnityEngine;

public class KnightRuleWrapper : RuleWrapper
{
    [SerializeField] private KnightRule knightRule;
    [SerializeField] private DistanceWordContainer distanceWordContainer1;
    [SerializeField] private DistanceWordContainer distanceWordContainer2;
    [SerializeField] private DistanceWordContainer distanceWordContainer3;
    [SerializeField] private DistanceWordContainer distanceWordContainer4;
    [SerializeField] private DirectionWordContainer directionWordContainer1;
    [SerializeField] private DirectionWordContainer directionWordContainer2;
    [SerializeField] private DirectionWordContainer directionWordContainer3;
    [SerializeField] private DirectionWordContainer directionWordContainer4;
    public override List<DirectionWordContainer> GetDirectionWords()
    {
        return new List<DirectionWordContainer>() { directionWordContainer1, directionWordContainer2, directionWordContainer3, directionWordContainer4};
    }

    public override List<DistanceWordContainer> GetDistanceWords()
    {
        return new List<DistanceWordContainer>() { distanceWordContainer1, distanceWordContainer2, distanceWordContainer3, distanceWordContainer4};
    }

    public override string GetRuleAsString()
    {
        return "";
    }

    public override void UpdateRule()
    {
        knightRule.firstDirection.Clear();
        knightRule.secondDirection.Clear();
        knightRule.firstDistance.Clear();
        knightRule.secondDistance.Clear();
        foreach (var firstDir in directionWordContainer1.directionWord.directions)
        {
            foreach (var secondDir in directionWordContainer2.directionWord.directions)
            {
                for (int i = distanceWordContainer1.distanceWord.minDistance;
                    i <= distanceWordContainer1.distanceWord.maxDistance; i++)
                {
                    for (int j = distanceWordContainer2.distanceWord.minDistance;
                    j <= distanceWordContainer2.distanceWord.maxDistance; j++)
                    {
                        knightRule.firstDirection.Add(firstDir);
                        knightRule.secondDirection.Add(secondDir);
                        knightRule.firstDistance.Add(i);
                        knightRule.secondDistance.Add(j);
                    }
                }

            }
        }
        foreach (var firstDir in directionWordContainer3.directionWord.directions)
        {
            foreach (var secondDir in directionWordContainer4.directionWord.directions)
            {
                for (int i = distanceWordContainer3.distanceWord.minDistance;
                    i <= distanceWordContainer3.distanceWord.maxDistance; i++)
                {
                    for (int j = distanceWordContainer4.distanceWord.minDistance;
                    j <= distanceWordContainer4.distanceWord.maxDistance; j++)
                    {
                        knightRule.firstDirection.Add(firstDir);
                        knightRule.secondDirection.Add(secondDir);
                        knightRule.firstDistance.Add(i);
                        knightRule.secondDistance.Add(j);
                    }
                }
            }
        }
        

    }

}
