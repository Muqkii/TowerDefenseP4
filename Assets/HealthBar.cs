using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _timeToDrain = 0.25f;
    [SerializeField] private Gradient _healthBarGradient;

    private Image _image;
    private Camera _camera;
    private float _target;
    private Coroutine drainHealthBarCoroutine;

    private void Start()
    {
        _image = GetComponent<Image>();

        _camera = Camera.main;

    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _camera.transform.position);
    }
    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _target = currentHealth / maxHealth;

        drainHealthBarCoroutine = StartCoroutine(drainHealthBar());
    }

    private IEnumerator drainHealthBar()
    {
        float fillAmount = _image.fillAmount;

        float elapsedTime = 0f;
        while(elapsedTime < _timeToDrain)
        {
        elapsedTime += Time.deltaTime;

            _image.fillAmount = Mathf.Lerp(fillAmount, _target, (elapsedTime / _timeToDrain));

            yield return null;
        }
    }
}


