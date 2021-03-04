using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class floatingTextScript : MonoBehaviour {

    public Animator animator;
    private Text pointText;
    private int random;

    void OnEnable()
    {
        //find the information on the clip for this text object
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        //destroy the object after the amount of time for the animation has passed
        Destroy(gameObject, clipInfo[0].clip.length);
        //set the text to the animator controller for the text object
        pointText = animator.GetComponent<Text>();
        //set a random number to decide which of the three text animations will be used
        random = Random.Range(0, 2);
        animator.SetInteger("random", random);
    }

    public void SetText(string text, bool miningIncrease, string color)
    {
        //if this is a mining increase text then we will set the animation up for that
        animator.SetBool("miningIncrease", miningIncrease);
        //if this is a mining increase we will make the font size smaller
        if(miningIncrease)
        {
            pointText.fontSize = 8;
        }

        //depending on what color is passed to this method we will change the color of the text
        if (color == "green")
        {
            pointText.color = new Color(0.49f, 0.99f, 0f);
        } 
        else if (color == "yellow") 
        {
            pointText.color = new Color(1.0f, 0.84f, 0f);
        }
        else if (color == "gray")
        {
            pointText.color = new Color(0.75f, 0.75f, 0.75f);
        }
        else if (color == "orange")
        {
            pointText.color = new Color(1.0f, 0.55f, 0f);
        }
        else if (color == "red")
        {
            pointText.color = new Color(1.0f, 0.27f, 0f);
        }
        else if (color == "magenta")
        {
            pointText.color = Color.magenta;
        }
        else if (color == "ice")
        {
            pointText.color = new Color(0.67f, 0.82f, 0.97f);
        }
        pointText.text = text;
    }

}
