using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private int xSize = 5;
    [SerializeField] private int ySize = 5;
    private List<List<FieldType>> fieldTypes;
    void Start()
    {
        InitializeBoard();
    }

    public void InitializeBoard()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
