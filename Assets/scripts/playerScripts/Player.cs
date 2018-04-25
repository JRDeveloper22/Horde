using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour {

    // Use this for initialization
    public Vector3 hitInfo;
    public bool clicked;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked = true;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                hitInfo = hit.point;
            }
        }
        else clicked = false;
    }
}
