using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoPlayer : MonoBehaviour {
    public Animator Animador;
    public float velocidade;
    public float direcao;
    public float soco;
    public GameObject colisorSoco;
    public float tempo;
    public float dano;


	// Use this for initialization
	void Start () {
        colisorSoco.SetActive(false);
        tempo = 0;
	}
	
	// Update is called once per frame
	void Update () {
        velocidade = Input.GetAxis("Vertical");
        direcao = Input.GetAxis("Horizontal");
        soco = Input.GetAxis("Fire1");

        Animador.SetFloat("velocidade", velocidade);
        Animador.SetFloat("direcao", direcao);
        Animador.SetFloat("soco", soco);

        if (soco > 0.0f)
        {
            colisorSoco.SetActive(true);
        }
        else {
            colisorSoco.SetActive(false);
        }
        tempo = tempo + (Time.deltaTime * 1);
        if (tempo > 0.3) {
            dano = 0;
            Animador.SetFloat("damage", dano);
        }
    }
    void OnTriggerEnter(Collider outro)
    {
        if (outro.gameObject.CompareTag("colisorSocoInimigo"))
        {
            tempo = 0;
            dano = 1;
            Animador.SetFloat("damage", dano);
            
            
            
            
        }
    }
}
