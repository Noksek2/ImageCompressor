/*
MIT LICENSE
 gcc `pkg-config --cflags gtk+-3.0` gtkmain.c -o hello `pkg-config --libs gtk+-3.0`
*/
#include <gtk/gtk.h>
typedef struct {
	GtkWidget* entry;
	GtkWidget* combo;
	GtkWidget* comboRotate;
	GtkWidget* comboFlip;
	GtkWidget* spinQuality;
} AppWidgets;
enum {
	CONV_TO_PNG,
	CONV_TO_JPG,
	CONV_TO_BMP,
	CONV_TO_WEBP,
};
enum {
	FLIP_NONE,
	FLIP_X,
	FLIP_Y,
};
enum {
	ROTATE_NONE,
	ROTATE_90,
	ROTATE_180,
	ROTATE_270,
};
static void on_convert_clicked(GtkWidget *widget, gpointer data) {
    // 여기에 이미지 변환 로직 호출 (GdkPixbuf 활용 등)
	AppWidgets *ui=(AppWidgets*)data;
    g_print("변환 시작...\n");
	
	int quality = gtk_spin_button_get_value_as_int ((GtkSpinButton*)ui->spinQuality);
	g_print("quality %d\n",quality);
    int index = gtk_combo_box_get_active(GTK_COMBO_BOX(ui->combo));
	switch(index) {
		case CONV_TO_PNG:
		g_print("to png\n");
		break;
		case CONV_TO_JPG:
		g_print("to jpg\n");
		break;
		case CONV_TO_BMP:
		g_print("to bmp\n");
		break;
		case CONV_TO_WEBP:
		g_print("to webp\n");
		break;
	}
	int index_rotate = gtk_combo_box_get_active(GTK_COMBO_BOX(ui->comboRotate));
	switch(index_rotate) {
		case ROTATE_NONE:
		g_print("rot 0\n");
		break;
		case ROTATE_90:
		g_print("rot 90\n");
		break;
		case ROTATE_180:
		g_print("rot 180\n");
		break;
		case ROTATE_270:
		g_print("rot 270\n");
		break;
	}
	int index_flip = gtk_combo_box_get_active(GTK_COMBO_BOX(ui->comboFlip));
	switch(index_flip) {
		case FLIP_NONE:
		g_print("flip none\n");
		break;
		case FLIP_X:
		g_print("flip x\n");
		break;
		case FLIP_Y:
		g_print("flip y\n");
		break;
	}
	//g_free(
}
static void on_print(GtkWidget *widget, gpointer data){
	g_print("wtf");
}
void add_list_item(GtkWidget *listbox, const char *item_text) {
    GtkWidget *row;
    GtkWidget *label;

    label = gtk_label_new(item_text);
    row = gtk_list_box_row_new();

    // Add the label to the row (row acts as a container)
    gtk_container_add(GTK_CONTAINER(row), label); // For GTK3
    // For GTK4: gtk_list_box_row_set_child(GTK_LIST_BOX_ROW(row), label);

    gtk_widget_show_all(row); // Show all children within the row
    gtk_list_box_prepend(GTK_LIST_BOX(listbox), row); // Add the row to the list box
}
static void activate(GtkApplication *app, gpointer user_data) {
    GtkWidget *window;
    GtkWidget *box;
    GtkWidget *entry;
	GtkWidget *entry2;
    GtkWidget *combo;
	GtkWidget *combo2;
	GtkWidget *comboRotate;
    GtkWidget *button;
	GtkWidget *spinQuality;
	GtkWidget *check;
	AppWidgets* appWidget=g_slice_new(AppWidgets);

	
    window = gtk_application_window_new(app);
    gtk_window_set_title(GTK_WINDOW(window), "ImageCompressor");
    gtk_container_set_border_width(GTK_CONTAINER(window), 10);

    // 세로 배치 박스 생성
    box = gtk_box_new(GTK_ORIENTATION_VERTICAL, 6);//6:여백
    gtk_container_add(GTK_CONTAINER(window), box);

    // Combo Format
	combo = gtk_combo_box_text_new();
    gtk_combo_box_text_append_text(GTK_COMBO_BOX_TEXT(combo), "to .png");
    gtk_combo_box_text_append_text(GTK_COMBO_BOX_TEXT(combo), "to .jpg");
    gtk_combo_box_text_append_text(GTK_COMBO_BOX_TEXT(combo), "to .bmp");
    gtk_combo_box_text_append_text(GTK_COMBO_BOX_TEXT(combo), "to .webp");

    gtk_combo_box_set_active(GTK_COMBO_BOX(combo), 0);
    gtk_box_pack_start(GTK_BOX(box), combo, FALSE, FALSE, 0);
	
	// Quality
	GtkAdjustment *adjustment = gtk_adjustment_new (50.0, 0.0, 100.0, 1.0, 5.0, 0.0);

	spinQuality = gtk_spin_button_new (adjustment, 1.0, 0);
	gtk_box_pack_start(GTK_BOX(box), spinQuality, FALSE, FALSE, 0);
	
	
	// Flip
	combo2 = gtk_combo_box_text_new();
    gtk_combo_box_text_append_text(GTK_COMBO_BOX_TEXT(combo2), "none");
    gtk_combo_box_text_append_text(GTK_COMBO_BOX_TEXT(combo2), "X flip");
    gtk_combo_box_text_append_text(GTK_COMBO_BOX_TEXT(combo2), "Y flip");

    gtk_combo_box_set_active(GTK_COMBO_BOX(combo2), 0);
    gtk_box_pack_start(GTK_BOX(box), combo2, FALSE, FALSE, 0);
	
	// Rotate
	comboRotate = gtk_combo_box_text_new();
    gtk_combo_box_text_append_text(GTK_COMBO_BOX_TEXT(comboRotate), "0");
    gtk_combo_box_text_append_text(GTK_COMBO_BOX_TEXT(comboRotate), "90");
    gtk_combo_box_text_append_text(GTK_COMBO_BOX_TEXT(comboRotate), "180");
	gtk_combo_box_text_append_text(GTK_COMBO_BOX_TEXT(comboRotate), "270(-90)");

    gtk_combo_box_set_active(GTK_COMBO_BOX(comboRotate), 0);
    gtk_box_pack_start(GTK_BOX(box), comboRotate, FALSE, FALSE, 0);
	
	
	
    entry = gtk_entry_new();
    gtk_entry_set_placeholder_text(GTK_ENTRY(entry), "write file path ... ");    
	gtk_box_pack_start(GTK_BOX(box), entry, FALSE, FALSE, 0);

	entry2 = gtk_entry_new();
    gtk_entry_set_placeholder_text(GTK_ENTRY(entry2), "Shit ");    
	gtk_box_pack_start(GTK_BOX(box), entry2, FALSE, FALSE, 0);
	
	entry2 = gtk_entry_new();
    gtk_entry_set_placeholder_text(GTK_ENTRY(entry2), "Shit ");    
	gtk_box_pack_start(GTK_BOX(box), entry2, FALSE, FALSE, 0);
	
	entry2 = gtk_entry_new();
    gtk_entry_set_placeholder_text(GTK_ENTRY(entry2), "Shit ");    
	gtk_box_pack_start(GTK_BOX(box), entry2, FALSE, FALSE, 0);
	
	entry2 = gtk_entry_new();
    gtk_entry_set_placeholder_text(GTK_ENTRY(entry2), "Shit ");    
	gtk_box_pack_start(GTK_BOX(box), entry2, FALSE, FALSE, 0);

	check = gtk_check_button_new_with_label("Output folder");
	gtk_box_pack_start(GTK_BOX(box), check, FALSE, FALSE, 0);

	//radio
	GtkWidget* radio;
	radio = gtk_radio_button_new(NULL);
	entry=gtk_entry_new();
	gtk_container_add(GTK_CONTAINER(radio), entry);
	gtk_entry_set_text(GTK_ENTRY(entry), "res"); 
	
	gtk_box_pack_start (GTK_BOX(box), radio, FALSE, FALSE, 0);
	radio = gtk_radio_button_new_with_label_from_widget(GTK_RADIO_BUTTON (radio),
        "No Output Folder");
	gtk_box_pack_start (GTK_BOX(box), radio, FALSE, FALSE, 0);
	
	
	
	/*list box?*/
	GtkWidget* listbox;
	listbox=gtk_list_box_new();
	gtk_box_pack_start(GTK_BOX(box), listbox, TRUE, TRUE, 0);
    add_list_item(listbox, "Item 1: Apple");
    add_list_item(listbox, "Item 2: Banana");
    add_list_item(listbox, "Item 3: Cherry");
    add_list_item(listbox, "Item 4: Date");

	
    // 3. Convert Button
    button = gtk_button_new_with_label("Convert");
    g_signal_connect(button, "clicked", G_CALLBACK(on_convert_clicked), appWidget);
    gtk_box_pack_start(GTK_BOX(box), button, FALSE, FALSE, 0);

    gtk_widget_show_all(window);
	appWidget->entry=entry;
	appWidget->combo=combo;
	appWidget->comboFlip=combo2;
	appWidget->comboRotate=comboRotate;
	appWidget->spinQuality=spinQuality;
}

