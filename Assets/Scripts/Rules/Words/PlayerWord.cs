using UnityEngine;

public class PlayerWord : PawnWord
{
    public override bool CheckPawnType(Pawn pawn)
    {
        return pawn is PlayerPawn;
    }

    public override string GetStringWord()
    {
        return "Игрок";
    }

    public override Pawn GetTarget()
    {
        return FindAnyObjectByType<PlayerPawn>(); 
    }
}
