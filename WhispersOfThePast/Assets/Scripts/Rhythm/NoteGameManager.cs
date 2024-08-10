using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGameManager : MonoBehaviour
{
    public static NoteGameManager instance;

    public AudioSource rhythmMusic;
    public bool startPlaying;
    public NoteMove noteMove;

    public int currentScore;
    public int scorePerNote = 100;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                noteMove.started = true;

                rhythmMusic.PlayDelayed(3f);
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("HIT NOTE");
        currentScore += scorePerNote;
    }

    public void NoteMiss()
    {
        Debug.Log("MISS NOTE");
    }
}
