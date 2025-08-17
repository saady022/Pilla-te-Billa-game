using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class count : MonoBehaviour
{
    Rigidbody gameObject;
    public float speed;
    public string playerName;
    public GameObject chapalObject;
    bool chappalReady = true;
    public int pointsCollected = 0;
    Vector3 prevPos;
    Vector3 currPos;
    Vector3 dir;
    public Material lal;
    public Material blue;
    float waitT = 1.0f;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("0 people asked.");
        gameObject = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (pointsCollected >= 3)
        {
            chappalReady = true;
            pointsCollected = 0;
        }
    }

    void FixedUpdate()
    {   //movement
        float horizontalMovement = Input.GetAxis("Horizontal" + playerName);
        float verticalMovement = Input.GetAxis("Vertical" + playerName);
        gameObject.AddForce(new Vector3(horizontalMovement * speed, -1f, verticalMovement * speed), ForceMode.VelocityChange  );
        //Chappal
        currPos = transform.position;
        dir = new Vector3(currPos.x - prevPos.x, currPos.y - prevPos.y, currPos.z - prevPos.z);

        


        if ((Input.GetAxisRaw("Fire" + playerName) == 1) && chappalReady)
        {

            if (playerName == "B")
            {
                for (int i = 0; i <= 3; i++)
                {
                    chapalObject.transform.GetChild(i).GetComponent<MeshRenderer>().material = lal;
                }
            }
            if (playerName == "A")
            {
                for (int i = 0; i <= 3; i++)
                {
                    chapalObject.transform.GetChild(i).GetComponent<MeshRenderer>().material = blue;
                }
            }
            Vector3 unitDir = dir.normalized;
            Vector3 newDir = transform.position + (unitDir * 5);
            Vector2 jutiPosition = newDir;
            jutiPosition.y = 4;
            GameObject juti = Instantiate(chapalObject, newDir, Quaternion.Euler(0, 0, 90));
            juti.GetComponent<Rigidbody>().mass += gameObject.GetComponent<Rigidbody>().mass*83;
            Vector3 forceToApply = unitDir * 200;
            forceToApply.y = 0;

            juti.GetComponent<Rigidbody>().AddForce(forceToApply, ForceMode.VelocityChange);
            chappalReady = false;
            StartCoroutine(DestroyJuti(juti));

            

        }
        if (transform.position.y <= -5f)
        {
            gameOver.SetActive(true);
        }
        prevPos = transform.position;
    }
    private IEnumerator DestroyJuti( GameObject juti)
    {
        yield return new WaitForSeconds(waitT);
        Destroy(juti);
    }
}
