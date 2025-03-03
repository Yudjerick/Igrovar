using System.Xml.Serialization;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource sfxObject;
    [SerializeField]
    private AudioClip deck;
    [SerializeField]
    private AudioClip move;
    [SerializeField]
    private AudioClip drawCard;
    [SerializeField]
    private AudioClip chessShake;
    [SerializeField]
    private AudioClip kill;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //Really bad idea to write like that. but in order to add sfx faster after cards are finished that will do it
    public void Deck()
    {
        sfxObject.clip = deck;
        sfxObject.Play();
    }

    public void Move()
    {
        sfxObject.clip = move;
        sfxObject.Play();
    }

    public void DrawCard()
    {
        sfxObject.clip = drawCard;
        sfxObject.Play();
    }

    public void ChessShake()
    {
        sfxObject.clip = chessShake;
        sfxObject.Play();
    }

    public void Kill()
    {
        sfxObject.clip = kill;
        sfxObject.Play();
    }

}
