using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsLauncher : MonoBehaviour
{

    private Vector3 startDragPos;
    private Vector3 endDragPos;
    private BlockSpowner blockSpowner;
    private LaunchPreview launchPreview;
    private int ballsReady;
    private bool inputAvailable;

    private List<Ball> balls = new List<Ball>();

    [SerializeField]
    private Ball BallPref;
    
    private void Awake()
    {
        blockSpowner = FindObjectOfType<BlockSpowner>();
        launchPreview = GetComponent<LaunchPreview>();
        CreateBall();
        inputAvailable = true;
    }

    private void Update()
    {
        //this will set the Z position of the camera to 0
        Vector3 wordPos = Camera.main.ScreenToViewportPoint(Input.mousePosition) + Vector3.back * - 10;

        if (inputAvailable)
        {
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
    }

    private void CreateBall()
    {
        var ball = Instantiate(BallPref, this.transform.position, Quaternion.identity);
        balls.Add(ball);
        ballsReady++;
    }

    private void EndDrag()
    {
        StartCoroutine(LaunchBalls());
    }

    private IEnumerator LaunchBalls()
    {
        Vector3 direction = endDragPos - startDragPos;
        //changing the existing vector
        direction.Normalize();

        foreach (var ball in balls)
        {
            ball.transform.position = this.transform.position;
            ball.gameObject.SetActive(true);
            ball.GetComponent<Rigidbody2D>().AddForce(-direction);

            yield return new WaitForSeconds(0.1f);
        }
        ballsReady = 0;
        inputAvailable = false;
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

    public void ReturnBall()
    {
        ballsReady++;
        if (ballsReady == balls.Count)
        {
            blockSpowner.SpownRowOfBlocks();
            CreateBall();
            inputAvailable = true;
        }
    }

}
