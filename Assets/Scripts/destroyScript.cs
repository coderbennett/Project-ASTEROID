using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyScript : MonoBehaviour {

    public float destroyTime = 0.5f;
    public bool deactivate = false;

    // Use this for initialization
    void Start()
    {
        Invoke("DestroyMyObject", destroyTime);
        if (deactivate)
        {
            Invoke("DestroyMyObject", destroyTime - 4f);
        }
    }

    void DestroyMyObject()
    {
        Destroy(gameObject);
    }

    void DeactivateyMyObject()
    {
        gameObject.SetActive(false);
    }
}
