using UnityEngine;
using UnityEngine.UIElements;

public class AmmoCollection : MonoBehaviour
{
    public float ammoCount = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        if (Input.GetMouseButtonDown(0) && ammoCount > 0)
        {
            ammoCount -= 1;
            RaycastHit result;
            Physics.Raycast(ray, out result);

            GameObject g = result.collider.gameObject;
            if (g.name == "Target")
            {
                Animation a = g.transform.parent.GetComponent<Animation>();
                a.Play("LowerBridge");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "AmmoBox")
        {
            ammoCount += 20;
            other.gameObject.SetActive(false);
        }
    }
}
