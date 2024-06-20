package commoditypricetracker;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;
import java.io.IOException;

/**
 * JavaFX App
 */
public class App extends Application {

    private static Stage window;
    private static Button buttton;

    @Override
    public void start(Stage stage) throws IOException {
        window = stage;
        window.setTitle("the new buttton");

        buttton = new Button("click me");
        buttton.setOnAction(e-> AlertBox.display("title of window", "alert box is awesome"));
        StackPane stackPane =  new StackPane();
        stackPane.getChildren().add(buttton);
        Scene scene = new Scene(stackPane, 300,300);
        scene.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
        window.setScene(scene);
        window.show();
    }

    public static void main(String[] args) {
        launch();
    }

    static void setRoot(String fxml) throws IOException {}

}
