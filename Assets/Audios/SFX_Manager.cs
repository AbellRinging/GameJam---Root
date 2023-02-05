using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Manager : MonoBehaviour
{
    public AudioSource CollisionSFX;
    public AudioSource EndSFX;
    public AudioSource NutrientSFX;
    public AudioSource MovementSFX;
    public AudioSource UIBack;
    public AudioSource UIClick;
    public AudioSource UIHover;
    
    public void PlayCollisionSFX(){
        CollisionSFX.Play();
    }

    public void PlayEndSFX(){
        EndSFX.Play();
    }
    
    public void PlayNutrientSFX(){
        NutrientSFX.Play();
    }

    public void PlayMovementSFX(){
        MovementSFX.Play();
    }

    public void PlayUIBack(){
        UIBack.Play();
    }

    public void PlayUIClick(){
        UIClick.Play();
    }

    public void PlayUIHover(){
        UIHover.Play();
    }
}
