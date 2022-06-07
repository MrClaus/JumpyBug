using UnityEngine;

public class WheelControl : MonoBehaviour
{
    // The current surface that the wheels are in contact with
    private static int cnt;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string name = collision.gameObject.name;

        if (name.Length > 3)
        {
            if (name.Substring(0, 3) == "way")
            {
                string num = name.Substring(3, name.Length - 3);
                int number = int.Parse(num);

                if (number > cnt)
                    cnt = number;
            }
        }
    }

    // Return surface(track) number
    public static int getNumHit()
    {
        return cnt;
    }

    // Set to restart parametr 'cnt'
    public static void setNumHit(int num)
    {
        cnt = num;
    }
}
