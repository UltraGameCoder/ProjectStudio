using UnityEngine;
using UnityEngine.UI;
using System.IO;
using YamlDotNet.RepresentationModel;

public enum QuestionState {
    FIRST,
    SECOND
}

public class SituationPanelScript : MonoBehaviour {

    public TextAsset textFile;
    public int rightAnswer = 0;
    public Text question;
    public Text[] answers;

    private HurtPersonScript person;

    // Use this for initialization
    void Start () {
        print(textFile.text);
        loadFile();
    }

    public void nextState() {
        if (person.state == QuestionState.FIRST) {
            person.state = QuestionState.SECOND;
            loadFile();
        }
    }

    public void loadFile() {
        var input = new StringReader(textFile.text);

        // Load the stream
        var yaml = new YamlStream();
        yaml.Load(input);

        // Examine the stream
        var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

        /*
        foreach(var entry in mapping.Children) {
            Debug.Log(( (YamlScalarNode)entry.Key ).Value);
        }
        */

        if(person.state == QuestionState.FIRST) {
            question.text = mapping.Children[new YamlScalarNode("Question1")].ToString();
            rightAnswer = int.Parse(mapping.Children[new YamlScalarNode("FirstRightAnswer")].ToString());
        } else if(person.state == QuestionState.SECOND) {
            question.text = mapping.Children[new YamlScalarNode("Question2")].ToString();
            rightAnswer = int.Parse(mapping.Children[new YamlScalarNode("SecondRightAnswer")].ToString());
        }

        var answersSection = (YamlMappingNode)mapping.Children[new YamlScalarNode("Answers")];

        answers[0].text = (answersSection.Children[new YamlScalarNode("1")] ).ToString();
        answers[1].text = (answersSection.Children[new YamlScalarNode("2")] ).ToString();
        answers[2].text = (answersSection.Children[new YamlScalarNode("3")] ).ToString();
        answers[3].text = (answersSection.Children[new YamlScalarNode("4")] ).ToString();
    }

    public int getRightAnswer() {
        return this.rightAnswer;
    }

    public void setPerson(HurtPersonScript p) {
        this.person = p;
    }

    public HurtPersonScript getPerson() {
        return this.person;
    }
}
