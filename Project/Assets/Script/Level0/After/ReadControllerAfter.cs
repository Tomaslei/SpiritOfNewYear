using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadControllerAfter : MonoBehaviour
{
    private TextAsset txt;
    private string[] str;
    private int txtNumber = 0;
    private string currentWord;
    public Text name;
    public Text contest;
    public SpriteRenderer bg;
    public GameObject Text;
    public GameObject Button1;
    public GameObject Button2;
    // Start is called before the first frame update
    void Start()
    {
        txt = Resources.Load("Text/text0-2") as TextAsset;
        str = txt.text.Split('\n');
        Text.SetActive(false);
        Button1.SetActive(false);
        Button2.SetActive(false);
        Screen.fullScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentWord = str[txtNumber];
        if (currentWord.Contains("+"))
        {
            name.text = "Chen";
            txtNumber += 1;
        }
        else if (currentWord.Contains("-"))
        {
            name.text = "Old Man";
            txtNumber += 1;
        }
        else if (currentWord.Contains("*"))
        {
            bg.sprite = Resources.Load("Sprite/level0-4", typeof(Sprite)) as Sprite;
            txtNumber += 1;
        }
        else if (currentWord.Contains("&"))
        {
            Text.SetActive(true);
            Button1.SetActive(true);
            Button2.SetActive(true);
        }
        else
        {
            contest.text = currentWord;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (txtNumber<str.Length-1) {
                txtNumber += 1;
            }
        }
    }
}
