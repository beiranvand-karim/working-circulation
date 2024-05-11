module stringcombinatioinsgenerator {
    requires javafx.controls;
    requires javafx.fxml;

    opens stringcombinatioinsgenerator to javafx.fxml;
    exports stringcombinatioinsgenerator;
}
