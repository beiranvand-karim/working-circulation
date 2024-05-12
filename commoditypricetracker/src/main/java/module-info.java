module commoditypricetracker {
    requires javafx.controls;
    requires javafx.fxml;

    opens commoditypricetracker to javafx.fxml;
    exports commoditypricetracker;
}
