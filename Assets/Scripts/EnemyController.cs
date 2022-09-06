using UnityEngine;
public class EnemyController : VehicleController // INHERITANCE
{
    private void FixedUpdate()
    {
        ForwardVehicle();
    }
    public override void ForwardVehicle() // POLYMORPHISM
    {
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DealDamage();
        }
    }
    private void DealDamage()
    {
        PlayerController.Health = -1;
    }
}