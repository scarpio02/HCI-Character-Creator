using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TraitOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool hover = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hover = true;
        TraitText();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hover = false;
        TraitText();
    }

    public void TraitText()
    {
        List<Category> cats = GameObject.Find("Backend").GetComponent<GameController>().categories;

        foreach (Category cat in cats)
        {
            for (int i = 0; i < cat.traits.Count; i++)
            {
                if ((gameObject.name == cat.traits[i].GetName()) && hover)
                {
                    gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = cat.traits[i].GetName() + " | Cost: " + cat.traits[i].GetPTString() + "\n" + cat.traits[i].GetDescription();
                }
                else if((gameObject.name == cat.traits[i].GetName()) && !hover)
                {
                    gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = cat.traits[i].GetName();
                }
            }
        }
    }
}
