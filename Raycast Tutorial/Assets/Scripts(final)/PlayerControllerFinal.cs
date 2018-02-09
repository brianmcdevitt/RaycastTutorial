using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFinal : MonoBehaviour {

    public float movementSpeed;
    public float rotationSpeed;
    public Transform explosion;

    private void Update() {

        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;

        transform.Translate(0, 0, moveVertical);
        transform.Rotate(0, moveHorizontal, 0);

    }

    private void FixedUpdate() {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10f))
        {
            Debug.Log("hit " + hit.collider.gameObject.name);

            if (hit.collider.tag == "evil_cylinder")
            {
                Destroy(hit.collider.gameObject);
                Transform explosionClone = Instantiate(explosion, hit.collider.transform.position, hit.collider.transform.rotation);
                Destroy(explosionClone.gameObject, 3);
            }
        }

        Debug.DrawRay(transform.position, transform.forward * 10f, Color.black);

    }
}
