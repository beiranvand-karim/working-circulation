module commoditypricetracker {
    requires javafx.controls;
    requires javafx.fxml;
    requires transitive javafx.graphics;

    opens commoditypricetracker to javafx.fxml;
    exports commoditypricetracker;
}
