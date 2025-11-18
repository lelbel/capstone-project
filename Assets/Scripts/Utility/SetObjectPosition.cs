using TMPro;
using UnityEngine;

public class SetObjectPosition : MonoBehaviour
{
    [SerializeField] private float xPos;
    [SerializeField] private float yPos;
    [SerializeField] private bool isHorizontallyCentered;
    [SerializeField] private bool isVerticallyCentered;
    private float xCenter = Screen.width * 0.5f;
    private float yCenter = Screen.height * 0.5f;

    void Start()
    {
        SetPosition(gameObject);
    }

    public void SetPosition(GameObject obj)
    {
        if (!isHorizontallyCentered && !isVerticallyCentered)
        {
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos);
            return;
        }

        if (isHorizontallyCentered && isVerticallyCentered)
        {
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(xCenter, yCenter);
            return;
        }

        else if (!isHorizontallyCentered && isVerticallyCentered)
        {
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yCenter);
            return;
        }

        else if (isHorizontallyCentered && !isVerticallyCentered)
        {
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(xCenter, yPos);
            return;
        }   
    }

    /*
    public enum UIType
    {
        MENUTITLE
    }

    [SerializeField] private UIType type;
    public float xPos;
    public float yPos;
    public bool isHorizontallyCentered;
    public bool isVerticallyCentered;
    [SerializeField] private float xCenter = Screen.width * 0.5f;
    [SerializeField] private float yCenter = Screen.height * 0.5f;

    void Start()
    {
        switch (type)
        {
            case UIType.MENUTITLE:
                SetPosition(gameObject.GetComponent<TMP_Text>());
                break;
        }
    }

    public void SetPosition(TMP_Text obj)
    {
        if (!isHorizontallyCentered && !isVerticallyCentered)
        {
            obj.rectTransform.anchoredPosition = new Vector2(xPos, yPos);
            return;
        }

        if (isHorizontallyCentered && isVerticallyCentered)
        {
            obj.rectTransform.anchoredPosition = new Vector2(xCenter, yCenter);
            return;
        }

        else if (!isHorizontallyCentered && isVerticallyCentered)
        {
            obj.rectTransform.anchoredPosition = new Vector2(xPos, yCenter);
            return;
        }

        else if (isHorizontallyCentered && !isVerticallyCentered)
        {
            obj.rectTransform.anchoredPosition = new Vector2(xCenter, yPos);
            return;
        }   
    }
    */
}