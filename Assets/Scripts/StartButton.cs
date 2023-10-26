using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartButton : MonoBehaviour
{

    public GameObject StartScreenPanel;
    public GameObject StartB;
    public TMP_Text TitleText;
    public TMP_Text TeamText;
    public TMP_Text ButtonText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        StartCoroutine(FadeScreen());
        
    }

    public IEnumerator FadeScreen(int fadeSpeed = 1)
    {
        Color panelColor = StartScreenPanel.GetComponent<Image>().color;
        Color buttonColor = StartB.GetComponent<Image>().color;
        Color startColor = ButtonText.color;
        Color titleColor = TitleText.color;
        Color teamColor = TitleText.color;

        float fadeAmount;
        float fadeAmount2;
        float fadeAmount3;
        float fadeAmount4;
        float fadeAmount5;

        yield return new WaitForSecondsRealtime(1);

        while (StartScreenPanel.GetComponent<Image>().color.a > 0)
        {
            fadeAmount = panelColor.a - (fadeSpeed * Time.deltaTime);
            fadeAmount2 = buttonColor.a - (fadeSpeed * Time.deltaTime);
            fadeAmount3 = startColor.a - (fadeSpeed * Time.deltaTime);
            fadeAmount4 = titleColor.a - (fadeSpeed * Time.deltaTime);
            fadeAmount5 = teamColor.a - (fadeSpeed * Time.deltaTime);

            panelColor = new Color(panelColor.r, panelColor.g, panelColor.b, fadeAmount);
            buttonColor = new Color(buttonColor.r, buttonColor.g, buttonColor.b, fadeAmount2);
            startColor = new Color(startColor.r, startColor.g, startColor.b, fadeAmount3);
            titleColor = new Color(titleColor.r, titleColor.g, titleColor.b, fadeAmount4);
            teamColor = new Color(teamColor.r, teamColor.g, teamColor.b, fadeAmount5);

            StartScreenPanel.GetComponent<Image>().color = panelColor;
            StartB.GetComponent<Image>().color = buttonColor;
            ButtonText.color = startColor;
            TitleText.color = titleColor;
            TeamText.color = teamColor;

            yield return null;
        }


        StartScreenPanel.SetActive(false);
    }

}
