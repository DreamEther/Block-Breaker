﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;

    //These are the values that the Color Sliders return
    float m_Red, m_Blue, m_Green;
    private static UnityEngine.Color blue;

    public Color(float m_Red, float m_Green, float m_Blue)
    {
        this.m_Red = m_Red;
        this.m_Green = m_Green;
        this.m_Blue = m_Blue;
    }

    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //Set the GameObject's Color quickly to a set Color (blue)
        m_SpriteRenderer.color = blue;
    }

    void OnGUI()
    {
        //Use the Sliders to manipulate the RGB component of Color
        //Use the Label to identify the Slider
        GUI.Label(new Rect(0, 30, 50, 30), "Red: ");
        //Use the Slider to change amount of red in the Color
        m_Red = GUI.HorizontalSlider(new Rect(35, 25, 200, 30), m_Red, 0, 1);

        //The Slider manipulates the amount of green in the GameObject
        GUI.Label(new Rect(0, 70, 50, 30), "Green: ");
        m_Green = GUI.HorizontalSlider(new Rect(35, 60, 200, 30), m_Green, 0, 1);

        //This Slider decides the amount of blue in the GameObject
        GUI.Label(new Rect(0, 105, 50, 30), "Blue: ");
        m_Blue = GUI.HorizontalSlider(new Rect(35, 95, 200, 30), m_Blue, 0, 1);

        //Set the Color to the values gained from the Sliders
        m_NewColor = new Color(m_Red, m_Green, m_Blue);

        //Set the SpriteRenderer to the Color defined by the Sliders
        m_SpriteRenderer.color = m_NewColor;
    }

    public static implicit operator UnityEngine.Color(Color v)
    {
        throw new NotImplementedException();
    }
}