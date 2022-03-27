using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    Vector3 newPos;
    bool portal;
    bool goldenportal;
    private float timer = 0f;
    private float waitTime = 2f;
    


    // Start is called before the first frame update
    void Start()
    {
        goldenportal = false;
    }

    // Update is called once per frame
    void Update()
    {
        newPos = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f)).normalized;

        if (goldenportal == true)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
        }

        if (timer >= waitTime)
        {
            transform.position = newPos;
        }
        
    } 
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.name == "Portal")
        {
            Scale();           
        }
        Shrinker shrinker = other.transform.gameObject.GetComponent<Shrinker>();

        if (shrinker != null)
        {
            Debug.Log("Este objeto tiene componente Shrinker");
        }

        if (other.transform.gameObject.name == "Portal Dorado")
        {
            goldenportal = true;
        }
        
        GameObject otherObj = other.gameObject;
        Debug.Log("Este objeto es Trigger: " + otherObj);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.name == "Portal Dorado")
        {
            goldenportal = false;
        }       
    }
    private void Scale()
    {
        if (portal == true)
        {
            portal = false;
            transform.localScale = transform.localScale * 2;

        }
        else
        {
            portal = true;
            transform.localScale = transform.localScale / 2;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherObj = collision.gameObject;
        Debug.Log("Este objeto es Collision: " + otherObj);
    }

}
