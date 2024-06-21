package commoditypricetracker;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.HBox;
import javafx.scene.layout.StackPane;
import javafx.scene.layout.VBox;
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

        HBox topMenu =new HBox();
        Button butttonA = new Button("File");
        Button butttonB = new Button("Edit");
        Button butttonC = new Button("View");
        topMenu.getChildren().addAll(butttonA,butttonB, butttonC);


        VBox leftMenu =new VBox();
        Button butttonD = new Button("D");
        Button butttonE = new Button("E");
        Button butttonF = new Button("F");
        leftMenu.getChildren().addAll(butttonD,butttonE, butttonF);

        buttton = new Button("Close program");
        buttton.setOnAction(e-> closeProgram());

        BorderPane borderPane =  new BorderPane();
        borderPane.setTop(topMenu);
        borderPane.setLeft(leftMenu);

        Scene scene = new Scene(borderPane, 300,300);
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
