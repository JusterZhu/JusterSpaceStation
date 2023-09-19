from pywinauto.application import Application
import time

# 启动应用程序
app = Application(backend="uia").start("D:/git_community/JusterSpaceStation/src/python_test_demo/ava/WpfApp1/bin/Debug/net6.0-windows/WpfApp1.exe")

time.sleep(1)  # Wait for 5 seconds

# 选择窗口
dlg = app.window(title='MainWindow')

# 在密码框中输入内容 , control_type="TextBox"
dlg.child_window(auto_id="TxboxPwd").type_keys('123')
# 点击登录按钮 , control_type="Button"
dlg.child_window(auto_id="BtnOK").click()
