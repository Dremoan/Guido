using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Guido_Controller : MonoBehaviour
{
    [SerializeField] private float guidoSpeed = 10f;
    [SerializeField] private bool enableGame;
    [SerializeField] private CinemachineVirtualCamera gameCam;
    private Vector3 mousePos;
    private Vector3 desiredPosition;
    private Vector3 currentVelocity;
    private Transform guidoPos;

    // Start is called before the first frame update
    void Start()
    {
        guidoPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }


    public void FollowMousePosition()
    {
        if (enableGame)
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

}
