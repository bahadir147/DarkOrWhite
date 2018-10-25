using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    public float scaleSizeValue;

    public float scaleChangeSpeedX;
    public float scaleChangeSpeedY;

    public float rotationSpeed;

    [Space(10)]
    public float angleForSideMove = 0;
    public float sideMoveDistance;
    public float sideMoveSpeed;

    [Space(10)]
    public float angleForUpDownMove = 0;
    public float upDownMoveDistance;
    public float upDownMoveSpeed;


    float angleX = 0;
    float angleY = 0;



    float OriginalScaleX;
    float OriginalScaleY;

    Vector2 OriginalPosition;


    void Start()
    {
        OriginalScaleX = transform.localScale.x;
        OriginalScaleY = transform.localScale.y;

        OriginalPosition = transform.position;
    }


    void Update()
    {
        if (scaleChangeSpeedX != 0 || scaleChangeSpeedY != 0)
        {
            ScaleChange();
        }

        if (rotationSpeed != 0)
        {
            AngleChange();
        }

        if (sideMoveSpeed != 0)
        {
            SideToSidePositionChange();
        }

        if (upDownMoveDistance != 0)
        {
            UpDownPositionChange();
        }
    }


    void ScaleChange()
    {
        transform.localScale = new Vector2(OriginalScaleX + Mathf.Sin(angleX) * scaleSizeValue, OriginalScaleY + Mathf.Sin(angleY) * scaleSizeValue);
        angleX += Time.deltaTime * scaleChangeSpeedX;
        angleY += Time.deltaTime * scaleChangeSpeedY;
    }


    void AngleChange()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed, Space.World);
    }


    void SideToSidePositionChange()
    {
        Vector2 pos = transform.position;
        pos.x = OriginalPosition.x + Mathf.Sin(angleForSideMove) * sideMoveDistance;
        transform.position = pos;

        angleForSideMove += Time.deltaTime * sideMoveSpeed;
    }


    void UpDownPositionChange()
    {
        Vector2 pos = transform.position;
        pos.y = OriginalPosition.y + Mathf.Sin(angleForUpDownMove) * upDownMoveDistance;
        transform.position = pos;

        angleForUpDownMove += Time.deltaTime * upDownMoveSpeed;
    }




}
