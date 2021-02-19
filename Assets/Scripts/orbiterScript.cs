using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbiterScript : MonoBehaviour {

    public float speed;

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, speed) * Time.deltaTime);
    }
}
