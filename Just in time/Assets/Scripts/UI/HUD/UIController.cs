using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;

    private PlayerAttributes _playerAttributes;

    private void Start()
    {
        _playerAttributes = GameController.SPlayer.PlayerAttributes;
        hpSlider.maxValue = _playerAttributes.MaxHealthPoints;
    }

    private void Update()
    {
        hpSlider.value = _playerAttributes.HealthPoints;
    }
}
