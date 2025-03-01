using UnityEngine;

public class ClickableField : MonoBehaviour
{
    protected virtual void OnMouseDown()
    {
        MovementManager.target.Move(Board.Instance.WorldToBoard(transform.position));
        MovementManager.DestroyAllClickableFields();
    }
}
