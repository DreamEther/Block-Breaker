using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float xMin = 1f;
    [SerializeField] float xMax = 15f;


    //cached references
    GameSession theGameSession;
    Ball theBall;


    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    
    // Update is called once per frame
    void Update()                                 // using Update because as the paddle moves we need to update the frames. 
    { 
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);    // we can also use mousePosInUnits which is determined by our mouse movement while the paddle stays at the same y position no matter what.
        paddlePosition.x = Mathf.Clamp(GetXPos(), xMin, xMax);
        transform.position = paddlePosition;                                        // referring to the Transform component in Unity
    }                                                                                 // track of the position of our mouse on the x and y axis as we move it about. Writing .x will only track the x position.
                                                                                    // Screen.width gives the position of our mouse as a percentage of the width of the screen.

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled()) // using cached references so that we don't keep finding the game object every frame, since GetXPos is being called in Update 
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
    
}