int main(int argc, char **argv) {
    GtkApplication *app;
    int status;

    app = gtk_application_new("org.noksek2.imgcompress", G_APPLICATION_FLAGS_NONE);
    g_signal_connect(app, "activate", G_CALLBACK(activate), NULL);
    status = g_application_run(G_APPLICATION(app), argc, argv);
    g_object_unref(app);

    return status;
}

/*

#include <gtk/gtk.h>

// Callback function for when a row is activated (double-clicked or Enter pressed)
static void row_activated_cb(GtkListBox *list_box, GtkListBoxRow *row, gpointer user_data) {
    GtkWidget *label = gtk_bin_get_child(GTK_BIN(row)); // For GTK3; use gtk_list_box_row_get_child() for GTK4
    const char *name;
    
    // For GTK3; use gtk_label_get_text() for GTK4
    gtk_label_get(GTK_LABEL(label), &name);
    
    g_print("Row activated: %s\n", name);
}

// Callback function for when the selection changes
static void selected_rows_changed_cb(GtkListBox *list_box, gpointer user_data) {
    GtkListBoxRow *row = gtk_list_box_get_selected_row(list_box);
    if (row) {
        GtkWidget *label = gtk_bin_get_child(GTK_BIN(row)); // For GTK3; use gtk_list_box_row_get_child() for GTK4
        const char *name;
        
        // For GTK3; use gtk_label_get_text() for GTK4
        gtk_label_get(GTK_LABEL(label), &name);
        
        g_print("Selected row changed to: %s\n", name);
    }
}

// Function to add a new item (row) to the list box
void add_list_item(GtkWidget *listbox, const char *item_text) {
    GtkWidget *row;
    GtkWidget *label;

    label = gtk_label_new(item_text);
    row = gtk_list_box_row_new();

    // Add the label to the row (row acts as a container)
    gtk_container_add(GTK_CONTAINER(row), label); // For GTK3
    // For GTK4: gtk_list_box_row_set_child(GTK_LIST_BOX_ROW(row), label);

    gtk_widget_show_all(row); // Show all children within the row
    gtk_list_box_append(GTK_LIST_BOX(listbox), row); // Add the row to the list box
}

int main(int argc, char *argv[]) {
    GtkWidget *window;
    GtkWidget *vbox;
    GtkWidget *listbox;

    gtk_init(&argc, &argv);

    window = gtk_window_new(GTK_WINDOW_TOPLEVEL);
    gtk_window_set_title(GTK_WINDOW(window), "GtkListBox Example");
    gtk_container_set_border_width(GTK_CONTAINER(window), 10);
    g_signal_connect(window, "destroy", G_CALLBACK(gtk_main_quit), NULL);

    vbox = gtk_box_new(GTK_ORIENTATION_VERTICAL, 5);
    gtk_container_add(GTK_CONTAINER(window), vbox);

    listbox = gtk_list_box_new();
    gtk_box_pack_start(GTK_BOX(vbox), listbox, TRUE, TRUE, 0);
    
    // Connect signals
    g_signal_connect(listbox, "row-activated", G_CALLBACK(row_activated_cb), NULL);
    g_signal_connect(listbox, "selected-rows-changed", G_CALLBACK(selected_rows_changed_cb), NULL);

    // Add items to the list box
    add_list_item(listbox, "Item 1: Apple");
    add_list_item(listbox, "Item 2: Banana");
    add_list_item(listbox, "Item 3: Cherry");
    add_list_item(listbox, "Item 4: Date");

    gtk_widget_show_all(window);

    gtk_main();

    return 0;
}
*/