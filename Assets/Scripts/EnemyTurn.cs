using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{

    [SerializeField] List<EnemyPawn> enemies;
    
    void Update()
    {
        if(GameStateManager.instance.gameState == GameState.EnemyTurn)
        {
            var enemyAtacks = false;
            var playerPos = FindAnyObjectByType<PlayerPawn>().boardPosition;
            foreach (EnemyPawn enemy in enemies)
            {
                var atackFields = enemy.movementRule.GetAtackFields(enemy);
                foreach(var field in atackFields)
                {
                    if(field == playerPos)
                    {
                        if (WinLoseManager.instance.won)
                        {
                            return;
                        }
                        enemy.Move(playerPos, enemy.canJump);
                        enemyAtacks = true;
                        WinLoseManager.instance.ShowLoseScreen();
                    }
                    
                }
            }
            if (!enemyAtacks)
            {
                GameStateManager.instance.gameState = GameState.ClickableCards;
            }
        }
    }
}
