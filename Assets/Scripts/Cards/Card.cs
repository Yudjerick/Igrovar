using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    [SerializeField] private CardAction action;
    [SerializeField] private float highlightOffset;
    private void OnMouseEnter()
    {
        if(GameStateManager.instance.gameState == GameState.ClickableCards)
        {
            transform.localPosition += Vector3.back * highlightOffset;
        }
        
    }

    private void OnMouseExit()
    {
        if (GameStateManager.instance.gameState == GameState.ClickableCards)
        {
            transform.localPosition -= Vector3.back * highlightOffset;
        }
        
    }

    private void OnMouseDown()
    {
        if (GameStateManager.instance.gameState == GameState.ClickableCards)
        {
            transform.localPosition += Vector3.up * 2 * highlightOffset;
            action.Execute();
            GameStateManager.instance.cardToDesttroy = this;
        }
            

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
