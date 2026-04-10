using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float desired_acceleration_x;
    private float desired_acceleration_z;
    public float impulse;
    public float turnrate;

    public CheckpointController target;
    void Start()
    {
        desired_acceleration_x = 0;
        desired_acceleration_z = 0;
    }

    // Update is called once per frame
    void Update()
    {

        float dx = (Mouse.current.position.x.value - Screen.width / 2) / turnrate; // this is very sensitive (was originally 200)
        // how far the mouse is to the right/left of center of screen, then divided to make it a managable value
    
        if (Mathf.Abs(dx) > 0.01f)
        {
            transform.Rotate(0, dx, 0);
        }

        GetComponent<Rigidbody>().AddRelativeForce(desired_acceleration_x*impulse, 0, desired_acceleration_z*impulse); // force defined in Newtons
        // the original 5 was fairly fast
    }   

    void OnMove(InputValue action)
    {
        var movement = action.Get<Vector2>();
        desired_acceleration_x = movement.y;
        desired_acceleration_z = -movement.x;
    }
}
