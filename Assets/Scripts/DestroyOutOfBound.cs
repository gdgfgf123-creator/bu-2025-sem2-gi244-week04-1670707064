using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    public float xRunge = 10;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > -xRunge)
        {
            Destroy(gameObject,1f);
        }
        else if(transform.position.z < xRunge)
        {
            Destroy(gameObject,1f);
        }

    }
}
