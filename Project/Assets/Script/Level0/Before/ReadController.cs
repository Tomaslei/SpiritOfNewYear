using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadController : MonoBehaviour
{
    private TextAsset txt;
    private string[] str;
    private int txtNumber=0;
    private string currentWord;
    public bool inOption=false;
    private bool readOption = false;
    private bool isReading = false;
    public int optionNumber=0;
    public Text name;
    public Text contest;
    public SpriteRenderer bg;
    public GameObject option1;
    public GameObject option2;
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        txt = Resources.Load("Text/text0-1") as TextAsset;
        str = txt.text.Split('\n');
        Screen.fullScreen = false;
        option1.SetActive(false);
        option2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        currentWord = str[txtNumber];
        print(txtNumber);
        if (!inOption && (option1.active) && option2.active) {
            option1.SetActive(false);
            option2.SetActive(false);
        }
        if (optionNumber == 0)
        {
            readOption = false;
        }
        else {
           
            readOption = true;
        }
        if (!readOption)
        {
            ReadText();
        }
        else {
            if (!isReading)
            {
                if (optionNumber == 1)
                {
                    if (currentWord.Contains("["))
                    {
                        txtNumber += 1;
                        isReading = true;
                    }
                    else
                    {
                        txtNumber += 1;
                    }
                }
                else if (optionNumber == 2)
                {
                    if (currentWord.Contains("{"))
                    {
                        txtNumber += 1;
                        isReading = true;
                    }
                    else
                    {
                       
                        txtNumber += 1;
                    }
                }
            }
            else {

                if ((currentWord.Contains("}")))
                {
                    isReading = false;
                    readOption = false;
                    optionNumber = 0;
                    txtNumber += 1;
                }
                else if (currentWord.Contains("]")) {
                    while (!currentWord.Contains("}")) {
                        txtNumber += 1;
                        currentWord = str[txtNumber];
                    }
                }
                else
                {
                    ReadText();
                }
               
            }
            
        }
        
        if (!inOption&&Input.GetMouseButtonDown(0)) {
            txtNumber += 1;
        }
    }
    private void ReadText() {


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
            bg.sprite = Resources.Load("Sprite/level0-2", typeof(Sprite)) as Sprite;
            txtNumber += 1;
        }
        else if (currentWord.Contains("&"))
        {
            SceneManager.LoadScene(1);
        }

        else if (currentWord.Contains("$"))
        {
            inOption = true;
            option1.SetActive(true);
            option2.SetActive(true);
            txtNumber += 1;
            currentWord = str[txtNumber];
            option1.GetComponentInChildren<Text>().text = currentWord;
            txtNumber += 1;
            currentWord = str[txtNumber];
            option2.GetComponentInChildren<Text>().text = currentWord;
        }
        else if (currentWord.Contains("%")) {
            sound.Play();
            txtNumber += 1;
        }
        else if (!inOption)
        {
            contest.text = currentWord;
        }
    }
}
