using UnityEngine;
using System.Collections;

public class ConcentrxWave : MonoBehaviour {

    // Vector3 axisOfRotation = new Vector3(0, 0, 1);
    // Vector3 referencePoint = new Vector3(1, 0, 0);
    // new ParticleSystem particleSystem { get; set; }
    Vector3 center;
    public GameObject camera;
    public Transform glow;
    public float radius;
    public Vector3 location;
    public float z;
    public int numberOfRays;
    bool[] blacklist;
    Quaternion[] angles;

    // Use this for initialization
    void Start () {
        this.transform.position = new Vector2(0, 0);
        // ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        center = GameObject.Find("Player").transform.position;
        radius = 0f;
        angles = new Quaternion[numberOfRays - 1];
        blacklist = new bool[numberOfRays - 1];
        float angle = 0f, angleIncrement = 360f / (float)numberOfRays;
        for (int i = 0; i < angles.Length; i++) {
            blacklist[i] = false;
            angles[i] = Quaternion.AngleAxis(angle, Vector3.forward);
            angle += angleIncrement;
        }
    }
	
	// Update is called once per frame
	void Update () {
        radius += Time.deltaTime * 20;

        for (int i = 0; i < numberOfRays - 1; i++) {
            this.transform.rotation = angles[i];
            RaycastHit2D hit = Physics2D.Raycast(center, transform.up, radius/12);
            if (hit.collider != null && !blacklist[i]) {
                blacklist[i] = true;
                Instantiate(glow, hit.point, Quaternion.FromToRotation(glow.up, hit.normal));
            }
        }
        //Vector3 corner = camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0, 0));
        //camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        //camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        //camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        //sp.transform.position = camera.GetComponent<Camera>().WorldToScreenPoint(corner);
        sp.transform.localScale = new Vector3(radius, radius, 0);
        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a - Time.deltaTime / 5);
	}

    void Emit() {
        //for(int i)
    }
}
