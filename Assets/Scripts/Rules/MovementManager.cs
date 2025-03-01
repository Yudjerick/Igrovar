using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public static class MovementManager
{
    public static Pawn target;
    public static List<ClickableField> clickableFields = new List<ClickableField>();

    public static void DestroyAllClickableFields()
    {
        //Debug.Log(clickableFields);
        foreach (ClickableField field in clickableFields)
        {
            //Debug.Log(field);
            Object.Destroy(field.transform.parent.gameObject);
            
        }
        clickableFields.Clear();
    }
}
