using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update

    public GameObject[] traits;
    public GameObject label;

    void Start()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        foreach (GameObject trait in traits)
        {
            trait.transform.Translate(new Vector3(0, .2f, 0), Space.World);
        }
        //label.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (GameObject trait in traits)
        {
            trait.transform.Translate(new Vector3(0, -.2f, 0), Space.World);
        }
        //label.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
