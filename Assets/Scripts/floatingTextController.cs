using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingTextController : MonoBehaviour {
    private static floatingTextScript popupText;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        popupText = Resources.Load<floatingTextScript>("Prefabs/PopupTextParent");
    }

    public static void CreateFloatingText(string text, Transform location, bool miningIncrease, string color)
    {
        Initialize();
        floatingTextScript instance = Instantiate(popupText);
        instance.SetText(text, miningIncrease, color);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPosition;
    }
}
