using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    public string sensorName;
    [HideInInspector] public bool buttonDown = false;
    [HideInInspector] public int pressForce = 0;


    [SerializeField] private float durationLimit = 0.5f;
    [SerializeField] public Material pressedColor, defaultColor;
    [SerializeField] private bool keyboardMode;
    [SerializeField] private KeyCode key;
    [SerializeField] private GameController gc;

    private float buttonPressDuration = 0;
    private bool pressing, colorLocked, holding = false;

    void Start()
    {
        gameObject.GetComponent<Renderer>().material = defaultColor;
    }


    void Update()
    {
        if (keyboardMode)
            keyBoardInput();
 
        
        if (buttonDown)
            ChangeColor(pressedColor);
        else
            ChangeColor(defaultColor);

    }

    public void PressButton(int force)
    {
        colorLocked = (Time.time <= buttonPressDuration);
        pressing = (force >= 50);


        if (!colorLocked)
        {
            if (pressing && !holding)
            {
                pressForce = force;
                Debug.Log(pressForce);
                buttonDown = true;
                buttonPressDuration = (durationLimit + Time.time);
                holding = true;
            }
            else if (!pressing)
            {
                buttonDown = false;
                holding = false;
            }
            else
            {
                buttonDown = false; ;
            }
        }
        else
        {
            buttonDown = true;
            if (pressing)
                holding = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            Note note = other.gameObject.GetComponent<Note>();
            if (buttonDown)
            {
                gc.addScore(note.Hit(pressForce));
                
            }
                

        }
    }

    private void ChangeColor(Material material)
    {
        gameObject.GetComponent<Renderer>().material = material;
    }

    private void keyBoardInput()
    {
        if (Input.GetKey(key))
         {
             pressForce = 800;
             buttonDown = true;
         }
         else
         {
             pressForce = 6;
             buttonDown = false;
         }
    }
}

