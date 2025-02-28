using UnityEngine;

public class ClickableField : MonoBehaviour
{
    private void OnMouseDown()
    {
        MovementManager.target.Move(new Vector2(transform.position.x, transform.position.z));
        MovementManager.DestroyAllClickableFields();
    }
}
