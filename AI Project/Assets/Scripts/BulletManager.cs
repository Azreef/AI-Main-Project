using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    GameObject slingshotObject; 
    
    //DESTROY THE BULLET
    void DestroyBullet()
    {
        Destroy(gameObject);
    }

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

            Debug.Log("BOOST");
        }
    }

    //DETECT COLLISION
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //COLLIDE WITH ENEMY
        if (collision.gameObject.tag == "enemy")
        {
            //explosion.Play();
            Destroy(gameObject);
            Debug.Log("HIT");
        }
    }


    void Start()
    {
        slingshotObject = GameObject.FindWithTag("slingshot");
    }
    void Update()
    {
        Debug.Log(slingshotObject.GetComponent<Slingshot>().getBulletIsExist());
        if((!slingshotObject.GetComponent<Slingshot>().getBulletIsExist()))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Lalu");
                Destroy(gameObject);
            }
        }
            
       
    }
}
