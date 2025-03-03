using UnityEngine;

public class EnemyPawn : Pawn
{
    [SerializeField] public Rule movementRule;
    [SerializeField] public bool canJump;
}
