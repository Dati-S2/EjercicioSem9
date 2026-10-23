using UnityEngine;

public class House : MonoBehaviour
{
    public int level = 1;

    public GameObject[] levelModels;

    public int GetIncome() // Método para obtener los ingresos según el nivel de la casa
    {
        if (level == 1)
        {
            return 5;
        }
        else if (level == 2)
        {
            return 10;
        }
        else if (level == 3)
        {
            return 20;
        }
        else
        {
            return 35;
        }
    }
    public int GetUpgradeCost() // Método para obtener el costo de mejora según el nivel de la casa
    {
        if (level == 1)
        {
            return 50;
        }
        else if (level == 2)
        {
            return 100;
        }
        else if (level == 3)
        {
            return 200;
        }
        else
        {
            return 0;
        }
    }

    public bool Upgrade() // Método para mejorar la casa, incrementando su nivel y retornando true si la mejora fue exitosa
    {
        if (level >= 4)
        {
            return false;
        }

        level++;

        UpdateHouseVisual();

        return true;
    }
        void UpdateHouseVisual() // Método para actualizar la apariencia de la casa según su nivel
    {
        for (int i = 0; i < levelModels.Length; i++)
        {
            levelModels[i].SetActive(i == level - 1);
        }
    }
}
