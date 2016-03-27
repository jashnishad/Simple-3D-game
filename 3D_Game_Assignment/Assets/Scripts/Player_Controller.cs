using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {

    public Transform flashPoint;
    public GameObject muzzleFlash;
    public GameObject bulletImpact;
    private Transform _transform;
    public GameController gameController;
   // public AudioSource shoot; 
  //  private AudioSource[] _audioSources;
    //private AudioSource gunfire;

    // Use this for initialization
    void Start () {
        //this.shoot = gameObject.GetComponent<AudioSource>();
        // shoot.clip = Resources.Load() as AudioClip;
        // shoot.Play();
        this._transform = gameObject.GetComponent<Transform>();
        
	}
	
	// Update is called once per frame
	void Update () {

        
	}
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            Instantiate(this.muzzleFlash, flashPoint.position, Quaternion.identity);
            // Instantiate(this.bulletImpact, flashPoint.position, Quaternion.identity);
            RaycastHit hit;
            if (Physics.Raycast(this._transform.position, this._transform.forward, out hit, 50f))
            {
                if (hit.transform.gameObject.CompareTag("Enemy"))

                {
                    Debug.Log("hekll");
                   // Instantiate(this.bulletImpact, hit.point, Quaternion.identity);
                    Destroy(hit.transform.gameObject);
                    this.gameController.ScoreValue += 10;
                }
                else
                {
                    Instantiate(this.muzzleFlash, hit.point, Quaternion.identity);
                    Debug.Log("Object Instantiated");
                }
            }
            else
            {
                Debug.Log("Object Instantiated");
            }
        }

    }
}
