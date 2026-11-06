using UnityEngine;
using UnityEngine.InputSystem;

public class HousePlacer : MonoBehaviour
{
    public GameObject housePrefab;
    public Camera mainCamera;
    public LayerMask groundLayer;

    public Economy economy;
    public int houseCost = 100;

    private bool hasPaid = false;

    private bool placingHouse = false;

    void Update()
    {
        if (!placingHouse)
            return;

        if (Mouse.current == null) // Comprueba si el ratón está disponible
            return;

        Vector2 mousePosition = Mouse.current.position.ReadValue(); // Obtiene la posición del ratón en la pantalla

        Ray ray = mainCamera.ScreenPointToRay(mousePosition); // Crea un rayo desde la cámara hacia la posición del ratón
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f, groundLayer)) // Realiza un raycast para detectar la colisión con el suelo
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                if (!hasPaid)
                {
                    economy.money -= houseCost;
                    hasPaid = true;
                }

                Instantiate(housePrefab, hit.point, Quaternion.identity);
                placingHouse = false;


                Debug.Log("Coso colocado! Dinero: " + economy.money);
            }
        }

        if (Mouse.current.rightButton.wasPressedThisFrame) // Permite cancelar la colocación de la casa al hacer clic derecho
        {
            placingHouse = false;
            Debug.Log("Se cancelo el colocamiento del Coso.");
        }
    }

    public void StartPlacingHouse() // Método para iniciar la colocación de la casa
    {
        if (economy.money >= houseCost)
        {
            hasPaid = false;
            placingHouse = true;

            Debug.Log("Elige dónde quieres colocar tu Coso.");
        }
        else
        {
            Debug.Log("¡No hay suficiente dinero!");
        }
    }
}
