using UnityEngine;
using UnityEngine.UI;
using System.IO;
using YamlDotNet.RepresentationModel;

public class SituationPanelScript : MonoBehaviour {

    public TextAsset textFile;
    public int rightAnswer = 0;
    public Text question;
    public Text[] answers;

	// Use this for initialization
	void Start () {
        print(textFile.text);
        loadFile();
    }

    private void loadFile() {
        var input = new StringReader(textFile.text);

        // Load the stream
        var yaml = new YamlStream();
        yaml.Load(input);

        // Examine the stream
        var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

        foreach(var entry in mapping.Children) {
            Debug.Log(( (YamlScalarNode)entry.Key ).Value);
        }

        question.text = mapping.Children[new YamlScalarNode("Question")].ToString();

        rightAnswer = int.Parse(mapping.Children[new YamlScalarNode("RightAnswer")].ToString());

        var answersSection = (YamlMappingNode)mapping.Children[new YamlScalarNode("Answers")];

        answers[0].text = (answersSection.Children[new YamlScalarNode("1")] ).ToString();
        answers[1].text = (answersSection.Children[new YamlScalarNode("2")] ).ToString();
        answers[2].text = (answersSection.Children[new YamlScalarNode("3")] ).ToString();
        answers[3].text = (answersSection.Children[new YamlScalarNode("4")] ).ToString();
    }
}
