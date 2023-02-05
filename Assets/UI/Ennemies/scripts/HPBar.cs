using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HPBar : MonoBehaviour
{

    public Health health;

    public Slider healthbarDisplay;
    public Image HPValue;
    public Color highHealthColor = new Color(0.35f, 1f, 0.35f);
    public Color mediumHealthColor = new Color(0.9450285f, 1f, 0.4481132f);
    public Color lowHealthColor = new Color(1f, 0.259434f, 0.259434f);
    public Color BloodBlurColor = new Color(0.3962264f, 0.3962264f, 0.3962264f);
    public Image BloodBlur = null;

    private float Max_hp;
    private float hp;
    private float hp_percent;

    // Start is called before the first frame update
    void Start()
    {
        healthbarDisplay.minValue = 0;
        healthbarDisplay.maxValue = health.Max_hp;

        Update_Local_Var();
    }

    // Update is called once per frame
    void Update()
    {
        Update_Local_Var();
        healthbarDisplay.value = hp_percent;
        Update_Bar_Color();
        if (BloodBlur) {
            BloodBlurColor.a = ((100 - hp_percent) / 100);
            BloodBlur.color = BloodBlurColor;
        }
        if (hp_percent == 0)
            gameObject.SetActive(false);
        
    }

    private void Update_Bar_Color() {
        if (hp_percent > 50)
            HPValue.color = highHealthColor;
        else if (hp_percent <= 50 && hp_percent > 25)
            HPValue.color = mediumHealthColor;
        else
            HPValue.color = lowHealthColor;
    }

    private void Update_Local_Var() {
        Max_hp = health.Max_hp;
        hp = health.hp;
        hp_percent = health.getHPpercent();
    }
}
