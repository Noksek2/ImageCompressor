CC = gcc
TARGET = app
SRCS = gtkmain.c
GTK_R = $(shell pgk-config --cflags --libs gtk+-3.0)

$(TARGET): $(SRCS)
	$(CC) $(SRCS) -o $@ $(GTK_R) $^

.PHONY: clean
clean:
	rm -f $(OBJS) $(TARGET)
