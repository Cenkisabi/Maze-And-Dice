using UnityEngine;
using System.Collections;

public class UpSide : MonoBehaviour {

    public Vector3[] dice = new Vector3[6];

    public void Cross(Vector3 rotatedAxis)
    {
        for (int i = 0; i < 6; i++)
        {
            if (rotatedAxis != dice[i] && rotatedAxis != -dice[i])
                dice[i] = Vector3.Cross(dice[i], rotatedAxis);
        }
    }

    public int[] GetFaces()
    {
        int [] x = new int[6];
        for (int i = 0; i < 6; i++)
        {
            if (dice[i] == Vector3.back)
                x[0] = i;
            else if (dice[i] == Vector3.forward)
                x[1] = i;
            else if (dice[i] == Vector3.right)
                x[2] = i;
            else if (dice[i] == Vector3.left)
                x[3] = i;
            else if (dice[i] == Vector3.up)
                x[4] = i;
            else if (dice[i] == Vector3.down)
                x[5] = i;
        }
        return x;
    }

}
