using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffects : MonoBehaviour {

    
    // Singleton
    
    public static SpecialEffects Instance;

    public ParticleSystem smokeEffect;
    //public ParticleSystem fireEffect;

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            // Debug.LogError("Multiple instances of SpecialEffects!");
        }

        Instance = this;
    }

    /// <summary>
    /// Create an explosion at the given location
    /// </summary>
    /// <param name="position"></param>
    public void Explosion(Vector3 position)
    {
        // Smoke on the water
        //Debug.LogError("Error!!!!");
        //Debug.LogError(smokeEffect);
        Instantiate(smokeEffect, position);

        // Tu tu tu, tu tu tudu

        // Fire in the sky
        //instantiate(fireEffect, position);
    }

    /// <summary>
    /// Instantiate a Particle system from prefab
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns></returns>
    private void Instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(
          prefab,
          position,
          Quaternion.identity
        ) as ParticleSystem;

        // Make sure it will be destroyed
        //Destroy(
        //  newParticleSystem.gameObject,
        //  newParticleSystem.startLifetime
        //);

        // return newParticleSystem;
    }
}
