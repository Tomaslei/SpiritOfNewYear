using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceController : MonoBehaviour
{
    private static int VOLAUM_DATA_LENGTH = 256;
    public float volume;
    public Slider progress;
    private AudioClip mMicroRecord;
    private string mDeviceName;
    private const int frequency = 44100;
    private const int length = 99;
    private float offsetX;
    private float offsetY;
    private float offsetZ;
    private int state = 1;
    private float defaultLineBottom = -3.4f;
    private float defaultLineTop = 4.2f;
    private GameObject Line;
    private float firePositionY;
    private float fireValue;
    // Start is called before the first frame update
    void Start()
    {
        mDeviceName = Microphone.devices[0];
        mMicroRecord = Microphone.Start(mDeviceName, true, length, frequency);
        offsetX = this.transform.localScale.x;
        offsetY = this.transform.localScale.y;
        offsetZ = this.transform.localScale.z;
        fireValue = 20;
        progress.value = 10;
        Line = GameObject.Find("MarkLine");

    }

    // Update is called once per frame
    void Update()
    {
        firePositionY = defaultLineBottom + ((fireValue / 100f) * (defaultLineTop - defaultLineBottom));
        Line.transform.position = new Vector3(Line.transform.position.x, firePositionY, Line.transform.position.z);
        fireValue -= 0.1f;
        if (progress.value >= 0.5f && progress.value<100f) {
            progress.value -= 0.1f;
        }
       
        volume = GetMaxVolume();
        if (volume >= 0.2)
        {
            float xx = volume - 0.1f;
            float change = xx * 5;
            this.transform.localScale = new Vector3(offsetX + change, offsetY + change, offsetZ);
            fireValue += volume;
            
        }
        else {
            this.transform.localScale = new Vector3(offsetX, offsetY, offsetZ);
        }
        if (state == 1) {
            if (fireValue > 0 && fireValue <= 35 && progress.value < 100)
            {
                progress.value += 0.2f;
            }
        }
        else if (state == 2) {
            if (fireValue >= 35 && fireValue <= 70 && progress.value < 100)
            {
                progress.value += 0.2f;
            }
        }
        else if (state == 3) {
            if (fireValue >= 70 && fireValue <= 100 && progress.value < 100)
            {
                progress.value += 0.2f;
            }
        }
        else if (state == 0) {
            progress.value += 0.2f;
        }
        
    }

    private float GetMaxVolume() {
        float maxVolume = 0f;
        float[] volumeData = new float[VOLAUM_DATA_LENGTH];
        int offset = Microphone.GetPosition(mDeviceName) - VOLAUM_DATA_LENGTH + 1;
        if (offset < 0) {
            return 0f;
        }
        mMicroRecord.GetData(volumeData, offset);
        for (int i = 0; i < VOLAUM_DATA_LENGTH; i++) {
            float tempVolume = volumeData[i];
            if (tempVolume > maxVolume) {
                maxVolume = tempVolume;
            }
        }
        return maxVolume;
    }
    public void ChangeState(int m) {
        state = m;
    }
}
