using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    void Start()
    {
        
    }

    public Vector3 GetPosition()
    {
       
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 2000))
            {
               return hit.point + offset;
            }

        return transform.position;
    }
}
