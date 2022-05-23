FROM mycenv:v1
WORKDIR /app
COPY src/hello.c /app/
RUN gcc -o hello hello.c
ENTRYPOINT ["/app/hello"]