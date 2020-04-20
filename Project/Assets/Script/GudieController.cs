using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GudieController : MonoBehaviour
{
    private SpriteRenderer Guide;
    private string path = "Sprite/";
    private string target;
    // Start is called before the first frame update
    void Start()
    {
        Guide = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeState(int x) {
        if (x == 1)
        {
            target = "Little";
        }
        else if (x == 2)
        {
            target = "Middle";
        }
        else if (x == 3) {
            target = "Large";
        }
        string tempPath = path + target;
        Guide.sprite = Resources.Load(tempPath, typeof(Sprite)) as Sprite;
    }
}
