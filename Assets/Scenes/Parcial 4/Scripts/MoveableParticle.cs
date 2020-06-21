using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableParticle : ParticleWithCharge
{
    [SerializeField]
    public float masa = 1;

    public Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        UpdateColor();
        rigidBody = gameObject.AddComponent<Rigidbody2D>();
        rigidBody.mass = masa;
        //rigidBody.useGravity = false;
    }

}
