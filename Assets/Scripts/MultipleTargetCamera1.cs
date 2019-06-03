using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera1 : MonoBehaviour
{

    public List<Transform> targets;
    public Vector3 offset;
    public float smoothTime = 0.2f;
    public float minZoom = 6f;
    public float maxZoom = 2f;
    public float zoomLimiter = 10f;
    private Vector3 velocity;
    private Camera cam;
    public int NumberOfplayers;

    public Camera maincam;
    public float shakeAmount = 0;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public bool Player1Null;
    public bool Player2Null;
    public bool Player3Null;
    public bool Player4Null;

    void Start()
    {
        cam = GetComponent<Camera>();

        Player1 = GameObject.FindGameObjectWithTag("Player1");
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        Player3 = GameObject.FindGameObjectWithTag("Player3");
        Player4 = GameObject.FindGameObjectWithTag("Player4");
        if (Player1 != null)
        {
            NumberOfplayers = NumberOfplayers + 1;
            Player1Null = false;
        }
        if (Player2 != null)
        {
            NumberOfplayers = NumberOfplayers + 1;
            Player2Null = false;
        }
        if (Player3 != null)
        {
            NumberOfplayers = NumberOfplayers + 1;
            Player3Null = false;

        }
        if (Player4 != null)
        {
            NumberOfplayers = NumberOfplayers + 1;
            Player4Null = false;
        }
    }

    private void LateUpdate()
    {
        if (targets.Count == 0)
            return;

        Move();
        Zoom();
    }
    void Update()
    {
        if(Player1 == null && Player1Null == false)
        {
            NumberOfplayers = NumberOfplayers - 1;
            Player1Null = true;
        }
        if (Player2 == null && Player2Null == false)
        {
            NumberOfplayers = NumberOfplayers - 1;
            Player2Null = true;
        }
        if (Player3 == null && Player3Null == false)
        {
            NumberOfplayers = NumberOfplayers - 1;
            Player3Null = true;
        }
        if (Player4 == null && Player4Null == false)
        {
            NumberOfplayers = NumberOfplayers - 1;
            Player4Null = true;
        }

        if (NumberOfplayers == 1)
        {
            SceneManager.LoadScene(Random.Range(5, 7));
        }
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
       // print(GetGreatestDistance() / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
        Vector2 Left = targets[0].transform.position;
        Vector2 Right = targets[0].transform.position;
        if (targets.Count > 1)
        {

            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i].transform.position.x < Left.x)
                {
                    Left = targets[i].transform.position;
                }
                if (targets[i].transform.position.x > Right.x)
                {
                    Right = targets[i].transform.position;
                }
            }

        }
        float dist = Vector2.Distance(Left, Right);
    }
    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }


        return bounds.center;

    }
        void Awake()
        {
          if (maincam == null)
          {
            maincam = cam;
          }
        }

    public void shake(float amt, float lenght)
    {
        shakeAmount = amt;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", lenght);
    }

    void BeginShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 campos = cam.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            campos.x += offsetX;
            campos.y += offsetY;

            cam.transform.position = campos;

        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
    }
}
