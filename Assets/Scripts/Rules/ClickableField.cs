using UnityEngine;

public class ClickableField : MonoBehaviour
{
    public bool jumpField;
    protected virtual void OnMouseDown()
    {
        MovementManager.instance.target.Move(Board.Instance.WorldToBoard(transform.position), jumpField);
        MovementManager.instance.DestroyAllClickableFields();
    }
}
