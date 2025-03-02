using System;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class DirectionWordContainer: WordContainer, IPointerClickHandler
{
    public DirectionWord directionWord;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickable)
        {
            Destroy(transform.GetChild(0).gameObject);
            var inst = Instantiate(RuleChangeManager.instance.directionWordBuff, transform);
            directionWord = inst;
            transform.parent.GetComponent<RuleWrapper>().UpdateRule();
            RuleChangeManager.instance.FinishReplacing();
        }
    }
}
