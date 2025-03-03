using NaughtyAttributes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class RuleChangeManager : MonoBehaviour
{
    public static RuleChangeManager instance;

    public DirectionWord testDirection;
    public DistanceWord testDistance;
 
    [HideInInspector]
    public DistanceWord distanceWordBuff;
    [HideInInspector]
    public DirectionWord directionWordBuff;
    [HideInInspector]
    public List<WordContainer> containersBuff;
    [SerializeField] private List<GameObject> rules;
    void Start()
    {
        instance = this;
        containersBuff = new List<WordContainer> ();
    }

    [Button]
    public void TestChangeDirection()
    {
        StartDirectionWordReplacing(testDirection);
    }
    [Button]
    public void TestChangeDistance()
    {
        StartDistanceWordReplacing(testDistance);
    }

    public void StartDirectionWordReplacing(DirectionWord directionWord)
    {
        containersBuff.Clear ();
        directionWordBuff = directionWord;
        foreach (GameObject rule in rules)
        {
            var ruleWrapper = rule.GetComponent<RuleWrapper>();
            var directionContainers = ruleWrapper.GetDirectionWords();

            containersBuff.AddRange(directionContainers.Select(x => (WordContainer)x).ToList());
            foreach (var container in directionContainers)
            {
                container.ActivateButton();
            }
        }
    }

    public void StartDistanceWordReplacing(DistanceWord distanceWord)
    {
        containersBuff.Clear();
        distanceWordBuff = distanceWord;
        foreach (GameObject rule in rules)
        {
            var ruleWrapper = rule.GetComponent<RuleWrapper>();
            var distanceContainers = ruleWrapper.GetDistanceWords();

            containersBuff.AddRange(distanceContainers.Select(x => (WordContainer)x).ToList());
            foreach (var container in distanceContainers)
            {
                container.ActivateButton();
            }
        }
    }

    public void FinishReplacing()
    {
        foreach(var container in containersBuff)
        {
            container.DeactivateButton();
        }
        GameStateManager.instance.gameState = GameState.EnemyTurn; 
        GameStateManager.instance.DestroyCard();
    }
}
