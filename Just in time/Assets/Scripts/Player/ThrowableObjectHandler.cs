using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObjectHandler : MonoBehaviour
{
    public GameObject ThrowableObject
    {
        get => ThrowableObject;
        set
        {
            if (value != null)
            {
                var toc = value.GetComponent<ThrowableObjectController>();

                if (toc != null)
                {
                    ThrowableObject = value;
                    _throwableObjectScale = value.transform.localScale;
                }
                else
                {
                    ThrowableObject = null;
                    _throwableObjectScale = Vector3.one;
                }
            }
            else
                ThrowableObject = null;
        }
    }

    private Vector3 _throwableObjectScale; 
    
    void Update()
    {
        if (ThrowableObject != null)
        {
            ThrowableObject.transform.parent.position = transform.position;
            //ThrowableObject.transform.localScale = _throwableObjectScale;
            
            if (Input.GetMouseButton(0))
            {
                var throwingDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                throwingDirection *= ThrowableObject.GetComponent<ThrowableObjectController>().ThrowingForce;
                
                ThrowableObject.GetComponent<Rigidbody2D>().AddForce(throwingDirection, ForceMode2D.Impulse);

                ThrowableObject = null;
            }
        }
    }
}
