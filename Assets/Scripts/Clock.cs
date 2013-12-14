using UnityEngine;
{
    [SerializeField] private UILabel label; 
    private int minuts = 0;
    private float seconds = 0;
    private bool on = false;

    private void Start()
    {
        StartClock();
    }
    
    {
        if (on)
        {
            seconds += Time.deltaTime;
            if (seconds.ToString("f0") == "60" || seconds > 60)
            {
                minuts++;
                seconds -= 60;
            }
            string timeText = "";
            if (seconds.ToString("f0").Length < 2)
                timeText = minuts.ToString("f0") + ":0" + seconds.ToString("f0");
            else
                timeText = minuts.ToString("f0") + ":" + seconds.ToString("f0");

            label.text = timeText;
        }
    }
    {
        seconds = 0;
        minuts = 0;
        on = true;
    }