    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health_Stamina : MonoBehaviour {

	public float currentHealth;
	public float maxHealth = 100.0f;
	public Transform HealthMeter;

	public float currentStamina;
    public float maxStamina = 100.0f;
    public Transform StaminaMeter;

	public float currentShield;
    public float maxShield = 100.0f;
	public Transform ShieldMeter;

	public Text HealthBar;
	public Text StaminaBar;
	public Text ShieldBar;

    public int coin;
    public Text coinText;


	void Start () 
	{
		currentHealth = maxHealth;
		currentStamina = maxStamina;
		currentShield = maxShield;
		HealthMeter.GetComponent<Image>().color = new Color(0, 1, 0);
	}
	
	void FixedUpdate ()
	{
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if(currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }

        if(currentShield > maxShield)
        {
            currentShield = maxShield;
        }

        coinText.text = coin.ToString("f0");
        HealthBar.text = currentHealth.ToString("f0") + " / " + maxHealth;
		StaminaBar.text = currentStamina.ToString("f0") + " / " + maxStamina;
		ShieldBar.text = currentShield.ToString("f0") + " / " + maxShield;
		 
		if (currentHealth < (maxHealth/2))
        {
            HealthMeter.GetComponent<Image>().color = new Color(1, 1, 0);
        }

        if (currentHealth < (maxHealth/10))
        {
            HealthMeter.GetComponent<Image>().color = new Color(1, 0, 0);
        }

		if (currentHealth == 0)
        {
            SceneManager.LoadScene(2);
        }

		if (currentHealth < maxHealth && currentHealth > (maxHealth/2))
		{
			HealthMeter.GetComponent<Image>().color = new Color(0, 1, 0);
		}


		if (currentStamina < (maxStamina/2))
        {
            StaminaMeter.GetComponent<Image>().color = new Color(1, 1, 0);
        }

		if (currentStamina < (maxStamina/10))
        {
            StaminaMeter.GetComponent<Image>().color = new Color(1, 0, 0);
        }

		if (currentStamina < maxStamina && currentStamina > (maxStamina/2))
		{
			StaminaMeter.GetComponent<Image>().color = new Color(0.225f, 0.553f, 0.868f, 1.000f);
		}
		
		if(currentStamina<maxStamina)
		{
			currentStamina += 0.02f;
		}

		if(currentShield<maxShield)
		{
			currentShield += 0.02f;
		}

		if(currentHealth<maxHealth)
		{
			currentHealth += 0.01f;
		}

		if(currentHealth< 0)
		{
			currentHealth = 0;
		}

		if(currentShield < 0)
		{
			currentShield = 0;
		}

		if(currentStamina < 0)
		{
			currentStamina = 0;
		}

		HealthMeter.GetComponent<RectTransform>().localScale = new Vector3(currentHealth / maxHealth, 1, 1);

        StaminaMeter.GetComponent<RectTransform>().localScale = new Vector3(currentStamina / maxStamina, 1, 1);

		ShieldMeter.GetComponent<RectTransform>().localScale = new Vector3(currentShield / maxShield, 1, 1);	
	}
}
