using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchControl : MonoBehaviour
{
    static public TouchControl Instance()
    {
        return instance;
    }

    static private TouchControl instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        DisableUIButton("Interact");
    }

    public bool DisableUIButton(string button)
    {
        return SetButtonActive(button, false);
    }

    public bool EnableUIButton(string button)
    {
        return SetButtonActive(button, true);
    }

    private bool SetButtonActive(string button, bool active)
    {
        var child = transform.FindChild(button);
        if (child == null)
            return false;

        var images = child.GetComponents<Image>();
        var handler = child.GetComponent<UnityStandardAssets.CrossPlatformInput.ButtonHandler>();
        foreach (var img in images)
        {
            img.enabled = active;
        }
        if (handler)
        {
            handler.enabled = active;
        }
        return true;
    }
}
