using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] GameObject car;  //�Ԃ��A�^�b�`
    [SerializeField] float roadNormalLength;  // �����Ȃ����H�̒���
    [SerializeField] float roadWithCrosswalkLength;  // ���f�����̂��铹�H�̒���

    [SerializeField] int genetatingTrafficLightinterval; // �M���@�������Ă������H��1�񐶐�����邩
    int _generatingCount = 0;

    // �����Ȃ����H�𐶐�����m���� ( 100 - persentOfGeneratingCrosswalk ) [%]
    [SerializeField] int persentOfGeneratingCrosswalk; // ���f�����̂��铹�H�𐶐�����p�[�Z���g(�ő�100)

    // �M���@���̊m���� ( 100 - PersentOfRedTrafficLight ) [%]
    [SerializeField] int PersentOfRedTrafficLight; // �M���@���ԐM���̃p�[�Z���g(�ő�100)

    [SerializeField] GameObject roadNormal;
    [SerializeField] GameObject roadStopArea;
    [SerializeField] GameObject roadZebra;

    float _roadGeneratingPosition;  // �Ԃ̈ʒu�������𒴂�����V�������H�����
    float _allRoadLength; // �����铹�H�̒����̍��v
    
    void Start()
    {
        _roadGeneratingPosition = 0;
        _allRoadLength = 2 * roadNormalLength;
    }

    void Update()
    {
        if (car.transform.position.z > _roadGeneratingPosition)
        {
            int randomNumForCrossWalk = Random.Range(0, 100); // ���f�����̂��铹�H�𐶐����邩�ǂ����̂��߂̗���
            if (randomNumForCrossWalk < persentOfGeneratingCrosswalk && _generatingCount == 0)
            {
                // ���ɓ��H�𐶐�����ꏊ��V�����ݒ肷��
                _roadGeneratingPosition += roadWithCrosswalkLength;

                int randomNumForTrafficLight = Random.Range(0, 100); // �M����Ԃɂ��邩�ǂ����̂��߂̗���
                if (randomNumForTrafficLight < PersentOfRedTrafficLight)
                {
                    // �����铹�H�̐�ɐԐM���t�����H�𐶐�����
                    Instantiate(roadStopArea, new Vector3(0, 0, _allRoadLength), Quaternion.Euler(0, 180, 0));
                }
                else
                {
                    // �����铹�H�̐�ɐM���t�����H�𐶐�����
                    Instantiate(roadZebra, new Vector3(0, 0, _allRoadLength), Quaternion.Euler(0, 180, 0));
                }

                _allRoadLength += roadWithCrosswalkLength;
                _generatingCount = genetatingTrafficLightinterval - 1;
            }
            else
            {
                // ���ɓ��H�𐶐�����ꏊ��V�����ݒ肷��
                _roadGeneratingPosition += roadNormalLength;

                // �����铹�H�̐�ɉ����Ȃ����H�𐶐�����
                Instantiate(roadNormal, new Vector3(0, 0, _allRoadLength),Quaternion.Euler(0, 180, 0));

                _allRoadLength += roadNormalLength;

                if (_generatingCount > 0)
                    _generatingCount--;
            }
        }
    }
}
