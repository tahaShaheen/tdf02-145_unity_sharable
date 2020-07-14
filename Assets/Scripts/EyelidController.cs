/**
    @file EyelidController.cs
    @brief Handles eyelids.
    @details Contains code pertaining to eyelids, their animations and their transitions.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @brief Controls the eyelids
    @details Handles eyelids and their animations
 */
public class EyelidController : MonoBehaviour
{

    /**
        @brief Animator object
        @details Instance of the Animator class. Holds an animator controller which in turn holds animations and handles the switches between them. 
    */
    private Animator animator;

    /**
        @brief Called before the first frame update
        @details
        @li Runs once
        @li Fetches a reference to the Animator instance attached to the Unity object "eyelids" in the Unity environment
     */
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    /**
        @brief Called once per frame
        @details
        @li Loops
        @li Is empty here
    */
    void Update()
    {
    }

    /**
        @brief Blinks if poked
        @details 
        @li The "eyelids" animator controller fed to the Animator instance attached to the Unity object "eyelids" has its intgers poke and goToSleep to FALSE when it starts
        @li This runs the "blinking" animation on a loop
        @li When a touch event is registered by the EyePokeHandler class it calls ForcedBlink()
        @li The "poke" integer of the "eyelids" animator controller gets set to FALSE. This makes sure a "blink" animation can happen. If one is already happening, it gets cancelled.
        @li The "blink" integer of the "eyelids" animator controller gets set to TRUE trigerring a "poke" animation.
        @li Sets up a time delayed call (in seconds) to SetPokeFalse() 
     */
    public void ForcedBlink()
    {
        animator.SetBool("poke", false);
        animator.SetBool("poke", true);
        //because the forced_poke animation has an exit time we just need to make sure the boolean goes back to false so the animation isn't triggered again //
        Invoke("SetPokeFalse", 1);
    }

    /**
        @brief Sets "poke" to FALSE
        @details Called by ForcedBlink(). Sets "poke" integer of "eyelids" animator controller to FALSE
     */
    private void SetPokeFalse()
    {
        animator.SetBool("poke", false);
    }

    /**
        @brief Triggers sleep animation
        @details 
        @li Called from JAVA code. 
        @li Triggers sleep animation by setting "goToSleep" integer of the "eyelids" animator controller to TRUE
        @li Sets up a time delayed call (in seconds) to SetGoToSleepFalse() 
     */
    public void GoToSleep()
    {
        //This function is called by the Andoird code
        animator.SetBool("goToSleep", true);
        Invoke("SetGoToSleepFalse", 5);
    }

    /**
        @brief Sets "poke" to FALSE
        @details Called by GoToSleep(). Sets "goToSleep" integer of "eyelids" animator controller to FALSE
     */
    private void SetGoToSleepFalse()
    {
        animator.SetBool("goToSleep", false);
    }
}
