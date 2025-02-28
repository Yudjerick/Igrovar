using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RuleMovementPlayed : Rule
{
    public PawnWord target;
    public List<Vector2> directions;
    [SerializeField] private GameObject clickableFieldPrefab;
    public int distance;

    public string testRuleString;
    public override string GetRuleAsString()
    {
        return "Перемещение: " + target.GetStringWord() + " двигается на север, юг, запад или восток на " + distance + "  клетку";
    }

    private void OnEnable()
    {
        RuleEventBus.MovementActionPlayedEvent += Execute;
    }

    private void OnDisable()
    {
        RuleEventBus.MovementActionPlayedEvent -= Execute;
    }
    public override void Execute()
    {
        print("Исполнение правила перемещения");
        MovementManager.target = target.GetTarget();
        foreach (var dir in directions)
        {
            var clickableField = Instantiate(clickableFieldPrefab, new Vector3(target.GetTarget().transform.position.x, 0, target.GetTarget().transform.position.z) + new Vector3(Mathf.Round(dir.x), 0, Mathf.Round(dir.y)) * distance, Quaternion.identity);
            MovementManager.clickableFields.Add(clickableField.GetComponentInChildren<ClickableField>());
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        testRuleString = GetRuleAsString();
    }

    
}
