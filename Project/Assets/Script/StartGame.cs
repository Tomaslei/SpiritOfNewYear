using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(btClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void btClick() {
        SceneManager.LoadScene(0);
    }
}
