using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionController2 : MonoBehaviour
{
    private Button btn;
    public Button anotherBtn;
    public ReadController rc;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(this.btnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void btnClick()
    {
        rc.optionNumber = 2;
        rc.inOption = false;

    }
}
