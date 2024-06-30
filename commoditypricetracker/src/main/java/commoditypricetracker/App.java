package commoditypricetracker;

import javafx.application.Application;
import javafx.beans.property.IntegerProperty;
import javafx.beans.property.SimpleIntegerProperty;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
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

    @Override
    public void start(Stage stage) throws IOException {
        window = stage;
        window.setTitle("the new window");


        TextField  userInpuTextField = new TextField();
        userInpuTextField.setMaxWidth(200);

        Label firstLabel  = new Label("Welcome to the site, ");
        Label secoondLabel  = new Label();

        HBox bottomTextHBox  = new HBox(firstLabel,  secoondLabel);
        bottomTextHBox.setAlignment(Pos.CENTER);

        VBox vBox = new VBox(10, userInpuTextField, bottomTextHBox);
        vBox.setAlignment(Pos.CENTER);

        secoondLabel.textProperty().bind(userInpuTextField.textProperty());

        IntegerProperty x= new SimpleIntegerProperty(3);
        IntegerProperty y= new SimpleIntegerProperty();
        y.bind(x.multiply(10));

        System.err.println("x: " + x.getValue());
        System.err.println("y: " + y.getValue());

        x.setValue(10);

        System.err.println("x: " + x.getValue());
        System.err.println("y: " + y.getValue());


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

        Scene scene = new Scene(vBox, 600,300);
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
