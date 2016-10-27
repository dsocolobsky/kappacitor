using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BotonAtrasJuego : MonoBehaviour {

    public JuegoMenu juegoMenu;

    void OnMouseUpAsButton()
    {
        juegoMenu.Salir();
    }

}
