using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeScript : MonoBehaviour
{
    public Animator animator;
    public static int volume = 0;
    public SpriteRenderer sprite;

    private Vector3 mousePosition;
    private bool isOver = false;

    void Update()
    {
        animator.SetInteger("volumeNum", volume);
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && isOver)
        {
            if(volume < 2)
            {
                volume++;
            } else if (volume == 2)
            {
                volume = 0;
            }
        }

        if (isOver)
        {
            sprite.color = new Color(1f, 1f, 1f);
        } else
        {
            sprite.color = new Color(0.75f, 0.75f, 0.75f);
        }
    }

    //this will track the mouse movement (if it is over the volume button)
    public void OnMouseEnter()
    {
        isOver = true;
    }

    //this will let us know if the mouse has gone away from the volume button
    public void OnMouseExit()
    {
        isOver = false;
    }
}
