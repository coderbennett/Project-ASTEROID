using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingTextController : MonoBehaviour {
    private static floatingTextScript popupText;
    private static GameObject canvas;

    public static void Initialize()
    {
        //find the canvas in the scene to put the floating text onto
        canvas = GameObject.Find("Canvas");
        //find the popuptext prefab within the resources folder
        popupText = Resources.Load<floatingTextScript>("Prefabs/PopupTextParent");
    }

    public static void CreateFloatingText(string text, Transform location, bool miningIncrease, string color)
    {
        //use the initialize method
        Initialize();
        //create an instance of the floating text script as the popupText parent prefab object
        floatingTextScript instance = Instantiate(popupText);
        //set the text of instance to the text, boolean and color variables being passed from the script calling this method
        instance.SetText(text, miningIncrease, color);
        //set the screen position of the location provided in relation to the world, rather than in relation to the parent
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);
        //set the instance as a child of the canvas
        instance.transform.SetParent(canvas.transform, false);
        //set the screen position to the instance position
        instance.transform.position = screenPosition;
    }
}
