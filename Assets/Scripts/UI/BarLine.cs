using UnityEngine;

public class BarLine : MonoBehaviour
{
    private static float benzinLife = 100f;
    private Vector3 positions;
    public CarController control;

    void Start()
    {
        positions = GetComponent<RectTransform>().localPosition;
    }

    // Update bar position
    void Update()
    {
        if (benzinLife >= 0f)
        {
            positions.x = benzinLife - 100f;
            GetComponent<RectTransform>().localPosition = positions;
            benzinLife -= 2.333f * Time.deltaTime;
        }
        else
            // If the fuel is out, then the loss
            control.FuelOut();
    }

    // Benzin selection
    public void AddBenzin()
    {
        benzinLife += 25f;
        benzinLife = (benzinLife > 100) ? 100 : benzinLife;
    }

    // Restart parametr
    public static void Restart()
    {
        benzinLife = 100f;
    }
}
