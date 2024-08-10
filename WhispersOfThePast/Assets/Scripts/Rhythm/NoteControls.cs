using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteControls : MonoBehaviour
{
    private SpriteRenderer noteSprite;
    public Sprite defaultImg;
    public Sprite pressedImg;
    private BoxCollider2D boxCollider;

    public KeyCode pressKey;

    // Start is called before the first frame update
    void Start()
    {
        noteSprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if pressed change image
        if (Input.GetKeyDown(pressKey))
        {
            noteSprite.sprite = pressedImg;
        }
        // when let go change image back
        if (Input.GetKeyUp(pressKey))
        {
            noteSprite.sprite = defaultImg;
        }
    }

}
