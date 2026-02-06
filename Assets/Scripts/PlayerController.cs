using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float xRunge = 10;
    private InputAction moveAction;
    private InputAction shootAction;
    public GameObject foodPrafab;
    
    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        
        var hInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(hInput * speed * Time.deltaTime * Vector3.right);
        if(transform.position.x < -xRunge)
        {
            transform.position = new Vector3 (-xRunge,
                transform.position.y,
                transform.position.z);
        }
        else if (transform.position.x > xRunge)
        {
            transform.position = new Vector3(xRunge,
                transform.position.y,
                transform.position.z);
        }
        if(shootAction.triggered)
        {
            Instantiate(foodPrafab , transform.position, Quaternion.identity);
        }    
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, 1f);
        //Gizmos.color = Color.orange;
        //Gizmos.DrawLine(transform.position, Camera.main.transform.position);

        Vector3 left = new Vector3(-xRunge,
            transform.position.y,
            transform.position.z);
        Vector3 right = new Vector3(xRunge,
            transform.position.y,
            transform.position.z);
        Gizmos.DrawLine(left, right);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(left, 0.5f);
        Gizmos.DrawSphere(right, 0.5f);

    }
}
