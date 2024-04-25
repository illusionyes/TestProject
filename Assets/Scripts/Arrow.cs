using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float _rotationZ;
    public int ArrowInt { get; private set; }
    // private enum ArrowDirection
    // {
    //     Up = 0,
    //     Down = 180,
    //     Left = 90,
    //     Right = -90
    // }

    private void Awake()
    {
        var rotation = transform.rotation.eulerAngles;
        ArrowInt = (int)rotation.z;
        // RandomRotation();
        // this.transform.rotation = Quaternion.Euler(0,0,_rotationZ);
    }

    private void RandomRotation()
    {
        // ArrowInt = Random.Range(0, 4);
        _rotationZ = 0;
        // Debug.Log(_rotationZ);
        switch (_rotationZ)
        {
            case 0 :
            {
                ArrowInt = 0;
                return;
            }
            case 180:
            {
                ArrowInt = 1;
                return;
            }
            case 90:
            {
                ArrowInt = 2;
                return;
            }
            case -90:
            {
                ArrowInt = 3;
                return;
            }
        }
        // switch (ArrowInt)
        // {
        //     case 0 :
        //     {
        //         _rotationZ = (float)ArrowDirection.Up;
        //         return;
        //     }
        //     case 1:
        //     {
        //         _rotationZ = (float)ArrowDirection.Down;
        //         return;
        //     }
        //     case 2:
        //     {
        //         _rotationZ = (float)ArrowDirection.Left;
        //         return;
        //     }
        //     case 3:
        //     {
        //         _rotationZ = (float)ArrowDirection.Right;
        //         return;
        //     }
        // }
    }
}
