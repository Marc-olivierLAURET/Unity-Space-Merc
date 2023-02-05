using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public WeaponStat weapon;

    public Image active;
    public Image inActive;
    public Text clip;

    public Color emptyColor = new Color(1f, 0.259434f, 0.259434f);
    public Color normalColor = new Color(1f, 1f, 1f);
    public Color emptyColor_inactive = new Color(1f, 0.259434f, 0.259434f);
    public Color normalColor_inactive = new Color(1f, 1f, 1f);

    // Start is called before the first frame update
    void Start()
    {
         emptyColor_inactive.a = 0.6f;
         normalColor_inactive.a = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        clip.text = weapon.current_clip.ToString();

        if (weapon.gameObject.activeInHierarchy) {
            active.gameObject.SetActive(true);
            inActive.gameObject.SetActive(false);

            if (weapon.current_clip == 0) {
                clip.color = emptyColor;
                active.color = emptyColor;
            }
            else {
                clip.color = normalColor;
                active.color = normalColor;
            }
        }
        else {
            inActive.gameObject.SetActive(true);
            active.gameObject.SetActive(false);

            if (weapon.current_clip == 0) {
                clip.color = emptyColor_inactive;
                inActive.color = emptyColor_inactive;
            }
            else {
                clip.color = normalColor_inactive;
                inActive.color = normalColor_inactive;
            }
        }
    }


}
