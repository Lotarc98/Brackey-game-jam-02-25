using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Grab : MonoBehaviour
{
    public GameObject HandPoint;
    private GameObject PickedObject = null;







    void Update()
    {
        if (PickedObject != null) 
        {
            if (Input.GetKey("e"))
            {
                PickedObject.gameObject.transform.SetParent(null);
                PickedObject=null;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            if (Input.GetKey("e")&& PickedObject== null)
            { 
            other.transform.position = HandPoint.transform.position;
            other.gameObject.transform.SetParent(HandPoint.gameObject.transform);
            PickedObject = other.gameObject;
            
            }
        }
    }

}
