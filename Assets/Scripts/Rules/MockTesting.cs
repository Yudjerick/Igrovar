using NaughtyAttributes;
using UnityEngine;

public class MockTesting : MonoBehaviour
{
    [Button]
    public void DoMovement()
    {
        RuleEventBus.MovementActionPlayedEvent?.Invoke();
    }

    [Button]
    public void DoAtack() 
    {
        RuleEventBus.AtackPlayedEvent?.Invoke();
    }
}
