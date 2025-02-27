using UnityEngine;

public abstract class PawnWord : MonoBehaviour
{
    public abstract string GetStringWord();
    public abstract bool CheckPawnType(Pawn pawn);

    public abstract Pawn GetTarget();
}
