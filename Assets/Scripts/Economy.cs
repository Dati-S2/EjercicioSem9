using UnityEngine;

public class Economy : MonoBehaviour
{
    public int money = 100; // Cantidad inicial de dinero

    public House house; // Referencia a la casa para obtener los ingresos

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime; // Incrementa el temporizador con el tiempo transcurrido desde el último frame

        if (timer >= 1f)
        {
            money += house.GetIncome(); // Agrega los ingresos de la casa al dinero total
            timer = 0f;

            Debug.Log("Dinero: " + money);
        }
    }

    public void UpgradeHouse() // Método para mejorar la casa
    {
        int cost = house.GetUpgradeCost();

        if (money >= cost && house.level < 4) // Verifica si hay suficiente dinero y si la casa no ha alcanzado el nivel máximo
        {
            money -= cost;
            house.Upgrade();

            Debug.Log("Coso Mejorado! Nivel: " + house.level);
        }
        else
        {
            Debug.Log("No tienes suficiene dinero o es su maximo nivel del coso.");
        }
    }
}
