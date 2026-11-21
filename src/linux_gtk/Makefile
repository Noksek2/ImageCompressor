CC = gcc
TARGET = app
SRCS = gtkmain.c
OBJS = $(SRCS:.c=.o)
GTK_L = pkg-config --cflags gtk+-3.0
GTK_R = pgk-config --libs gtk+-3.0

$(TARGET): $(OBJS)
	$(CC) $(GTK_L) $(CFLAGS) -o $(TARGET) $(GTK_R) $^

.PHONY: clean
clean:
	rm -f $(OBJS) $(TARGET)
