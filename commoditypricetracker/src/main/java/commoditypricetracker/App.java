package commoditypricetracker;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import java.io.IOException;

/**
 * JavaFX App
 */
public class App extends Application {

    @Override
    public void start(Stage primartStage) throws IOException {

        Parent root = FXMLLoader.load(getClass().getResource("primary.fxml"));
        primartStage.setTitle("Hello World");

        Scene scene = new Scene(root, 600,300);
        scene.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
        primartStage.setScene(scene);
        primartStage.show();
    }

    public static void main(String[] args) {
        launch();
    }
}
