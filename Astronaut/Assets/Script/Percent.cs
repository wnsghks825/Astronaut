using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Percent : MonoBehaviour
{
    public float n;
    private float n1 = 0;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites = new Sprite[10];
    float score = 0;

    Text scoreLabel;
    CreateNote createNote;
    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GetComponent<Text>();
        createNote = GameObject.Find("NoteManager").GetComponent<CreateNote>();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        score = ((Player.score / createNote.type.Count) * 100);

        n1 = score / n;
        gameObject.GetComponent<Image>().sprite = sprites[(int)n1 % 10]; //이미지 변경

        //scoreLabel.text = ((Player.score / createNote.type.Count)*100).ToString();
    }
}
