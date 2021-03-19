using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("speed")] [SerializeField]
    private float _speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * _speed * verticalInput);

        // setting up vertical boundaries for player position
        // y.position over 0?
        if (transform.position.y > 0)
        {
            //set to 0
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        // y.position hits the ground (here -4.9)?
        else if (transform.position.y < -4.9f)
        {
            //keep it there
            transform.position = new Vector3(transform.position.x, -4.9f, 0);
        }

        //horizontal check
        //x.position left
        if (transform.position.x < -9.2f)
        {
            //set left boundary at -9.2
            transform.position = new Vector3(-9.2f, transform.position.y, 0);
        }
        //x.position right
        else if (transform.position.x > 9.2f)
        {
            //set left boundary at -9.2
            transform.position = new Vector3(9.2f, transform.position.y, 0);
        }
    }
}
