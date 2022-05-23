FROM ubuntu:20.04 as build 
RUN apt-get update && apt-get install -y  build-essential
WORKDIR /app
COPY src/hello.c /app/
RUN gcc -o hello -static hello.c
# Is going to the database of all the APT packages, the compiler, the libraries (build essential)

FROM alpine:3.15.0 as final
WORKDIR /app/
COPY --from=build /app/hello ./
ENTRYPOINT [ "/app/hello" ]

