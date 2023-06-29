using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Slingshot : MonoBehaviour
{

    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI tipsText;
    

    public LineRenderer[] lineRenderers;
    public Transform[] stripPosition;
    public Transform center;
    public Transform idlePosition;

    public Vector3 currentPosition;

    public float maxLength;

    public float bottomBoundary;

    bool isMouseDown;
    public bool bulletIsExist;

    bool isReloading = false;

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
        lineRenderers[2].SetPosition(0, stripPosition[0].position);

        
        CreateBullet();

        bulletIsExist = true;
    }

    void CreateBullet()
    {
        bullet = Instantiate(bulletPrefab).GetComponent<Rigidbody2D>();
        bulletCollider = bullet.GetComponent<Collider2D>();
        bulletCollider.enabled = false;

        bullet.isKinematic = true;
        bulletIsExist = true;
        isReloading = false;
    }
    // Update is called once per frame

    void SpawnNewBullet()
    {
        if(!bulletIsExist && Input.GetKeyDown(KeyCode.Space))
        {
            if(!isReloading)
            {
                isReloading = true;
                Invoke("CreateBullet", 0.3f);
            }        
        }
    }
    void Update()
    {
        //Debug.Log(bulletIsExist);
        if (isMouseDown )
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            currentPosition.x = Camera.main.ScreenToWorldPoint(mousePosition).x;
            currentPosition.y = Camera.main.ScreenToWorldPoint(mousePosition).y;
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition - center.position, maxLength);

            currentPosition = ClampBoundary(currentPosition);
            SetStrips(currentPosition);

            if (bulletCollider)
            {
                bulletCollider.enabled = true;
            }

            DisplayTrajectory();
        }
        else
        {
            ResetStrips();
            lineRenderers[2].enabled = false;
        }

        
        if(bulletIsExist)
        {
            tipsText.enabled = false;
        }
        else if(!bulletIsExist)
        {
            tipsText.enabled = true;
        }

        SpawnNewBullet();
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
            gameManager.incrementScore();

            FindAnyObjectByType<SoundManager>().Play("shootSound");

        }
        
        bulletIsExist = false;

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

    void DisplayTrajectory ()
    {
        lineRenderers[2].enabled = true;

        Vector2[] trajectory = Plot(bullet, (Vector2)center.position, (currentPosition - center.position) * force * -1, 180);

        lineRenderers[2].positionCount = trajectory.Length;

        Vector3[] positions = new Vector3[trajectory.Length];

        for(int i = 0; i < trajectory.Length; i++)
        {
            positions[i] = trajectory[i];
        }

        lineRenderers[2].SetPositions(positions);
    }

    Vector3 ClampBoundary(Vector3 vector)
    {
        vector.y = Mathf.Clamp(vector.y, bottomBoundary, 1000);
        return vector;
    }

    public Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps)
    {
        Vector2[] results = new Vector2[steps];

        float timestep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * rigidbody.gravityScale * timestep * timestep;

        float drag = 1f - timestep * rigidbody.drag;
        Vector2 moveStep = velocity * timestep;

        for (int i = 0; i < steps; i++)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }

        return results;
    }

    public bool getBulletIsExist()
    {
        return bulletIsExist;
    }
}