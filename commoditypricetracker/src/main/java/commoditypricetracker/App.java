package commoditypricetracker;

import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;
import java.io.IOException;

/**
 * JavaFX App
 */
public class App extends Application {

    private static Stage window;

    @Override
    public void start(Stage stage) throws IOException {
        window = stage;
        window.setTitle("the new window");

        Person bucky = new Person();
        bucky.firstNameProperty().addListener((value, oldValue, newValue) -> {
            System.err.println("value -> " + value);
            System.err.println("oldValue -> " + oldValue);
            System.out.println("Named changed to: " + newValue);
            System.out.println("firstNameProperty():" + bucky.firstNameProperty());
            System.out.println("getFirstName():" + bucky.getFirstName());
        });

        Button submiButton = new Button("submit");
        submiButton.setOnAction(event -> {
            bucky.setFirstName("gus");
        });

        window.setOnCloseRequest(e-> {
            e.consume();
            closeProgram();
        });

        StackPane layout = new StackPane();
        layout.getChildren().add(submiButton);

        Scene scene = new Scene(layout, 600,300);
        scene.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
        window.setScene(scene);
        window.show();
    }

    private void closeProgram(){
        boolean result = ConfirmBox.display("title","do you want to proceed");
        if (result) {
            window.close();
        }
    }

    public static void main(String[] args) {
        launch();
    }
}
