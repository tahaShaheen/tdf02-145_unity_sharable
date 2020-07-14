/**
    @file BackgroundColorController.cs
    @brief Handles background color.
    @details Contains code pertaining to facial color and how it changes.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @brief Controls the background color
    @details Handles facial color and deals with the transition from one to the other
 */
public class BackgroundColorController : MonoBehaviour
{

    /**
        @brief Camera object
        @details Instance of the Camera class through which we view the "scene"
     */
    private Camera cam;

    /**
        @brief Color before transition
        @details Contains the color the background must be before transition
     */
    public Color32 startColor;

    /**
        @brief Color after transition
        @details Contains the color the background must be after transition
     */
    public Color32 endColor;

    /**
        @brief Contains the default orange color
     */
    public Color32 defaultColor = new Color32(255, 180, 0, 255);

    /**
        @brief Speed with which the color transition occurs
     */
    public float speed = 1.0F;

    /**
        @brief Stores time at the start of transition
     */
    private float startTime;

    /**
        @brief Called before the first frame update
        @details
        @li Runs once
        @li Fetches a reference to Camera instance attached to Unity object "Main Camera" in the Unity environment
        @li Saves current time
        @li Puts defaultColor into startColor and endColor so the first transition is not noticeable
     */
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        startTime = Time.time;
        startColor = defaultColor;
        endColor = defaultColor;
    }

    /**
        @brief Called once per frame
        @details
        @li Loops
        @li Compares time and multiplies it by speed constant. The value of the float t only grows.
        @li Lerps from startColor to endColor ad infinitum
     */
    void Update()
    {
        // changes from first color to second color through a gradient //
        float t = (Time.time - startTime) * speed;
        GetComponent<Camera>().backgroundColor = Color32.Lerp(startColor, endColor, t);
    }

    /**
        @brief Changes value of endColor
        @details 
        @li Called from JAVA code
        @li Receives hexcode of the color as a string
        @li Breaks it into individual RGB values and converts values into integers
        @li Updates the value of endColor. Opacity is max (255).
        @param hexColor Color in hexadecimal 
     */
    public void ChangeBackgroundColor(string hexColor)
    {

        // fetches current color //
        startColor = Camera.main.backgroundColor;

        // converting from hexadecimal color value to RGB //
        int red, green, blue;
        red = int.Parse(hexColor.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        green = int.Parse(hexColor.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        blue = int.Parse(hexColor.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        endColor = new Color32((byte)red, (byte)green, (byte)blue, 255);

        // reseting start time //
        startTime = Time.time;
    }

}

