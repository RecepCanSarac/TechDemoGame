using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;
    public float maxRotationAngle = 30f;

    public Rigidbody rb;
    public Transform shipTransform;
    private Quaternion initialRotation;

    void Start()
    {
        shipTransform = rb.transform;
        initialRotation = shipTransform.rotation;
    }

    void FixedUpdate()
    {
        if (rb == null || shipTransform == null)
        {
            Debug.LogError("Rigidbody veya Transform bulunamadý!");
            return;
        }

        float verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(shipTransform.right * 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(shipTransform.right * verticalInput * moveSpeed * 2);
        }
        else
        {
            rb.AddForce(shipTransform.right * moveSpeed);
        }
       

        float horizontalInput = Input.GetAxis("Horizontal");
        float currentAngle = Quaternion.Angle(initialRotation, shipTransform.rotation);
        if (currentAngle < maxRotationAngle || (horizontalInput * rb.angularVelocity.y < 0))
        {
            rb.AddTorque(Vector3.up * horizontalInput * rotationSpeed);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
    }


}
