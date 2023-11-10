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

def releaseOrDebug():
    print("1. 디버그 \n2. 릴리즈")
    debugOrRelease = input("값을 입력하세요 :")
    if int(debugOrRelease) == 1:
        return "Kiosk_UI\\bin\Debug\\"
    elif int(debugOrRelease) == 2:
        return "Kiosk_UI\\bin\\x64\\Release\\"
    else:
        print("올바른 값을 입력하세요.")
        return 0

host = "capstonekiosk.koreacentral.cloudapp.azure.com"
port = 22

username = input("username을 입력하세요.: ")
password = input("password를 입력하세요.: ")

count=3
while(count):
    try:
        transport = paramiko.Transport((host, port))
        transport.connect(username=username, password=password)
        break
    except:
        print("오류 발생")
        username = input("username을 입력하세요.: ")
        password = input("password를 입력하세요.: ")
        count-=1
if count == 0:
    print("에러가 발생하였습니다. username,password를 확인하세요.")
else:
    directory_path=0
    while(directory_path == 0):
        directory_path=releaseOrDebug()
        print("선택된 디렉토리 경로:", directory_path)
    print("키오스크 실행파일 압축 시작")
    
    output_zip_path =  "Kiosk.zip"
    with zipfile.ZipFile(output_zip_path, "w") as zipFile:
        for root, dirs, files in os.walk(directory_path):
            for file in files:
                file_path = os.path.join(root, file)
                rel_path = os.path.relpath(file_path, directory_path)
                zipFile.write(file_path, arcname=os.path.join(os.path.basename(directory_path), rel_path), compress_type=zipfile.ZIP_DEFLATED)
    print("업로드 시작")
    ssh = paramiko.SSHClient()
    ssh.set_missing_host_key_policy(paramiko.AutoAddPolicy())
    ssh.connect(hostname=host, username=username, password=password)
    sftp = paramiko.SFTPClient.from_transport(transport)
    sftp.put("Kiosk.zip","Kiosk.zip")

    stdin, stdout, stderr = ssh.exec_command('sh /home/azureuser/makeHash.sh')
    # 결과 출력
    print(stdout.read().decode())
    print(stderr.read().decode())
    ssh.close()

    