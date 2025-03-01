using UnityEngine;

public class AtackClickableField : ClickableField
{
    public GameObject atackTarget;
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        Destroy( atackTarget );
    }
}
