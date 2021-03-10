using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class quitButtonScoreScript : MonoBehaviour
{
    public Text text;

    private bool isOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isOver)
        {
            text.color = new Color(1f, 1f, 1f, 1f);
        }

        if (!isOver)
        {
            text.color = new Color(0.75f, 0.75f, 0.75f, 1f);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && isOver)
        {
            SceneManager.LoadScene("Menu");
        }
    }

        public void OnMouseEnter()
    {
        isOver = true;
    }

    public void OnMouseExit()
    {
        isOver = false;
    }
}
