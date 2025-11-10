using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class UIObject
{
    public float xPos;
    public float yPos;
    public bool isHorizontallyCentered;
    public bool isVerticallyCentered;

}

/*
public enum UIType
    {
        MENUTITLE,
        MENUBUTTON
    }
    
    public UIType type;
    public GameObject obj;
    public string text;
    public float xPos;
    public float yPos;
    public TMP_FontAsset font;
    public int fontSize;
    public bool isHorizontallyCentered;
    public bool isVerticallyCentered;
    public Color color;
    private float xCenter = Screen.width * 0.5f;
    private float yCenter = Screen.height * 0.5f;


    public UIType GetUIType()
    {
        return type;
    }

    public GameObject GetObject()
    {
        return obj;
    }

    public void MenuTitle()
    {
        //  check that object is a TMP_Text object
        if (type == UIType.MENUTITLE && obj.GetComponent<TMP_Text>() != null)
        {
            TMP_Text menuTitle = obj.GetComponent<TMP_Text>();

            SetPosition(menuTitle);

            SetText(menuTitle);

            
        }

        else
        {
            Debug.Log("UIObject has incompatible UIType or is missing a required component");
        }

    }

    public void SetPosition(TMP_Text obj)
    {
        
    }

    public void SetText(TMP_Text obj)
    {
        if (text != null)
        {
            obj.text = text;

            if (font != null && fontSize > 0)
            {
                obj.font = font;
                obj.fontSize = fontSize;
            }

            else
            {
                Debug.Log("Missing font or font size");
            }
        }

        else
        {
            Debug.Log("Missing text");
        }
    }*/