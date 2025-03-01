using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RuleMovementPlayed : Rule
{
    public PawnWord target;
    public List<Vector2> directions;
    [SerializeField] private GameObject clickableFieldPrefab;
    public DistanceWord distanceWord;
    public int minDistance;
    public int maxDistance;
    public bool canJump = false;
    public string testRuleString;
    public override string GetRuleAsString()
    {
        return "Перемещение: " + target.GetStringWord() + " двигается на север, юг, запад или восток на " + distanceWord.word ;
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
            Pawn pawn = target.GetTarget();
            for(int i = minDistance; i < maxDistance; i++)
            {
                
                var boardPos = pawn.boardPosition + new Vector2(Mathf.Round(dir.x), Mathf.Round(dir.y)) * i;
                if (Board.Instance.IsOnBoard(boardPos))
                {
                    if (Board.Instance.objectsOnBoard[((int)Math.Round(boardPos.x))][(int)Math.Round(boardPos.y)] == null)
                    {
                        var clickableField = Instantiate(clickableFieldPrefab,
                        Board.Instance.BoardToWorld(boardPos),
                        Quaternion.identity);
                        MovementManager.clickableFields.Add(clickableField.GetComponentInChildren<ClickableField>());
                    }
                    else
                    {
                        if (!canJump)
                        {
                            break; 
                        }
                    }
                    
                }
                else { break; }
                
            }
            
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        testRuleString = GetRuleAsString();
    }

    
}
