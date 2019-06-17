using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rig2D;

    [SerializeField]
    private float moveSpeed = 10;

    private void Awake()
    {
        rig2D= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //adding movement speed to the ball
        rig2D.velocity = rig2D.velocity.normalized * moveSpeed;
    }
}
