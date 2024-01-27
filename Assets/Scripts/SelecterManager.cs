using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecterManager : MonoBehaviour
{

    public Color PlayerColor1;
    public Color PlayerColor2;
    public Color PlayerColor3;
    public Color PlayerColor4;
    public Color PlayerColor5;
    public Color PlayerColor6;
    public Image Character;

    void Start()
    {
        Character.color = PlayerColor1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelecterCharacter_Red()
    {
        Character.color = PlayerColor1;
    }
    public void SelecterCharacter_Orange()
    {
        Character.color = PlayerColor2;
    }
    public void SelecterCharacter_Yellow()
    {
        Character.color = PlayerColor3;
    }
    public void SelecterCharacter_Green()
    {
        Character.color = PlayerColor4;
    }
    public void SelecterCharacter_LightBlue()
    {
        Character.color = PlayerColor5;
    }
    public void SelecterCharacter_Blue()
    {
        Character.color = PlayerColor6;
    }

}
