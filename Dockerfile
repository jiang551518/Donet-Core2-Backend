FROM golang
WORKDIR /go
ADD server /go
CMD ["./server"]
