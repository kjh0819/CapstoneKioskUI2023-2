#의존성 해결
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
#주소 및 계정 설정
host = "capstonekiosk.koreacentral.cloudapp.azure.com"
port = 22
username = "ftpuser"
password = "itisanon"

#키오스크 소프트웨어 존재여부 확인
if os.path.exists("c:\Kiosk"):
    os.chdir(r'c:\Kiosk')
else:
    os.mkdir(r"c:\Kiosk")
    os.chdir(r'c:\Kiosk')

#서버 연결
transport = paramiko.Transport((host, port))
transport.connect(username=username, password=password)

sftp = paramiko.SFTPClient.from_transport(transport)

#서버에서 Hash다운로드
remote_path = "KioskHash.txt"
local_path = "hash.txt"
sftp.get(remote_path, local_path)

#프로그램의 초기실행이 아니라면
if os.path.isfile("KioskHash.txt"):
    #로컬과 클라우드의 hash값 비교
    if filecmp.cmp(remote_path, local_path):
        print("프로그램이 최신버전입니다.")
    #만약 해쉬값이 다르다면
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
#프로그램의 초기 실행 이라면
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

#키오스크 소프트웨어 실행
import subprocess
os.chdir(r'c:\Kiosk')
subprocess.run(r'.\Kiosk_UI.exe', capture_output=True, text=True)

#키오스크 소프트웨어가 종료 된 후
os.chdir(r'c:\Kiosk')

#위의 코드와 마찬가지로 업데이트 시행
#함수화 요함
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