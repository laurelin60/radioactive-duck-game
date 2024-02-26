using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenFlash : MonoBehaviour
{
    public Image flashImage;

    void Start()
    {
        HideGreen();
        GameManager.OnDuckShot = Flash;
    }

    public void Flash()
    {
        flashImage.enabled = true;
        Invoke("HideGreen", 0.2f);
    }

    void HideGreen()
    {
        flashImage.enabled = false;
    }
}
