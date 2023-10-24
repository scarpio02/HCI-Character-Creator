using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        //Debug.Log(mousePos.x);
        //Debug.Log(mousePos.y);

        transform.position = new Vector3(0,3,0) - new Vector3((mousePos.x - (Screen.width / 2)) / 2000, 0, (mousePos.y - (Screen.height / 2)) / 2000);
    }
}
