using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)   // in english: when a trigger event happens in relation to the LoseCollider...
    {
        SceneManager.LoadScene("Game Over");            // Game Over is a hard reference to our scene in Unity. It has to be exactly the same or it won't work.
    }
}
