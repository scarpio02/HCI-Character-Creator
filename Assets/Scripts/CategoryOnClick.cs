using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CategoryOnClick : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] Cats;
    public GameObject[] traits;
    public GameObject label;
    public bool open;

    void Start()
    {
        open = false;
    }

    public void OnCategoryClick()
    {
        foreach (GameObject Cat in Cats)
        {
            if (Cat.GetComponent<CategoryOnClick>().open)
            {
                Cat.GetComponent<CategoryOnClick>().CloseCategory();
            }
        }

        foreach (GameObject trait in traits)
        {
            trait.SetActive(true);
        }
        //label.SetActive(false);

        this.open = true;
        this.GetComponent<Button>().interactable = false;
    }

    public void CloseCategory()
    {
        this.GetComponent<Button>().interactable = true;
        foreach (GameObject trait in traits)
        {
            trait.SetActive(false);
        }
        label.SetActive(true);

        this.open = false;

    }

    /*public void OnPointerExit(PointerEventData eventData)
    {
        foreach (GameObject trait in traits)
        {
            trait.SetActive(false);
        }
        label.SetActive(true);
    }*/


}
