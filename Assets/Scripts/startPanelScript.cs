using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startPanelScript : MonoBehaviour
{
    public float time = 20f;
    public Image panel;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("setInvisible", time);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void setInvisible()
    {
        panel.color = new Color(1f, 1f, 1f, 0f);
    }
}
