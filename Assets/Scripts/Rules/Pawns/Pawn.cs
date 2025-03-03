using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Player, monsters and other entities that have figure should inherit this class
/// </summary>
public class Pawn : MonoBehaviour
{
    public bool isMoving;
    [SerializeField] private float moveTime = 0.5f;
    public Vector2 boardPosition;
    
    public void Move(Vector2 pos, bool jumpOver)
    {
        Board.Instance.objectsOnBoard[((int)Math.Round(boardPosition.x))][(int)Math.Round(boardPosition.y)] = null;
        boardPosition = pos;
        var targetWorldPos = Board.Instance.BoardToWorld(pos) + Vector3.up * transform.position.y;
        isMoving = true;
        StartCoroutine(MoveSmoothly(transform.position, targetWorldPos, jumpOver));
        Board.Instance.objectsOnBoard[((int)Math.Round(boardPosition.x))][(int)Math.Round(boardPosition.y)] = gameObject;
        if (Board.Instance.ySize - 1 == pos.y)
        {
            WinLoseManager.instance.ShowWinScreen();
        }
    }

    public void TakeDamage(float damage)
    {

    }
    void Start()
    {
        transform.position = Board.Instance.BoardToWorld(boardPosition) + transform.position.y * Vector3.up;
        Board.Instance.objectsOnBoard[((int)Math.Round(boardPosition.x))][(int)Math.Round(boardPosition.y)] = gameObject;
    }

    IEnumerator MoveSmoothly(Vector3 oldPos, Vector3 targetPos, bool jumpOver)
    {
        
        if(jumpOver)
        {
            var jumpAlpha = 0f;
            while (jumpAlpha <= 1f)
            {

                if (jumpAlpha > 1f)
                {
                    jumpAlpha = 1f;
                }
                transform.position = Vector3.Lerp(oldPos, oldPos + Vector3.up * 1f, jumpAlpha);
                jumpAlpha += Time.deltaTime / moveTime;
                yield return new WaitForEndOfFrame();
            }
            oldPos = transform.position;
            targetPos += Vector3.up * transform.position.y;
        }
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
        if (jumpOver)
        {
            oldPos = transform.position;
            var jumpAlpha = 0f;
            while (jumpAlpha <= 1f)
            {

                if (jumpAlpha > 1f)
                {
                    jumpAlpha = 1f;
                }
                transform.position = Vector3.Lerp(oldPos, oldPos - Vector3.up * 1f, jumpAlpha);
                jumpAlpha += Time.deltaTime / moveTime;
                yield return new WaitForEndOfFrame();
            }
        }
        isMoving = false;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
