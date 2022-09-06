using UnityEngine;
public class VehicleController : MonoBehaviour
{
    public int forwardSpeed;
    Rigidbody vehicleRb;
    private void Awake()
    {
        vehicleRb = GetComponent<Rigidbody>();
    }
    public virtual void ForwardVehicle() //POLYMORPHISM
    {
        float forward = Input.GetAxis("Vertical") * Time.deltaTime * forwardSpeed;
        vehicleRb.velocity = forward * transform.forward;
    }
}