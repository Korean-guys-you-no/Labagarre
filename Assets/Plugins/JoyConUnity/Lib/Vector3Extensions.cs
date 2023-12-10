using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions
{
    public static void SetAxisValue(this Vector3 vector, int axis, float value)
    {
        switch (axis)
        {
            case 0:
                vector.x = value;
                break;
            case 1:
                vector.y = value;
                break;
            case 2:
                vector.z = value;
                break;
        }
    }
    public static float GetAxisValue(this Vector3 vector, int axis)
    {
        switch (axis)
        {
            case 0:
                return vector.x;
            case 1:
                return vector.y;
            case 2:
                return vector.z;
            default:
                return 0;
        }
    }
}
