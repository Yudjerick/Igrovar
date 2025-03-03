using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    [SerializeField] private CardAction action;
    [SerializeField] private float highlightOffset;
    private void OnMouseEnter()
    {
        transform.localPosition += Vector3.back * highlightOffset;
    }

    private void OnMouseExit()
    {
        transform.localPosition -= Vector3.back * highlightOffset;
    }

    private void OnMouseDown()
    {
        action.Execute();
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
