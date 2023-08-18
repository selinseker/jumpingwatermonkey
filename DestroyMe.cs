using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyObject()
    {
        
        Destroy(gameObject);
    }
}
