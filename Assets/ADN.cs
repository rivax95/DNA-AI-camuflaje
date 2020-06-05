//                                          ▂ ▃ ▅ ▆ █ arc █ ▆ ▅ ▃ ▂ 
//                                        ..........<(+_+)>...........
// ADN.cs (22/12/18)
//Autor: Alejandro Rivas                 alejandrotejemundos@hotmail.es
//Desc:
//Mod : 
//Rev :
//..............................................................................................\\
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADN : MonoBehaviour {

    //Gen del color
    public float r;
    public float g;
    public float b;
    public float s;
    bool dead = false;
    public float timeToDie;
    SpriteRenderer srender;
    Collider2D sCollider;
    void Start()
    {
        srender = GetComponent<SpriteRenderer>();
        sCollider = GetComponent<Collider2D>();
        srender.color = new Color(r, g, b);
        transform.localScale = new Vector3(0.267065f, s, 0.267065f);

    }
    void OnMouseDown()
    {
        dead = true;
        timeToDie = PopulationManager.elapsed;
        srender.enabled = false;
        sCollider.enabled = false;
    }
}
