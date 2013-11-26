//You can use only one script to all your scenes with all your methods or use one by scene
using UnityEngine;
using System.Collections;

public class GUIDesignGeneric : GUIDesign {

    public void ShowCode(object[] objs) {
        HTMLElement code = html.AllElements.Find(n => n.Id == "code");
        code.Visible = !code.Visible;

        HTMLElement htmlCode = html.AllElements.Find(n => n.Id == "htmlCode");
        htmlCode.Value = html.TextHTML;

        HTMLElement cssCode = html.AllElements.Find(n => n.Id == "cssCode");
        cssCode.Value = css.TextCSS;
    }

    public void ShowResults(object[] objs) {
        HTMLElement results = html.AllElements.Find(n => n.Id == "results");
        results.Visible = !results.Visible;

        html.AllElements.ForEach(n => n.Enable = n.ZIndex < results.ZIndex ? false : true);

        HTMLElement tdName = html.AllElements.Find(n => n.Id == "tdName");
        tdName.Text = html.AllElements.Find(n => n.Id == "name").Value;

        HTMLElement tdRace = html.AllElements.Find(n => n.Id == "tdRace");
        tdRace.Text = HTMLElement.GetChecked("race").Value;

        HTMLElement tdTeam = html.AllElements.Find(n => n.Id == "tdTeam");
        tdTeam.Text = HTMLElement.GetChecked("team").Value;

        HTMLElement tdSounds = html.AllElements.Find(n => n.Id == "tdSounds");
        HTMLElement sounds = (HTMLElement)html.AllElements.Find(n => n.Id == "sounds");
        tdSounds.Text = Mathf.RoundToInt(sounds.SlideValue).ToString();

        HTMLElement tdVolume = html.AllElements.Find(n => n.Id == "tdVolume");
        HTMLElement volume = (HTMLElement)html.AllElements.Find(n => n.Id == "volume");
        tdVolume.Text = Mathf.RoundToInt(volume.SlideValue).ToString();
    }

    public void CloseResults(object[] objs) {
        ((HTMLElement)objs[0]).Parent.Parent.Visible = false;
        html.AllElements.ForEach(n => n.Enable = true);
    }

    public void LevelSelected(object[] objs) {
        HTMLElement htmlElement = (HTMLElement)objs[0];
        if (htmlElement.Value == "0") {
            htmlElement.Value = "1";
            htmlElement.Image = (Texture2D)Resources.Load("Images/unlock");
        } else if (htmlElement.Value == "1") {
            htmlElement.Value = "0";
            htmlElement.Image = (Texture2D)Resources.Load("Images/lock");
        }
    }
}
