using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PotController : MonoBehaviour
{
    private SpriteRenderer pot;
    private string path = "Sprite/Pot-";
    private float target;
    private float defaultY;
    private bool ifUP=true;
    // Start is called before the first frame update
    void Start()
    {
        pot = this.GetComponent<SpriteRenderer>();
        target = this.transform.position.y + 1.0f;
        defaultY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (ifUP) {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.01f, this.transform.position.z);
        }
        else{
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.01f, this.transform.position.z); ;
        }
        if (this.transform.position.y >= target) {
            ifUP = false;
        }
        else if (this.transform.position.y <= defaultY) {
            ifUP = true;
        }
    }
    public void changeSprite(int x) {
        string tempPath = path + x;
        pot.sprite = Resources.Load(tempPath, typeof(Sprite)) as Sprite;
    }
}
