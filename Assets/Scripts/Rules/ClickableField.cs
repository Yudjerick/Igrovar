using UnityEngine;

public class ClickableField : MonoBehaviour
{
    private void OnMouseDown()
    {
        MovementManager.target.Move(Board.Instance.WorldToBoard(transform.position));
        MovementManager.DestroyAllClickableFields();
    }
}
