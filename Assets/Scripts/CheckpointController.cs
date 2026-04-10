using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) // when something collides
    {
        Debug.Log("trigger enter " + other.transform.name);
    }
}
