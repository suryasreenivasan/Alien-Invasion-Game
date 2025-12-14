using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private BoxCollider2D boundaryCollider;
    public float moveSpeed;
    public Transform Ships;
    public float yThreshold;
    public PlayerController player;


    // Start is called before the first frame update
    void Start()
    {
        boundaryCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
 
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        Debug.Log("Current Position: " + transform.position);

        UpdateColliderBounds();

        if (boundaryCollider.bounds.min.y <= yThreshold)
        {
            if (player != null)
            {
                player.lives = 0;
                player.UpdateLivesUI();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision Detected with: " + collision.gameObject.name);

        if (collision.gameObject.tag == "boundary")
        {
            Debug.Log("Hit Boundary");

            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            moveSpeed *= -1;
        }
    }

    void UpdateColliderBounds()
    {
        
        Bounds newBounds = new Bounds(Vector3.zero, Vector3.zero);
        bool boundsInitialized = false;
               foreach (Transform ship in Ships)
        {
            if (ship.gameObject.activeSelf)
            {
                if (!boundsInitialized)
                {
                    newBounds = new Bounds(ship.position, Vector3.zero);
                    boundsInitialized = true;
                }
                else
                {
                    newBounds.Encapsulate(ship.position);
                }
            }
        }

        if (boundsInitialized)
        {
            boundaryCollider.size = newBounds.size;

            boundaryCollider.offset = newBounds.center - Ships.position;

            boundaryCollider.size += new Vector2(1f, 0); 
        }
        else
        {
            
            boundaryCollider.size = Vector2.zero;
            boundaryCollider.offset = Vector2.zero;
        }

        Debug.Log($"Updated Collider - Size: {boundaryCollider.size}, Offset: {boundaryCollider.offset}");
    }


}
