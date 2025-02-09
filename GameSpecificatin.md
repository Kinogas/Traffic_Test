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
<img src="https://github.com/user-attachments/assets/d0683258-0cb4-434f-a1e1-4f75fb57663a"
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
