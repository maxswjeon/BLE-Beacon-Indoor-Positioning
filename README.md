# Mapo2019
마포탐구발표대회 제작형 - 하이파이브  
20129 전상완, 20130 정윤석  
블루투스 비컨을 이용한 실내 위치 측위의 새로운 패러다임 제시 및 장단점 비교  

이 Github Repository는 연구를 진행하며 생성된 모든 자료들을 담고 있습니다.

Beacon Scanner Install Scipt 등의 소스는 다음 링크에서 확인할 수 있습니다.  
https://gist.github.com/maxswjeon/7524ae1acd2e6a18fbcb16016c2c6230

## Data
실험 측정 값 (원자료), 분석 값을 확인할 수 있게 원본 데이터를 그대로 업로드 하였습니다.  

## Source
### BeaconManager
C#으로 제작된 툴로, 실험 전반적으로 사용된 툴입니다. 비컨 데이터 수신 및 분석, Kalman Filter 적용 등의 기능을 가지고 있습니다.

### BeaconScan
Python으로 제작된 스크립트로, 스캐너 내부에 들어가는 소스와 데이터 처리를 위해 일시적으로 사용했던 스크립트가 포함되어 있습니다.

### BeaconScnner
C++로 개발 시도했던 소스입니다. 실제 실험이나 연구에 직접적인 영향은 끼치지 않았습니다. 

