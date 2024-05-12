module com.compressed.words.extender.dictionary {
    requires javafx.controls;
    requires javafx.fxml;

    opens com.compressed.words.extender.dictionary to javafx.fxml;
    exports com.compressed.words.extender.dictionary;
}
