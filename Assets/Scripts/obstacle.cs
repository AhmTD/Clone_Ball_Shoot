using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class obstacle : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    bool buttonPressed;
    public GameObject _obstacle;
    [SerializeField] private float turn;
    [SerializeField] private string direction;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       buttonPressed=false;
    }

    private void Update()
    {
        ButtonoPressed();
    }

    private void ButtonoPressed()
    {
        if (buttonPressed)
        {
            if (direction==("left"))
            {
                _obstacle.transform.Rotate(0, turn * Time.deltaTime, 0, Space.Self);
            }
            else
            {
                _obstacle.transform.Rotate(0, -turn * Time.deltaTime, 0, Space.Self);
            }
        }
        
    }

}
