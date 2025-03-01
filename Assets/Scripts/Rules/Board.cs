using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board Instance;
    [SerializeField] private int xSize = 5;
    [SerializeField] private int ySize = 5;
    [SerializeField] private Vector3 boardZero;
    [SerializeField] private float cellSize = 1;
    public List<List<FieldType>> fieldTypes;
    public List<List<GameObject>> objectsOnBoard;
    void Start()
    {
        InitializeBoard();
        Instance = this;
    }

    public void InitializeBoard()
    {
        objectsOnBoard = new List<List<GameObject>>();
        fieldTypes = new List<List<FieldType>>();
        for (int i = 0; i < xSize; i++)
        {
            objectsOnBoard.Add(new List<GameObject>());
            fieldTypes.Add(new List<FieldType>());
            for (int j = 0; j < ySize; j++)
            {
                objectsOnBoard[i].Add(null);
                fieldTypes[i].Add(FieldType.Empty);
            }
        }
    }

    public bool IsOnBoard(Vector2 boardPos)
    {
        return boardPos.x >= 0 && boardPos.x < xSize && boardPos.y >= 0 && boardPos.y < ySize;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 WorldToBoard(Vector3 worldPosition)
    {
        worldPosition = worldPosition - boardZero;
        return new Vector2(worldPosition.x, worldPosition.z) / cellSize;
    }

    public Vector3 BoardToWorld(Vector2 boardPos)
    {
        return boardZero + new Vector3(boardPos.x, 0, boardPos.y) * cellSize;
    }
}
