using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{

    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x; // Get the width of the sprite
    }

    void Update()
    {
        // Calculate the parallax effect
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        // Move the background
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        // Check if the background needs to be looped
        if (temp > startpos + length)
            startpos += length;
        else if (temp < startpos - length)
            startpos -= length;
    }

}
