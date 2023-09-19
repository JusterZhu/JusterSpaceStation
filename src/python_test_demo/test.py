import pyautogui

# 找到按钮图像位置 (这里需要一张按钮的截图，命名为'button.png')
button_location = pyautogui.locateOnScreen('button.jpg')

if button_location:
    # 计算按钮中心点位置
    button_center = pyautogui.center(button_location)
    
    # 移动鼠标至按钮中心并点击
    pyautogui.moveTo(button_center)
    pyautogui.click()
else:
    print("Button not found on screen.")
