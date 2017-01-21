using UnityEngine;
using System.Collections;

public class ConcentrxWave : MonoBehaviour {

    // Vector3 axisOfRotation = new Vector3(0, 0, 1);
    // Vector3 referencePoint = new Vector3(1, 0, 0);
    // new ParticleSystem particleSystem { get; set; }
    public GameObject camera;
    public Transform glow;
    public float radius;
    public float glowLifespan;
    public Vector3 location;
    public float z;
    public int numberOfRays;
    public float decayAlpha;
    public float radiusIncrement;
    bool[] blacklist;
    Quaternion[] angles;
    GameObject Player;

    // Use this for initialization
    void Start () {
        // ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        //center = GameObject.Find("Player").transform.position;
        //center = Player.transform.position;
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
        radius += Time.deltaTime * radiusIncrement;

        GameObject instanciatedObject;

        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        sp.transform.localScale = new Vector3(radius, radius, 0);
        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a - Time.deltaTime * decayAlpha);
        float magnitude = sp.bounds.size.x/2*0.87f;

        for (int i = 0; i < numberOfRays - 1; i++) {
            this.transform.rotation = angles[i];
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, transform.up, magnitude);
            //Debug.DrawLine(center, hit.point, Color.yellow, 0.1f);
            //Debug.DrawRay(center, transform.up*magnitude, Color.yellow, 0.1f);
            if (hit.collider != null && !blacklist[i]) {
                blacklist[i] = true;
                instanciatedObject = Instantiate(glow, hit.point, Quaternion.FromToRotation(glow.up, hit.normal)).gameObject;
                Destroy(instanciatedObject, glowLifespan);
            }
        }
        //Vector3 corner = camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0, 0));
        //camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        //camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        //camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        
        //sp.transform.position = camera.GetComponent<Camera>().WorldToScreenPoint(corner);

        if (sp.color.a <= 0) {
            Destroy(gameObject);
        }
	}
}
