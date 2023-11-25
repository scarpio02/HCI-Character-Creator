using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CategoryOnClick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update

    public GameObject[] Cats;
    public GameObject[] traits;
    public GameObject label;
    public GameObject description;
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
        description.SetActive(false);

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!this.open)
        {
            description.SetActive(true);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    { 
        description.SetActive(false);
    }


}
