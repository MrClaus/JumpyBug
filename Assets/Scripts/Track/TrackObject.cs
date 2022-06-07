using UnityEngine;
using UnityEngine.UI;

public class TrackObject : MonoBehaviour
{
    private int mNum;
    public GameObject Post;
    public GameObject PostPosition;
    public GameObject Can;
    public GameObject CanPosition;

    // Track object init
    void Start()
    {
        mNum = WheelControl.getNumHit() + 1;

        if (mNum > 1 && mNum % 5 == 0)
        {
            GameObject mPost = Instantiate(Post, gameObject.transform.position + PostPosition.transform.position, Quaternion.identity);
            mPost.GetComponentInChildren(typeof(Text)).gameObject.GetComponent<Text>().text = "" + mNum;
            mPost.transform.SetParent(gameObject.transform);
        }
        if (mNum > 2 && mNum % 2 == 0)
        {
            GameObject mCan = Instantiate(Can, gameObject.transform.position + CanPosition.transform.position, Quaternion.identity);
            mCan.transform.SetParent(gameObject.transform);
        }
    }

    // Checking the track life
    void Update()
    {
        int currentNum = WheelControl.getNumHit();
        if (currentNum - mNum > 3)
        {
            Destroy(gameObject);
        }
    }
}
