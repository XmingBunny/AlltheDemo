using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Auto Look")]
public class CameraAutoMove : MonoBehaviour
{
    public Transform Player;
    public float MoveSpeed;
    public float RotationSpeed;
    public Vector3[] Points;
    public Vector3 cameraPoint;

    void Awake()
    {
        cameraPoint = transform.position - Player.position;
    }

    void FixedUpdate()
    {
        Vector3 targetPoint = new Vector3();

        UpdatePoints();

        for (int i = 0; i < Points.Length; i++)
        {
            if (CheckPoint(Points[i]))
            {
                targetPoint = Points[i];
                break;
            }
        }

        //transform.position = Vector3.Lerp(transform.position, targetPoint, MoveSpeed * Time.deltaTime);

        SmoothLookAt();
    }

    void UpdatePoints()
    {
        Points = new Vector3[5];
        float height = cameraPoint.y;
        Vector3 abovePos = new Vector3(Player.position.x, height, Player.position.z);

        Points[0] = Player.position + cameraPoint;
        Points[1] = Vector3.Lerp(cameraPoint, abovePos, 0.25f);
        Points[2] = Vector3.Lerp(cameraPoint, abovePos, 0.5f);
        Points[3] = Vector3.Lerp(cameraPoint, abovePos, 0.75f);
        Points[4] = abovePos;
    }

    bool CheckPoint(Vector3 point)
    {
        RaycastHit raycastHit;

        if (Physics.Raycast(point, Player.position - point, out raycastHit))
        {
            if (raycastHit.collider.tag == Tags.Player)
            {
                return true;
            }
        }

        return false;
    }

    void SmoothLookAt()
    {
        Vector3 lookDirction = Player.position - transform.position;
        Quaternion targetAngle = Quaternion.LookRotation(lookDirction, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetAngle, RotationSpeed * Time.deltaTime);
    }
}
