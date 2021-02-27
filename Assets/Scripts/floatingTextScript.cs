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
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
        pointText = animator.GetComponent<Text>();
        random = Random.Range(0, 2);
        animator.SetInteger("random", random);
    }

    public void SetText(string text, bool miningIncrease, string color)
    {
        animator.SetBool("miningIncrease", miningIncrease);
        if(miningIncrease)
        {
            pointText.fontSize = 8;
        }

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
