using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    public static WinLoseManager instance;
    public bool won = false;

    private void Start()
    {
        instance = this;
    }
    public void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }

    public void ShowWinScreen()
    {
        won = true;
        winScreen.SetActive(true);
    }
}
