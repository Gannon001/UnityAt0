using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject tilePrefab;

    // Monbre de tuile affiché
    private const int nbTitleShow = 12;
 
    void Start()
    {
        // On crée toutes les tuiles au depart
        for (int i = 0; i < nbTitleShow; i++)
        {
            createNewTitle();
        }
        // Note c'est un peu inutile car Update va faire le job juste apres.
    }

    // Update is called once per frame
    void Update()
    {
        // On verifie qu'il y a tout les tuiles
        // Si il manque, on les crée jusqu'a arriver au bon compte
        for (int i = transform.childCount; i < nbTitleShow; i += 1)
        {
            createNewTitle();
        }
    }

    public void createNewTitle()
    {
        /*
            La position de la tuile correspond au centre de la tuile.
            Il faut donc ajouter la motier de ça taille pour obtenir l'extrémité
            PositionExtremité = Pos + titleLength / 2
            
                tuile A           Tuille B
            -------------------------------------
            |      *      |          *          |
            -------------------------------------
                   |                 |
                   |-----distance----|
                     = TuilleA.Taille / 2 + TuilleB.Taille / 2
        */

        // Create de l'object tuile
        GameObject go = Instantiate(tilePrefab) as GameObject;
        // On recupere le instance script de cette tuile pour avoir sa taille
        TileScript ts = go.GetComponent<TileScript>();
        // On decale l'object de la moituer de sa taile
        float offset = ts.titleLength / 2;

        // Si il y a déja des tuiles de posée
        if (transform.childCount != 0)
        {
            // On recupere le derriere tuile
            Transform lastTitle = transform.GetChild(transform.childCount - 1);
            // On recupere le instance script de cette tuile
            TileScript lastTileScript = lastTitle.GetComponent<TileScript>();
            // On decale la nouvelle truile de sa position + la moitier de sa taille
            offset += lastTitle.position.z + (lastTileScript.titleLength / 2);
        }
        
        // On place la tuile a la valeur calculé
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(0, 0, offset);
    }
}
