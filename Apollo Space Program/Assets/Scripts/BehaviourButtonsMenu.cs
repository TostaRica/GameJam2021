using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BehaviourButtonsMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Text textButton;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //textButton.color = new Color(0, 255, 0); //Or however you do your color
        textButton.color = Color.black; //Or however you do your color
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //textButton.color = new Color(34, 33, 31); //Or however you do your color
        textButton.color = Color.green; //Or however you do your color
    }
}
