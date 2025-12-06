using UnityEngine;

public class NPC1AnimationBlend : MonoBehaviour
{
    public Animator animator;
    public Transform[] waypoints;
    public float speed = 2f;
    public float rotationSpeed = 6f;
    public float reachDistance = 0.2f;
    public float waitTimeAtPoint = 1f;

    private int index = 0;
    private bool waiting = false;
    private float waitCounter = 0f;
    private Vector3 lastPosition;

    void Start()
    {
        if (waypoints.Length > 0)
            lastPosition = transform.position;
    }

    void Update()
    {
        if (waypoints.Length == 0) return;

if (waiting)
{
    animator.SetFloat("velocity", 0f);
    animator.SetFloat("moveX", 0f);
    animator.SetFloat("moveY", 0f);

    waitCounter += Time.deltaTime;
    if (waitCounter >= waitTimeAtPoint)
    {
        waiting = false;
        index = (index + 1) % waypoints.Length;
    }
    return;
}

        Transform target = waypoints[index];
        
        Vector3 moveDir = (target.position - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);


        if (moveDir != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, target.position) < reachDistance)
        {
            waiting = true;
            waitCounter = 0f;
        }
        Vector3 velocity = (transform.position - lastPosition) / Time.deltaTime;

        animator.SetFloat("velocity", velocity.magnitude);
        animator.SetFloat("moveX", transform.InverseTransformDirection(velocity).x);
        animator.SetFloat("moveY", transform.InverseTransformDirection(velocity).z);

        lastPosition = transform.position;
    }
}
