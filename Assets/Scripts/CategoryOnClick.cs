using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CategoryOnClick : MonoBehaviour, IPointerExitHandler
{
    // Start is called before the first frame update

    public GameObject[] traits;
    public GameObject label;

    void Start()
    {

    }

    public void OnCategoryClick()
    {
        foreach (GameObject trait in traits)
        {
            trait.SetActive(true);
        }
        label.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (GameObject trait in traits)
        {
            trait.SetActive(false);
        }
        label.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
