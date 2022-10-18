using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StarGenerator : MonoBehaviour
{
    public static StarGenerator instance;
    #region Input
    public TMP_InputField starNameInput;
    public TMP_InputField decInput;
    public TMP_InputField raInput;
    public TMP_Dropdown typeDropdown;
    public TMP_Dropdown brightnessDropdown;
    public List<GameObject> starTypeList = new List<GameObject>();
    public List<GameObject> starBrightnessList = new List<GameObject>();
    #endregion

    //õ��
    public GameObject CelestialSpehere;
    //õ�� ������
    public float celestialSphereRadius;
    //�� �̸�
    public string starName;
    //����
    public float dec;
    //����
    public float ra;
    //�� ����
    public GameObject starType;
    //�� ���
    public GameObject brightness;

    public GameObject player;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        typeDropdown.onValueChanged.AddListener(OnTypeDropDownEvent);
        brightnessDropdown.onValueChanged.AddListener(OnBrightnessDropDownEvent);
        typeDropdown.ClearOptions();
        brightnessDropdown.ClearOptions();
    }
    // Start is called before the first frame update
    void Start()
    {
        typeDropdownSet();
        brightnessDropDownSet();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(starNameInput.text !="") starName = starNameInput.text;
        if (decInput.text != "") dec = float.Parse(decInput.text);
        if (raInput.text != "") ra = float.Parse(raInput.text);
    }
    public void typeDropdownSet()
    {
        List<TMP_Dropdown.OptionData> typeOptionList = new List<TMP_Dropdown.OptionData>();
        typeOptionList.Add(new TMP_Dropdown.OptionData("�����Ͻ� ���� ������ �����ϼ���"));
        foreach (GameObject type in starTypeList)
        {
            typeOptionList.Add(new TMP_Dropdown.OptionData(type.gameObject.name));
        }
        typeDropdown.AddOptions(typeOptionList);
        typeDropdown.value = 0;
    }

    public void brightnessDropDownSet()
    {
        List<TMP_Dropdown.OptionData> brightnessOptionList = new List<TMP_Dropdown.OptionData>();
        brightnessOptionList.Add(new TMP_Dropdown.OptionData("�����Ͻ� ���� ��⸦ �����ϼ���"));
        foreach (GameObject brightness in starBrightnessList)
        {
            brightnessOptionList.Add(new TMP_Dropdown.OptionData(brightness.gameObject.name));
        }
        brightnessDropdown.AddOptions(brightnessOptionList);
        brightnessDropdown.value = 0;
    }
    public void OnTypeDropDownEvent(int index)
    {
        starType = starTypeList[index - 1];
    }
    public void OnBrightnessDropDownEvent(int index)
    {
        brightness = starBrightnessList[index - 1];
    }
    public void OnGenerateStarBtn()
    {
        GameObject star = Instantiate(starType);
        star.transform.parent = CelestialSpehere.transform;
        dec = dec * (Mathf.PI / 180);
        dec = (Mathf.PI / 2) - dec;
        ra = ra * -15f * Mathf.PI / 180;
        var rr = celestialSphereRadius * Mathf.Sin(dec);
        float x = rr * Mathf.Sin(ra);
        float y = celestialSphereRadius * Mathf.Cos(dec);
        float z = rr * Mathf.Cos(ra);

        star.name = starName;
        star.transform.localPosition = new Vector3(x, y, z);
        player.GetComponent<PlayerRot>().StarSet(star.transform.position);
    }
}
