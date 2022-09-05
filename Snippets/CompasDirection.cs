using UnityEngine;

public class CompasDirection : MonoBehaviour
{
    // Turn a vector into a compass
    string CompassDirection(Vector2 v)
    {
        string direction = "";

        v.Normalize();

        if (Vector3.Angle(v, Vector3.forward) <= 45.0)
        {
            direction = "up";
        }
        else if (Vector3.Angle(v, Vector3.right) <= 45.0)
        {
            direction = "right";
        }
        else if (Vector3.Angle(v, Vector3.back) <= 45.0)
        {
            direction = "down";
        }
        else
        {
            direction = "left";
        }

        return direction;
    }
}
