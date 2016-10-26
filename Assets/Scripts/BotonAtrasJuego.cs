using UnityEngine;
using System.Collections;

public class BotonAtrasJuego : MonoBehaviour {

    public JuegoMenu juegoMenu;

    void OnMouseUpAsButton()
    {
        juegoMenu.Salir();
    }

}
