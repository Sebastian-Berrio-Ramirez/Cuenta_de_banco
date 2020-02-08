using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Botones : MonoBehaviour
{
    public AudioSource source { get { return GetComponent<AudioSource>(); } }
    public Button btn { get { return GetComponent<Button>(); } }
    public AudioClip beep;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        btn.onClick.AddListener(Reproducir);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Reproducir()
    {
        source.PlayOneShot(beep);
    }
}
