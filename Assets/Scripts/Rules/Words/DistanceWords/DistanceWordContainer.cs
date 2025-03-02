using System;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class DistanceWordContainer: WordContainer, IPointerClickHandler
{
    public DistanceWord distanceWord;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickable)
        {
            Destroy(transform.GetChild(0).gameObject);
            var inst = Instantiate(RuleChangeManager.instance.distanceWordBuff, transform);
            distanceWord = inst;
            transform.parent.GetComponent<RuleWrapper>().UpdateRule();
            RuleChangeManager.instance.FinishReplacing();
        }
    }
}
