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
        window.setOnCloseRequest(e-> {
            e.consume();
            closeProgram();
        });

        buttton = new Button("Close program");
        buttton.setOnAction(e-> closeProgram());
        StackPane stackPane =  new StackPane();
        stackPane.getChildren().add(buttton);
        Scene scene = new Scene(stackPane, 300,300);
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

    static void setRoot(String fxml) throws IOException {}

}
