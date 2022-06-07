using UnityEngine;
using UnityEngine.UI;

public class ButtonControlCar : MonoBehaviour
{
    public GameObject car;
    private bool isPressedLeft;
    private bool isPressedRight;

    // Ñlick on the screen - Jump
    public void TapCar()
    {
        car.GetComponent<CarController>().ButtonTapScreen();
    }

    private void Update()
    {
        if (isPressedLeft)
            car.GetComponent<CarController>().ButtonLeftScreen();
        if (isPressedRight)
            car.GetComponent<CarController>().ButtonRightScreen();
    }

    // Ñlick on the screen button - Turn Left
    public void LeftCarDown()
    {
        isPressedLeft = true;
        ColorPressed(true);
    }

    public void LeftCarUp()
    {
        isPressedLeft = false;
        ColorPressed(false);
    }

    // Ñlick on the screen button - Turn Right
    public void RightCarDown()
    {
        isPressedRight = true;
        ColorPressed(true);
    }

    public void RightCarUp()
    {
        isPressedRight = false;
        ColorPressed(false);
    }

    // Color button press
    private void ColorPressed(bool isPressed)
    {
        Color color = GetComponent<Image>().color;
        color.a = isPressed ? 0.6f : 0.39f;
        GetComponent<Image>().color = color;
    }
}
