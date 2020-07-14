/**
    @file MouthController.cs
    @brief Handles the mouth.
    @details Contains code pertaining to the mouth, its animations and its transitions.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @brief Controls the mouth
    @details Handles the mouth and its animations
 */
public class MouthController : MonoBehaviour {
    
    /**
        @brief Animator object
        @details Instance of the Animator class. Holds an animator controller which in turn holds animations and handles the switches between them. 
    */
    private Animator animator;

    /** 
        @var SAD
        @brief Universal integer for SAD
        @details Triggers mouth tied to the SAD look
        
        @var ANGRY
        @brief Universal integer for ANGRY
        @details Triggers mouth tied to the ANGRY look

        @var HAPPY
        @brief Universal integer for HAPPY
        @details Triggers mouth tied to the HAPPY look
        
        @var SURPRISED
        @brief Universal integer for SURPRISED
        @details Triggers mouth tied to the SURPRISED look

        @var SPEAKING
        @brief Universal integer for SPEAKING
        @details Triggers mouth tied to the SPEAKING look

        @var IDLE
        @brief Universal integer for IDLE
        @details Triggers mouth tied to the IDLE look
     */
    private readonly int SAD = 1, ANGRY = 1, HAPPY = 0, SURPRISED = 2, SPEAKING = 5, IDLE = 4;
    
    /**
        @brief Holds present emotion
        @details Contains the present emotional state.
     */
    int currentEmotion;  

    /**
        @brief Called before the first frame update
        @details
        @li Runs once
        @li Fetches a reference to the Animator instance attached to the Unity object "mouth" in the Unity environment
        @li sets default starting emotion
     */
     void Start() {
        animator = GetComponent<Animator>();
        currentEmotion = HAPPY; //just in case scenario
    }

    /**
        @brief Called once per frame
        @details
        @li Loops
        @li Is empty here
    */
    void Update() {
    }

    /**
        @brief Sets mouth emotion
        @details 
        @li Called from JAVA code
        @li Receives an emotion String
        @li Runs a switch case that updates the animator's integer named "emotion"
        @li That triggers an animation
        @param emotion Possible values: HAPPY, SAD, ANGRY, SURPRISED, IDLE, SPEAKING
    */
    public void SetEmotion(string emotion) {
        switch (emotion) {
            case "ANGRY":
                animator.SetInteger("emotion", ANGRY);
                break;
            case "SAD":
                animator.SetInteger("emotion", SAD);
                break;
            case "HAPPY":
                animator.SetInteger("emotion", HAPPY);
                break;
            case "SURPRISED":
                animator.SetInteger("emotion", SURPRISED);
                break;
            case "IDLE":
                animator.SetInteger("emotion", IDLE);
                break;
        }
    }

    /**
        @brief Handles mouth movement in SPEAKING emotion
        @details 
        @li Called from JAVA code
        @li Receives a String pertaining to whether the mouth should speaking or not speaking
        @li Saves the current emotion value unless it is speaking. This prevents a speaking loop.
        @li Updates the animator's integer named "emotion" to SPEAKING. That triggers an animation.
        @li Once it receives a STOP instruction from JAVA, it sets the "emotion" value back to what it was before it was set to SPEAKING.
        @param speaking Possible values: START and STOP
     */
    public void SetSpeaking(string speaking) {
        
        switch (speaking) {
            case "START":
                // save previous mouth state //
                if(animator.GetInteger("emotion") != SPEAKING)
                    currentEmotion = animator.GetInteger("emotion");
                // set state to speaking //
                animator.SetInteger("emotion", SPEAKING);
                break;
            case "STOP":
                // reset mouth state after done speaking //
                animator.SetInteger("emotion", currentEmotion);
                break;
        }

    }
}
