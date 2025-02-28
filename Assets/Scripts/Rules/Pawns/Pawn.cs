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
        boardPosition = pos;
        var targetWorldPos = new Vector3(pos.x, transform.position.y, pos.y);
        StartCoroutine(MoveSmoothly(transform.position, targetWorldPos));
    }
    void Start()
    {
        
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
