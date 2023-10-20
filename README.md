
<div align="center">
<h1>[오함마]Crazy_Zookeeper🎮</h1>
평화로운 동물농장, 🍄버섯을 먹고 미쳐버린 사육사를 🦛다섯 하마들이 구하는 게임입니다.<br> 각각의 미니게임 형식의 3스테이지 플레이어를 통해 플레이어가 하마가 되어서<br> 사육사를 치료하기 위한 미션과 전투를 수행합니다.<br> 플레이어는 하마가 되어 미쳐버린 사육사를 구하는 스릴을 느낄 수 있습니다
</div>
<br>


## 목차
- [개요](#개요)
- [FrameWork](#Framework)
- [게임 설명](#게임-설명)
- [게임 플레이 방식](#게임-플레이-방식)
- [게임 소개 영상](#게임-소개-영상)
<br>

## 개요
- **프로젝트 이름** : Crazy Zookeeper 🏠
- **프로젝트 지속기간** : 2023 .10 .12 - 2023 .10 .20
- **개발 엔진 및 언어** : Unity & C#
- **멤버** : 김어진, 어하림, 김윤경, 최하나, 박민호, 우성훈
<br>

## FrameWork
- **김어진** : 팀장, Hippo Character, Menu, IntroScene, StartScene, EndScene
- **우성훈** : Stage1, Map, Player Controller, Stage Fail, Stage Clear
- **어하림** : Stage2, Map, Sound Source, Project Video
- **박민호** : Stage2, Player Controller, Enemy, NPC, Interactable
- **김윤경** : Stage3, Map, Player Controller, Zookeeper Controller, Potion, Cinemachine
- **최하나** : Stage3, State UI, State System, Sound
<br>

## 게임 설명
- **Intro Scene** : 평화롭던 어느날 미치광이 버섯을 먹어버린 사육사
광기로 미쳐 날뛰기 시작한다는 게임 시작 줄거리 영상 씬, 6개의 장면을 TimeLine을 통해 연결, Skip 버튼으로 StartScene 이동
- **Start Scene** :  각 스테이지 클리어 시 해금 기능
- **Stage1** : 120초의 제한시간 안에 출구를 찾아 도망치는 게임, 탈출 성공 시 Enter로 다음 Stage 이동
- **Stage2** : 적을 피해 맵을 탐험하며 사육사를 치료할 단서 찾기, Q키로 사물 또는 NPC와 상호작용, 적과 부딪히면 GameOver, 나무를 도끼로 찍어 치료제 수액 얻기, Enter로 다음 Stage 이동
- **Boss Intro** : Cinemachine을 사용해서 제작한 사육사와 하마의 결투 시작 영상
- **Stage3** : 사육사와의 전투(보스), 맵에 숨겨진 Potion으로 HP를 채우며 사육사와의 전투에서 승리하기
- **End Scene** : 사육사를 기절시킨 다섯 하마들은 빠르게 치료제를 투여하고, 원래 모습으로 돌아온 사육사는 감동하여 답답한 우리가 아닌 아름다운 산과 호수가 있는 곳에서 함께 추억을 쌓기로 결심하는 장면 To a new journey...
<br>

## 게임 플레이 방식
- 캐릭터 이동 방법

|이동방향|상(위)|좌(왼쪽)|하(아래)|우(오른쪽)|대쉬|점프|공격|
|---|---|---|---|---|---|---|---|
|키보드| W | A | S | D ||||
|방향키|⬆️|⬅️|⬇️|➡️|SHIFT|SPACE BAR|MOUSE_LEFT|
<br>

- 게임 순서

|Start|Stage1|Stage2|Stage3|
|---|---|---|---|
|![image](https://github.com/coco0715/ReadMe_Study/assets/101281567/0de58f47-6ece-44ba-8974-cad448ea1908)|![image](https://github.com/coco0715/ReadMe_Study/assets/101281567/9a0f0f04-0cae-46e1-a599-d704d84ef503)|![image](https://github.com/coco0715/ReadMe_Study/assets/101281567/56a3e650-74a1-40df-b9e7-3f964fde71b3)|![image](https://github.com/coco0715/ReadMe_Study/assets/101281567/8a2cbb49-9b4f-474b-8b3c-070b1f38832f)|
|게임시작화면|사육실 탈출하기|해독제 만들기|사육사와 전투, 해독제 투여|
<br>

## 게임 소개 영상
https://github.com/coco0715/ReadMe_Study/assets/101281567/8284f473-d0b2-4bed-86aa-6869caa8f220
<br>
