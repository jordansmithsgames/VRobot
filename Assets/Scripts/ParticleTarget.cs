using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTarget : MonoBehaviour
{

    public Transform Target;

    private ParticleSystem system;

    public int speed;

    private static ParticleSystem.Particle[] particles = new ParticleSystem.Particle[20];

    // Start is called before the first frame update
    void Start()
    { }

    void Update()
    {
        if (system == null) system = GetComponent<ParticleSystem>();

        var count = system.GetParticles(particles);

        for (int i = 0; i < count; i++)
        {
            var particle = particles[i];

            float distance = Vector3.Distance(Target.position, particle.position);

            if (distance > 0.01f)
            {
                particle.position = Vector3.Lerp(particle.position, Target.position, Time.deltaTime * speed);

                particles[i] = particle;
            }

            if (distance <= 0.01f)
            {
                particle.remainingLifetime = 0;
            }
        }

        system.SetParticles(particles, count);
    }
}

