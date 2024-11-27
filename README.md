***

# ゲーム開発強化月間
チームメンバー
- 原佑心
- 塚本清美
- 石川天琉

## プロジェクトの目的
**Unity**でゲームを**短期間**で**チーム開発**する。

## 開発期間
11/28-12/25


***


# プロジェクト名-チキチキ信号ゲーム（仮）

直線道路を走っている車が、

信号の色を見極め適切な停止位置で止まりながら、

できるだけ遠くに進み、

ハイスコアを目指すランゲーム。

## 仕様

### 概要
- 青信号と赤信号がランダムで向かってくる
- 赤信号が来たら止まる
- 赤信号の時に停止線を超えるか停止線の手前で止まりすぎたらゲームオーバー
- ゲームオーバーになるまで続けてスコアを稼ぐ

### 目的
- ゲームオーバーを避けながらハイスコアを目指す


### 操作
- ボタン一つでブレーキを操作する。

### 画面構成
<img src="https://private-user-images.githubusercontent.com/146317421/390507809-5d4d4236-876b-43ca-8621-76c20dc2c013.jpg?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MzI3MjgzMzgsIm5iZiI6MTczMjcyODAzOCwicGF0aCI6Ii8xNDYzMTc0MjEvMzkwNTA3ODA5LTVkNGQ0MjM2LTg3NmItNDNjYS04NjIxLTc2YzIwZGMyYzAxMy5qcGc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjQxMTI3JTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI0MTEyN1QxNzIwMzhaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT1iZTZkOWE0ZTE2MmNmYjk0ZjE1YmRhOWFmOGQ0NmNhZTdkODg0MTQ4NDY0NGM5NGQ4NmY2N2E5NjA0MWE1YTJhJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCJ9.1jbiGr_IMH7p961yh99AuE2jwkxGn12ljnwn21qxVGA"
 width="200">
- 上記画像のように車、信号、道路、停止ライン、俯瞰マップがある。

### ゲームオブジェクト
#### 車
- 信号間は一定の速さで走る
- たくさん進むほど速くなり難易度が上がる
- ブレーキボタンで停止（制動距離あり）

#### 信号
- 青信号と赤信号がランダムで向かってくる
- 赤信号と青信号は走っている途中で切り替わらない
- 赤信号で車が適切に止まれば青になる


#### スコア
- 進んだ距離でスコアが加算
- 赤信号で止まった時に、停止線からの距離に応じてスコアが加算
- 赤信号で停止時に加算されるスコアの重みを重くする


***

# 活動記録

## 2024年11月27日
- 時間：20:00から25:00
- 場所：Discord
- 参加者：全員
- 書記(README)：原佑心

### 成果
- 作るゲームの大まかなコンセプトを決定し、全員で認識をすり合わせた
- GitHubの環境構築
- READMEのひな型作成

### 次回やること
- GitHubの環境構築の続き(conflictの解決など)
- 作業の分配


