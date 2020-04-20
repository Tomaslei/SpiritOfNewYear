using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    private VoiceController vc;
    private PotController pc;
    private GudieController gc;
    public Slider progress;
    public GameObject cong;
    public GameObject btn1;
    // Start is called before the first frame update
    void Start()
    {
        vc = GameObject.Find("Player").GetComponent<VoiceController>();
        pc = GameObject.Find("pot").GetComponent<PotController>();
        gc=GameObject.Find("FireGuide").GetComponent<GudieController>();
        cong.SetActive(false);
        btn1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (progress.value >= 100) {
            cong.SetActive(true);
            btn1.SetActive(true);
        }
        if (progress.value < 49) {
            vc.ChangeState(1);
            pc.changeSprite(1);
            gc.ChangeState(1);
        }
        else if (progress.value >= 50 && progress.value < 79)
        {
            vc.ChangeState(2);
            pc.changeSprite(2);
            gc.ChangeState(2);
        }
        else if (progress.value >= 80)
        {
            vc.ChangeState(3);
            pc.changeSprite(3);
            gc.ChangeState(3);
        }
        else if((progress.value>=49 && progress.value<50) || (progress.value>=79 && progress.value<80)){
            vc.ChangeState(0);
        }
    }
}
