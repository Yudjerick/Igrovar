using UnityEngine;

public class DistanceWord : MonoBehaviour
{
    public int minDistance;
    public int maxDistance;
    public GameObject textViewPrefab;

    public string word;
    public DistanceWordContainer container;

    private void OnMouseDown()
    {
        container.distanceWord = RuleChangeManager.instance.distanceWordBuff;
        RuleChangeManager.instance.distanceWordBuff.container = container;
        Destroy(gameObject);
    }
}
