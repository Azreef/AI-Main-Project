using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    void DestroyBullet()
    {
        Destroy(gameObject);
        Debug.Log("Spawn");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
       
    }


    void OnTriggerEnter2D(Collider2D collide)
    {
        if(collide.gameObject.tag == "booster")
        {
            float rotationZ = collide.transform.rotation.eulerAngles.z;

            gameObject.GetComponent<Rigidbody2D>().AddForce(-gameObject.GetComponent<Rigidbody2D>().velocity, ForceMode2D.Impulse);
            Vector2 force = Quaternion.Euler(0f, 0f, rotationZ) * Vector2.right * 20;

            gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);

            Debug.Log("BOOST");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }

       
    }
}
