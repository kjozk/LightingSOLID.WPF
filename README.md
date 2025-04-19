# LightingSOLID.WPF

## �T�v
LightingSOLID.WPF �́A�Ɩ������ނɃI�u�W�F�N�g�w���v���O���~���O (OOP) ���w�Ԃ��߂� WPF �A�v���P�[�V�����ł��B���̃v���W�F�N�g�ł́A���ۂ̏Ɩ����̓��������f�������A�݌v�̒��� GOF (Gang of Four) �f�U�C���p�^�[���� SOLID �������ӎ������\�����̗p���Ă��܂��B

---

## ����
### 1. **�I�u�W�F�N�g�w���v���O���~���O (OOP) �̊w�K**
- �Ɩ����𒊏ۉ����A�C���^�[�t�F�[�X�⒊�ۃN���X�����p���đ��l�ȏƖ��������f�����B
- �p����|�����[�t�B�Y����ʂ��āA�R�[�h�̍ė��p���Ɗg�����������B
- ���ۂ̏Ɩ����̓����i���邳�A����d�́A�F���x�Ȃǁj���v���O�����ŕ\���B

### 2. **GOF �f�U�C���p�^�[���̓K�p**
- **Template Method �p�^�[��**:
  - `NonDimmableLightingDevice` �N���X�����N���X�Ƃ��āAHID �Ɩ����� LED �Ɩ����̋��ʓ�����e���v���[�g���B
- **Factory Method �p�^�[��**:
  - `LedLightingDeviceFactory` ���g�p���āA����� LED �Ɩ����i�����F�A�����F�A�d���F�Ȃǁj���ȒP�ɐ����B
- **Strategy �p�^�[��**:
  - �����\�ȃf�o�C�X (`DimmableLedDevice`) �ɂ����āA���邳�̑������W�b�N���_��ɐ؂�ւ��\�B

### 3. **SOLID �����Ɋ�Â��݌v**
- **�P��ӔC�̌��� (SRP)**:
  - �e�N���X�͒P��̐ӔC�������AUI ���W�b�N (`LightingDeviceViewModel`) �ƃr�W�l�X���W�b�N (`ILightingDevice`) �𖾊m�ɕ����B
- **�J��/���̌��� (OCP)**:
  - �V�����Ɩ�����ǉ�����ہA�����̃R�[�h��ύX�����Ɋg���\�B
- **���X�R�t�̒u������ (LSP)**:
  - `ILightingDevice` �C���^�[�t�F�[�X���������邷�ׂẴN���X�́A�u���\�Ȍ`�œ���B
- **�C���^�[�t�F�[�X�����̌��� (ISP)**:
  - `IDimmable` �C���^�[�t�F�[�X�𕪗����A�����@�\�������Ȃ��f�o�C�X�ɕs�v�Ȉˑ���r���B
- **�ˑ����t�]�̌��� (DIP)**:
  - �����x�����W���[���iUI ���W�b�N�j�́A�჌�x�����W���[���i��̓I�ȏƖ����N���X�j�Ɉˑ������A���ۉ����ꂽ�C���^�[�t�F�[�X�Ɉˑ��B

---

## ��ȃN���X�ƍ\��
### **1. �C���^�[�t�F�[�X**
- `ILightingDevice`:
  - �Ɩ����̊�{�I�ȑ���i�_���A�����A���邳�A����d�͂Ȃǁj���`�B
- `IDimmable`:
  - �����\�ȃf�o�C�X��p�̑���i���邳�̑����j���`�B

### **2. ���ۃN���X**
- `BasicLightingDevice`:
  - �����@�\�������Ȃ��Ɩ����̊��N���X�B
  - HID �Ɩ����� LED �Ɩ����̋��ʓ���������B
- `DimmableLedDevice`:
  - �����\�� LED �Ɩ�����\���B

### **3. ��ۃN���X**
- `MetalHalideLightingDevice`:
  - ���^���n���C�h��\���B

---

## �w�K�|�C���g
1. **OOP �̊�{�T�O**:
   - ���ۉ��A�J�v�Z�����A�p���A�|�����[�t�B�Y�������ۂ̃R�[�h�ő̌��B
2. **�݌v�p�^�[���̎��H**:
   - GOF �f�U�C���p�^�[����K�p�����݌v���w�K�B
3. **SOLID �����̓K�p**:
   - �ێ琫�Ɗg�������ӎ������݌v�̏d�v���𗝉��B
