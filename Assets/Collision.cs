using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private PointSpawning obj;
    
    void Start()
    {
        obj = GameObject.Find("points").GetComponent<PointSpawning>();
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Player") {
            Debug.Log("Name" + other.gameObject.name);
            obj.point = false;
            Destroy(gameObject); //dhushhh

            Vector3 playerScale = other.gameObject.transform.localScale;  //bushhhh
            playerScale = new Vector3(playerScale.x * 1.02f, playerScale.y * 1.02f, playerScale.z * 1.02f);
            other.gameObject.transform.localScale = playerScale;

            float playerMass = other.gameObject.GetComponent<Rigidbody>().mass;
            playerMass *= 1.5f;
            other.gameObject.GetComponent<Rigidbody>().mass = playerMass;
            other.gameObject.GetComponent<count>().pointsCollected++;
        }
       
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 1.5f, 0));
    }
}
