module newfeatureworkflowcreator {
    requires javafx.controls;
    requires javafx.fxml;

    opens newfeatureworkflowcreator to javafx.fxml;
    exports newfeatureworkflowcreator;
}
