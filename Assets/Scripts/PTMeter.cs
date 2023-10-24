using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PTMeter : MonoBehaviour
{
    public Slider ptMeter;
    public TMP_Text ptText;
    private int pt = 0;
    private int maxPT = 0;

    // Start is called before the first frame update
    void Start()
    {
        maxPT = GameObject.Find("Backend").GetComponent<GameController>().getPsychTokens();
        pt = maxPT;
        updateMeter();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    pt = pt - 1;
        //    updateMeter();
        //    Debug.Log("Test PT Meter");
        //}
    }

    public void updateMeter()
    {
        pt = GameObject.Find("Backend").GetComponent<GameController>().getPsychTokens();
        ptMeter.value = pt / (float)maxPT;
        ptText.text = "Psych Tokens: " + pt.ToString();
    }
}
