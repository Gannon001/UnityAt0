using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    // Vitesse - Nombre unité parcouru en 1 sec.
    private const float speed = 30f;

    // Taille des tuile max & min
    private const float minLength = 10f;
    private const float maxLength = 50f;

    // Distance à laquelle on suprime l'elements
    private const float distanceToRemove = 10f;

    // Taille de la tuile
    // { get; private set; } => Lecteur seul hors de la classe.
    // On pourra accedez à la valeur, mais on ne poura pas la modifié
    public float titleLength { get; private set; } = 50f;

    // Couleur de la tuile
    private Color color;


    void Awake ()
    {
        // Generation d'un taille aléatoire
        titleLength = Random.Range(minLength, maxLength);

        // Génération d'une couleur aléatoire
        color = new Color(Random.Range(0, 8) / 8f, Random.Range(0, 8) / 8f, Random.Range(0, 8) / 8f);
    }

    void Start()
    {
        // Affectation de la taille à la tuile
        transform.localScale = new Vector3(5f, 1, titleLength);

        // Affecation de la couleur
        GetComponent<Renderer>().material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        // On avance l'object
        transform.position -= Vector3.forward * speed * Time.deltaTime;

        // Si l'object est plus loin que distanceToRemove, on le detruit
        if (transform.position.z + titleLength / 2 <= -distanceToRemove)
        {
            Destroy(gameObject);
        }
    }
}
