using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Animator gameManagerAnim;
    private int stepIndex;
    void Start()
    {
        gameManagerAnim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void NextAnimation()
    {
        gameManagerAnim.SetTrigger(stepIndex);
    }

    public void TriggerNextPhase()
    {

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
