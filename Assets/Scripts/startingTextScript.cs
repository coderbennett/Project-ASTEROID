using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startingTextScript : MonoBehaviour
{
    public Text text;
    public float time = 10f;
    public bool first;

    // Start is called before the first frame update
    void Start()
    {
        if (first)
        {
            Invoke("setInvisible", time);
        } else
        {
            setInvisible();
            Invoke("setVisible", time);
            Invoke("setInvisible", (time * 2f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setInvisible ()
    {
        text.color = new Color(1f, 1f, 1f, 0f);
    }

    void setVisible()
    {
        text.color = new Color(1f, 1f, 1f, 1f);
    }
}
