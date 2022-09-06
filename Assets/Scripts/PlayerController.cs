using UnityEngine;
using UnityEngine.UI;
public class PlayerController : VehicleController
{
    [SerializeField] int rotateSpeed;
    [SerializeField] Text endLevelText;
    static int health = 1;
    public static int Health  //ENCAPSULATION
    {
        set { health = value; }
        get { return health; }
    }
    private void FixedUpdate()
    {
        ForwardVehicle();
        RotateVehicle(); //ABSTRACTION
    }
    public void RotateVehicle()
    {
        float rotation = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
        transform.Rotate(Vector3.up * rotation);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EndLevel"))
        {
            EndLevel();
        }
    }
    public void EndLevel()
    {
        endLevelText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}