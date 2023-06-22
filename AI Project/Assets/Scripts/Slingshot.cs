using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{

    [SerializeField] GameManager gameManager;

    public LineRenderer[] lineRenderers;
    public Transform[] stripPosition;
    public Transform center;
    public Transform idlePosition;

    public Vector3 currentPosition;

    public float maxLength;

    public float bottomBoundary;

    bool isMouseDown;
    bool bulletIsExist;


    // bawah ni untuk main character punya attributes
    public GameObject bulletPrefab;

    public float bulletPositionOffSet;
    Rigidbody2D bullet;
    Collider2D bulletCollider;

    public float force;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPosition[0].position);
        lineRenderers[1].SetPosition(0, stripPosition[1].position);


        CreateBullet();

        bulletIsExist = true;
    }

    void CreateBullet()
    {
        bullet = Instantiate(bulletPrefab).GetComponent<Rigidbody2D>();
        bulletCollider = bullet.GetComponent<Collider2D>();
        bulletCollider.enabled = false;

        bullet.isKinematic = true;
    }
    // Update is called once per frame

    void SpawnNewBullet()
    {
        if(!bulletIsExist && Input.GetKeyDown(KeyCode.Space))
        {
            CreateBullet();
            bulletIsExist = true;
        }
    }
    void Update()
    {
        if (isMouseDown )
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition - center.position, maxLength);

            currentPosition = ClampBoundary(currentPosition);
            SetStrips(currentPosition);

            if (bulletCollider)
            {
                bulletCollider.enabled = true;
            }
        }
        else
        {
            ResetStrips();
        }

        SpawnNewBullet();
        Debug.Log(bulletIsExist);
    }

    private void OnMouseDown()
    {
        if (bulletIsExist)
        {
            isMouseDown = true;
        }
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        Shoot();
    }

    void Shoot()
    {
        if(bulletIsExist)
        {
            bullet.isKinematic = false;
            Vector3 bulletForce = (currentPosition - center.position) * force * -1;
            bullet.velocity = bulletForce;

            bullet = null;
            bulletCollider = null;
        }
        

        bulletIsExist = false;

        gameManager.incrementScore();
    }

    void ResetStrips() // bila dh tarik, dia akan reset balik position getah hitam tu
    {
        currentPosition = idlePosition.position;
        SetStrips(currentPosition);
    }

    void SetStrips(Vector3 position) //initialize position default getah sebelum tarik
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);

        if (bullet)
        {
            Vector3 dir = position - center.position;
            bullet.transform.position = position + dir.normalized * bulletPositionOffSet;
            bullet.transform.right = -dir.normalized;
        }
    }

    Vector3 ClampBoundary(Vector3 vector)
    {
        vector.y = Mathf.Clamp(vector.y, bottomBoundary, 1000);
        return vector;
    }

}