using Unity.VisualScripting;
using UnityEngine;

public class AnyEnemyWord : PawnWord
{
    public override bool CheckPawnType(Pawn pawn)
    {
        return pawn is EnemyPawn;
    }

    public override string GetStringWord()
    {
        return "какой-то враг";
    }

    public override Pawn GetTarget()
    {
        var enemies = FindObjectsOfType<EnemyPawn>();
        return enemies[Random.Range(0, enemies.Length - 1)];
    }
}
