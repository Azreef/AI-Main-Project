using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    GameObject slingshotObject; 
      
    //DETECT COLLIDE
    void OnTriggerEnter2D(Collider2D collide)
    {
        //COLLIDE WITH BOOSTER
        if (collide.gameObject.tag == "booster")
        {
            float rotationZ = collide.transform.rotation.eulerAngles.z;

            gameObject.GetComponent<Rigidbody2D>().AddForce(-gameObject.GetComponent<Rigidbody2D>().velocity, ForceMode2D.Impulse);
            Vector2 force = Quaternion.Euler(0f, 0f, rotationZ) * Vector2.right * 30;

            gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);

            FindAnyObjectByType<SoundManager>().Play("boostSound");
        }
    }

    //DETECT COLLISION
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //COLLIDE WITH ENEMY
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
        else
        {
            FindAnyObjectByType<SoundManager>().Play("bounceSound");
        }
    }


    void Start()
    {
        slingshotObject = GameObject.FindWithTag("slingshot");
    }
    void Update()
    {
        if((!slingshotObject.GetComponent<Slingshot>().getBulletIsExist()))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {  
                Destroy(gameObject);
            }
        }
            
       
    }
}
