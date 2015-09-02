using UnityEngine;
using System.Collections;

public class OpenedDice : MonoBehaviour {

    private static Vector3[] directions = new Vector3[6]; // move directions of sprites according to their positions on dice
    private static GameObject[] diceFaces = new GameObject[6]; // sprite objects that used for opened dice in scene
    private static Vector3[] moveSpriteVectors = new Vector3[6]; // move toward vectors for each sprite
    private static int[] positions = new int[6]; //positions of each number on dice. For more understanding, look to UpSide().GetFaces()

    void Start()
    {
        directions[0] = new Vector3(0, 0, 0) + transform.position; //back
        directions[1] = new Vector3(0, -1.6f, 0) + transform.position; //forward
        directions[2] = new Vector3(0.8f, 0, 0) + transform.position; //right
        directions[3] = new Vector3(-0.8f, 0, 0) + transform.position; //left
        directions[4] = new Vector3(0, 0.8f, 0) + transform.position; //up 
        directions[5] = new Vector3(0, -0.8f, 0) + transform.position; //down

        diceFaces[0] = transform.FindChild("1").gameObject;
        diceFaces[1] = transform.FindChild("2").gameObject;
        diceFaces[2] = transform.FindChild("3").gameObject;
        diceFaces[3] = transform.FindChild("4").gameObject;
        diceFaces[4] = transform.FindChild("5").gameObject;
        diceFaces[5] = transform.FindChild("6").gameObject;

        SetPositions();
    }

    public static void SetPositions()
    {
        positions = GameObject.Find("Dice").GetComponent<UpSide>().GetFaces();
    }

	// Update is called once per frame
	void Update () {

        for (int i = 0; i < 6; i++)
        {
            moveSpriteVectors[i] = Vector3.MoveTowards(diceFaces[positions[i]].transform.position, directions[i], 0.1f);
            diceFaces[positions[i]].GetComponent<Rigidbody>().MovePosition(moveSpriteVectors[i]);
        }
	}
}