using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class Guido_Controller : MonoBehaviour
{
    [SerializeField] private float guidoSpeed = 10f;
    [SerializeField] private bool canMove;
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private TextMeshProUGUI text;

    private bool nearWheel;
    private bool isFocusingWheel;
    private Vector3 mousePos;
    private Vector3 desiredPosition;
    private Vector3 currentVelocity;
    private Transform guidoPos;
    private GameObject SelectedWheel;

    void Start()
    {
        guidoPos = GetComponent<Transform>();
    }

    void Update()
    {
        FollowMousePosition();
        WheelFocus();
        PrintKey();
    }


    public void FollowMousePosition()
    {
        if (canMove)
        {
            mousePos = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                desiredPosition = new Vector3(hit.point.x, guidoPos.position.y, guidoPos.position.z);
                guidoPos.position = Vector3.Lerp(guidoPos.position, desiredPosition, guidoSpeed / 100);
            }
        }
    }

        

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Wheel")
        {
            nearWheel = true;
            text.enabled = true;
            SelectedWheel = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wheel")
        {
            nearWheel = false;
            text.enabled = false;
        }
    }

    public void WheelFocus()
    {
        if(Mouse.current.press.ReadValue()>0 && nearWheel)
        {
            canMove = false;
            isFocusingWheel = true;
        }
        else
        {
            canMove = true;
            isFocusingWheel = false;
        }
    }

    public void PrintKey()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {

        }
    }
}
