try:
    import paramiko
    import filecmp
    import os
    import zipfile
except:
    import os
    os.system("pip install paramiko")
    import paramiko
    import filecmp
    import zipfile

host = "capstonekiosk.koreacentral.cloudapp.azure.com"
port = 22
username = "ftpuser"
password = "itisanon"
if os.path.exists("c:\Kiosk"):
    os.chdir(r'c:\Kiosk')
else:
    os.mkdir(r"c:\Kiosk")
    os.chdir(r'c:\Kiosk')

transport = paramiko.Transport((host, port))
transport.connect(username=username, password=password)

sftp = paramiko.SFTPClient.from_transport(transport)

remote_path = "KioskHash.txt"
local_path = "hash.txt"
sftp.get(remote_path, local_path)
if os.path.isfile("KioskHash.txt"):
    if filecmp.cmp(remote_path, local_path):
        print("프로그램이 최신버전입니다.")
    else:
        print("업데이트를 시작합니다.")
        transport = paramiko.Transport((host, port))
        transport.connect(username=username, password=password)
        sftp = paramiko.SFTPClient.from_transport(transport)
        remote_path = "Kiosk.zip"
        local_path = "Kiosk.zip"
        sftp.get(remote_path, local_path)
        os.remove("KioskHash.txt")
        os.rename("hash.txt","KioskHash.txt")
        print("압축을 해제합니다.")
        with zipfile.ZipFile('Kiosk.zip', 'r') as zip_file:
            zip_file.extractall()
else:
    print("프로그램 초기 설정을 시작합니다.")
    transport = paramiko.Transport((host, port))
    transport.connect(username=username, password=password)
    sftp = paramiko.SFTPClient.from_transport(transport)
    remote_path = "Kiosk.zip"
    local_path = "Kiosk.zip"
    sftp.get(remote_path, local_path)
    os.rename("hash.txt","KioskHash.txt")
    print("압축을 해제합니다.")
    with zipfile.ZipFile('Kiosk.zip', 'r') as zip_file:
        zip_file.extractall()

sftp.close()
transport.close()

print("프로그램을 시작합니다.")

import subprocess
os.chdir(r'c:\Kiosk')
subprocess.run(r'.\Kiosk_UI.exe', capture_output=True, text=True)


os.chdir(r'c:\Kiosk')

transport = paramiko.Transport((host, port))
transport.connect(username=username, password=password)

sftp = paramiko.SFTPClient.from_transport(transport)

remote_path = "KioskHash.txt"
local_path = "hash.txt"
sftp.get(remote_path, local_path)
if os.path.isfile("KioskHash.txt"):
    if filecmp.cmp(remote_path, local_path):
        print("프로그램이 최신버전입니다.")
    else:
        print("업데이트를 시작합니다.")
        transport = paramiko.Transport((host, port))
        transport.connect(username=username, password=password)
        sftp = paramiko.SFTPClient.from_transport(transport)
        remote_path = "Kiosk.zip"
        local_path = "Kiosk.zip"
        sftp.get(remote_path, local_path)
        os.remove("KioskHash.txt")
        os.rename("hash.txt","KioskHash.txt")
        print("압축을 해제합니다.")
        with zipfile.ZipFile('Kiosk.zip', 'r') as zip_file:
            zip_file.extractall()
else:
    print("프로그램 초기 설정을 시작합니다.")
    transport = paramiko.Transport((host, port))
    transport.connect(username=username, password=password)
    sftp = paramiko.SFTPClient.from_transport(transport)
    remote_path = "Kiosk.zip"
    local_path = "Kiosk.zip"
    sftp.get(remote_path, local_path)
    os.rename("hash.txt","KioskHash.txt")
    print("압축을 해제합니다.")
    with zipfile.ZipFile('Kiosk.zip', 'r') as zip_file:
        zip_file.extractall()

sftp.close()
transport.close()

transport = paramiko.Transport((host, port))
transport.connect(username=username, password=password)

sftp = paramiko.SFTPClient.from_transport(transport)

remote_path = "KioskHash.txt"
local_path = "hash.txt"
sftp.get(remote_path, local_path)
if os.path.isfile("KioskHash.txt"):
    if filecmp.cmp(remote_path, local_path):
        print("프로그램이 최신버전입니다.")
    else:
        print("업데이트를 시작합니다.")
        transport = paramiko.Transport((host, port))
        transport.connect(username=username, password=password)
        sftp = paramiko.SFTPClient.from_transport(transport)
        remote_path = "Kiosk.zip"
        local_path = "Kiosk.zip"
        sftp.get(remote_path, local_path)
        os.remove("KioskHash.txt")
        os.rename("hash.txt","KioskHash.txt")
        print("압축을 해제합니다.")
        with zipfile.ZipFile('Kiosk.zip', 'r') as zip_file:
            zip_file.extractall()
else:
    print("프로그램 초기 설정을 시작합니다.")
    transport = paramiko.Transport((host, port))
    transport.connect(username=username, password=password)
    sftp = paramiko.SFTPClient.from_transport(transport)
    remote_path = "Kiosk.zip"
    local_path = "Kiosk.zip"
    sftp.get(remote_path, local_path)
    os.rename("hash.txt","KioskHash.txt")
    print("압축을 해제합니다.")
    with zipfile.ZipFile('Kiosk.zip', 'r') as zip_file:
        zip_file.extractall()

sftp.close()
transport.close()

print("프로그램을 종료합니다.")