package commoditypricetracker;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.layout.StackPane;
import javafx.scene.control.Button;
import javafx.stage.Stage;

import java.io.IOException;

/**
 * JavaFX App
 */
public class App extends Application {

    private static Scene scene;
    private static Button button;
    private static StackPane layout;

    @Override
    public void start(Stage stage) throws IOException {

        button = new Button();
        button.setText("click me");
        
        layout = new StackPane();
        layout.getChildren().add(button);
        
        scene = new Scene(layout, 640, 480);
        
        stage.setScene(scene);
        stage.setTitle("title of window");
        stage.show();
    }

    static void setRoot(String fxml) throws IOException {
        scene.setRoot(loadFXML(fxml));
    }

    public static void main(String[] args) {
        launch();
    }

}
