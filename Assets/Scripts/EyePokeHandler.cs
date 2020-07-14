/**
    @file EyePokeHandler.cs
    @brief Handles poke events.
    @details Handles everything that has to be done when the eyes are poked.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @brief Handles poke events
    @details Handles eyelids, mouth and sound related to when the eyes are poked. Not connected to JAVA code.
 */
public class EyePokeHandler : MonoBehaviour {

    /**
        @brief AudioSource object
        @details Instance of the AudioSource class. Holds an AudioClip object and settings on how to run it etc.
    */
    private AudioSource audioSource;

    /**
        @brief AudioClip object
        @details Instance of the AudioClip class. Holds an audio clip.
    */
    private AudioClip audioClip;

    /**
        @brief MouthController object
        @details Instance of the custom MouthController class. Handles mouth animations and transitions.
    */
    private MouthController mouthController;
    
    /**
        @brief EyelidController object
        @details Instance of the custom EyelidController class. Handles eyelid animations and transitions.
    */
    private EyelidController eyelidController;

    /**
        @brief Holds eyepoke enabled state
        @details Boolean which holds the status on whether or not poking is enabled.
    */
    public bool EYE_POKE_ENABLED;

    /**
        @brief Called before the first frame update
        @details
        @li Runs once
        @li Fetches a reference to AudioSource instance attached to Unity object "ouch_zone" in the Unity environment
        @li Locates a reference to the MouthController instance already present in the Unity environment
        @li Locates a reference to the EyelidController instance already present in the Unity environment
        @li Extracts the audioClip fed to the AudioSource instance of the Unity object "ouch_zone" in the Unity environment
        @li sets pokes to be enabled
     */
    void Start() {
        audioSource = GetComponent<AudioSource>();
        mouthController = FindObjectOfType<MouthController>();
        eyelidController = FindObjectOfType<EyelidController>();
        audioClip = audioSource.clip;

        EYE_POKE_ENABLED = true;
    }

    /**
        @brief Called once per frame
        @details
        @li Loops
        @li Detects a touch and checks if poking is enabled.
        @li If the touch is within the specified poke zone
            @li an audio plays
            @li the mouth moves
            @li the eyes blink
        @li Sets up a time delayed call (in seconds equal to the length of the audioClip) to StopMouthMoving() 
    */
    void Update() {
        if ((EYE_POKE_ENABLED) && (Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began)) {
            Debug.Log("Touching");

            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null) {
                Debug.Log(hit.collider.name);
                // audio plays //
                audioSource.Play();
                // mouth moves and stops moving after audio ends //
                mouthController.SetSpeaking("START");
                Invoke("StopMouthMoving", audioClip.length);
                // eyes blink //
                eyelidController.ForcedBlink();
            }
        }
    }


    /**
        @brief Sets mouth back to what it was doing
        @details Called by Update(). Sets "emotion" integer of the "mouth" animator controller STOP.
     */
    void StopMouthMoving() {
    mouthController.SetSpeaking("STOP");
    }

    /**
        @brief Toggles poking between enabled/or disabled
        @details 
        @li Called from JAVA
        @li Changes the value of EYE_POKE_ENABLED enabling or disabling a poke event response.
        @param state TRUE or FALSE
     */
    void SetEyePokeEnabledState(string state) {
        switch (state.ToUpper()) {
            case "TRUE":
                EYE_POKE_ENABLED = true;
                break;
            case "FALSE":
                EYE_POKE_ENABLED = false;
                break;
        }
    }
}