using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager: MonoBehaviour 
{
    public static MovementManager instance;
    public Pawn target;
    public List<ClickableField> clickableFields = new List<ClickableField>();

    private void Start()
    {
        instance = this;
    }

    public void DestroyAllClickableFields()
    {
        //Debug.Log(clickableFields);
        foreach (ClickableField field in clickableFields)
        {
            //Debug.Log(field);
            Object.Destroy(field.transform.parent.gameObject);
            
        }
        clickableFields.Clear();
        
        GameStateManager.instance.DestroyCard();
        
        StartCoroutine(WaitForFinishMovement());
    }

    IEnumerator WaitForFinishMovement()
    {
        yield return new WaitUntil(() => !target.isMoving);
        if(target is PlayerPawn)
        {
            GameStateManager.instance.gameState = GameState.EnemyTurn;
        }
        if (target is EnemyPawn)
        {
            GameStateManager.instance.gameState = GameState.EnemyTurn;
        }

    }
}
