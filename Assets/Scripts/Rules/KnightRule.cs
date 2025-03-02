using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class KnightRule : Rule
{
    public List<Vector2> firstDirection;
    public List<Vector2> secondDirection;
    public List<int> firstDistance;
    public List<int> secondDistance;
    [SerializeField] private GameObject clickableFieldPrefab;
    [SerializeField] private GameObject atackClickableFieldPrefab;
    [SerializeField] private Pawn pawn;
    public override void Execute()
    {
        CreateClickableFields();
    }

    public override List<Vector2> GetAtackFields()
    {
        var atackFields = new List<Vector2>();
        for(int i = 0; i < firstDirection.Count; i++)
        {
            var boardPos = pawn.boardPosition + firstDirection[i] * firstDistance[i] + secondDirection[i] * secondDistance[i];
            if (Board.Instance.IsOnBoard(boardPos))
                atackFields.Add(boardPos);
        }
        return atackFields;
    }

    public void CreateClickableFields()
    {
        var fieldsPositions = GetAtackFields();
        foreach(var pos in fieldsPositions)
        {
            var atackTarget = Board.Instance.objectsOnBoard[((int)Math.Round(pos.x))][(int)Math.Round(pos.y)];
            if (atackTarget == null)
            {
                var clickableField = Instantiate(clickableFieldPrefab,
                         Board.Instance.BoardToWorld(pos),
                         Quaternion.identity);
                MovementManager.clickableFields.Add(clickableField.GetComponentInChildren<ClickableField>());
            }
            else
            {
                var clickableField = Instantiate(atackClickableFieldPrefab,
                Board.Instance.BoardToWorld(pos),
                Quaternion.identity);
                var atackField = clickableField.GetComponentInChildren<AtackClickableField>();
                atackField.atackTarget = atackTarget;
                MovementManager.clickableFields.Add(atackField);
            }
        }
    }

    public override string GetRuleAsString()
    {
        return "";
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
