using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch_with_Audio_test : MonoBehaviour
{

    public GameObject projectile;
    public GameObject target;
    public float launchVelocity = 600f;
    public AudioClip shootsound;
    public float lowVolumeRange = .5f;
    public float highVolumeRange = 1.0f;
    private AudioSource source;
    private int update = 0;
    private GameObject lastLaunched;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        update++;
        if(update >= 500) {

        float vol = Random.Range(lowVolumeRange, highVolumeRange);
         source.PlayOneShot(shootsound, vol);

         GameObject launchThis = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
         if(lastLaunched != null) {
            lastLaunched.SetActive(false);
         }
         lastLaunched = launchThis;
         launchThis.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
         update = 0;
         
         }
    }

}
