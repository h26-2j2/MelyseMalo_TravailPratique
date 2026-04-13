using UnityEngine;
using UnityEngine.Audio;

public class InstructionNiveau1 : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip instructions;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        
        InvokeRepeating("Instructions", 3.5f, 20f);
    }

    void Instructions()
    {
        audio.PlayOneShot(instructions);
    }
}
