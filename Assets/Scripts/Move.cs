using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public GameObject flipper; // a empty gameobject for rotating dice in different direction
    private Quaternion to; // which direction will flipper rotate the dice

    public int counter; // counts how many times dice will be rotate
    bool isMoving = false;

    public Vector3 finishOffset;//finish position's offset to start position
    private Vector3 startPosition;

    private Vector3 flipperOffset; //flipper's position according to dice
    private Vector3 cross; //crossing factor to get new direction of each face

    void Start()
    {
        startPosition = transform.position;
    }

	void Update () {

        //check if game finished
        if (transform.position == startPosition + finishOffset)
        {
            //Add here what you want to be at end of game
            Time.timeScale = 0; 
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !isMoving)
        {
            if (Valid(counter*Vector3.up))
            {
                flipperOffset = new Vector3(0, 0.5f, 0.5f);
                /* set flipper position to edge that we want to rotate dice and
                 * Set Quaternion.Lerp "to"
                 */
                SetTo(new Vector3(90, 0, 0), (transform.position + flipperOffset));

                //rotating on -x axis
                cross = Vector3.left;
                isMoving = true;
            }
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && !isMoving)
        {
            if (Valid(counter * Vector3.down))
            {
                flipperOffset = new Vector3(0, -0.5f, 0.5f);
                /* set flipper position to edge that we want to rotate dice and
                 * Set Quaternion.Lerp "to"
                 */
                SetTo(new Vector3(-90, 0, 0), (transform.position + flipperOffset));

                //rotating on x axis
                cross = Vector3.right;
                isMoving = true;
            }
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) && !isMoving)
        {
            if (Valid(counter * Vector3.right))
            {
                flipperOffset = new Vector3(0.5f, 0, 0.5f);
                /* set flipper position to edge that we want to rotate dice and
                 * Set Quaternion.Lerp "to"
                 */
                SetTo(new Vector3(0, -90, 0), transform.position + flipperOffset);

                //rotating on y axis,
                cross = Vector3.up;
                isMoving = true;
            }
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isMoving)
        {
            if (Valid(counter * Vector3.left))
            {
                flipperOffset = new Vector3(-0.5f, 0, 0.5f);
                /* set flipper position to edge that we want to rotate dice and
                 * Set Quaternion.Lerp "to"
                 */
                SetTo(new Vector3(0, 90, 0), transform.position + flipperOffset);

                //rotating on -y axis
                cross = Vector3.down;
                isMoving = true;
            }
        }


        if (Mathf.Abs(flipper.transform.eulerAngles.magnitude-to.eulerAngles.magnitude)<3f && isMoving)
        {
            //sets the direction of each faces again
            transform.GetComponent<UpSide>().Cross(cross);

            //reset flipper
            flipper.transform.eulerAngles = to.eulerAngles;
            transform.parent = null;
            flipper.transform.eulerAngles = Vector3.zero;

            // if counter bigger than 1 keep on moving
            if (counter > 1)
            {
                SetTo(to.eulerAngles,transform.position + flipperOffset);
                counter--;
            }
            //else stop and set counter to up face of dice, and set positions of opened dice.
            else
            {
                isMoving = false;
                counter = transform.GetComponent<UpSide>().GetFaces()[0]+1;
                OpenedDice.SetPositions();
            }
        }


        
        
	}

    void SetTo(Vector3 toEuler, Vector3 positionOfFlipper)
    {
        to.eulerAngles = toEuler;
        flipper.transform.position = positionOfFlipper;
        transform.parent = flipper.transform;
        isMoving = true;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            flipper.transform.rotation = Quaternion.Slerp(flipper.transform.rotation, to, 0.2f);
        }
    }



    //Check if movement is possible
    bool Valid(Vector3 dir)
    {

        Vector3 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos , pos + dir);


        if (hit.transform != null)
            return (!"Maze".Equals(hit.transform.name));
        else
            return true;
    }
}
