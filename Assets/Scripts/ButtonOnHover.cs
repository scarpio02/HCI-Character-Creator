using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update

    public GameObject[] traits;

    void Start()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (GameObject trait in traits)
        {
            trait.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (GameObject trait in traits)
        {
            trait.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
