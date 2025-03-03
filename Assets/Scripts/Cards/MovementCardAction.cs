using UnityEngine;

public class MovementCardAction : CardAction
{
    [SerializeField] private FigureType figureType;
    public override void Execute()
    {
        if(figureType == FigureType.Pawn)
        {
            RuleEventBus.instance.PawnPlayedEvent?.Invoke();
        }
        if (figureType == FigureType.Bishop)
        {
            RuleEventBus.instance.BishopPlayedEvent?.Invoke();
        }
        if (figureType == FigureType.Rook)
        {
            RuleEventBus.instance.RookPlayedEvent?.Invoke();
        }
        if (figureType == FigureType.Knight)
        {
            RuleEventBus.instance.KnightPlayedEvent?.Invoke();
        }
        if (figureType == FigureType.King)
        {
            RuleEventBus.instance.KingPlayedEvent?.Invoke();
        }
        if (figureType == FigureType.Queen)
        {
            RuleEventBus.instance.QueenPlayedEvent?.Invoke();
        }
        GameStateManager.instance.gameState = GameState.Movement;

    }
}
