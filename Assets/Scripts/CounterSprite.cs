using UnityEngine;
{
    [SerializeField] private TextChild textChild = null;
    private Vector3 stPos = Vector3.zero;
    {
        stPos = transform.localPosition;
    }
    
    private void Update()
    {
        transform.localPosition = new Vector3(stPos.x + textChild.RightAnswer * 10, stPos.y,
                                              stPos.z);
    }