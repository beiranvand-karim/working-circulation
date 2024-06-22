module stringcombinatioinsgenerator {
    requires javafx.controls;
    requires javafx.fxml;
    requires transitive javafx.graphics;
    
    opens stringcombinatioinsgenerator to javafx.fxml;
    exports stringcombinatioinsgenerator;
}
