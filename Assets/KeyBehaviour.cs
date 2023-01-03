using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyBehaviour : MonoBehaviour
{
    private string debug = "a";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            RandomizedKeys(5);
        }
    }

    public void RandomizedKeys(int difficultyNumber)
    {
        string[] keyArrays = new string[difficultyNumber];

        for (int i = 0; i < keyArrays.Length -1; i++)
        {
            keyArrays[i] = "A" + debug;
        }

    }
}
