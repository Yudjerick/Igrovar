using UnityEngine;

public class MovedToFieldRule : Rule
{
    private void OnEnable()
    {
        RuleEventBus.MovedToFieldEvent += Activate;
    }

    void Activate(Pawn pawn, FieldType fieldType) 
    { 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
