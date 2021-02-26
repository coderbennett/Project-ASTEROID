using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class floatingTextScript : MonoBehaviour {

    public Animator animator;
    private Text pointText;

    void OnEnable()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
        pointText = animator.GetComponent<Text>();
    }

    public void SetText(string text, Color color)
    {
        pointText.color = color;
        pointText.text = "+" + text;
    }

}
