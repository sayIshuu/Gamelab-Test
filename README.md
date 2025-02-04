# Gamelab-Test

### 🛠 제작 정보
- **제작 인원**: 1명  
- **제작 기간**: 1일  

---

## 🎮 게임 소개  

### **제작 의도**  
이 게임은 여러 장르의 핵심 재미를 결합하여 개발되었습니다.  

- **전략적인 퍼즐 요소**: 목표 달성을 위해 플레이 전체를 설계해야 하는 **스노우볼** 요소  
- **심리적 압박감 제공**: **시간 제한이 아닌 요소**로 몰입도를 높이는 게임 디자인  

<p align="center">
  <table>
    <tr>
      <td align="center">
        <img src="https://github.com/user-attachments/assets/f8dbfa38-a85a-4909-904d-a466de1c0e56" width="400">
      </td>
      <td align="center">
        <img src="https://github.com/user-attachments/assets/233924f6-09c6-4854-aff8-f2a16bab9ffa" width="400">
      </td>
    </tr>
  </table>
</p>

- 개발적 의의 : A* 알고리즘 활용해보기

---

## 🚀 게임 진행  

### **MOVE & SHOOT!**  
플레이어는 **이동할 때마다 총알이 장전되는 시스템**을 활용해 적들을 물리쳐야 합니다.

<table>
  <tr>
    <td align="left">
      <img src="https://github.com/user-attachments/assets/c3d4a1a7-7164-4b65-8aec-cf352d9e333a" width="200">
    </td>
    <td>
      <strong>🎮 조작 방법</strong><br>
      - <strong>이동</strong>: 방향키 (↑↓←→) <br>
      - <strong>총알 발사</strong>: W, A, S, D <br><br>
      플레이어의 이동과 총알 발사는 <br>
      <strong>상하좌우 방향</strong>으로만 가능하며, <br>
      적들도 <strong>최단 거리 경로</strong>를 따라 이동합니다.
    </td>
  </tr>
</table>

---

## ⚔️ 게임 규칙  

**최단거리로 다가오는 적들을 모두 물리쳐 살아남으세요!**  

<table>
  <tr>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/4889abe3-b329-4393-af5b-420f656ecee2" width="200">
      <br>
      <b>Enemy Type 01</b>
      <p>최단거리로 한 타일씩 다가옵니다.</p>
    </td>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/1eb2869e-2f7e-4b56-9041-51316f5edf18" width="200">
      <br>
      <b>Enemy Type 02</b>
      <p>최단거리로 두 타일씩 다가오며, <br> Enemy Type 01을 방패로 삼을 수 있습니다.</p>
    </td>
  </tr>
</table>

---

## 🔥 발전 방향  

현재는 **단일 스테이지**로 구성되어 있지만, 다음과 같은 방식으로 확장할 계획입니다.  

### 📌 난이도 조절 요소  
- **맵 구성** 변화  
- **적의 수 및 종류** 추가  
- **플레이어와 적의 행동 패턴 조정**  
  - **이동을 한 턴 쉬어야 하는 타일**  
  - **플레이어처럼 총을 쏘는 적 등장**  
  - **한 턴에 발사할 수 있는 총알 개수 조절**  

이러한 확장을 고려하여, **인스펙터에서 변수 조정을 통해 난이도를 유연하게 조절할 수 있도록 개발**하였습니다.  

---
