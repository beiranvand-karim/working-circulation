package commoditypricetracker;

import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;
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
        window.setOnCloseRequest(e-> {
            e.consume();
            closeProgram();
        });

        GridPane gridPane = new GridPane();
        gridPane.setPadding(new Insets(10));
        gridPane.setVgap(8);
        gridPane.setHgap(10);

        Label nameLabel = new Label("Username: ");
        GridPane.setConstraints(nameLabel, 0, 0);

        TextField nameTextField = new TextField("Bucky");
        GridPane.setConstraints(nameTextField, 1, 0);


        Label passLabel = new Label("Password: ");
        GridPane.setConstraints(passLabel, 0, 1);

        TextField passwordTextField = new TextField();
        passwordTextField.setPromptText("password");
        GridPane.setConstraints(passwordTextField, 1, 1);


        Button loginButton = new Button("login");
        GridPane.setConstraints(loginButton, 1, 2);
        loginButton.setOnAction(event -> {
            setUserAgentStylesheet(STYLESHEET_CASPIAN);
        });

        gridPane.getChildren().addAll(nameLabel,  nameTextField, passLabel, passwordTextField,  loginButton);

        Scene scene = new Scene(gridPane, 300,300);
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
