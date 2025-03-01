using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Player, monsters and other entities that have figure should inherit this class
/// </summary>
public class Pawn : MonoBehaviour
{
    [SerializeField] private float moveTime = 0.5f;
    public Vector2 boardPosition;
    
    public void Move(Vector2 pos)
    {
        Board.Instance.objectsOnBoard[((int)Math.Round(boardPosition.x))][(int)Math.Round(boardPosition.y)] = null;
        boardPosition = pos;
        var targetWorldPos = Board.Instance.BoardToWorld(pos) + Vector3.up * transform.position.y;
        StartCoroutine(MoveSmoothly(transform.position, targetWorldPos));
        Board.Instance.objectsOnBoard[((int)Math.Round(boardPosition.x))][(int)Math.Round(boardPosition.y)] = gameObject;
    }

    public void TakeDamage(float damage)
    {

    }
    void Start()
    {
        transform.position = Board.Instance.BoardToWorld(boardPosition) + transform.position.y * Vector3.up;
        Board.Instance.objectsOnBoard[((int)Math.Round(boardPosition.x))][(int)Math.Round(boardPosition.y)] = gameObject;
    }

    IEnumerator MoveSmoothly(Vector3 oldPos, Vector3 targetPos)
    {
        var alpha = 0f;
        while(alpha <= 1f)
        {
            
            if(alpha > 1f)
            {
                alpha = 1f;
            }
            transform.position = Vector3.Lerp(oldPos, targetPos, alpha);
            alpha += Time.deltaTime / moveTime;
            yield return new WaitForEndOfFrame();
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
