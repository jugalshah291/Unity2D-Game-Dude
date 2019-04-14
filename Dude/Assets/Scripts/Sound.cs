using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip jumpSound, hitSound,shootSound,coinSound;
    static AudioSource audioSource;

    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("Adventure Island SFX Jump");
        hitSound = Resources.Load<AudioClip>("Adventure Island SFX Hit");
		shootSound = Resources.Load<AudioClip>("Adventure Island SFX Shoot");
        coinSound = Resources.Load<AudioClip>("Adventure Island SFX Coin");
		

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSource.PlayOneShot(jumpSound);
                break;
            case "hit":
                audioSource.PlayOneShot(hitSound);
                break;
            case "shoot":
                audioSource.PlayOneShot(shootSound);
                break;
            case "coin":
                audioSource.PlayOneShot(coinSound);
                break;

        }
    }
}
