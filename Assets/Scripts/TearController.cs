/**
    @file TearController.cs
    @brief Handles the tear.
    @details Contains code pertaining to the tear.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @brief Controls the tear
    @details Handles the tear and its animation
 */
public class TearController : MonoBehaviour {
    
    /**
        @brief Animator object
        @details Instance of the Animator class. Holds an animator controller which in turn holds animations and handles the switches between them. 
    */
    private Animator animator;

    /** 
        @var SAD
        @brief Universal integer for SAD
        @details Triggers objects and animations tied to the SAD look
        
        @var NOT_SAD
        @brief Universal integer for NO EXPRESSION
        @details Triggers the tear to turn off
     */
    private readonly int SAD = 1, NOT_SAD = 0;
    
    /**
        @brief Called before the first frame update
        @details
        @li Runs once
        @li Fetches a reference to the Animator instance attached to the Unity object "tear" in the Unity environment
     */
    void Start(){
        animator = GetComponent<Animator>();
    }

    /**
        @brief Called once per frame
        @details
        @li Loops
        @li Is empty here
    */
    void Update(){
        
    }

    /**
        @brief Sets tear state
        @details 
        @li Called from JAVA code
        @li Receives an emotion String
        @li Runs a switch case that updates the animator's integer named "emotion"
        @li That triggers an animation
        @param emotion Possible values: HAPPY, SAD, ANGRY, SURPRISED, IDLE, SPEAKING
    */
    public void SetEmotion(string emotion){
        switch (emotion){

            case "SAD":
                animator.SetInteger("emotion", SAD);
                break;
            case "SPEAKING":
                // SPEAKING doesn't change the tear state //
                // This allows for teary speaking //
                break;
            default:
                animator.SetInteger("emotion", NOT_SAD);
                break;
        }
    }
}
