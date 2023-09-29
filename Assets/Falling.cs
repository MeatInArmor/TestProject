using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    GameObject textObject;

    public void Start()
    {
    textObject = this.gameObject;  
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(out Portal p))
        {
            textObject.transform.position = new Vector2(0, 8);
            textObject.GetComponent<Rigidbody2D>().Sleep();

        }
    }

}
