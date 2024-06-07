package commoditypricetracker;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.layout.StackPane;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;
import java.io.IOException;

/**
 * JavaFX App
 */
public class App extends Application {

    private static Stage window;
    private static Scene scene1, scene2;

    @Override
    public void start(Stage stage) throws IOException {
        window = stage;
        Label label1 = new Label("welcome to the first scene");
        Button button1 = new Button("go to scene 2");
        button1.setOnAction(e -> window.setScene(scene2));

        VBox layout1 = new VBox(20);
        layout1.getChildren().addAll(label1,button1);

        scene1 = new Scene(layout1, 400,400);


        Button button2 = new Button("go back to scene 1");
        button2.setOnAction(e -> window.setScene(scene1));

        StackPane layout2 = new StackPane();
        layout2.getChildren().addAll(button2);

        scene2 = new Scene(layout2, 500,500);

        window.setScene(scene1);
        window.setTitle("window title");
        window.show();

    }

    public static void main(String[] args) {
        launch();
    }

    static void setRoot(String fxml) throws IOException {}

}
