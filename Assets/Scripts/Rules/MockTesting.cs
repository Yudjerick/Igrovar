using NaughtyAttributes;
using UnityEngine;

public class MockTesting : MonoBehaviour
{
    [Button]
    public void PlayPawn()
    {
        RuleEventBus.instance.PawnPlayedEvent?.Invoke();
    }

    [Button]
    public void PlayRook()
    {
        RuleEventBus.instance.RookPlayedEvent?.Invoke();
    }

    [Button]
    public void PlayBishop()
    {
        RuleEventBus.instance.BishopPlayedEvent?.Invoke();
    }

    [Button]
    public void PlayKnight()
    {
        RuleEventBus.instance.KnightPlayedEvent?.Invoke();
    }

    [Button]
    public void PlayKing()
    {
        RuleEventBus.instance.KingPlayedEvent?.Invoke();
    }

    [Button]
    public void PlayQueen()
    {
        RuleEventBus.instance.QueenPlayedEvent?.Invoke();
    }
}
