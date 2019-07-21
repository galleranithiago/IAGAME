using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {
    public float campo;
    public Transform player;
    public float soco;
    public GameObject inimigo;
    public GameObject colisorSocoInimigo;
    public float tempo;
    public float dano;

    public Animator Animador;
    

	// Use this for initialization
	void Start () {
        //colisorSocoInimigo.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
       

        campo = Vector3.Distance(player.position, transform.position);
      
        if (campo < 50) {
            olhar();
        }
        if (campo < 30)
        {
            olhar();
            seguir();
        }
        if (campo < 1.3f)
        {
            golpear();
        }


        tempo = tempo + (Time.deltaTime * 1);
        if ((tempo > 2) && (dano > 0))
        {
            dano = 0;
            inimigo.SetActive(false);
        }
        if ((tempo > 0.5f) && (soco > 0))
        {
            soco = 0;
            Animador.SetFloat("soco", soco);
        }
           
	}

    void olhar() {
        Quaternion visao;
        visao = Quaternion.LookRotation(player.position -transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, visao, 6f * Time.deltaTime);           
      }

    void seguir()
    {
        //transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        Animador.SetFloat("velocidade", 1);
     }
    void golpear()
    {
        tempo = 0;
        soco = 1;
        Animador.SetFloat("soco", soco);
        Animador.SetFloat("velocidade", 0);        
    }

    void OnTriggerEnter(Collider outro)
    {
        if (outro.gameObject.CompareTag("colisorSoco"))
        {
            tempo = 0;
            dano = 1;
            Animador.SetFloat("morte", dano);
        }
    }
}
