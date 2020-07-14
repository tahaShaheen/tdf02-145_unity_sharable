/**
    @file EyebrowController.cs
    @brief Handles eyebrows.
    @details Contains code pertaining to eyebrows, their animations and their transitions.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @brief Controls the eyebrows
    @details Handles eyebrows and their animations
 */
public class EyebrowController : MonoBehaviour
{

    /**
        @brief Animator object
        @details Instance of the Animator class. Holds an animator controller which in turn holds animations and handles the switches between them. 
    */
    private Animator animator;

    /**
        @brief Universal integer for NO EXPRESSION
        @details Triggers eyebrows to turn off
     */
    private readonly int NO_EYEBROWS = 0;


    /** 
        @var ANGRY
        @brief Universal integer for ANGRY
        @details Triggers eyebrows tied to the ANGRY look
        
        @var SURPRISED
        @brief Universal integer for SURPRISED
        @details Triggers eyebrows tied to the SURPRISED look
     */
    private readonly int ANGRY = 3, SURPRISED = 2;

    /**
        @brief Called before the first frame update. Runs once.
        @details
        @li Fetches a reference to the Animator instance attached to the Unity object "eyebrows" in the Unity environment
     */
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    /**
        @brief Called once per frame. Loops.
        @details
        @li Is empty here
     */
    void Update()
    {
    }

    /**
        @brief Sets eyebrow emotion
        @details 
        @li Called from JAVA code
        @li Receives an emotion String
        @li Runs a switch case that updates the animator's integer named "emotion"
        @li That triggers an animation
        @param emotion Possible values: HAPPY, SAD, ANGRY, SURPRISED, IDLE, SPEAKING
     */
    public void SetEmotion(string emotion)
    {
        switch (emotion)
        {
            case "ANGRY":
                animator.SetInteger("emotion", ANGRY);
                break;
            case "SURPRISED":
                animator.SetInteger("emotion", SURPRISED);
                break;
            case "SPEAKING":
                // SPEAKING doesn't change the eyebrows state //
                // This allows for surprised speaking and angry speaking //
                break;
            default:
                // EVerything that doesn't need eyebrows goes here //
                animator.SetInteger("emotion", NO_EYEBROWS);
                break;
        }
    }
}

