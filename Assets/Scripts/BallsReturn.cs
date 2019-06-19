using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsReturn : MonoBehaviour
{
    private BallsLauncher ballLauncher;

    private void Awake()
    {
        ballLauncher = FindObjectOfType<BallsLauncher>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballLauncher.ReturnBall();
        collision.collider.gameObject.SetActive(false);
    }
}
