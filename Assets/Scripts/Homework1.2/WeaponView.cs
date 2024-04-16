using UnityEngine;
using TMPro;

public class WeaponView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBullets;
    [SerializeField] BulletCirlce bulletCirlceExample;
    [SerializeField] Transform placeWhereBulletOut;
    public delegate void FirePressed();
    FirePressed firePressed;
    private const int spacing = 2;

    public void RegDelegate(FirePressed firePressed)
    {
        this.firePressed = firePressed;
    }

    public void UpdateTextBullets(int bullets)
    {
        textBullets.text = bullets.ToString();
    }

    public void DrawFire(int bullets)
    {
        for(int i = 0; i < bullets; i++)
        {
            float xPos = i * spacing + placeWhereBulletOut.position.x;
            var bul = Instantiate(bulletCirlceExample, transform);
            bul.transform.position = new Vector3(xPos, placeWhereBulletOut.position.y, placeWhereBulletOut.position.z);
            bul.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            firePressed?.Invoke();
        }

    }
}
