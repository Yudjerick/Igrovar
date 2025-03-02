using System;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class DistanceWordContainer: MonoBehaviour, IPointerClickHandler
{
    public DistanceWord distanceWord;
    public bool clickable;

    public void OnPointerClick(PointerEventData eventData)
    {
        print("aaa");
        if (clickable)
        {
            Destroy(transform.GetChild(0).gameObject);
            var inst = Instantiate(RuleChangeManager.instance.distanceWordBuff, transform);
            distanceWord = inst;
            transform.parent.GetComponent<RuleWrapper>().UpdateRule();
        }
    }
}
