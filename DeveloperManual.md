# 개발자 매뉴얼

## 목차
1. [개요](#1-개요)
2. [요구사항 및 설치](#2-요구사항-및-설치)
   
## 1. 개요
본 프로젝트는 2024년 한양대학교 ERICA 캠퍼스의 강의 '가상및증강현실프로그래밍' 팀 프로젝트로서 진행되었습니다. [안산산업역사박물관](https://ansan.go.kr/aim/)과의 협업으로, 관람객을 위한 체혐형 콘텐츠입니다.

## 2. 요구사항 및 설치
### 2.1 하드웨어 요구사항
권장 기기는 [Meta(Oculus) Quest 3](https://www.meta.com/kr/quest/products/quest-3/)입니다. 또한 PC는 Unity 엔진의 권장사양을 충족해야 합니다. 또한, 원활한 개발을 위해서 QuestLink 와의 연동을 권장합니다. 이에 [최소권장사양](https://www.meta.com/ko-kr/help/quest/articles/headsets-and-accessories/oculus-link/requirements-quest-link/) 을 충족해야 합니다.

### 2.2 소프트웨어 요구사항
Unity 엔진의 2022.3.26f1 버전으로 개발을 진행했습니다.

### 2.3 에셋 요구사항
**본 프로젝트는 라이선스를 포함한 에셋을 사용하고 있습니다.**

### 2.4 설치 및 실행
1. 저장소를 clone하고 main 브랜치를 checkout 합니다.
2. File - Build Settings로 이동합니다.
3. Android로 Platform을 변경합니다.
4. Build 하여 Apk 파일을 생성합니다.
5. [Meta Quest Developer Hub](https://developer.oculus.com/documentation/unity/ts-odh/)를 다운로드하고 실행합니다.
6. 기기를 등록하고 USB로 연결합니다.
7. 디버깅 활성화 여부 팝업이 등장하면 "허용"을 누릅니다.
8. 실행하고자 하는 Apk 파일을 드래그하여 추가합니다.
9. 추가된 Apk의 우측 ... 버튼을 누르고 Launch App을 선택합니다.
10.  MetaQuest 내의 설치된 어플리케이션을 실행합니다.
