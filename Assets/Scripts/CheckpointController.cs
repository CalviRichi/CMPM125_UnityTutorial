using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CheckpointController next;

    public MeshRenderer left, right;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) // when something collides
    {
        //Debug.Log("trigger enter " + other.transform.name);
        VehicleController vehicle = other.gameObject.GetComponent<VehicleController>();
        if (vehicle != null) {
            if (vehicle.target == this)
            {
                vehicle.target = next;
                
                next.left.materials[0].color = Color.red;
                next.right.materials[0].color = Color.red;
                left.materials[0].color = Color.white;
                right.materials[0].color = Color.white;
            } 
        }
    }
}
