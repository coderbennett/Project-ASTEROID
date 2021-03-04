using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbiterScript : MonoBehaviour {

    public float speed;
    private float staticSpeed;


    void Start()
    {
        staticSpeed = speed;
    }

        private void Update()
    {
        //rotate this object at a certain speed
        transform.Rotate(new Vector3(0f, 0f, speed) * Time.deltaTime);
        //if the game is paused stop orbitting by setting the speed to zero
        if (healthBarScript.paused)
        {
            speed = 0;
        }

        //if the game is not paused and the orbitting speed is zero, update the speed back to what it was at the start
        if (!healthBarScript.paused && speed == 0)
        {
            speed = staticSpeed;
        }
    }
}
