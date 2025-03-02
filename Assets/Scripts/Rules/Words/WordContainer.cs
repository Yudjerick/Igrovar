using UnityEngine;
using UnityEngine.UI;

public class WordContainer : MonoBehaviour
{
    public bool clickable;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void ActivateButton()
    {
        clickable = true;
        GetComponent<Image>().enabled = true;
    }

    public virtual void DeactivateButton()
    {
        clickable = false;
        GetComponent<Image>().enabled = false;
    }
}
