using NaughtyAttributes;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    public GameState gameState;
    public Card cardToDesttroy;

    [Button]
    public void CancelCardAction()
    {
        gameState = GameState.ClickableCards;
        cardToDesttroy = null;
    }

    public void DestroyCard()
    {
        Destroy(cardToDesttroy.gameObject);
    }
    void Start()
    {
        instance = this;
        gameState = GameState.ClickableCards;
    }

    
}
