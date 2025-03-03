using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Can describe movement of pawn, rook, bishop, queen, king
/// </summary>
public class BasicChessMovementRule : Rule
{
    public PawnWord target;
    public List<Vector2> moveDirections;
    public List<Vector2> atackDirections;
    [SerializeField] private GameObject clickableFieldPrefab;
    [SerializeField] private GameObject atackClickableFieldPrefab;
    public DistanceWord moveDistanceWord;
    public DistanceWord atackDistanceWord;
    public bool canJump = false;
    public string testRuleString;
    public override string GetRuleAsString()
    {
        return "";
    }
    public override void Execute()
    {
        print("Исполнение правила перемещения");
        CreateMovementFields();
        CreateAtackFields();
    }



    protected virtual void CreateMovementFields()
    {
        MovementManager.instance.target = target.GetTarget();
        foreach (var dir in moveDirections)
        {
            Pawn pawn = target.GetTarget();
            for (int i = moveDistanceWord.minDistance; i <= moveDistanceWord.maxDistance; i++)
            {

                var boardPos = pawn.boardPosition + new Vector2(Mathf.Round(dir.x), Mathf.Round(dir.y)) * i;
                if (Board.Instance.IsOnBoard(boardPos))
                {
                    if (Board.Instance.objectsOnBoard[((int)Math.Round(boardPos.x))][(int)Math.Round(boardPos.y)] == null)
                    {
                        var clickableField = Instantiate(clickableFieldPrefab,
                        Board.Instance.BoardToWorld(boardPos),
                        Quaternion.identity);
                        MovementManager.instance.clickableFields.Add(clickableField.GetComponentInChildren<ClickableField>());
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

    protected virtual void CreateAtackFields()
    {
        var atackFieldsPositions = GetAtackFields(target.GetTarget());
        foreach (var pos in atackFieldsPositions)
        {
            var atackTarget = Board.Instance.objectsOnBoard[((int)Math.Round(pos.x))][(int)Math.Round(pos.y)];
            if (atackTarget != null)
            {
                var clickableField = Instantiate(atackClickableFieldPrefab,
                Board.Instance.BoardToWorld(pos),
                Quaternion.identity);
                var atackField = clickableField.GetComponentInChildren<AtackClickableField>();
                atackField.atackTarget = atackTarget;
                MovementManager.instance.clickableFields.Add(atackField);
                if (!canJump)
                {
                    break;
                }
            }
        }

        MovementManager.instance.target = target.GetTarget();
        foreach (var dir in atackDirections)
        {
            Pawn pawn = target.GetTarget();
            for (int i = atackDistanceWord.minDistance; i <= atackDistanceWord.maxDistance; i++)
            {

                var boardPos = pawn.boardPosition + new Vector2(Mathf.Round(dir.x), Mathf.Round(dir.y)) * i;
                if (Board.Instance.IsOnBoard(boardPos))
                {
                    var atackTarget = Board.Instance.objectsOnBoard[((int)Math.Round(boardPos.x))][(int)Math.Round(boardPos.y)];
                    if (atackTarget != null)
                    {
                        var clickableField = Instantiate(atackClickableFieldPrefab,
                        Board.Instance.BoardToWorld(boardPos),
                        Quaternion.identity);
                        var atackField = clickableField.GetComponentInChildren<AtackClickableField>();
                        atackField.atackTarget = atackTarget;
                        MovementManager.instance.clickableFields.Add(atackField);
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

    public override List<Vector2> GetAtackFields(Pawn pawn)
    {
        var atackFields = new List<Vector2>();
        MovementManager.instance.target = target.GetTarget();
        foreach (var dir in atackDirections)
        {
            for (int i = atackDistanceWord.minDistance; i <= atackDistanceWord.maxDistance; i++)
            {

                var boardPos = pawn.boardPosition + new Vector2(Mathf.Round(dir.x), Mathf.Round(dir.y)) * i;
                if (Board.Instance.IsOnBoard(boardPos))
                {
                    atackFields.Add(boardPos);
                    if (!canJump)
                    {
                        break;
                    }
                }
                else { break; }

            }

        }
        return atackFields;
    }
}
