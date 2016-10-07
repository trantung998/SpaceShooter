using UnityEngine;
using System.Collections;
using Config;

[System.Serializable]
public class Boundary
{
    public float xMax, xMin, zMax, zMin;

    public Boundary(float xm, float xmax, float zmin, float zmax)
    {
        xMax = xmax;
        xMin = xm;
        zMax = zmax;
        zMin = zmin;
    }
}

public class PlayerMovment : MonoBehaviour {
    //public float speed = 30;

    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 mousePos ;
    public Boundary boundary;
    private Rigidbody rigbody;

    private 
    // Use this for initialization
    void Start () {
        rigbody = this.GetComponent<Rigidbody>();

        float dpi = Screen.dpi;
        int height = Screen.height;
        int width = Screen.width;

        int h = Screen.currentResolution.height;
        int w = Screen.currentResolution.width;
        int r = Screen.currentResolution.refreshRate;
        boundary = new Boundary(0,0,0,0);

        Debug.Log("Dpi: " + dpi);
        Debug.Log("height: " + height);
        Debug.Log("width: " + width);

        Debug.Log("h: " + h);
        Debug.Log("w: " + w);
        Debug.Log("r: " + r);

        Vector3 bottomLeft = new Vector3(0, 0, 0);
        Vector3 bottomRight = new Vector3(width, 0, 0);
        Vector3 topRight = new Vector3(width, height, 0);
        Vector3 topLeft = new Vector3(0, height, 0);

        bottomLeft = Camera.main.ScreenToWorldPoint(bottomLeft);
        bottomRight = Camera.main.ScreenToWorldPoint(bottomRight);
        topRight = Camera.main.ScreenToWorldPoint(topRight);
        topLeft = Camera.main.ScreenToWorldPoint(topLeft);

        Debug.Log("bottomLeft: " + bottomLeft);
        Debug.Log("bottomRight: " + bottomRight);

        Debug.Log("topRight: " + topRight);
        Debug.Log("topLeft: " + topLeft);
        
        boundary.xMin = bottomLeft.x;
        boundary.xMax = bottomRight.x;

        boundary.zMin = bottomLeft.z;
        boundary.zMax = topRight.z;

        Debug.Log("xMin: " + boundary.xMin);
        Debug.Log("xMax: " + boundary.xMax);
        Debug.Log("zMin: " + boundary.zMin);
        Debug.Log("zMax: " + boundary.zMax);

    }
	
	// Update is called once per frame
	void Update () {
        mousePos = Input.mousePosition;
        //Debug.Log("--" + mousePos.x + "," + mousePos.y + "," + mousePos.z);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.y = 0;
        //Debug.Log("++" + mousePos.x + "," + mousePos.y + "," + mousePos.z);

        mousePos = new Vector3(Mathf.Clamp(mousePos.x, boundary.xMin, boundary.xMax),
                          0.0f,
                          Mathf.Clamp(mousePos.z, boundary.zMin, boundary.zMax));

        transform.position = Vector3.Lerp(transform.position, mousePos, GameConfig.PLAYER_SPEED * Time.deltaTime);

        //rigbody.rotation = Quaternion.Euler(0.0f, 0.0f,  4* -transform.position.x);
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;

        transform.position = Vector3.Lerp(transform.position, cursorPosition, GameConfig.PLAYER_SPEED * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
                                  0.0f,
                                  Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax));


    }
}
