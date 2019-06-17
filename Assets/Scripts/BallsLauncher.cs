using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsLauncher : MonoBehaviour
{

    private Vector3 startDragPos;
    private Vector3 endDragPos;
    private LaunchPreview launchPreview;

    [SerializeField]
    private GameObject BallPref;

    private void Awake()
    {
        launchPreview = GetComponent<LaunchPreview>();
    }

    private void Update()
    {
        //this will set the Z position of the camera to 0
        Vector3 wordPos = Camera.main.ScreenToViewportPoint(Input.mousePosition) + Vector3.back * -10;

        if (Input.GetMouseButtonDown(0))
        {
            StartDrag(wordPos);
        }
        else if (Input.GetMouseButton(0))
        {
            ContinueDrag(wordPos);
        }
        else if (Input.GetMouseButtonUp(0))
            {
            EndDrag();
        }
    }

    private void EndDrag()
    {
        Vector3 direction = endDragPos - startDragPos;
        //changing the existing vector
        direction.Normalize();

        //Instantiating a ball and adding force to it 
        var ball = Instantiate(BallPref, transform.position, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().AddForce(-direction);
    }

    private void ContinueDrag(Vector3 wordPos)
    {
        //cash the end pos
        endDragPos = wordPos;

        Vector3 dir = endDragPos - startDragPos;
        launchPreview.SetStartPoint(this.transform.position - dir);
    }

    private void StartDrag(Vector3 wordPos)
    {
        //cаsh the start pos
        startDragPos = wordPos;

        launchPreview.SetStartPoint(this.transform.position);
    }
}
