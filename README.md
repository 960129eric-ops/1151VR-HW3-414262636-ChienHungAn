https://github.com/960129eric-ops/1151VR-HW3-414262636-ChienHungAn
https://youtu.be/O4VjBI6Jd84


建立專案與素材匯入：
在 Unity 中建立一個新的 2D 專案。
匯入準備好的 2D 輪盤圖片（PNG 去背格式）至專案的 Assets 資料夾中，並拖曳至 Scene 畫面中作為遊戲物件。
撰寫輪盤控制腳本 (WheelController.cs)：
實作變速與音效控制機制，包含加速階段、維持最高速階段、減速階段。
使用 Coroutine（協程）來動態調整轉動速度（currentSpeed）與處理計時。
透過鍵盤事件（Input.GetKeyDown(KeyCode.Space)）來控制輪盤的啟動與停止，並連動音效的播放與關閉。
音效設定與綁定：
在輪盤物件上新增 Audio Source 元件，取消勾選 Play On Awake。
匯入音效檔案（Audio Clip），並透過 C# 腳本在啟動時自動載入並進行循環播放（Loop），在停止時呼叫 AudioSource.Stop() 關閉音效。



