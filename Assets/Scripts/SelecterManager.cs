using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecterManager : MonoBehaviour
{
    public Image Character;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelecterCharacter_Red()
    {
        Character.color = Color.red;
    }
    public void SelecterCharacter_Green()
    {
        Character.color = Color.green;
    }
    public void SelecterCharacter_Blue()
    {
        Character.color = Color.blue;
    }
    public void SelecterCharacter_Yellow()
    {
        Character.color = Color.yellow;
    }
    public void SelecterCharacter_Pink()
    {
        Character.color = Color.magenta;
    }
    public void SelecterCharacter_Black()
    {
        Character.color = Color.black;
    }

}
