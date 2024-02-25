using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void LoadLevel(string _name)
    {
        Application.LoadLevel(_name);
    }
}
