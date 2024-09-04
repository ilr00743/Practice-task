using TMPro;
using UnityEngine;
using PrimeTween;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _movingDuration = 2f;
    [SerializeField] private float _endValueY = 2f;
    [SerializeField] private float _fadeDuration = 1.5f;

    public void SetText(ItemType itemType, int quantity)
    {
        _text.SetText($"{itemType} +{quantity}");
    }

    public void PlayAnimation(Transform chestTransform)
    {
        var offset = new Vector3(chestTransform.position.x, chestTransform.position.y + 0.3f, chestTransform.position.z - 1);
        
        transform.position = offset;

        Tween.PositionY(transform, _endValueY, _movingDuration, Ease.Linear).OnComplete(() => Destroy(gameObject));
        Tween.Alpha(_text, endValue:0, _fadeDuration);
    }
}
