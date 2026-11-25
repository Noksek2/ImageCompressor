gcc gtkmain.c -o gtkmain $(pkg-config --cflags --libs gtk+-3.0)
./gtkmain
