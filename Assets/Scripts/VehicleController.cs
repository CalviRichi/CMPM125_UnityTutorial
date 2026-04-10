using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UIElements;

public class VehicleController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float desired_acceleration_x;
    private float desired_acceleration_z;
    public float impulse;
    public float turnrate;

    public uint lapCount;

    private float starttime;
    private float raceStart;
    public TextMeshProUGUI timelbl;

    public CheckpointController target;
    void Start()
    {
        desired_acceleration_x = 0;
        desired_acceleration_z = 0;

        lapCount = 0;

        starttime = Time.time;
        raceStart = starttime;

        target.left.materials[0].color = Color.red;
        target.right.materials[0].color = Color.red;
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
        //timelbl.text = string.Format("Lap {} | Time: {0:F2} seconds\n" + 
        //"Total Time: {0:F2} seconds", lapCount, (Time.time - starttime), (Time.time - raceStart));
        timelbl.text = string.Format("Lap {0} | Time: {1:F2} seconds\n" + 
        "Total Time: {2:F2}", lapCount, (Time.time - starttime), (Time.time - raceStart));
    }   

    void OnMove(InputValue action)
    {
        var movement = action.Get<Vector2>();
        desired_acceleration_x = movement.x;
        desired_acceleration_z = movement.y;
    }

    public void UpdateLap()
    {
        if (lapCount++ == 0)
        {
            return;
        }
        starttime = Time.time;

    }
}
